using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// BGMを再生、遷移する。
/// </summary>
public class MusicJockey : MonoBehaviour
{
    /// <summary>
    /// BGMのオーディオソース。
    /// </summary>
    [SerializeField] private AudioSource bgmMainSource = default;
    /// <summary>
    /// BGMのクロスフェード用ソース。
    /// </summary>
    [SerializeField] private AudioSource bgmFadeSource = default;

    /// <summary>
    /// クロスフェード実行中のTweener。
    /// </summary>
    private Tweener currentTween = default;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// 指定したClipを再生する。
    /// </summary>
    /// <param name="musicClip"></param>
    /// <param name="duration"></param>
    public void PlayMusic(AudioClip musicClip, float fadeDuration)
    {
        if(bgmMainSource.clip == null)
        {
            InstantSwap(musicClip);
            return;
        }

        if ((currentTween != null) && currentTween.IsActive())
        {
            InstantSwap(musicClip);
            return;
        }

        if (bgmMainSource.clip == musicClip)
        {
            return;
        }

        bgmFadeSource.clip = musicClip;
        bgmFadeSource.Play();
        CrossFade(fadeDuration);
    }

    /// <summary>
    /// ふたつのBGMをクロスフェードで切り替える。
    /// </summary>
    /// <param name="duration"></param>
    private void CrossFade(float duration)
    {
        bgmFadeSource.volume = 0.0f;
        currentTween = bgmFadeSource.DOFade(1.0f, duration)
            .OnComplete(() => SwapSource());

        _ = bgmMainSource.DOFade(0.0f, duration);
    }

    /// <summary>
    /// BGM用のソースを主客転倒する。
    /// </summary>
    private void SwapSource()
    {
        AudioSource tempSource = bgmFadeSource;
        bgmFadeSource = bgmMainSource;
        bgmMainSource = tempSource;
        bgmFadeSource.Stop();
    }

    /// <summary>
    /// BGM即時切り替え。
    /// </summary>
    /// <param name="musicClip"></param>
    private void InstantSwap(AudioClip musicClip)
    {
        currentTween.Kill(true);

        bgmMainSource.volume = 1.0f;
        bgmMainSource.clip = musicClip;
        bgmMainSource.Play();
        bgmFadeSource.volume = 0.0f;
        bgmFadeSource.Stop();
    }
}