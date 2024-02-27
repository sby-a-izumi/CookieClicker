using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace AIWpfIntroduction.Example
{
    internal class GameTimer
    {
        public GameTimer()
        {
            SetupTimer();
        }

        private void MyTimerMethod(object sender, EventArgs e)
        {
            //undefined
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
