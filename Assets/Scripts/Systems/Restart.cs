using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// ステージをリスタートする。
/// </summary>
public class Restart : MonoBehaviour
{
    [SerializeField] private Image fill = default;
    private Tweener currentFilling = default;
    private bool restarting = false;

    private void Update()
    {
        if(restarting)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartFilling();
        }
        else if(Input.GetKeyUp(KeyCode.R))
        {
            RestartEmptying();
        }
    }

    /// <summary>
    /// リスタートゲージを貯める。
    /// </summary>
    private void RestartFilling()
    {
        currentFilling.Kill();
        currentFilling = DOTween.To(() => fill.fillAmount,
             num => fill.fillAmount = num,
             endValue: 1.0f,
             duration: 1.0f - fill.fillAmount
        ).OnComplete(() => CompleteFill());
    }

    /// <summary>
    /// リスタートゲージを空にする。
    /// </summary>
    private void RestartEmptying()
    {
        currentFilling.Kill();
        currentFilling = DOTween.To(() => fill.fillAmount,
             num => fill.fillAmount = num,
             endValue: 0.0f,
             duration: fill.fillAmount
        );
    }

    /// <summary>
    /// リスタートゲージが最大まで貯まった。
    /// </summary>
    private void CompleteFill()
    {
        restarting = true;
        GetComponent<StageManager>().RestartStage();
    }
}
