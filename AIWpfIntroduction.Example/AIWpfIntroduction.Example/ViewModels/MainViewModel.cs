namespace AIWpfIntroduction.Example.ViewModels;

using AIWpfIntroduction.Example.Models;

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
        UpgradeAddValueCommand = new DelegateCommand(_ => UpgradeAddValue());
        UpgradeMultiValueCommand = new DelegateCommand(_ => UpgradeMultiValue());
    }

    #region フィールド

    /// <summary>
    /// CookkieClicker 機能を提供します。
    /// </summary>
    private CookieClicker _cookieClicker = new ();

    #endregion フィールド

    #region 公開プロパティ

    /// <summary>
    /// 現在値を取得します。
    /// </summary>
    public double CurrentCookie { get { return _cookieClicker.CurrentCookie; } }

    /// <summary>
    /// 現在の増加量を取得します。
    /// </summary>
    public double CurrentIncCookie { get { return _cookieClicker.CurrentIncCookie; } }

    /// <summary>
    /// 加算増加量を取得します。
    /// </summary>
    public double AddIncCookie { get { return _cookieClicker.AddIncCookie; } }

    /// <summary>
    /// 増加量倍率を取得します。
    /// </summary>
    public double MultiIncCookie { get { return _cookieClicker.MultiIncCookie; } }

    /// <summary>
    /// 毎秒増加量を取得します。
    /// </summary>
    public double SecIncCookie { get { return _cookieClicker.SecIncCookie; } }

    /// <summary>
    /// 利息率を取得します。
    /// </summary>
    public double IntIncCookie { get { return _cookieClicker.IntIncCookie; } }

    /// <summary>
    /// 加算コストを取得します。
    /// </summary>
    public double CostAdd { get { return _cookieClicker.CostAdd; } }

    /// <summary>
    /// 倍率コストを取得します。
    /// </summary>
    public double CostMul { get { return _cookieClicker.CostMul; } }

    /// <summary>
    /// 毎秒コストを取得します。
    /// </summary>
    public double CostSec { get { return _cookieClicker.CostSec; } }

    /// <summary>
    /// 利息率 コストを取得します。
    /// </summary>
    public double CostInt { get { return _cookieClicker.CostInt; } }

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
        _cookieClicker.UpdateCurrentCookie();
        RaisePropertyChanged(nameof(CurrentCookie));
    }

    /// <summary>
    /// 増加値加算ボタンが押された際のコマンドを取得します。
    /// </summary>
    public DelegateCommand UpgradeAddValueCommand { get; init; }

    /// <summary>
    /// 増加値を加算します。
    /// </summary>
    private void UpgradeAddValue()
    {
        _cookieClicker.UpgradeAddIncCookie();
        RaisePropertyChanged(nameof(AddIncCookie));
        RaisePropertyChanged(nameof(CostAdd));
        RaisePropertyChanged(nameof(CurrentCookie));
        RaisePropertyChanged(nameof(CurrentIncCookie));
    }

    /// <summary>
    /// 倍率増加ボタンを押された際のコマンドを取得します。
    /// </summary>
    public DelegateCommand UpgradeMultiValueCommand { get; init; }

    /// <summary>
    /// 倍率を増加させます。
    /// </summary>
    private void UpgradeMultiValue()
    {
        _cookieClicker.UpgradeMultiIncCookie();
        RaisePropertyChanged(nameof(MultiIncCookie));
        RaisePropertyChanged(nameof(CostMul));
        RaisePropertyChanged(nameof(CurrentCookie));
        RaisePropertyChanged(nameof(CurrentIncCookie));
    }

    #endregion コマンド
}