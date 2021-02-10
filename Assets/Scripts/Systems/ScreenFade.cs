using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 画面全体をフェードアウト・フェードインする。
/// </summary>
public class ScreenFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadePanel = default;
    /// <summary>
    /// 画面全体をフェードアウト（暗く）する。
    /// </summary>
    public void ScreenFadeOut(float duration)
    {
        fadePanel.DOFade(1.0f, duration);
    }

    public void ScreenFadeIn(float duration)
    {
        fadePanel.alpha = 1.0f;
        fadePanel.DOFade(0.0f, duration);
    }
}
