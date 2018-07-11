using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using BingMapsRESTToolkit;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.SqlServer.Types;
using System.Runtime.Serialization.Json;

namespace BingMapUI
{
    public class SearchByAdress
    {
        private string sessionKey;

        public SearchByAdress(string keySessionKey)
        {
                sessionKey = keySessionKey;
        }

        public async void CalculateAndShowOnMap(Map MyMap, string StartTbx, string EndTbx)
        {
            MyMap.Children.Clear();
            try
            {
                var r = await CalculateRoute(StartTbx, EndTbx);

                if (r != null &&
                    r.ResourceSets != null &&
                    r.ResourceSets.Length > 0 &&
                    r.ResourceSets[0].Resources != null &&
                    r.ResourceSets[0].Resources.Length > 0)
                {
                    Route route = r.ResourceSets[0].Resources[0] as Route;

                    double[][] routePath = route.RoutePath.Line.Coordinates;

                    var locs = new LocationCollection();

                    //Create SqlGeography from route line points.
                    SqlGeographyBuilder geomBuilder = new SqlGeographyBuilder();
                    geomBuilder.SetSrid(4326);
                    geomBuilder.BeginGeography(OpenGisGeographyType.LineString);
                    geomBuilder.BeginFigure(routePath[0][0], routePath[0][1]);

                    for (int i = 0; i < routePath.Length; i++)
                    {
                        locs.Add(new Microsoft.Maps.MapControl.WPF.Location(routePath[i][0], routePath[i][1]));
                        geomBuilder.AddLine(routePath[i][0], routePath[i][1]);
                    }

                    geomBuilder.EndFigure();
                    geomBuilder.EndGeography();

                    //Calculate distances in countries.
                    //var routeGeom = geomBuilder.ConstructedGeography;

                    var sb = new StringBuilder();
                    sb.AppendFormat("Total Driving Distance: {0} KM\r\n", route.TravelDistance);

                    

                    //Display route on map
                    var routeLine = new MapPolyline()
                    {
                        Locations = locs,
                        Stroke = new SolidColorBrush(Colors.Blue),
                        StrokeThickness = 5
                    };

                    MyMap.Children.Add(routeLine);

                    MyMap.SetView(locs, new Thickness(30), 0);
                    MessageBox.Show(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("In Calculate  " + ex.Message);
            }
        }

        private async Task<Response> CalculateRoute(string start, string end)
        {
            var requestURI = new Uri(string.Format("https://dev.virtualearth.net/REST/V1/Routes/Driving?wp.0={0}&wp.1={1}&rpo=Points&key={2}",
                                       Uri.EscapeDataString(start), Uri.EscapeDataString(end), sessionKey));

            using (var stream = await GetStreamAsync(requestURI))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var ser = new DataContractJsonSerializer(typeof(Response));
                    return ser.ReadObject(stream) as Response;
                }
            }
        }

        public static Task<Stream> GetStreamAsync(Uri url)
        {
            var tcs = new TaskCompletionSource<Stream>();

            var request = HttpWebRequest.Create(url);
            request.BeginGetResponse((a) =>
            {
                try
                {
                    var r = (HttpWebRequest)a.AsyncState;
                    HttpWebResponse response = (HttpWebResponse)r.EndGetResponse(a);
                    tcs.SetResult(response.GetResponseStream());
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }, request);

            return tcs.Task;
        }
    }
}

