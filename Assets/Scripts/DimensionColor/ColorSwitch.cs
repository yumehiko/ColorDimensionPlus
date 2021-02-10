using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

/// <summary>
/// 次元色。
/// </summary>
public enum DimensionColor
{
    White,
    Red,
    Black,
    Blue,
    Yellow,
}

/// <summary>
/// 対象の次元色を変更する。
/// </summary>
public class ColorSwitch : MonoBehaviour
{
    [SerializeField] private DimensionColor dimensionColor = default;

    [SerializeField] private List<GameObject> changeLayerObjects = default;
    [SerializeField] private List<SpriteRenderer> changeSprites = default;

    /// <summary>
    /// 次元色のパレット。DimensionColorのIndexでピックする。
    /// </summary>
    public static readonly Color[] DimensionPalette = new Color[5]
    {
        Color.white,
        new Color(0.8f,0.16f,0.2666669f),
        new Color(0.1f,0.1f,0.1f),
        new Color(0.1607843f,0.8f,0.693464f),
        new Color(0.8f,0.5866667f,0.16f),
    };

    /// <summary>
    /// 設定した次元色を適用する。
    /// </summary>
    [ContextMenu("SetDimensionColor")]
    public void ChangeDimensionColor()
    {
        Debug.Log("SetColor");
        for(int i = 0; i < changeLayerObjects.Count; i++)
        {
            changeLayerObjects[i].layer = 8 + (int)dimensionColor;
        }

        for(int i = 0; i < changeSprites.Count; i++)
        {
            changeSprites[i].color = DimensionPalette[(int)dimensionColor];
        }
    }

    /// <summary>
    /// 次元色を設定し、適用する。
    /// </summary>
    public void SetDimensionColor(DimensionColor newColor)
    {
        dimensionColor = newColor;
        ChangeDimensionColor();
    }
}
