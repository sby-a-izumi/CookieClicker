using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIWpfIntroduction.Example.Models;

/// <summary>
/// クッキークリッカー機能を提供します。
/// </summary>
internal class CookieClicker : IDisposable
{
    /// <summary>
    /// 新しいインスタンスを生成します。
    /// </summary>
    public CookieClicker()
    {
        ProductCookieAsync();
    }

    #region フィールド

    /// <summary>
    /// 非同期タスク制御機能です。
    /// </summary>
    private CancellationTokenSource _cancellationTokenSource = new ();

    #endregion フィールド

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
        RaiseCurrentCookieChanged();
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
    /// 毎秒生産します。
    /// </summary>
    private void ProductCookieAsync()
    {
        // このメソッド自体を async にするとコンストラクタで呼び出せない
        Task.Run(async () =>
        {
            try
            {
                while (_cancellationTokenSource.Token.IsCancellationRequested is false)
                {
                    CurrentCookie += CurrentProductCookie;
                    RaiseCurrentCookieChanged();
                    await Task.Delay(1000);
                }
            }
            catch (Exception)
            {
                // 例外処理
            }
            finally
            {
                _cancellationTokenSource.Dispose();
            }
        }, _cancellationTokenSource.Token);
    }

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

    #region イベント

    /// <summary>
    /// 現在値が変更されたときに発生するイベントです。
    /// </summary>
    public event EventHandler? CurrentCookieChanged;

    /// <summary>
    /// CurrentCookieChanged イベントを発行します。
    /// </summary>
    private void RaiseCurrentCookieChanged()
    {
        App.Current.Dispatcher.BeginInvoke(() => CurrentCookieChanged?.Invoke(this, EventArgs.Empty));
    }

    #endregion イベント

    #region IDispose

    /// <summary>
    /// リソースを解放します。
    /// </summary>
    public void Dispose()
    {
        _cancellationTokenSource.Dispose();
    }

    #endregion IDispose
}
