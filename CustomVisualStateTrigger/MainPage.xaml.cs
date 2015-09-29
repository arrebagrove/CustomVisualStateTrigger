using Windows.UI.Xaml;

namespace CustomVisualStateTrigger
{
    public sealed partial class MainPage
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
