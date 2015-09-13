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
        private string _dateStr;
        private DateTime _date;
        private readonly DispatcherTimer _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };

        public DateTimeTrigger()
        {
            _timer.Tick += TimerChanged;
            _timer.Start();
        }

        public string Date
        {
            get { return _dateStr; }
            set
            {
                _dateStr = value;
                if (_dateStr.All(c => c != ':') && _dateStr.All(c => c != '-') && _dateStr.All(c => c != '/'))
                {
                    throw new ArgumentException("Invalid or unknown date format, please see DateTime.Parse documentation");
                }
                var currentTime = DateTime.Now;
                var result = DateTime.TryParse(_dateStr, out _date);
                if (!result)
                {
                    throw new ArgumentException("Invalid or unknown date format, please see DateTime.Parse documentation");
                }
                SetActive(currentTime.Subtract(_date).TotalSeconds > 0);
            }
        }

        private async void TimerChanged(object sender, object e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var currentTime = DateTime.Now;
                SetActive(currentTime.Subtract(_date).TotalSeconds > 0);
            });
        }
    }

}
