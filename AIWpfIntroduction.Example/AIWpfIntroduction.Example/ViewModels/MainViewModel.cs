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
            this._cookie = new Cookie();
        }

        #region 各プロパティの取得または設定
        private string _nowCookie = 0.ToString();
        //現在値の取得または設定
        public string NowCookie
        {
            get { return this._nowCookie; }
            //値が違う場合更新
            set
            {
                if (SetProperty(ref this._nowCookie, value))
                {
                    this.UpgradeAdd.RaiseCanExecuteChanged();
                    this.UpgradeMul.RaiseCanExecuteChanged();
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

        private string _costAdd = 10.ToString();
        //増加値の増加量コスト
        public string CostAdd
        {
            get { return this._costAdd; }
            private set { SetProperty(ref this._costAdd, value); }
        }

        private string _costMul = 20.ToString();
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
        #endregion 各プロパティの取得または設定


        #region 各コマンドの取得メソッド

        private DelegateCommand _calcNowCommand;
        //現在値変更コマンドの取得
        public DelegateCommand CalcNowCommand
        {
            get
            {
                return this._calcNowCommand ?? (this._calcNowCommand = new DelegateCommand(
                    _ =>
                    {
                        this._cookie.UpdateNowCookie();
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
                        this._cookie.UpdateIncCookie();
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
                        this._cookie.OnAdd();
                    },
                    _ =>
                    {
                        var dummy = 0.0;
                        var nowCookie = 0.0;
                        var costAdd = 0.0;
                        if (!double.TryParse(this._nowCookie, out nowCookie))
                        {
                            return false;
                        }
                        if (!double.TryParse(this._nowAdd, out dummy))
                        {
                            return false;
                        }
                        if (!double.TryParse(this._costAdd, out costAdd))
                        {
                            return false;
                        }
                        if (!double.TryParse(this._incCookie, out dummy))
                        {
                            return false;
                        }
                        if (!double.TryParse(this._nowMul, out dummy))
                        {
                            return false;
                        }
                        // アップグレード条件
                        if (nowCookie < costAdd)
                        {
                            return false;
                        }
                        return true;
                    }));
            }
        }

        private DelegateCommand _upgradeMul;
        //増加量の倍率をアップグレードするコマンドの取得
        public DelegateCommand UpgradeMul
        {
            get
            {
                return this._upgradeMul ?? (this._upgradeMul = new DelegateCommand(
                    _ =>
                    {
                        this._cookie.OnMul();
                    },
                    _ =>
                    {
                        var dummy = 0.0;
                        var nowCookie = 0.0;
                        var costMul = 0.0;
                        if (!double.TryParse(this._nowCookie, out nowCookie))
                        {
                            return false;
                        }
                        if (!double.TryParse(this._nowMul, out dummy))
                        {
                            return false;
                        }
                    if (!double.TryParse(this._costMul, out costMul))
                        {
                            return false;
                        }
                        if (!double.TryParse(this._incCookie, out dummy))
                        {
                            return false;
                        }

                        if (nowCookie < costMul)
                        {
                            return false;
                        }
                        return true;
                    }));
            }
        }
        #endregion 各コマンドの取得メソッド


        
        //時間を計測するオブジェクト
        private GameTimer _timer;

        //モデルオブジェクト
        private Cookie _cookie;
    }
}

