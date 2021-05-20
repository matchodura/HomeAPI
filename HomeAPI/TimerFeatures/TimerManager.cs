using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HomeAPI.TimerFeatures
{
    public class TimerManager
    {
        private Timer _timer;
        private AutoResetEvent _autoResetEvent;
        private Action _action;

        public DateTime TimerStarted { get; set; }

        public TimerManager(Action action, int time)
        {
            _action = action;
            //_autoResetEvent = new AutoResetEvent(false);
            //_timer = new Timer(Execute, _autoResetEvent, 1000, 10);
            TimerStarted = DateTime.Now;

            _timer = new Timer(Execute, null, TimeSpan.Zero,
               TimeSpan.FromSeconds(time));


        }

        public void Execute(object stateInfo)
        {

            _action();

            if((DateTime.Now - TimerStarted).Seconds > 60)
            {
                _timer.Dispose();
            }
        }
    }
}
