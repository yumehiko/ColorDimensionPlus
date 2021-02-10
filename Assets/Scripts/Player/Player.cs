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
    [SerializeField] private SoundEffect soundEffect = default;
    [SerializeField] private ColorSwitch colorSwitch = default;

    /// <summary>
    /// このキャラの操作を取得する。
    /// </summary>
    public CharaControl GetControl(bool playSound)
    {
        targetIcon.enabled = true;
        if (playSound)
        {
            soundEffect.PlaySoundRandomPitch(1.0f, 0.8f, 1.2f);
        }
        return GetComponent<CharaControl>();
    }

    public void LoseControl()
    {
        targetIcon.enabled = false;
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
