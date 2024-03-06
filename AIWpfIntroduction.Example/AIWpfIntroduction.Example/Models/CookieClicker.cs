namespace AIWpfIntroduction.Example.Models;

internal class CookieClicker
{
    #region 公開プロパティ

    /// <summary>
    /// 現在値を取得します。
    /// </summary>
    public double CurrentCookie { get; private set; }

    /// <summary>
    /// 現在の増加量を取得します。
    /// </summary>
    public double CurrentIncCookie { get; private set; } = 1;

    /// <summary>
    /// 加算増加量を取得します。
    /// </summary>
    public double AddIncCookie { get; private set; } = 1;

    /// <summary>
    /// 倍率増加量を取得します。
    /// </summary>
    public double MultiIncCookie { get; private set; } = 1;

    /// <summary>
    /// 毎秒増加量を取得します。
    /// </summary>
    public double SecIncCookie { get; private set; } = 1;

    /// <summary>
    /// 利息増加量を取得します。
    /// </summary>
    public double IntIncCookie { get; private set; } = 1;

    /// <summary>
    /// 加算コストを取得します。
    /// </summary>
    public double CostAdd { get; private set; } = 10;

    /// <summary>
    /// 倍率コストを取得します。
    /// </summary>
    public double CostMul { get; private set; } = 20;

    /// <summary>
    /// 毎秒コストを取得します。
    /// </summary>
    public double CostSec { get; private set; } = 30;

    /// <summary>
    /// 利息率コストを取得します。
    /// </summary>
    public double CostInt { get; private set; } = 100;

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
        MultiIncCookie += 0.5;
        CurrentCookie -= CostMul;
        CostMul *= 10;
        UpdateCurrentIncCookie();
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

    #endregion 非公開メソッド
}
