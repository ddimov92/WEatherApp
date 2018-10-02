using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WEatherApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page

    {
        public string Kardzhali = "729794";
        public string Plovdiv = "728193";
        public string Sofia = "727011";
        public string Devin = "732285";

        public MainPage()
        {
            this.InitializeComponent();
        }

        public async void GetWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            var position = await LocationManager.GetPosition();

            RootObject myWeather = await OpenWeatherMapProxy.GetCurrentWeather(position.Coordinate.Latitude, position.Coordinate.Longitude);

            #region WeatherIcons

            int[] thunderstorms = new int[] { 200, 201, 202, 210, 211, 212, 221, 230, 231, 232 };
            int[] drizzle = new int[] { 300, 301, 302, 310, 311, 312, 313, 314, 321 };
            int[] rain = new int[] { 500, 501, 502, 503, 504, 511, 520, 521, 522, 531 };
            int[] snow = new int[] { 600, 601, 602, 611, 612, 615, 616, 620, 621, 622 };
            int[] atmoshpere = new int[] { 701, 711, 721, 731, 741, 751, 761, 762, 771, 781 };
            int[] clouds = new int[] { 801, 802, 803, 804 };
            string pngNumber = "";

            if (thunderstorms.Contains(myWeather.weather[0].id))
            {
                pngNumber = "11d";

            }
            if (drizzle.Contains(myWeather.weather[0].id))
            {
                pngNumber = "09d";

            }
            if (rain.Contains(myWeather.weather[0].id))
            {
                pngNumber = "10d";

            }
            if (snow.Contains(myWeather.weather[0].id))
            {
                pngNumber = "13d";

            }
            if (atmoshpere.Contains(myWeather.weather[0].id))
            {
                pngNumber = "50d";

            }
            if (myWeather.weather[0].id == 800)
            {
                pngNumber = "01d";

            }
            if (clouds.Contains(myWeather.weather[0].id))
            {
                pngNumber = "03d";

            }
            #endregion

            string weatherIconUri = String.Format("ms-appx:///Assets/Test/{0}.png", pngNumber);
            ResultImage.Source = new BitmapImage(new Uri(weatherIconUri));
            NameTextBlock.Text = myWeather.name;
            TempTextBlock.Text = ((int)myWeather.main.temp).ToString() + "°C";
            WeatherTextBlock.Text = myWeather.weather[0].description.ToUpper();

            #region Visibilities
            ResultImage.Visibility = Visibility.Visible;
            NameTextBlock.Visibility = Visibility.Visible;
            TempTextBlock.Visibility = Visibility.Visible;
            WeatherTextBlock.Visibility = Visibility.Visible;
            GetWeatherButton.Visibility = Visibility.Collapsed;
            #endregion

            NameTextBlock.Loaded += new RoutedEventHandler(NameTextBlockAnimationLoader);
        }

        public void NameTextBlockAnimationLoader(object sender, RoutedEventArgs e)
        {
            MyStoryboard.Begin();
        }

        private async void TestButton_Click(object sender, RoutedEventArgs e)
        {
            JSONLoader.RootObject testWeather = await JSONLoader.LoadJSON();

            TestTextBlock.Text = testWeather.list[0].clouds.ToString();
        }

        private void MyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyComboBox.SelectedItem == KardzhaliItem)
            {
                UiManager(Kardzhali);
            }
            else if (MyComboBox.SelectedItem == PlovdivItem)
            {
                UiManager(Plovdiv);
            }
            else if (MyComboBox.SelectedItem == SofiaItem)
            {
                UiManager(Sofia);
            }
            else if(MyComboBox.SelectedItem == DevilItem)
            {
                UiManager(Devin);
            }
        }

        public async void UiManager(string city)
        {
            RootObject myWeather = await OpenWeatherMapProxy.GetSpecificWeatherLocationData(city);

            #region Weather Icons2
            int[] thunderstorms = new int[] { 200, 201, 202, 210, 211, 212, 221, 230, 231, 232 };
            int[] drizzle = new int[] { 300, 301, 302, 310, 311, 312, 313, 314, 321 };
            int[] rain = new int[] { 500, 501, 502, 503, 504, 511, 520, 521, 522, 531 };
            int[] snow = new int[] { 600, 601, 602, 611, 612, 615, 616, 620, 621, 622 };
            int[] atmoshpere = new int[] { 701, 711, 721, 731, 741, 751, 761, 762, 771, 781 };
            int[] clouds = new int[] { 801, 802, 803, 804 };
            string pngNumber = "";

            if (thunderstorms.Contains(myWeather.weather[0].id))
            {
                pngNumber = "11d";

            }
            if (drizzle.Contains(myWeather.weather[0].id))
            {
                pngNumber = "09d";

            }
            if (rain.Contains(myWeather.weather[0].id))
            {
                pngNumber = "10d";

            }
            if (snow.Contains(myWeather.weather[0].id))
            {
                pngNumber = "13d";

            }
            if (atmoshpere.Contains(myWeather.weather[0].id))
            {
                pngNumber = "50d";

            }
            if (myWeather.weather[0].id == 800)
            {
                pngNumber = "01d";

            }
            if (clouds.Contains(myWeather.weather[0].id))
            {
                pngNumber = "03d";

            }

            #endregion

            string weatherIconUri = String.Format("ms-appx:///Assets/Test/{0}.png", pngNumber);
            ResultImage.Source = new BitmapImage(new Uri(weatherIconUri));
            NameTextBlock.Text = myWeather.name;
            TempTextBlock.Text = ((int)myWeather.main.temp).ToString() + "°C";
            WeatherTextBlock.Text = myWeather.weather[0].description.ToUpper();

            #region Visibilities2
            ResultImage.Visibility = Visibility.Visible;
            NameTextBlock.Visibility = Visibility.Visible;
            TempTextBlock.Visibility = Visibility.Visible;
            WeatherTextBlock.Visibility = Visibility.Visible;
            GetWeatherButton.Visibility = Visibility.Collapsed;
            #endregion
        }


    }
}
