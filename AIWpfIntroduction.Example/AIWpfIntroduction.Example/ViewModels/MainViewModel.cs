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
        UpgradeAddValueCommand = new DelegateCommand(_ => UpgradeAddValue(), _ => CanUpgradeAddValue());
        UpgradeMultiValueCommand = new DelegateCommand(_ => UpgradeMultiValue(), _ => CanUpgradeMultiValue());
        UpgradeSecValueCommand = new DelegateCommand(_ => UpgradeSecValue(), _ => CanUpgradeSecValue());
        UpgradeIntValueCommand = new DelegateCommand(_ => UpgradeIntValue(), _ => CanUpgradeIntValue());
        _cookieClicker.CurrentCookieChanged += (s, e) =>
        {
            RaiseAllPropertyChanged();
            RaiseCanExcuteChanged();
        };
    }

    #region フィールド

    /// <summary>
    /// CookkieClicker 機能を提供します。
    /// </summary>
    private CookieClicker _cookieClicker = new (new NormalCookieClickerCalculator());

    #endregion フィールド

    #region 公開プロパティ

    /// <summary>
    /// 現在値を取得します。
    /// </summary>
    public int CurrentCookie { get { return _cookieClicker.CurrentCookie; } }

    /// <summary>
    /// 現在の増加量を取得します。
    /// </summary>
    public int CurrentIncCookie { get { return _cookieClicker.CurrentIncCookie; } }

    /// <summary>
    /// 現在の生産量を取得します。
    /// </summary>
    public int CurrentProductCookie { get { return _cookieClicker.CurrentProductCookie; } }

    /// <summary>
    /// 加算増加量を取得します。
    /// </summary>
    public int AddIncCookie { get { return _cookieClicker.AddIncCookie; } }

    /// <summary>
    /// 増加量倍率を取得します。
    /// </summary>
    public int MultiIncCookie { get { return _cookieClicker.MultiIncCookie; } }

    /// <summary>
    /// 毎秒増加量を取得します。
    /// </summary>
    public int SecIncCookie { get { return _cookieClicker.SecIncCookie; } }

    /// <summary>
    /// 毎秒倍率を取得します。
    /// </summary>
    public int IntIncCookie { get { return _cookieClicker.IntIncCookie; } }

    /// <summary>
    /// 加算コストを取得します。
    /// </summary>
    public int CostAdd { get { return _cookieClicker.CostAdd; } }

    /// <summary>
    /// 倍率コストを取得します。
    /// </summary>
    public int CostMul { get { return _cookieClicker.CostMul; } }

    /// <summary>
    /// 毎秒コストを取得します。
    /// </summary>
    public int CostSec { get { return _cookieClicker.CostSec; } }

    /// <summary>
    /// 毎秒倍率コストを取得します。
    /// </summary>
    public int CostInt { get { return _cookieClicker.CostInt; } }

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
        RaiseAllPropertyChanged();
        RaiseCanExcuteChanged();
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
        RaiseAllPropertyChanged();
        RaiseCanExcuteChanged();
    }

    /// <summary>
    /// 増加値加算ボタンの実行可否を返します。
    /// </summary>
    /// <returns>実行可否を返します。</returns>
    private bool CanUpgradeAddValue()
    {
        return _cookieClicker.CurrentCookie > _cookieClicker.CostAdd;
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
        RaiseAllPropertyChanged();
        RaiseCanExcuteChanged();
    }

    /// <summary>
    /// 倍率増加ボタンの実行可否を返します。
    /// </summary>
    /// <returns>実行可否を返します。</returns>
    private bool CanUpgradeMultiValue()
    {
        return _cookieClicker.CurrentCookie > _cookieClicker.CostMul;
    }

    /// <summary>
    /// 毎秒増加ボタンを押された際のコマンドを取得します。
    /// </summary>
    public DelegateCommand UpgradeSecValueCommand { get; init; }

    /// <summary>
    /// 毎秒増加量を増加させます。
    /// </summary>
    private void UpgradeSecValue()
    {
        _cookieClicker.UpgradeSecIncCookie();
        RaiseAllPropertyChanged();
        RaiseCanExcuteChanged();
    }

    /// <summary>
    /// 毎秒増加ボタンの実行可否を返します。
    /// </summary>
    /// <returns>実行可否を返します。</returns>
    private bool CanUpgradeSecValue()
    {
        return _cookieClicker.CurrentCookie > _cookieClicker.CostSec;
    }

    /// <summary>
    /// 毎秒倍率増加ボタンを押された際のコマンドを取得します。
    /// </summary>
    public DelegateCommand UpgradeIntValueCommand { get; init; }

    /// <summary>
    /// 毎秒倍率を増加させます。
    /// </summary>
    private void UpgradeIntValue()
    {
        _cookieClicker.UpgradeIntProductCookie();
        RaiseAllPropertyChanged();
        RaiseCanExcuteChanged();
    }

    /// <summary>
    /// 毎秒倍率増加ボタンの実行可否を返します。
    /// </summary>
    /// <returns>実行可否を返します。</returns>
    private bool CanUpgradeIntValue()
    {
        return _cookieClicker.CurrentCookie > _cookieClicker.CostInt;
    }

    #endregion コマンド

    #region 非公開メソッド

    /// <summary>
    /// コマンドの実行可否の変更を通知します。
    /// </summary>
    private void RaiseCanExcuteChanged()
    {
        UpgradeAddValueCommand.RaiseCanExecuteChanged();
        UpgradeMultiValueCommand.RaiseCanExecuteChanged();
        UpgradeSecValueCommand.RaiseCanExecuteChanged();
        UpgradeIntValueCommand.RaiseCanExecuteChanged();
    }

    #endregion 非公開メソッド
}