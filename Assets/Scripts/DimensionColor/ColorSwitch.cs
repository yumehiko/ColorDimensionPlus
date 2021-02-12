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
        new Color(0.94f,0.94f,0.94f), //White
        new Color(0.7490196f, 0.1333333f, 0.2392157f), //Red
        new Color(0.12f,0.12f,0.12f), //Black
        new Color(0.1333333f, 0.7490196f, 0.6431373f), // Blue
        new Color(0.9215686f, 0.7372549f, 0.3686275f), //Yellow
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
