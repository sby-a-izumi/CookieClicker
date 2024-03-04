using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWpfIntroduction.Example.Models
{
    class Cookie
    {
        public Cookie()
        {
            this._calc = new Calculator();
        }
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
                        UpdateNowCookie();
                    },
                    _ =>
                    {
                        var dummy = 0.0;
                        if (!double.TryParse(MainViewModel._nowCookie, out dummy))
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
                        OnMul();
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

        #region 各コマンド本体
        //現在値を変更する
        private void UpdateNowCookie()
        {
            var nowCookie = 0.0;
            var incCookie = 0.0;
            if (!double.TryParse(this.NowCookie, out nowCookie))
            {
                return;
            }
            if (!double.TryParse(this.IncCookie, out incCookie))
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
            if (!double.TryParse(this.IncCookie, out incCookie))
            {
                return;
            }
            if (!double.TryParse(this.NowAdd, out nowAdd))
            {
                return;
            }
            if (!double.TryParse(this.NowMul, out nowMul))
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
            var incCookie = 0.0;
            var nowMul = 0.0;
            //コマンド取得の時点で数値以外弾いているが、想定外のトラブルを想定してTryParseで実装
            if (!double.TryParse(this.NowCookie, out nowCookie)) { return; }
            if (!double.TryParse(this.NowAdd, out nowAdd)) { return; }
            if (!double.TryParse(this.CostAdd, out costAdd)) { return; }
            if (!double.TryParse(this.IncCookie, out incCookie)) { return; }
            if (!double.TryParse(this.NowMul, out nowMul)) { return; }
            this._calc.NowCookie = nowCookie;
            this._calc.NowAdd = nowAdd;
            this._calc.CostAdd = costAdd;
            this._calc.IncCookie = incCookie;
            this._calc.NowMul = nowMul;
            this._calc.ExecuteUpgradeAdd();
            this.NowCookie = this._calc.NowCookie.ToString();
            this.NowAdd = this._calc.NowAdd.ToString();
            this.CostAdd = this._calc.CostAdd.ToString();
            this.IncCookie = this._calc.IncCookie.ToString();

        }

        private void OnMul()
        {
            var nowCookie = 0.0;
            var nowMul = 0.0;
            var costMul = 0.0;
            var incCookie = 0.0;
            if (!double.TryParse(this.NowCookie, out nowCookie)) { return; }
            if (!double.TryParse(this.NowMul, out nowMul)) { return; }
            if (!double.TryParse(this.CostMul, out costMul)) { return; }
            if (!double.TryParse(this.IncCookie, out incCookie)) { return; }
            this._calc.NowCookie = nowCookie;
            this._calc.NowMul = nowMul;
            this._calc.CostMul = costMul;
            this._calc.IncCookie = incCookie;
            this._calc.ExecuteUpgradeMul();
            this.NowCookie = this._calc.NowCookie.ToString();
            this.NowMul = this._calc.NowMul.ToString();
            this.CostMul = this._calc.CostMul.ToString();
            this.IncCookie = this._calc.IncCookie.ToString();

        }
    #endregion 各コマンド本体

        private Calculator _calc;

    }
}
