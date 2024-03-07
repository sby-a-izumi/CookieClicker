using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace AIWpfIntroduction.Example
{
    internal class GameTimer
    {
        public GameTimer(Action action)
        {
            SetupTimer();
            _action = action;
        }

        private Action _action;
        private void MyTimerMethod(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            _action();
        }
        private DispatcherTimer _timer;
        public DispatcherTimer Timer
        {
            get { return _timer; }
        }

        private void SetupTimer()
        {
            _timer = new DispatcherTimer();

            _timer.Interval = new TimeSpan(0, 0, 1);

            _timer.Tick += new EventHandler(MyTimerMethod);

            _timer.Start();


        }
        
    }
}
