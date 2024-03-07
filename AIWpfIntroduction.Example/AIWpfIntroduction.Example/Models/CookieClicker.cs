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
    /// <param name="calculator">計算機能を提供します。</param>
    public CookieClicker(ICookieClickerCalculator calculator)
    {
        ProductCookieAsync();
        _calculator = calculator;
    }


    #region フィールド

    /// <summary>
    /// 計算機能を提供します。
    /// </summary>
    private ICookieClickerCalculator _calculator;

    /// <summary>
    /// 非同期タスク制御機能です。
    /// </summary>
    private CancellationTokenSource _cancellationTokenSource = new ();

    #endregion フィールド

    #region 公開プロパティ

    /// <summary>
    /// 現在値を取得します。
    /// </summary>
    public int CurrentCookie { get { return _calculator.CurrentCookie; } }

    /// <summary>
    /// 現在の増加量を取得します。
    /// </summary>
    public int CurrentIncCookie { get { return _calculator.CurrentIncCookie; } }

    /// <summary>
    /// 現在の生産量を取得します。
    /// </summary>
    public int CurrentProductCookie { get { return _calculator.CurrentProductCookie; } }

    /// <summary>
    /// 加算増加量を取得します。
    /// </summary>
    public int AddIncCookie { get { return _calculator.AddIncCookie; } }

    /// <summary>
    /// 倍率増加量を取得します。
    /// </summary>
    public int MultiIncCookie { get { return _calculator.MultiIncCookie; } }

    /// <summary>
    /// 毎秒増加量を取得します。
    /// </summary>
    public int SecIncCookie { get { return _calculator.SecIncCookie; } }

    /// <summary>
    /// 毎秒増加量を取得します。
    /// </summary>
    public int IntIncCookie { get { return _calculator.IntIncCookie; } }

    /// <summary>
    /// 加算コストを取得します。
    /// </summary>
    public int CostAdd { get { return _calculator.CostAdd; } }

    /// <summary>
    /// 倍率コストを取得します。
    /// </summary>
    public int CostMul { get { return _calculator.CostMul; } }

    /// <summary>
    /// 毎秒コストを取得します。
    /// </summary>
    public int CostSec { get { return _calculator.CostSec; } }

    /// <summary>
    /// 毎秒倍率コストを取得します。
    /// </summary>
    public int CostInt { get { return _calculator.CostInt; } }

    #endregion 公開プロパティ

    #region 公開メソッド

    /// <summary>
    /// 現在値を更新します。
    /// </summary>
    public void UpdateCurrentCookie()
    {
        _calculator.UpdateCurrentCookie();
        RaiseCurrentCookieChanged();
    }

    /// <summary>
    /// 増加量を更新します。
    /// </summary>
    public void UpgradeAddIncCookie()
    {
        _calculator.UpgradeAddIncCookie();
    }

    /// <summary>
    /// 倍率を更新します。
    /// </summary>
    public void UpgradeMultiIncCookie()
    {
        _calculator.UpgradeMultiIncCookie();
    }

    /// <summary>
    /// 毎秒増加量を更新します。
    /// </summary>
    public void UpgradeSecIncCookie()
    {
        _calculator.UpgradeSecIncCookie();
    }

    /// <summary>
    /// 毎秒増加率を更新します。
    /// </summary>
    public void UpgradeIntProductCookie()
    {
        _calculator.UpgradeIntProductCookie();
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
                    _calculator.UpdateCurrentCookieProduct();
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
