using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームで使用するキー種。
/// </summary>
public enum GameKey
{
    None,
    PauseMenu,
    MoveRight,
    MoveLeft,
}

/// <summary>
/// （非使用）
/// キー入力の解釈を管理する。
/// </summary>
public class KeyConfig : MonoBehaviour
{
    /// <summary>
    /// ポーズ。
    /// </summary>
    public KeyCode PauseMenu { get; private set; } = KeyCode.Tab;

    /// <summary>
    /// 右へ移動。
    /// </summary>
    public KeyCode MoveRight { get; private set; } = KeyCode.D;

    /// <summary>
    /// 左へ移動。
    /// </summary>
    public KeyCode MoveLeft { get; private set; } = KeyCode.A;
}
