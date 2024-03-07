using System.Reflection.Metadata;

namespace AIWpfIntroduction.Example.Models;

internal class NormalCookieClickerCalculator : ICookieClickerCalculator
{
    #region 公開プロパティ

    /// <summary>
    /// 現在値を取得します。
    /// </summary>
    public int CurrentCookie { get; private set; }

    /// <summary>
    /// 現在の増加量を取得します。
    /// </summary>
    public int CurrentIncCookie { get; private set; } = 1;

    /// <summary>
    /// 現在の生産量を取得します。
    /// </summary>
    public int CurrentProductCookie { get; private set; } = 1;

    /// <summary>
    /// 加算増加量を取得します。
    /// </summary>
    public int AddIncCookie { get; private set; } = 1;

    /// <summary>
    /// 倍率増加量を取得します。
    /// </summary>
    public int MultiIncCookie { get; private set; } = 1;

    /// <summary>
    /// 毎秒増加量を取得します。
    /// </summary>
    public int SecIncCookie { get; private set; } = 1;

    /// <summary>
    /// 毎秒増加量を取得します。
    /// </summary>
    public int IntIncCookie { get; private set; } = 1;

    /// <summary>
    /// 加算コストを取得します。
    /// </summary>
    public int CostAdd { get; private set; } = 10;

    /// <summary>
    /// 倍率コストを取得します。
    /// </summary>
    public int CostMul { get; private set; } = 20;

    /// <summary>
    /// 毎秒コストを取得します。
    /// </summary>
    public int CostSec { get; private set; } = 30;

    /// <summary>
    /// 毎秒倍率コストを取得します。
    /// </summary>
    public int CostInt { get; private set; } = 100;

    #endregion 公開プロパティ

    #region 公開メソッド

    /// <summary>
    /// 現在値を更新します。
    /// </summary>
    public void UpdateCurrentCookie()
    {
        CurrentCookie += CurrentIncCookie;
    }

    /// <summary>
    /// 生産量に応じて現在値を更新します。
    /// </summary>
    public void UpdateCurrentCookieProduct()
    {
        CurrentCookie += CurrentProductCookie;
    }

    /// <summary>
    /// 増加量を更新します。
    /// </summary>
    public void UpgradeAddIncCookie()
    {
        AddIncCookie++;
        CurrentCookie -= CostAdd;
        CostAdd += 50;
        UpdateCurrentIncCookie();
    }

    /// <summary>
    /// 倍率を更新します。
    /// </summary>
    public void UpgradeMultiIncCookie()
    {
        MultiIncCookie++;
        CurrentCookie -= CostMul;
        CostMul *= 10;
        UpdateCurrentIncCookie();
    }

    /// <summary>
    /// 毎秒増加量を更新します。
    /// </summary>
    public void UpgradeSecIncCookie()
    {
        SecIncCookie++;
        CurrentCookie -= CostSec;
        CostSec += 100;
        UpdateCurrentProductCookie();
    }

    /// <summary>
    /// 毎秒増加率を更新します。
    /// </summary>
    public void UpgradeIntProductCookie()
    {
        IntIncCookie++;
        CurrentCookie -= CostInt;
        CostInt *= 10;
        UpdateCurrentProductCookie();
    }

    #endregion 公開メソッド

    #region 非公開メソッド

    /// <summary>
    /// 増加量を更新します。
    /// </summary>
    private void UpdateCurrentIncCookie()
    {
        CurrentIncCookie = AddIncCookie * MultiIncCookie;
    }

    /// <summary>
    /// 生産量を更新します。
    /// </summary>
    private void UpdateCurrentProductCookie()
    {
        CurrentProductCookie = SecIncCookie * IntIncCookie;
    }

    #endregion 非公開メソッド
}
