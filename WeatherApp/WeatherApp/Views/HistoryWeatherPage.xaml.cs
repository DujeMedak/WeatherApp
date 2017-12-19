using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryWeatherPage : ContentPage
    {
        WeatherServices ws;
        WeatherHistoryViewModel viewModel;

        public HistoryWeatherPage()
        {
            InitializeComponent();
            ws = new WeatherServices();

            viewModel = new WeatherHistoryViewModel();
            BindingContext = viewModel;
        }

        public HistoryWeatherPage(WeatherHistoryViewModel vm)
        {
            InitializeComponent();
            ws = new WeatherServices();

            BindingContext = this.viewModel = vm;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            //Initialize the Canvas  

            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            //clear
            canvas.Clear();

            if (viewModel.WeatherHistoryModel != null)
            {
                SKPath path = new SKPath();
                SKPath fillPath = new SKPath();
                SKPoint[] chart = new SKPoint[24];

                SKPaint paint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = Color.Red.ToSKColor(),
                    StrokeWidth = 50
                };
                SKPaint chartLinePaint = new SKPaint
                {
                    Color = SKColors.Black,
                    Style = SKPaintStyle.Stroke,
                    StrokeWidth = 2,
                    StrokeCap = SKStrokeCap.Round
                };
                SKPaint chartFillPaint = new SKPaint
                {
                    Color = SKColors.GhostWhite,
                    Style = SKPaintStyle.Fill,
                    StrokeWidth = 1,
                    StrokeCap = SKStrokeCap.Round
                };
                SKPaint chartLabelPaint = new SKPaint
                {
                    Color = SKColors.Black,
                    Style = SKPaintStyle.StrokeAndFill,
                    StrokeWidth = 1,
                    StrokeCap = SKStrokeCap.Round,
                    TextSize = 15
                };


                double[] vx = new double[chart.Length];
                double[] vy = new double[chart.Length];
                for (int i = 0; i < 24; i++)
                {
                    chart[i]=calcPoint(info.Width-50f, info.Height-50f, i);
                    vx[i] = chart[i].X;
                    vy[i] = chart[i].Y;
                }

                CubicBezierCoefficients(vx, out double[] Ax, out double[] Bx);
                CubicBezierCoefficients(vy, out double[] Ay, out double[] By);

                fillPath.MoveTo(chart[0].X, info.Height-25f);
                fillPath.LineTo(chart[0]);
                path.MoveTo(chart[0]);
                for (int i = 0; i < chart.Length-3; i++)
                {
                    path.CubicTo((float)Ax[i], (float)Ay[i], (float)Bx[i], (float)By[i], chart[i+1].X, chart[i + 1].Y);
                    fillPath.CubicTo((float)Ax[i], (float)Ay[i], (float)Bx[i], (float)By[i], chart[i + 1].X, chart[i + 1].Y);
                }
                fillPath.LineTo(info.Width-25f, info.Height - 25f);
                fillPath.Close();
                canvas.DrawPath(fillPath, chartFillPaint);
                canvas.DrawPath(path, chartLinePaint);

                string topLabel, bottomLabel;
                for(int i = 0; i<chart.Length; i += 3)
                {
                    topLabel = viewModel.WeatherHistoryModel.forecast.forecastday[0].hour[i].temp_c + "º";
                    canvas.DrawText(topLabel, chart[i].X - chartLabelPaint.MeasureText(topLabel)/2, chartLabelPaint.TextSize, chartLabelPaint);

                    bottomLabel = viewModel.WeatherHistoryModel.forecast.forecastday[0].hour[i].time.Split(' ')[1].Split(':')[0] + "h";
                    canvas.DrawText(bottomLabel, chart[i].X - chartLabelPaint.MeasureText(bottomLabel)/2, info.Height, chartLabelPaint);

                    canvas.DrawCircle(chart[i].X, chart[i].Y, 3f, chartLabelPaint);
                }
            }
            
        }

        void OnIsBusyChanged(object sender, SKPaintSurfaceEventArgs args)
        {
            chartCanvas.InvalidateSurface();
        }

        SKPoint calcPoint(float width, float height, int i)
        {
            double tempDelta = viewModel.WeatherHistoryModel.forecast.forecastday[0].day.maxtemp_c - viewModel.WeatherHistoryModel.forecast.forecastday[0].day.mintemp_c + 4;
            return new SKPoint(i * width / 21+25f, (float)(height * (viewModel.WeatherHistoryModel.forecast.forecastday[0].day.maxtemp_c-viewModel.WeatherHistoryModel.forecast.forecastday[0].hour[i].temp_c+2) / tempDelta));
        }
        
        public static void CubicBezierCoefficients(double[] V, out double[] A, out double[] B)
        {

            int N = V.Length - 1;
            int N2 = N << 1;
            int i = 0;
            int j = 0;
            double r11, r12, r15;
            double r22, r23, r25;
            double r31, r32, r33, r34, r35;
            double[,] Rows = new double[N2, 3];
            double a;

            A = new double[N];
            B = new double[N];

            r11 = 2;
            r12 = -1;
            r15 = V[j++];

            r22 = 1;
            r23 = 1;
            r25 = 2 * V[j++];

            r31 = 1;
            r32 = -2;
            r33 = 2;
            r34 = -1;
            r35 = 0;

            while (true)
            {
                a = 1 / r11;
                r11 = 1;
                r12 *= a;
                r15 *= a;
                r31 -= r11;
                r32 -= r12;
                r35 -= r15;

                if (r32 != 0)
                {
                    r33 -= r32 * r23;
                    r35 -= r32 * r25;
                    r32 = 0;
                }
                Rows[i, 0] = r12;
                Rows[i, 1] = 0;
                Rows[i, 2] = r15;
                i++;
                
                Rows[i, 0] = r22;
                Rows[i, 1] = r23;
                Rows[i, 2] = r25;
                i++;

                if (i >= N2 - 2)
                    break;

                r11 = r33;
                r12 = r34;
                r15 = r35;

                r22 = 1;
                r23 = 1;
                r25 = 2 * V[j++];

                r31 = 1;
                r32 = -2;
                r33 = 2;
                r34 = -1;
                r35 = 0;
            }

            r11 = r33;
            r12 = r34;
            r15 = r35;
            
            r22 = 2;
            r23 = 0;
            r25 = V[j++];

            a = 1 / r11;
            r11 = 1;
            r12 *= a;
            r15 *= a;
            
            r22 += r12;
            r25 += r15;

            r25 /= r22;
            r22 = 1;
            
            Rows[i, 0] = r12;
            Rows[i, 1] = 0;
            Rows[i, 2] = r15;
            i++;
            
            Rows[i, 0] = r22;
            Rows[i, 1] = r23;
            Rows[i, 2] = r25;
            i++;
            
            j--;
            while (i > 0)
            {
                i--;
                if (i < N2 - 1)
                {
                    a = Rows[i, 1];
                    if (a != 0)
                    {
                        Rows[i, 1] = 0;
                        Rows[i, 2] -= a * Rows[i + 1, 2];
                    }
                }

                B[--j] = Rows[i, 2];

                i--;
                a = Rows[i, 0];
                if (a != 0)
                {
                    Rows[i, 0] = 0;
                    Rows[i, 2] -= a * Rows[i + 1, 2];
                }

                A[j] = Rows[i, 2];
            }
        }
    }
}