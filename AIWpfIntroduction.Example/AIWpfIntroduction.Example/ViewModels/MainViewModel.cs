namespace AIWpfIntroduction.Example.ViewModels;

using AIWpfIntroduction.Example.Models;
using System.Threading.Tasks.Dataflow;

/// <summary>
/// MainView に対するデータコンテキストを表します。
/// </summary>
internal class MainViewModel : NotificationObject
{
    /// <summary>
    /// 新しいインスタンスを生成します。
    /// </summary>
    public MainViewModel()
    {
        AddCommand = new DelegateCommand(_ => Add());
        UpgradeAddValueCommand = new DelegateCommand(_ => UpgaredeAddValue());
        UpgradeMulValueCommand = new DelegateCommand(_ => UpgradeMulValue());
    }

    #region フィールド

    /// <summary>
    /// クッキークリッカー機能を提供します。
    /// </summary>
    private Calculator _calc = new Calculator();

    #endregion フィールド

    #region 公開プロパティ

    private double _currentCookie = 0;
    /// <summary>
    /// 現在値を取得します。
    /// </summary>
    public double CurrentCookie
    {
        get { return this._currentCookie; }
        private set { SetProperty(ref this._currentCookie, value); }
    }
    
    private double _currentIncCookie = 1;
    /// <summary>
    /// 現在の増加量を取得します。
    /// </summary>
    public double CurrentIncCookie
    {
        get { return this._currentIncCookie; }
        private set { SetProperty(ref this._currentIncCookie, value); }
    }

    private double _addIncCookie = 0;
    /// <summary>
    /// 加算増加量を取得します。
    /// </summary>
    public double AddIncCookie
    {
        get { return this._addIncCookie; }
        private set { SetProperty(ref this._addIncCookie, value); }
    }

    private double _multiIncCookie = 1;
    /// <summary>
    /// 増加量倍率を取得します。
    /// </summary>
    public double MultiIncCookie
    {
        get { return this._multiIncCookie; }
        private set { SetProperty(ref this._multiIncCookie, value); }
    }

    private double _secIncCookie = 1;
    /// <summary>
    /// 毎秒増加量を取得します。
    /// </summary>
    public double SecIncCookie
    {
        get { return this._secIncCookie; }
        private set { SetProperty(ref this._secIncCookie, value); }
    }

    private double _intIncCookie = 1;
    /// <summary>
    /// 利息率を取得します。
    /// </summary>
    public double IntIncCookie
    {
        get { return this._intIncCookie; }
        private set { SetProperty(ref this._intIncCookie, value); }
    }

    private double _costAdd = 10;
    /// <summary>
    /// 追加コストを取得します。
    /// </summary>
    public double CostAdd
    {
        get { return this._costAdd; }
        private set { SetProperty(ref this._costAdd, value); }
    }

    private double _costMul = 20;
    /// <summary>
    /// 倍率をコストを取得します。
    /// </summary>
    public double CostMul
    {
        get { return this._costMul; }
        private set { SetProperty(ref this._costMul, value); }
    }

    private double _costSec = 30;
    /// <summary>
    /// 毎秒コストを取得します。
    /// </summary>
    public double CostSec
    {
        get { return this._costSec; }
        private set { SetProperty(ref this._costSec, value); }
    }

    private double _costInt = 100;
    /// <summary>
    /// 利息率をコストを取得します。
    /// </summary>
    public double CostInt
    {
        get { return this._costInt; }
        private set { SetProperty(ref this._costInt, value); }
    }

    #endregion 公開プロパティ

    #region コマンド

    /// <summary>
    /// 増加ボタンが押された際のコマンドを取得します。
    /// </summary>
    public DelegateCommand AddCommand { get; init; }

    /// <summary>
    /// 現在値を増加させます。
    /// </summary>
    public void Add()
    {
        var nowCookie = 0.0;
        var incCookie = 0.0;
        this._calc.NowCookie = nowCookie;
        this._calc.IncCookie = incCookie;
        this._calc.ExecuteCalcNowCookie();
        CurrentCookie = this._calc.NowCookie;
    }

    /// <summary>
    /// 増加値加算ボタンが押された際のコマンドを取得します。
    /// </summary>
    public DelegateCommand UpgradeAddValueCommand { get; init; }

    /// <summary>
    /// 増加値を加算します。
    /// </summary>
    private void UpgaredeAddValue()
    {
        //var nowCookie = 0.0;
        //var nowAdd = 0.0;
        //var costAdd = 0.0;
        //var incCookie = 0.0;
        //var nowMul = 0.0;
        //this._calc.NowCookie = nowCookie;
        //this._calc.NowAdd = nowAdd;
        //this._calc.CostAdd = costAdd;
        //this._calc.IncCookie = incCookie;
        //this._calc.NowMul = nowMul;
        //this._calc.ExecuteUpgradeAdd();
        //this.NowCookie = this._calc.NowCookie.ToString();
        //this.NowAdd = this._calc.NowAdd.ToString();
        //this.CostAdd = this._calc.CostAdd.ToString();
        //this.IncCookie = this._calc.IncCookie.ToString();
    }

    /// <summary>
    /// 倍率増加ボタンを押された際のコマンドを取得します。
    /// </summary>
    public DelegateCommand UpgradeMulValueCommand { get; init; }

    /// <summary>
    /// 倍率を増加させます。
    /// </summary>
    private void UpgradeMulValue()
    {
        //var nowCookie = 0.0;
        //var nowMul = 0.0;
        //var costMul = 0.0;
        //var incCookie = 0.0;
        //if (!double.TryParse(this.NowCookie, out nowCookie)) { return; }
        //if (!double.TryParse(this.NowMul, out nowMul)) { return; }
        //if (!double.TryParse(this.CostMul, out costMul)) { return; }
        //if (!double.TryParse(this.IncCookie, out incCookie)) { return; }
        //this._calc.NowCookie = nowCookie;
        //this._calc.NowMul = nowMul;
        //this._calc.CostMul = costMul;
        //this._calc.IncCookie = incCookie;
        //this._calc.ExecuteUpgradeMul();
        //this.NowCookie = this._calc.NowCookie.ToString();
        //this.NowMul = this._calc.NowMul.ToString();
        //this.CostMul = this._calc.CostMul.ToString();
        //this.IncCookie = this._calc.IncCookie.ToString();
    }

    #endregion コマンド
}