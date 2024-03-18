using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWpfIntroduction.Example.Models
{
    using AIWpfIntroduction.Example.ViewModels;
    using System.Security.Cryptography.X509Certificates;

    internal class Cookie
    {
        public Cookie()
        {
            //this._timer = new GameTimer(() => App.Current.Dispatcher.InvokeAsync((Action)(() => AddCookiePerSecond())));
            this._timer = new GameTimer(AddCookiePerSecond);
        }
        #region Cookieクラスの変数
        /// <summary>
        /// 現在値のプロパティ
        /// </summary>
        public int NowCookie { get; private set; } = 0;
        
        //ボタンを押すごとに増加する値
        public int IncCookie { get; private set; } = 1;

        //適応された増加値
        public int NowAdd { get; private set; } = 0;

        //適応された増加率
        public int NowMul { get; private set; } = 1;

        //適応された毎秒ごとの増加値
        public int NowSec { get; private set; } = 1;

        //適応された30秒ごとの増加率
        public int NowInt { get; private set; } = 0;

        //費用
        public int CostAdd { get; private set; } = 10;

        public int CostMul { get; private set; } = 20;

        public int CostSec { get; private set; } = 30;

        public int CostInt { get; private set; } = 100;
        
        #endregion Cookieクラスの変数


        #region 各コマンド本体
        private void AddCookiePerSecond()
        {
            this.NowCookie = this.NowCookie + this.NowSec + (this.NowCookie * this.NowInt / 100);

            App.Current.Dispatcher.InvokeAsync((Action)(() => RaiseNowCookieChanged()));
        }

        

        public event EventHandler? NowCookieChanged;

        /// <summary>
        /// NowCookieChangedイベントを発行しています。
        /// </summary>
        private void RaiseNowCookieChanged()
        {
            var h = NowCookieChanged;
            if (h != null)
            {
                h(this, EventArgs.Empty);
            }
        }
        /// <summary>
        /// 現在値を増加値分だけ加算する
        /// </summary>
        public void UpdateNowCookie()
        {
            this.NowCookie += this.IncCookie;
            RaiseNowCookieChanged();
        }

        /// <summary>
        /// 増加値を変更する
        /// </summary>
        public void UpdateIncCookie()
        {
            this.IncCookie = (1 + this.NowAdd) * this.NowMul;
        }

        /// <summary>
        /// 増加値の増加量をアップグレード
        /// </summary>
        public void OnAdd()
        {
            //増加値の増加量を計算
            this.NowAdd += 1;
            //コスト消費計算
            this.NowCookie -= this.CostAdd;
            //コスト上昇計算
            this.CostAdd += 50;
            //増加値更新
            UpdateIncCookie();
            //現在値更新
            RaiseNowCookieChanged();
        }

        /// <summary>
        /// 増加値の倍率をアップグレード
        /// </summary>
        public void OnMul()
        {
            //増加値の倍率を計算
            this.NowMul += 1;
            //コスト消費計算
            this.NowCookie -= this.CostMul;
            //コスト上昇計算
            this.CostMul *= 10;
            //増加値更新
            UpdateIncCookie();
            //現在値更新
            RaiseNowCookieChanged();
        }

        /// <summary>
        /// 生産量をアップグレード
        /// </summary>
        public void OnSec()
        {
            this.NowSec += 1;
            this.NowCookie -= this.CostSec;
            this.CostSec += 30;
            UpdateIncCookie();
            RaiseNowCookieChanged();
        }

        /// <summary>
        /// 利息率をアップグレード
        /// </summary>
        public void OnInt()
        {
            this.NowInt += 1;
            this.NowCookie -= this.CostInt;
            this.CostInt += 50;
            UpdateIncCookie();
            RaiseNowCookieChanged();
        }
    #endregion 各コマンド本体

        private GameTimer _timer;

    }
}
