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
                var currentHour = DateTime.Now.Hour;
                if (!(currentHour >= 18 || currentHour <= 6))
                //if (currentHour >= 18 || currentHour <= 6)
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
                var currentHour = DateTime.Now.Hour;
                if (!(currentHour >= 18 || currentHour <= 6))
                //if (currentHour >= 18 || currentHour <= 6)
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
