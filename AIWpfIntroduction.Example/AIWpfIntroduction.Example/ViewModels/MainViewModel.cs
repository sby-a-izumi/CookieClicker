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
    /// <summary>
    /// MainViewに対するデータコンテキスト
    /// </summary>
    internal class MainViewModel : NotificationObject
    {
        /// <summary>
        /// MainViewModelコンストラクタ
        /// </summary>
        public MainViewModel()
        {
            
            this._cookie = new Cookie();
            this._cookie.NowCookieChanged += OnNowCookieChanged;
        }

        /// <summary>
        /// NowCookieChanged イベントハンドラ
        /// </summary>
        /// <param name="obj">イベント発行元</param>
        /// <param name="args">イベント引数</param>
        private void OnNowCookieChanged(object? obj, EventArgs args)
        {
            RaisePropertyChanged(null);
            this.UpgradeAdd.RaiseCanExecuteChanged();
            this.UpgradeMul.RaiseCanExecuteChanged();
        }

        #region Modelのインスタンスから各プロパティを取得

        /// <summary>
        /// 現在値の取得
        /// </summary>
        public string NowCookie
        {
            get { return this._cookie.NowCookie; }
        }

        /// <summary>
        /// 増加値の取得
        /// </summary>
        public string IncCookie
        {
            get { return this._cookie.IncCookie; }
        }

        /// <summary>
        /// 増加値の増加量の取得
        /// </summary>
        public string NowAdd
        {
            get { return this._cookie.NowAdd; }
        }

        /// <summary>
        /// 増加値の倍率の取得
        /// </summary>
        public string NowMul
        {
            get { return this._cookie.NowMul; }
        }

        /// <summary>
        /// 生産量の取得
        /// </summary>
        public string NowSec
        {
            get { return this._cookie.NowSec; }
        }

        /// <summary>
        /// 利息率の取得
        /// </summary>
        public string NowInt
        {
            get { return this._cookie.NowInt; }
        }

        /// <summary>
        /// 増加量コスト
        /// </summary>
        public string CostAdd
        {
            get { return this._cookie.CostAdd; }
        }

        /// <summary>
        /// 倍率コスト
        /// </summary>
        public string CostMul
        {
            get { return this._cookie.CostMul; }
        }

        /// <summary>
        /// 生産量コスト
        /// </summary>
        public string CostSec
        {
            get { return this._cookie.CostSec; }
        }

        /// <summary>
        /// 利息率コスト
        /// </summary>
        public string CostInt
        {
            get { return this._cookie.CostInt; }
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
                        RaisePropertyChanged(null);
                    },
                    _ =>
                    {
                        var dummy = 0.0;
                        if (!double.TryParse(this.NowCookie, out dummy))
                        {
                            return false;
                        }
                        if (!double.TryParse(this.IncCookie, out dummy))
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
                        if (!double.TryParse(this.IncCookie, out dummy))
                        {
                            return false;
                        }
                        if (!double.TryParse(this.NowAdd, out dummy))
                        {
                            return false;
                        }
                        if (!double.TryParse(this.NowMul, out dummy))
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
                        if (!double.TryParse(this.NowCookie, out nowCookie))
                        {
                            return false;
                        }
                        if (!double.TryParse(this.NowAdd, out dummy))
                        {
                            return false;
                        }
                        if (!double.TryParse(this.CostAdd, out costAdd))
                        {
                            return false;
                        }
                        if (!double.TryParse(this.IncCookie, out dummy))
                        {
                            return false;
                        }
                        if (!double.TryParse(this.NowMul, out dummy))
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
                        if (!double.TryParse(this.NowCookie, out nowCookie))
                        {
                            return false;
                        }
                        if (!double.TryParse(this.NowMul, out dummy))
                        {
                            return false;
                        }
                    if (!double.TryParse(this.CostMul, out costMul))
                        {
                            return false;
                        }
                        if (!double.TryParse(this.IncCookie, out dummy))
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


        

        //モデルオブジェクト
        private Cookie _cookie;
    }
}

