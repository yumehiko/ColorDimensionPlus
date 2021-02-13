using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 命令を受けると移動するゾーン。
/// （不使用）
/// </summary>
public class MoveZone : MonoBehaviour
{
    //[System.NonSerialized] public float duration = 1.0f;
    [SerializeField] private Vector2 targetPoint = default;
    private Vector2 startPoint = default;

    private void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        startPoint = transform.localPosition;
    }

    /// <summary>
    /// 目標点へ移動する。
    /// </summary>
    public virtual void MoveWallOn()
    {
        transform.localPosition = targetPoint;
    }

    /// <summary>
    /// 初期位置へ戻る。
    /// </summary>
    public virtual void MoveWallOff()
    {
        transform.localPosition = startPoint;
    }
}
