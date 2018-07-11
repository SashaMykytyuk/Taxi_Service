using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace UI_Gmap
{
    public partial class Form1 : Form
    {
        private List<PointLatLng> _points;
        public Form1()
        {
            InitializeComponent();
            _points = new List<PointLatLng>();
            map.ShowCenter = false;
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            map.SetPositionByKeywords("rovno ukrainian");
            map.MinZoom = 1;
            map.MaxZoom = 20;
            map.Zoom = 14;
        }

      

        private void clearPoint_Click(object sender, EventArgs e)
        {
            _points.Clear();
            map.Overlays.Clear();
            double tempZoom = map.Zoom;
            map.Zoom = tempZoom + 1;
            map.Zoom = tempZoom;
        }

        private void getRoute_Click(object sender, EventArgs e)
        {
            var route = GoogleMapProvider.Instance
                .GetRoute(_points[0], _points[1], false, false, 14);
            var r = new GMapRoute(route.Points, "MyRoute")
            {
                Stroke = new Pen(Color.Green, 3)
            };
            var routes = new GMapOverlay("routes");
            routes.Routes.Add(r);
            map.Overlays.Add(routes);
            this.Text = route.Distance.ToString();
            double tempZoom = map.Zoom;
            map.Zoom = tempZoom + 1;
            map.Zoom = tempZoom;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                map.SetPositionByKeywords(findByKeyText.Text);
                geoCodeAsync(findByKeyText.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void geoCodeAsync(string address)
        {
            try
            {
                string requestUri =
                    string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false",
                        Uri.EscapeDataString(address));

                WebRequest request = WebRequest.Create(requestUri);
                WebResponse response = request.GetResponse();
                XDocument xdoc = XDocument.Load(response.GetResponseStream());

                XElement result = xdoc.Element("GeocodeResponse").Element("result");
                XElement locationElement = result.Element("geometry").Element("location");
                XElement lat = locationElement.Element("lat");
                XElement lng = locationElement.Element("lng");
                PointLatLng pointLatLng = new PointLatLng();
                pointLatLng.Lat = Double.Parse(lat.Value.Replace('.', ','));
                pointLatLng.Lng = Double.Parse(lng.Value.Replace('.', ','));
                MessageBox.Show(pointLatLng.Lat + "   " + pointLatLng.Lng);
                GMapOverlay markerOverlay = new GMapOverlay("markers");
                GMarkerGoogle marker = new GMarkerGoogle(pointLatLng,
                    GMarkerGoogleType.green_pushpin);
                map.Overlays.Add(markerOverlay);
                markerOverlay.Markers.Add(marker);
                _points.Add(pointLatLng);
                map.Zoom = 18;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void map_MouseDoubleClick(object sender, EventArgs e)
        {
            var x = (e as MouseEventArgs);
            if (x.Button == MouseButtons.Left)
            {
                double lat = map.FromLocalToLatLng(x.X, x.Y).Lat;
                double lng = map.FromLocalToLatLng(x.X, x.Y).Lng;
                GMapOverlay markerOverlay = new GMapOverlay("markers");
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.green_pushpin);
                marker.ToolTipText = "{0},{1}+";
                marker.ToolTip.Fill = Brushes.Black;
                marker.ToolTip.Foreground = Brushes.White;
                marker.ToolTip.Stroke = Pens.Black;
                marker.ToolTip.TextPadding = new Size(20, 20);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                map.Overlays.Add(markerOverlay);
                markerOverlay.Markers.Add(marker);
                _points.Add(new PointLatLng(Convert.ToDouble(lat), Convert.ToDouble(lng)));
            }
        }
    }
}

