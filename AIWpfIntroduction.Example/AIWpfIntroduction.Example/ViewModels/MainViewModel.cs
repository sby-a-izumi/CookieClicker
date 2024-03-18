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

            // CalcNowCommandのインスタンス化
            CalcNowCommand = new DelegateCommand(_ => CalcNow(), _ => CanCalcNow());

            // CalcIncCommandのインスタンス化
            CalcIncCommand = new DelegateCommand(_ => CalcInc(), _ => CanCalcInc());



            // NowCookieChangedイベントにOnNowCookieChangedイベントハンドラを購読しています。
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
            this.UpgradeSec.RaiseCanExecuteChanged();
            this.UpgradeInt.RaiseCanExecuteChanged();
        }

        #region Modelのインスタンスから各プロパティを取得

        /// <summary>
        /// 現在値の取得
        /// </summary>
        public int NowCookie
        {
            get { return this._cookie.NowCookie; }
        }

        /// <summary>
        /// 増加値の取得
        /// </summary>
        public int IncCookie
        {
            get { return this._cookie.IncCookie; }
        }

        /// <summary>
        /// 増加値の増加量の取得
        /// </summary>
        public int NowAdd
        {
            get { return this._cookie.NowAdd; }
        }

        /// <summary>
        /// 増加値の倍率の取得
        /// </summary>
        public int NowMul
        {
            get { return this._cookie.NowMul; }
        }

        /// <summary>
        /// 生産量の取得
        /// </summary>
        public int NowSec
        {
            get { return this._cookie.NowSec; }
        }

        /// <summary>
        /// 利息率の取得
        /// </summary>
        public int NowInt
        {
            get { return this._cookie.NowInt; }
        }

        /// <summary>
        /// 増加量コスト
        /// </summary>
        public int CostAdd
        {
            get { return this._cookie.CostAdd; }
        }

        /// <summary>
        /// 倍率コスト
        /// </summary>
        public int CostMul
        {
            get { return this._cookie.CostMul; }
        }

        /// <summary>
        /// 生産量コスト
        /// </summary>
        public int CostSec
        {
            get { return this._cookie.CostSec; }
        }

        /// <summary>
        /// 利息率コスト
        /// </summary>
        public int CostInt
        {
            get { return this._cookie.CostInt; }
        }
        #endregion 各プロパティの取得または設定


        #region 各コマンドの取得メソッド

        private void CalcNow()
        {
            this._cookie.UpdateNowCookie();
        }

        private bool CanCalcNow()
        {
            return true;
        }

        /// <summary>
        /// 現在値変更コマンド取得
        /// </summary>
        public DelegateCommand CalcNowCommand { get; private set; }

        
        private void CalcInc()
        {
            this._cookie.UpdateIncCookie();
        }

        private bool CanCalcInc()
        {
            return true;
        }

        /// <summary>
        /// 増加値変更コマンド取得
        /// </summary>
        public DelegateCommand CalcIncCommand { get; private set; }

        private DelegateCommand _upgradeAdd;
        /// <summary>
        /// 増加量アップグレードコマンド取得
        /// </summary>
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
                        // アップグレード条件
                        if (this._cookie.NowCookie < this._cookie.CostAdd)
                        {
                            return false;
                        }
                        return true;
                    }));
            }
        }

        private DelegateCommand _upgradeMul;
        /// <summary>
        /// 倍率アップグレードコマンド取得
        /// </summary>
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
                        if (this._cookie.NowCookie < this._cookie.CostMul)
                        {
                            return false;
                        }
                        return true;
                    }));
            }
        }

        private DelegateCommand _upgradeSec;
        /// <summary>
        /// 生産量アップグレードコマンド取得
        /// </summary>
        public DelegateCommand UpgradeSec
        {
            get
            {
                return this._upgradeSec ?? (this._upgradeSec = new DelegateCommand(
                    _ =>
                    {
                        this._cookie.OnSec();
                    },
                    _ =>
                    {
                        if (this._cookie.NowCookie < this._cookie.CostSec)
                        {
                            return false;
                        }
                        return true;
                    }));
            }
        }

        private DelegateCommand _upgradeInt;
        /// <summary>
        /// 生産利息アップグレードコマンド取得
        /// </summary>
        public DelegateCommand UpgradeInt
        {
            get
            {
                return this._upgradeInt ?? (this._upgradeInt = new DelegateCommand(
                    _ =>
                    {
                        this._cookie.OnInt();
                    },
                    _ =>
                    {
                        if (this._cookie.NowCookie < this._cookie.CostInt)
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

