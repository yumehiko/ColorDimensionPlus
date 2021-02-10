using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

/// <summary>
/// 命令を受けると色を変えるゾーン。
/// </summary>
public class SwapZone : MoveZone
{
    private SpriteShapeRenderer spriteShapeRenderer = default;
    [SerializeField] private DimensionColor initColor = default;
    [SerializeField] private DimensionColor targetColor = default;

    protected override void Initialize()
    {
        
    }

    public override void MoveWallOn()
    {
        ChangeDimensionColor(targetColor);
    }

    public override void MoveWallOff()
    {
        ChangeDimensionColor(initColor);
    }

    /// <summary>
    /// 次元色を設定する。
    /// </summary>
    /// <param name="newColor"></param>
    [ContextMenu("SetDimensionColor")]
    public void SetDimensionColor()
    {
        ChangeDimensionColor(initColor);
    }

    /// <summary>
    /// 次元色を指定した色に設定する。
    /// </summary>
    /// <param name="newColor"></param>
    private void ChangeDimensionColor(DimensionColor newColor)
    {
        gameObject.layer = 8 + (int)newColor;
        spriteShapeRenderer = GetComponent<SpriteShapeRenderer>();
        spriteShapeRenderer.color = ColorSwitch.DimensionPalette[(int)newColor];
    }
}
