using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AIWpfIntroduction.Example
{
    internal class DelegateCommand : ICommand
    {   
        //コマンド実行時の処理内容を保持
        private Action<object> _execute;

        //コマンド実行可能判別の処理内容を保持
        private Func<object, bool> _canExecute;

        //新しいインスタンスを生成（引数：execute→コマンド実行処理を指定　のコンストラクタ）
        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        //新しいインスタンスを生成（引数：execute→コマンド実行処理を指定、canExecute→コマンド実行可能判別処理を指定　のコンストラクタ）
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        #region ICommand の実装
        //コマンドが実行可能かどうかの判別処理
        public bool CanExecute(object parameter)
        {
            return (this._canExecute != null) ? this._canExecute(parameter) : true;
        }
        //実行可能かどうかの判別処理の関する状態が変更された時に発生
        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            var h = this.CanExecuteChanged;
            if (h != null) h(this, EventArgs.Empty);
        }

        //コマンドが実行されたときの処理
        public void Execute(object parameter)
        {
            if(this._execute != null)
                this._execute(parameter);
        }
        #endregion ICommand の実装
    }
}
