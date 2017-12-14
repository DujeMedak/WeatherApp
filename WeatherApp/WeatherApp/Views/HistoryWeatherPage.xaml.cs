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


            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = Color.Red.ToSKColor(),
                StrokeWidth = 50
            };

            //canvas.DrawRect(new SKRect(200, 200, 200, 200), paint);
            canvas.DrawCircle(args.Info.Width / 2, args.Info.Height / 2, 100, paint);
        }

    }
}