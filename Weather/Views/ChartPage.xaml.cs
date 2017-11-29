using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Threading;
using System.Collections.Concurrent;

namespace Weather
{
    public partial class ChartPage : ContentPage
    {
        Dictionary<int, string> hours_temperature = new Dictionary<int, string>();
        ConcurrentDictionary<int, SKBitmap> hours_weatherstatusthumb = new ConcurrentDictionary<int, SKBitmap>();

        PastDayViewModel viewModel;

        // SKCanvas canvas;
        float screen_width;
        float screen_height;

        public ChartPage(PastDayViewModel viewModel)
        {
            InitializeComponent();

            this.viewModel = viewModel;
            load_hour_temperature();
            load_bitmaps();
        }

        public ChartPage()
        {
            InitializeComponent();
        }

        public void load_hour_temperature()
        {

            hours_temperature[0] = viewModel.pastday.Forecast.Forecastday[0].Hour[0].TempC.ToString();
            hours_temperature[3] = viewModel.pastday.Forecast.Forecastday[0].Hour[3].TempC.ToString();
            hours_temperature[6] = viewModel.pastday.Forecast.Forecastday[0].Hour[6].TempC.ToString();
            hours_temperature[9] = viewModel.pastday.Forecast.Forecastday[0].Hour[9].TempC.ToString();

            hours_temperature[12] = viewModel.pastday.Forecast.Forecastday[0].Hour[12].TempC.ToString();
            hours_temperature[15] = viewModel.pastday.Forecast.Forecastday[0].Hour[15].TempC.ToString();
            hours_temperature[18] = viewModel.pastday.Forecast.Forecastday[0].Hour[18].TempC.ToString();
            hours_temperature[21] = viewModel.pastday.Forecast.Forecastday[0].Hour[21].TempC.ToString();
        }

        public void load_bitmaps()
        {
            load_bitmap("https:" + viewModel.pastday.Forecast.Forecastday[0].Hour[0].Condition.Icon, 0);
            load_bitmap("https:" + viewModel.pastday.Forecast.Forecastday[0].Hour[3].Condition.Icon, 3);
            load_bitmap("https:" + viewModel.pastday.Forecast.Forecastday[0].Hour[6].Condition.Icon, 6);
            load_bitmap("https:" + viewModel.pastday.Forecast.Forecastday[0].Hour[9].Condition.Icon, 9);

            load_bitmap("https:" + viewModel.pastday.Forecast.Forecastday[0].Hour[12].Condition.Icon, 12);
            load_bitmap("https:" + viewModel.pastday.Forecast.Forecastday[0].Hour[15].Condition.Icon, 15);
            load_bitmap("https:" + viewModel.pastday.Forecast.Forecastday[0].Hour[18].Condition.Icon, 18);
            load_bitmap("https:" + viewModel.pastday.Forecast.Forecastday[0].Hour[21].Condition.Icon, 21);
        }

        SKPaint fill_axis_line = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.LightBlue,
            StrokeWidth = 10
        };

        SKPaint fill_point = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Red,
            StrokeWidth = 10
        };

        SKPaint fill_line = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.LightBlue,
            StrokeWidth = 6
        };

        SKPaint fill_text = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Black,
            TextSize = 30
        };


        public void load_bitmap(string url, int key)
        {

            Uri uri = new Uri(url);
            WebRequest request = WebRequest.Create(uri);
            request.BeginGetResponse((IAsyncResult arg) =>
            {
                try
                {
                    using (Stream stream = request.EndGetResponse(arg).GetResponseStream())
                    using (MemoryStream memStream = new MemoryStream())
                    {
                        stream.CopyTo(memStream);
                        memStream.Seek(0, SeekOrigin.Begin);

                        using (SKManagedStream skStream = new SKManagedStream(memStream))
                        {
                            hours_weatherstatusthumb.AddOrUpdate(key, SKBitmap.Decode(skStream), (k, v) => v);


                            Device.BeginInvokeOnMainThread(() => CanvasView.InvalidateSurface());
                        }
                    }
                }
                catch
                {
                }

            }, null);
        }

        private void canvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {

            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            SKImageInfo image_info = e.Info;
            screen_width = image_info.Width;
            screen_height = image_info.Height;

            canvas.Clear(SKColors.White);

            //eixo das horas 

            float hours_x1 = screen_width - (8 * screen_width) / 9;
            float hours_y1 = screen_height - screen_height / 3;
            float hours_x2 = screen_width - screen_width / 9;
            float hours_y2 = screen_height - screen_height / 3;
            canvas.DrawLine(hours_x1, hours_y1, hours_x2, hours_y2, fill_axis_line);

            //eixo da temperatura

            float temp_x1 = screen_width - (8 * screen_width) / 9;
            float temp_y1 = screen_height - (4 * screen_height) / 5;
            float temp_x2 = screen_width - (8 * screen_width) / 9;
            float temp_y2 = screen_height - screen_height / 3;
            canvas.DrawLine(temp_x1, temp_y1, temp_x2, temp_y2, fill_axis_line);


            //pontos da temperatura

            List<Point> points = new List<Point>();

            Point point00 = new Point(screen_width - (8 * screen_width) / 9, temp_y2 - convert_temp_to_pos(hours_temperature[0]));
            points.Add(point00);
            Point point03 = new Point(screen_width - (7 * screen_width) / 9, temp_y2 - convert_temp_to_pos(hours_temperature[3]));
            points.Add(point03);
            Point point06 = new Point(screen_width - (6 * screen_width) / 9, temp_y2 - convert_temp_to_pos(hours_temperature[6]));
            points.Add(point06);
            Point point09 = new Point(screen_width - (5 * screen_width) / 9, temp_y2 - convert_temp_to_pos(hours_temperature[9]));
            points.Add(point09);
            Point point12 = new Point(screen_width - (4 * screen_width) / 9, temp_y2 - convert_temp_to_pos(hours_temperature[12]));
            points.Add(point12);
            Point point15 = new Point(screen_width - (3 * screen_width) / 9, temp_y2 - convert_temp_to_pos(hours_temperature[15]));
            points.Add(point15);
            Point point18 = new Point(screen_width - (2 * screen_width) / 9, temp_y2 - convert_temp_to_pos(hours_temperature[18]));
            points.Add(point18);
            Point point21 = new Point(screen_width - screen_width / 8, temp_y2 - convert_temp_to_pos(hours_temperature[21]));
            points.Add(point21);

            int hour_text = 0;
            float adjustment_x = 10;
            float adjustment_y = 50;
            for (int i = 0; i < points.Count - 1; i++)
            {
                //linhas que ligam os pontos do grafico
                canvas.DrawLine((float)points[i].X, (float)points[i].Y, (float)points[i + 1].X, (float)points[i + 1].Y, fill_line);
                //desenho da legenda das horas 
                canvas.DrawText(hour_text.ToString() + "h", (float)points[i].X - adjustment_x, temp_y2 + adjustment_y, fill_text);
                hour_text += 3;
            }
            //ultimo elemento da legenda das horas 
            canvas.DrawText(hour_text.ToString() + "h", (float)points[7].X - adjustment_x, temp_y2 + adjustment_y, fill_text);

            int temp_text = 0;
            float temp_text_y_pos = temp_y2;
            for (int i = 0; i < 10; i++)
            {
                canvas.DrawText(temp_text.ToString(), hours_x1 - adjustment_y, temp_text_y_pos, fill_text);
                temp_text += 5;
                temp_text_y_pos -= (7 * screen_height) / 150;
            }

            for (int i = 0; i < 8; i++)
            {
                int thumbkey = 3 * i;
                if (hours_weatherstatusthumb.ContainsKey(thumbkey))
                {
                    SKBitmap thumb = hours_weatherstatusthumb[thumbkey];
                    if (thumb != null && !thumb.IsNull)
                        canvas.DrawBitmap(thumb, (float)points[i].X, (float)points[i].Y - 10, null);
                }

            }
        }

        private float convert_temp_to_pos(string tempC)
        {

            return (float.Parse(tempC) * (70 * screen_height / 150)) / 45;
        }

    }
}
