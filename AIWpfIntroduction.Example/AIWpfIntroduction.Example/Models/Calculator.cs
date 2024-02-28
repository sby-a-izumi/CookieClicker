using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace AIWpfIntroduction.Example.Models
{
    internal class Calculator
    {
        //現在値
        public double NowCookie { get; set; }
        
        //ボタンを押すごとに増加する値
        public double IncCookie { get; set; }

        //適応された増加値
        public double NowAdd { get; set; }

        //適応された増加率
        public double NowMul { get; set; }

        //適応された毎秒ごとの増加値
        public double NowSec { get; set; }

        //適応された30秒ごとの増加率
        public double NowInt { get; set; }

        //費用
        public double CostAdd { get; set; }
        public double CostMul { get; set; }
        public double CostSec { get; set; }
        public double CostInt { get; set; }

        //現在値を計算
        public void ExecuteCalcNowCookie()
        {
            this.NowCookie = this.NowCookie + this.IncCookie;
        }
        //増加値を計算
        public void ExecuteCalcIncCookie()
        {
            this.IncCookie = (1 + this.NowAdd) * this.NowMul;
        }
        //増加値の増加量のアップグレード時の計算処理
        public void ExecuteUpgradeAdd()
        {
            //増加値の増加量を計算
            this.NowAdd = this.NowAdd + 1.0;
            //使ったコスト分、現在値を下げる
            this.NowCookie = this.NowCookie - this.CostAdd;
            //アップグレードコストを上昇
            this.CostAdd = this.CostAdd + 50;
            //増加値を増加量分増やす
            ExecuteCalcIncCookie();
        }
        //増加値の倍率のアップグレード時の計算処理
        public void ExecuteUpgradeMul()
        {
            this.NowMul = this.NowMul + 0.5;
            this.NowCookie = this.NowCookie - this.CostMul;
            this.CostMul = this.CostMul * 10;
            ExecuteCalcIncCookie();
        }
    }
}
