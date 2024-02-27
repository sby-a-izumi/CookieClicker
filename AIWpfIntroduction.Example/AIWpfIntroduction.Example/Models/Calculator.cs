using System;
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


        
        public void ExecuteCalcNowCookie()
        {
            this.NowCookie = this.NowCookie + this.IncCookie;
        }
        public void ExecuteCalcIncCookie()
        {
            this.IncCookie = (this.IncCookie + this.NowAdd) * this.NowMul;
        }

    }
}
