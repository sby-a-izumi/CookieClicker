using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
        private void MyTimerMethod(object? sender, ElapsedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            _action();
        }
        private System.Timers.Timer _timer;
        public System.Timers.Timer Timer
        {
            get { return _timer; }
        }

        private void SetupTimer()
        {
            _timer = new System.Timers.Timer(1000);


            _timer.Elapsed += MyTimerMethod;

            _timer.Start();


        
        }
    }
}
