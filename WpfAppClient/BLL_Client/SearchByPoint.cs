using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Maps.MapControl.WPF;
using WpfAppClient.BLL_Client;

namespace WpfAppClient
{
    public class SearchByPoint
    {
        private List<DragPin> Pins;
        private MapLayer RouteLayer;
        public string sessionKey;
        public double Distance { set; get; }

        public SearchByPoint(string _sessionKey)
        {
            sessionKey = _sessionKey;
            Pins = new List<DragPin>();
        }

        private async Task UpdateRoute(Location loc, DragPin StartPin, DragPin EndPin)
        {
            RouteLayer.Children.Clear();
            var startCoord = LocationToCoordinate(StartPin.Location);
            var endCoord = LocationToCoordinate(EndPin.Location);

            //Calculate a route between the start and end pushpin.
            var response = await BingMapsRESTToolkit.ServiceManager.GetResponseAsync(
                new BingMapsRESTToolkit.RouteRequest()
                {
                    Waypoints = new List<BingMapsRESTToolkit.SimpleWaypoint>()
                    {
                        new BingMapsRESTToolkit.SimpleWaypoint(startCoord),
                        new BingMapsRESTToolkit.SimpleWaypoint(endCoord)
                    },
                    BingMapsKey = sessionKey,
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
                    locs.Add(new Location(route.RoutePath.Line.Coordinates[i][0],
                        route.RoutePath.Line.Coordinates[i][1]));
                }

                var routeLine = new MapPolyline()
                {
                    Locations = locs,
                    Stroke = new SolidColorBrush(Colors.Blue),
                    StrokeThickness = 3
                };
                RouteLayer.Children.Add(routeLine);
                Distance += route.TravelDistance;
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

        public void OnMouseDoubleClick(Map MyMap, object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            Point mousePosition = e.GetPosition(MyMap);
            Location pinLocation = MyMap.ViewportPointToLocation(mousePosition);
            Pins.Add(new DragPin(MyMap)
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

        public async Task MapGetRoudAsync(Map MyMap)
        {
            Distance = 0;
            RouteLayer = new MapLayer();
            MyMap.Children.Add(RouteLayer);
            for (int i = 0; i < Pins.Count - 1; i++)
            {
                await UpdateRoute(null, Pins[i], Pins[i + 1]);
            }
        }
        public void ClearMap(Map MyMap)
        {
            Pins.Clear();
            MyMap.Children.Clear();
            Distance = 0;
        }
    }
}
