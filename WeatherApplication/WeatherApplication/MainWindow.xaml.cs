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

namespace WeatherApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            var temp = await WeatherHelper.init(CityTextBox.Text);

            var source = WeatherHelper.GetImage();
            Image.Source = source;

            double degrees = WeatherHelper.GetTemperature();
            ResultTextBox.Text = $"{Math.Round(degrees)} °C";

            string city = CityTextBox.Text;
            string country = WeatherHelper.GetCountry();
            CityNameTextBox.Text = city + ", " + country;

            string description = WeatherHelper.GetDescription();
            DescriptionTextBox.Text = description;

            string time = WeatherHelper.GetTime();
            TimeTextBox.Text = time;

            double humidity = WeatherHelper.GetHumidity();
            HumidityTextBox.Text = $"{humidity} %";

            double pressure = WeatherHelper.GetPressure();
            PressureTextBox.Text = $"{pressure} hpa";

            double windspeed = WeatherHelper.GetWindSpeed();
            WindSpeedTextBox.Text = $"{windspeed} m/s";
        }
    }
}
