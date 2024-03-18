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
        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="action">引数なしのデリゲートを指定</param>
        public GameTimer(Action action)
        {
            SetupTimer();
            _action = action;
        }

        private Action _action;
        /// <summary>
        /// Elapsedイベントが発行された際に実行されるイベントハンドラ
        /// </summary>
        /// <param name="sender">発行元</param>
        /// <param name="e">イベント引数</param>
        private void OnElapsed(object? sender, ElapsedEventArgs e)
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
            // 1秒ごとに実行するtimerをインスタンス化
            _timer = new System.Timers.Timer(1000);

            // ElapsedイベントにOnElapsedを購読
            _timer.Elapsed +=OnElapsed;

            // 設定されたTimer設定でスタート
            _timer.Start();


        
        }
    }
}
