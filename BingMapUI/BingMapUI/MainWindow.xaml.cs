﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Maps.MapControl.WPF;


namespace BingMapUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<DragPin> Pins;
        //private DragPin StartPin;
        //private DragPin EndPin;
        private MapLayer RouteLayer;
        private string SessionKey;
        private bool state = true;

        public MainWindow()
        {
            InitializeComponent();
            Pins = new List<DragPin>();
            //MyMap.Loaded += MyMap_Loaded;
        }
        private async void UpdateRoute(Location loc, DragPin StartPin, DragPin EndPin)
        {
            RouteLayer.Children.Clear();
            var startCoord = LocationToCoordinate(StartPin.Location);
            var endCoord = LocationToCoordinate(EndPin.Location);

            //Calculate a route between the start and end pushpin.
            var response = await BingMapsRESTToolkit.ServiceManager.GetResponseAsync(new BingMapsRESTToolkit.RouteRequest()
            {
                Waypoints = new List<BingMapsRESTToolkit.SimpleWaypoint>()
                {
                    new BingMapsRESTToolkit.SimpleWaypoint(startCoord),
                    new BingMapsRESTToolkit.SimpleWaypoint(endCoord)
                },
                BingMapsKey = SessionKey,
                RouteOptions = new BingMapsRESTToolkit.RouteOptions()
                {
                    RouteAttributes = new List<BingMapsRESTToolkit.RouteAttributeType>
                    {
                        BingMapsRESTToolkit.RouteAttributeType.RoutePath
                    }
                }
            });
            if (response != null &&
                response.ResourceSets != null &&
                response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0)
            {
                var route = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Route;
                var locs = new LocationCollection();
                for (var i = 0; i < route.RoutePath.Line.Coordinates.Length; i++)
                {
                    locs.Add(new Location(route.RoutePath.Line.Coordinates[i][0], route.RoutePath.Line.Coordinates[i][1]));
                }
                var routeLine = new MapPolyline()
                {
                    Locations = locs,
                    Stroke = new SolidColorBrush(Colors.Blue),
                    StrokeThickness = 3
                };
                RouteLayer.Children.Add(routeLine);
                MessageBox.Show(route.TravelDistance.ToString());
            }
        }

        private BingMapsRESTToolkit.Coordinate LocationToCoordinate(Location loc)
        {
            return new BingMapsRESTToolkit.Coordinate(loc.Latitude, loc.Longitude);
        }

        private BitmapImage GetImageSource(string imageSource)
        {
            var icon = new BitmapImage();
            icon.BeginInit();
            icon.UriSource = new Uri(imageSource, UriKind.Relative);
            icon.EndInit();

            return icon;
        }

        private void MyMap_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            Point mousePosition = e.GetPosition(MyMap);
            Location pinLocation = MyMap.ViewportPointToLocation(mousePosition);
            Pins.Add(new DragPin(this.MyMap)
            {
                Location = new Location(pinLocation),
                ImageSource = GetImageSource("/Assets/green_pin.png")
               
            });
            Pushpin pin = new Pushpin();
            pin.Tag = "BK7475AO";
            pin.Content = "T";   
            ToolTipService.SetToolTip(pin, pin.Tag);
            pin.MouseDoubleClick += (o, args) => { MessageBox.Show(pin.Content + "  " + pin.Tag); };
            pin.Location = pinLocation;
            MyMap.Children.Add(pin);
        }

      

        private void MapGetRoud(object sender, RoutedEventArgs e)
        {
            MyMap.CredentialsProvider.GetCredentials((c) =>
            {
                SessionKey = c.ApplicationId;
                RouteLayer = new MapLayer();
                MyMap.Children.Add(RouteLayer);
                for (int i = 0; i < Pins.Count - 1; i++)
                {
                    UpdateRoute(null, Pins[i], Pins[i+1]);
                }
            });
        }

        private void ClearMap(object sender, RoutedEventArgs e)
        {
            Pins.Clear();
            MyMap.Children.Clear();
        }
    }
}
