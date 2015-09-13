using System;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace CustomVisualStateTrigger
{
    /// <summary>
    /// Trigger for datetime switching
    /// </summary>
	public class DateTimeTrigger : StateTriggerBase
    {
        private int _hour;
        private readonly DispatcherTimer _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };

        public DateTimeTrigger()
        {
            _timer.Tick += TimerChanged;
            _timer.Start();
        }

        public int Hour
        {
            get { return _hour; }
            set
            {
                _hour = value;
                var currentTime = DateTime.Now;
                SetActive(currentTime.Hour >= _hour && currentTime.Minute >= _hour);
            }
        }

        private async void TimerChanged(object sender, object e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var currentTime = DateTime.Now;
                SetActive(currentTime.Hour >= _hour && currentTime.Minute >= _hour);
            });
        }
    }

}
