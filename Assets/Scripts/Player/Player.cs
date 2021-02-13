using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;

/// <summary>
/// ゲーム上のプレイヤーの状態を管理。
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer targetIcon = default;
    [SerializeField] private Animator iconAnimator = default;
    [SerializeField] private SoundEffect soundEffect = default;
    [SerializeField] private ColorSwitch colorSwitch = default;

    /// <summary>
    /// 現在操作対象になっているか。
    /// </summary>
    public bool IsControlActive { get; private set; } = false;

    /// <summary>
    /// このキャラの操作を取得する。
    /// </summary>
    public CharaControl GetControl(bool playSound)
    {
        targetIcon.enabled = true;
        iconAnimator.enabled = true;
        iconAnimator.Play("Start");
        IsControlActive = true;
        if (playSound)
        {
            soundEffect.PlaySoundRandomPitch(1.0f, 0.8f, 1.2f);
        }
        return GetComponent<CharaControl>();
    }

    /// <summary>
    /// このキャラの操作を放棄。
    /// </summary>
    public void LoseControl()
    {
        targetIcon.enabled = false;
        iconAnimator.enabled = false;
        IsControlActive = false;
    }
    
    /// <summary>
    /// このプレイヤーの次元色を変える。
    /// </summary>
    /// <param name="newColor"></param>
    public void ChangeColor(DimensionColor newColor)
    {
        colorSwitch.SetDimensionColor(newColor);
    }
}
