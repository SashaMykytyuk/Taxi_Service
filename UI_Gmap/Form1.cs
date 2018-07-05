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
            map.Zoom = 13;

        }

        //    map.DragButton = MouseButtons.Left;
        //    map.MapProvider = GMapProviders.GoogleMap;
        //    double lat = Convert.ToDouble(latitude.Text);
        //    double longt = Convert.ToDouble(longitude.Text);
        //    map.Position = new PointLatLng(lat, longt);
        //    map.MinZoom = 5;
        //    map.MaxZoom = 100;
        //    map.Zoom = 10;


        //    PointLatLng point = new PointLatLng(lat, longt);
        //    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_pushpin);

        //    GMapOverlay markers = new GMapOverlay("markers");
        //    markers.Markers.Add(marker);
        //    map.Overlays.Add(markers);
        //}


        private void clearPoint_Click(object sender, EventArgs e)
        {
            _points.Clear();
        }

        private void getRoute_Click(object sender, EventArgs e)
        {
            var route = GoogleMapProvider.Instance
                .GetRoute(_points[0], _points[1], false, false, 14);
            var r = new GMapRoute(route.Points, "MyRoute")
            {
                Stroke = new Pen(Color.Red, 5)
            };
            var routes = new GMapOverlay("routes");
            routes.Routes.Add(r);
            map.Overlays.Add(routes);
            this.Update();
            this.Text = route.Distance.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            map.Zoom = (sender as TrackBar).Value;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            map.SetPositionByKeywords(findByKeyText.Text);
            geoCodeAsync(findByKeyText.Text);
        }
        private void geoCodeAsync(string address)
        {
            //string address = "123 something st, somewhere";
            string requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

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
            /////////////////
            try
            {
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

        private void map_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                double lat = map.FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = map.FromLocalToLatLng(e.X, e.Y).Lng;
                GMapOverlay markerOverlay = new GMapOverlay("markers");
                GMarkerGoogle marker = new GMarkerGoogle(new
                        GMap.NET.PointLatLng(lat, lng),
                    GMarkerGoogleType.green_pushpin);
                map.Overlays.Add(markerOverlay);
                markerOverlay.Markers.Add(marker);
                MessageBox.Show(lat.ToString() + lng.ToString());
                _points.Add(new PointLatLng(Convert.ToDouble(lat), Convert.ToDouble(lng)));

            }
        }
    }
}

