using System;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace CustomVisualStateTrigger
{
    /// <summary>
    /// Trigger for datetime switching
    /// </summary>
	public class DateTimeTrigger : StateTriggerBase
    {
        private DateTime _date;
        private readonly DispatcherTimer _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };

        public DateTimeTrigger()
        {
            _timer.Tick += TimerChanged;
            _timer.Start();
        }

        public string Date
        {
            set
            {
                if (value.All(c => c != ':') && value.All(c => c != '-') && value.All(c => c != '/'))
                {
                    throw new ArgumentException("Invalid or unknown date format, please see DateTime.Parse documentation");
                }
                var result = DateTime.TryParse(value, out _date);
                if (!result)
                {
                    throw new ArgumentException("Invalid or unknown date format, please see DateTime.Parse documentation");
                }
                result = DateTime.Now.Subtract(_date).TotalSeconds > 0;
                SetActive(result);
            }
        }

        private async void TimerChanged(object sender, object e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                SetActive(DateTime.Now.Subtract(_date).TotalSeconds > 0);
            });
        }
    }

}
