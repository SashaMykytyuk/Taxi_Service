using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace G_Map
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GMapMarker markerFrom, markerTo;
        public MainWindow()
        {
            InitializeComponent();

        }
        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            // choose your provider here
            mapView.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            mapView.MinZoom = 2;
            mapView.MaxZoom = 17;
            // whole world zoom
            mapView.Zoom = 2;
            // lets the map use the mousewheel to zoom
            mapView.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            // lets the user drag the map
            mapView.CanDragMap = true;
            // lets the user drag the map with the left mouse button
            mapView.DragButton = MouseButton.Left;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (markerFrom != null && markerTo != null)
            {
                try
                {
                    RoutingProvider routingProvider =
                    mapView.MapProvider as RoutingProvider ?? GMapProviders.OpenStreetMap;

                    MapRoute route = routingProvider.GetRoute(
                        new PointLatLng(markerFrom.LocalPositionX, markerFrom.LocalPositionY), //start
                        new PointLatLng(markerTo.LocalPositionX, markerTo.LocalPositionY), //end
                        true, //avoid highways
                        true, //walking mode
                        (int)mapView.Zoom);

                    GMapRoute gmRoute = new GMapRoute(route.Points);

                    mapView.Markers.Add(gmRoute);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void mapView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            mapView.Markers.Clear();
            PointLatLng point1 = new PointLatLng((sender as GMapControl).Position.Lat, (sender as GMapControl).Position.Lng);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                markerFrom = new GMapMarker(point1);
                markerFrom.Shape = new Ellipse
                {
                    Width = 5,
                    Height = 5,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1.5
                };
                //MessageBox.Show(markerFrom.Ma.Position);

                //yuytutul;k;lk


                mapView.Markers.Add(markerFrom);
                if (markerTo != null)
                    mapView.Markers.Add(markerTo);
            }
            else
            {
                markerTo = new GMapMarker(point1);
                markerTo.Shape = new Ellipse
                {
                    Width = 5,
                    Height = 5,
                    Stroke = Brushes.Red,
                    StrokeThickness = 1.5
                };
                mapView.Markers.Add(markerTo);
                if (markerFrom != null)
                    mapView.Markers.Add(markerFrom);
            }
        }
    }
}
