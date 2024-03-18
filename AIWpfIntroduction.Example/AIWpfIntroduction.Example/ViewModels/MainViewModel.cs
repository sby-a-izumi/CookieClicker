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

            // UpgradeAddCommandのインスタンス化
            UpgradeAddCommand = new DelegateCommand(_ => UpgradeAdd(), _ => CanUpgradeAdd());

            // UpgradeMulCommandのインスタンス化
            UpgradeMulCommand = new DelegateCommand(_ => UpgradeMul(), _ => CanUpgradeMul());

            // UpgradeSecCommandのインスタンス化
            UpgradeSecCommand = new DelegateCommand(_ => UpgradeSec(), _ => CanUpgradeSec());

            // UpgradeMulCommandのインスタンス化
            UpgradeIntCommand = new DelegateCommand(_ => UpgradeInt(), _ => CanUpgradeInt());

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
            this.UpgradeAddCommand.RaiseCanExecuteChanged();
            this.UpgradeMulCommand.RaiseCanExecuteChanged();
            this.UpgradeSecCommand.RaiseCanExecuteChanged();
            this.UpgradeIntCommand.RaiseCanExecuteChanged();
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


        /// <summary>
        /// CalcNowCommandを実行したときに処理されるメソッド
        /// </summary>
        private void CalcNow()
        {
            this._cookie.UpdateNowCookie();
        }

        /// <summary>
        /// CalcNowCommandの実行可否判断
        /// </summary>
        /// <returns></returns>
        private bool CanCalcNow()
        {
            return true;
        }

        /// <summary>
        /// 現在値変更コマンド取得
        /// </summary>
        public DelegateCommand CalcNowCommand { get; init; }

        /// <summary>
        /// CalcIncCommandを実行したときに処理されるメソッド
        /// </summary>
        private void CalcInc()
        {
            this._cookie.UpdateIncCookie();
        }

        /// <summary>
        /// CalcIncCommandの実行可否判断
        /// </summary>
        /// <returns></returns>
        private bool CanCalcInc()
        {
            return true;
        }

        /// <summary>
        /// 増加値変更コマンド取得
        /// </summary>
        public DelegateCommand CalcIncCommand { get; init; }

        /// <summary>
        /// UpgradeAddCommandが実行されたときに処理されるメソッド
        /// </summary>
        private void UpgradeAdd()
        {
            this._cookie.OnAdd();
        }

        /// <summary>
        /// UpgradeAddCommandの実行可否判断
        /// </summary>
        /// <returns></returns>
        private bool CanUpgradeAdd()
        {
            return this._cookie.NowCookie >= this._cookie.CostAdd ;
        }

        /// <summary>
        /// 増加量アップグレードコマンド取得
        /// </summary>
        public DelegateCommand UpgradeAddCommand { get; init; }

        /// <summary>
        /// UpgradeMulCommandが実行されたときに処理されるメソッド
        /// </summary>
        private void UpgradeMul()
        {
            this._cookie.OnMul();
        }

        /// <summary>
        /// UpgradeMulCommandの実行可否判断
        /// </summary>
        /// <returns></returns>
        private bool CanUpgradeMul()
        {
            return this._cookie.NowCookie >= this._cookie.CostMul;
        }

        /// <summary>
        /// 倍率アップグレードコマンド取得
        /// </summary>
        public DelegateCommand UpgradeMulCommand { get; init; }

        /// <summary>
        /// UpgradeSecCommandが実行されたときに処理されるメソッド
        /// </summary>
        private void UpgradeSec()
        {
            this._cookie.OnSec();
        }

        /// <summary>
        /// UpgradeSecCommandの実行可否判断
        /// </summary>
        /// <returns></returns>
        private bool CanUpgradeSec()
        {
            return this._cookie.NowCookie >= this._cookie.CostSec;
        }
        
        /// <summary>
        /// 生産量アップグレードコマンド取得
        /// </summary>
        public DelegateCommand UpgradeSecCommand { get; init; }

        /// <summary>
        /// UpgradeIntCommandが実行されたときに処理されるメソッド
        /// </summary>
        private void UpgradeInt()
        {
            this._cookie.OnInt();
        }

        /// <summary>
        /// UpgradeIntCommandの実行可否判断
        /// </summary>
        /// <returns></returns>
        private bool CanUpgradeInt()
        {
            return this._cookie.NowCookie < this._cookie.CostInt;
        }
        
        /// <summary>
        /// 生産利息アップグレードコマンド取得
        /// </summary>
        public DelegateCommand UpgradeIntCommand { get; init; }
        #endregion 各コマンドの取得メソッド


        //モデルオブジェクト
        private readonly Cookie _cookie;
    }
}

