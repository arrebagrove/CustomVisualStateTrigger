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
        private bool _isLate;
        private readonly DispatcherTimer _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };

        public DateTimeTrigger()
        {
            _timer.Tick += TimerChanged;
        }

        public bool IsLate
        {
            get { return _isLate; }
            set
            {
                _isLate = value;
                var currentTime = DateTime.Now;
                //if (!(currentTime.Hour >= 18 || currentTime.Hour <= 6))
                //if (currentTime.Hour >= 18 || currentTime.Hour <= 6)
                if (currentTime.Hour >= App.CheckHour && currentTime.Minute >= App.CheckMinute)
                {
                    SetActive(value);
                }
                else
                {
                    SetActive(!value);
                }
            }
        }

        private async void TimerChanged(object sender, object e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var currentTime = DateTime.Now;
                //if (!(currentTime.Hour >= 18 || currentTime.Hour <= 6))
                //if (currentTime.Hour >= 18 || currentTime.Hour <= 6)
                if (currentTime.Hour >= App.CheckHour && currentTime.Minute >= App.CheckMinute)
                {
                    SetActive(IsLate);
                }
                else
                {
                    SetActive(!IsLate);
                }
            });
        }
    }

}
