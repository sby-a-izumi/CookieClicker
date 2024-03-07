namespace AIWpfIntroduction.Example.Models;

/// <summary>
/// クッキークリッカーの計算機能を提供します。
/// </summary>
internal interface ICookieClickerCalculator
{
    /// <summary>
    /// 現在値を取得します。
    /// </summary>
    public int CurrentCookie { get; }

    /// <summary>
    /// 現在の増加量を取得します。
    /// </summary>
    public int CurrentIncCookie { get; }

    /// <summary>
    /// 現在の生産量を取得します。
    /// </summary>
    public int CurrentProductCookie { get; }

    /// <summary>
    /// 加算増加量を取得します。
    /// </summary>
    public int AddIncCookie { get; }

    /// <summary>
    /// 倍率増加量を取得します。
    /// </summary>
    public int MultiIncCookie { get; }

    /// <summary>
    /// 毎秒増加量を取得します。
    /// </summary>
    public int SecIncCookie { get; }

    /// <summary>
    /// 毎秒増加量を取得します。
    /// </summary>
    public int IntIncCookie { get; }

    /// <summary>
    /// 加算コストを取得します。
    /// </summary>
    public int CostAdd { get; }

    /// <summary>
    /// 倍率コストを取得します。
    /// </summary>
    public int CostMul { get; }

    /// <summary>
    /// 毎秒コストを取得します。
    /// </summary>
    public int CostSec { get; }

    /// <summary>
    /// 毎秒倍率コストを取得します。
    /// </summary>
    public int CostInt { get; }

    /// <summary>
    /// 現在値を更新します。
    /// </summary>
    public void UpdateCurrentCookie();

    /// <summary>
    /// 生産量に応じて現在値を更新します。
    /// </summary>
    public void UpdateCurrentCookieProduct();

    /// <summary>
    /// 増加量を更新します。
    /// </summary>
    public void UpgradeAddIncCookie();

    /// <summary>
    /// 倍率を更新します。
    /// </summary>
    public void UpgradeMultiIncCookie();

    /// <summary>
    /// 毎秒増加量を更新します。
    /// </summary>
    public void UpgradeSecIncCookie();

    /// <summary>
    /// 毎秒増加率を更新します。
    /// </summary>
    public void UpgradeIntProductCookie();
}
