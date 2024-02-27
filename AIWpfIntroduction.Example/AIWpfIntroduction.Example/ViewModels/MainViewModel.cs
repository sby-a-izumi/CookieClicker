using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AIWpfIntroduction.Example.ViewModels
{
    using AIWpfIntroduction.Example.Models;
    using System.Security.Policy;
    using System.Windows.Media.Animation;

    internal class MainViewModel : NotificationObject
    {
        //新しいインスタンスの生成
        public MainViewModel()
        {
            this._timer = new GameTimer();
            this._calc = new Calculator();
        }

        private string _nowCookie = 0.ToString();
        //現在値の取得または設定
        public string NowCookie
        {
            get { return this._nowCookie; }
            //値が違う場合更新
            set
            {
                if (this._nowCookie == null)
                {
                    this._nowCookie = 0.ToString();
                }
                if (SetProperty(ref this._nowCookie, value))
                {
                    this.UpgradeAdd.RaiseCanExecuteChanged();
                }
            }
        }

        private string _incCookie = 1.ToString();
        //増加値の取得または設定
        public string IncCookie
        {
            get { return this._incCookie; }
            set { SetProperty(ref this._incCookie, value); }
        }

        //現在のパラメータ

        private string _nowAdd = 0.ToString();
        //現在の増加値の増加量
        public string NowAdd
        {
            get { return this._nowAdd; }
            set
            {
                if (SetProperty(ref this._nowAdd, value))
                {
                    this.CalcIncCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _nowMul = 1.0.ToString();
        //現在の増加値の倍率
        public string NowMul
        {
            get { return this._nowMul; }
            set
            {
                if (SetProperty(ref this._nowMul, value))
                {
                    this.CalcIncCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _nowSec = 0.ToString();
        //現在の毎秒増加量
        public string NowSec
        {
            get { return this._nowSec; }
            set
            {
                if (SetProperty(ref this._nowSec, value))
                {
                    this.CalcIncCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _nowInt = 0.ToString();
        //現在の利息率
        public string NowInt
        {
            get { return this._nowInt; }
            set
            {
                if (SetProperty(ref this._nowInt, value))
                {
                    this.CalcIncCommand.RaiseCanExecuteChanged();
                }
            }
        }

        //アップグレード費用

        private string _costAdd = 20.ToString();
        //増加値の増加量コスト
        public string CostAdd
        {
            get { return this._costAdd; }
            private set { SetProperty(ref this._costAdd, value); }
        }

        private string _costMul = 200.ToString();
        //増加値の倍率コスト
        public string CostMul
        {
            get { return this._costMul; }
            private set { SetProperty(ref this._costMul, value); }
        }

        private string _costSec = 30.ToString();
        //毎秒増加量のコスト
        public string CostSec
        {
            get { return this._costSec; }
            private set { SetProperty(ref this._costSec, value); }
        }

        private string _costInt = 100.ToString();
        //利息率のコスト
        public string CostInt
        {
            get { return this._costInt; }
            private set { SetProperty(ref this._costInt, value); }
        }

        private DelegateCommand _calcNowCommand;
        //現在値変更コマンドの取得
        public DelegateCommand CalcNowCommand
        {
            get
            {
                return this._calcNowCommand ?? (this._calcNowCommand = new DelegateCommand(
                    _ =>
                    {
                        UpdateNowCookie();
                    },
                    _ =>
                    {
                        var dummy = 0.0;
                        if (!double.TryParse(this._nowCookie, out dummy))
                        {
                            return false;
                        }
                        if (!double.TryParse(this._incCookie, out dummy))
                        {
                            return false;
                        }
                        return true;
                    }));
            }
        }

        private DelegateCommand _calcIncCommand;
        //増加値変更コマンドの取得
        public DelegateCommand CalcIncCommand
        {
            get
            {
                return this._calcIncCommand ?? (this._calcIncCommand = new DelegateCommand(
                    _ =>
                    {
                        UpdateIncCookie();
                    },
                    _ =>
                    {
                        var dummy = 0.0;
                        if (!double.TryParse(this._incCookie, out dummy))
                        {
                            return false;
                        }
                        if (!double.TryParse(this._nowAdd, out dummy))
                        {
                            return false;
                        }
                        if (!double.TryParse(this._nowMul, out dummy))
                        {
                            return false;
                        }
                        return true;
                    }));
            }
        }

        private DelegateCommand _upgradeAdd;
        //増加値の増加量をアップグレードするコマンドの取得
        public DelegateCommand UpgradeAdd
        {
            get
            {
                return this._upgradeAdd ?? (this._upgradeAdd = new DelegateCommand(
                    _ =>
                    {
                        OnAdd();
                    },
                    _ =>
                    {
                        var dummy = 0.0;
                        if (!double.TryParse(this._nowCookie, out dummy))
                        {
                            return false;
                        }
                        if (!double.TryParse(this._nowAdd, out dummy))
                        {
                            return false;
                        }
                        if (!double.TryParse(this._costAdd, out dummy))
                        {
                            return false;
                        }
                    
                        if (double.Parse(this._nowCookie) < double.Parse(this._costAdd))
                        {
                            return false;
                        }
                        return true;
                    }));
            }
        }
        //現在値を変更する
        private void UpdateNowCookie()
        {
            var nowCookie = 0.0;
            var incCookie = 0.0;
            if(!double.TryParse(this.NowCookie, out nowCookie))
            {
                return;
            }
            if(!double.TryParse(this.IncCookie, out incCookie))
            {
                return;
            }
            this._calc.NowCookie = nowCookie;
            this._calc.IncCookie = incCookie;
            this._calc.ExecuteCalcNowCookie();
            this.NowCookie = this._calc.NowCookie.ToString();
        }
        
        //増加値を変更する
        private void UpdateIncCookie()
        {
            var incCookie = 0.0;
            var nowAdd = 0.0;
            var nowMul = 1.0;
            if(!double.TryParse(this.IncCookie, out incCookie))
            {
                return;
            }
            if(!double.TryParse(this.NowAdd, out nowAdd))
            {
                return;
            }
            if(!double.TryParse(this.NowMul, out nowMul))
            {
                return;
            }
            this._calc.IncCookie = incCookie;
            this._calc.NowAdd = nowAdd;
            this._calc.NowMul = nowMul;
            this._calc.ExecuteCalcIncCookie();
            this.IncCookie = this._calc.IncCookie.ToString();
        }

        //増加値の増加量をアップグレード
        private void OnAdd()
        {
            var nowCookie = 0.0;
            var nowAdd = 0.0;
            var costAdd = 0.0;
            if(!double.TryParse(this.NowCookie, out nowCookie))
            {
                return;
            }
            if(! double.TryParse(this.NowAdd, out nowAdd))
            {
                return;
            }
            if(!double.TryParse(this.CostAdd, out costAdd))
            {
                return;
            }
            this._calc.NowCookie = nowCookie;
            this._calc.NowAdd = nowAdd;
            this._calc.CostAdd = costAdd;
            this._calc.ExecuteUpgradeAdd();
            this.NowCookie = this._calc.NowCookie.ToString();
            this.NowAdd = this._calc.NowAdd.ToString();
            this.CostAdd = this._calc.CostAdd.ToString();

        }
        //計算を行うオブジェクト
        private Calculator _calc;
        
        //時間を計測するオブジェクト
        private GameTimer _timer;
    }
}

