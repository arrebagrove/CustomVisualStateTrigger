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
            StarsStoryboard.Begin();
            SunStoryboard.Begin();
        }
    }
}
