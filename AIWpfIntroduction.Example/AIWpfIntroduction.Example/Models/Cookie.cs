using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWpfIntroduction.Example.Models
{
    using AIWpfIntroduction.Example.ViewModels;
    using System.Security.Cryptography.X509Certificates;

    class Cookie
    {
        public Cookie()
        {
            this._timer = new GameTimer(() => App.Current.Dispatcher.InvokeAsync((Action)(() => AddCookiePerSecond())));
            //this._timer = new GameTimer(() => App.Current.Dispatcher.Invoke(()=> AddCookiePerSecond()));
            RaiseNowCookieChanged();
            this._calc = new Calculator();
        }
        #region Cookieクラスの変数
        private int _nowCookie = 0;
        /// <summary>
        /// 現在値のプロパティ
        /// </summary>
        public int NowCookie
        {
            get { return this._nowCookie; }
            private set {
                this._nowCookie = value;
            }
        }  
        
        private int _incCookie = 1;
        //ボタンを押すごとに増加する値
        public int IncCookie
        {
            get { return this._incCookie; }
            set { this._incCookie = value; }
        }

        private int _nowAdd = 0;
        //適応された増加値
        public int NowAdd
        {
            get { return this._nowAdd; }
            set { this._nowAdd = value; }
        }

        private int _nowMul = 1;
        //適応された増加率
        public int NowMul
        {
            get { return this._nowMul; }
            set { this._nowMul = value; }
        }

        private int _nowSec = 1;
        //適応された毎秒ごとの増加値
        public int NowSec
        {
            get { return this._nowSec; }
            set { this._nowSec = value; }
        }

        private int _nowInt = 0;
        //適応された30秒ごとの増加率
        public int NowInt
        {
            get { return this._nowInt; }
            set { this._nowInt = value; }
        }

        //費用
        private int _costAdd = 10;
        public int CostAdd
        {
            get { return this._costAdd; }
            set { this._costAdd = value; }
        }

        private int _costMul = 20;
        public int CostMul
        {
            get { return this._costMul; }
            set { this._costMul = value; }
        }

        private int _costSec = 30;
        public int CostSec
        {
            get { return this._costSec; }
            set { this._costSec = value; }
        }

        private int _costInt = 100;
        public int CostInt
        {
            get { return this._costInt; }
            set { this._costInt = value; }
        }
        
        #endregion Cookieクラスの変数


        #region 各コマンド本体
        private void AddCookiePerSecond()
        {
            this.NowCookie = this.NowCookie + this.NowSec;
            RaiseNowCookieChanged();
        }

        public event EventHandler? NowCookieChanged;

        private void RaiseNowCookieChanged()
        {
            var h = NowCookieChanged;
            if (h != null)
            {
                h(this, EventArgs.Empty);
            }
        }
        //現在値を変更する
        public void UpdateNowCookie()
        {
            
            this._calc.NowCookie = this.NowCookie;
            this._calc.IncCookie = this.IncCookie;
            this._calc.ExecuteCalcNowCookie();
            this.NowCookie = this._calc.NowCookie;
        }

        //増加値を変更する
        public void UpdateIncCookie()
        {
            this._calc.IncCookie = this.IncCookie;
            this._calc.NowAdd = this.NowAdd;
            this._calc.NowMul = this.NowMul;
            this._calc.ExecuteCalcIncCookie();
            this.IncCookie = this._calc.IncCookie;
        }

        //増加値の増加量をアップグレード
        public void OnAdd()
        {
            this._calc.NowCookie = this.NowCookie;
            this._calc.NowAdd = this.NowAdd;
            this._calc.CostAdd = this.CostAdd;
            this._calc.IncCookie = this.IncCookie;
            this._calc.NowMul = this.NowMul;
            this._calc.ExecuteUpgradeAdd();
            this.NowCookie = this._calc.NowCookie;
            this.NowAdd = this._calc.NowAdd;
            this.CostAdd = this._calc.CostAdd;
            this.IncCookie = this._calc.IncCookie;
            RaiseNowCookieChanged();

        }

        public void OnMul()
        {
            this._calc.NowCookie = this.NowCookie;
            this._calc.NowMul = this.NowMul;
            this._calc.CostMul = this.CostMul;
            this._calc.IncCookie = this.IncCookie;
            this._calc.ExecuteUpgradeMul();
            this.NowCookie = this._calc.NowCookie;
            this.NowMul = this._calc.NowMul;
            this.CostMul = this._calc.CostMul;
            this.IncCookie = this._calc.IncCookie;
            RaiseNowCookieChanged();

        }

    #endregion 各コマンド本体

        private Calculator _calc;
        private GameTimer _timer;

    }
}
