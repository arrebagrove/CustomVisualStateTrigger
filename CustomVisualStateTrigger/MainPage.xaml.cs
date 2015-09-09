using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CustomVisualStateTrigger
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var currentHour = DateTime.Now.Hour;
            if (!(currentHour >= 18 || currentHour <= 6))
            //if (currentHour >= 18 || currentHour <= 6)
            {
                StarsStoryboard.Begin();
            }
            else
            {
                SunStoryboard.Begin();
            }
        }
    }
}
