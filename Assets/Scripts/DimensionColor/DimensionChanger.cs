using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージに設置された機械。
/// 起動したプレイヤーの次元を変換する。
/// </summary>
public class DimensionChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer targetMark = default;
    [SerializeField] private DimensionColor targetColor = default;
    [SerializeField] private LocalGravityDirection targetDirection = default;

    private Player currentPlayer = null;

    private void Update()
    {
        CheckInteract();
    }

    /// <summary>
    /// インタラクトチェック。
    /// </summary>
    private void CheckInteract()
    {
        if (Input.GetKeyDown(KeyCode.F) == false)
        {
            return;
        }


        if (currentPlayer != null && currentPlayer.IsControlActive)
        {
            DimensionChange(currentPlayer);
        }
    }

    [ContextMenu("SetTarget")]
    public void SetTarget()
    {
        targetMark.color = ColorSwitch.DimensionPalette[(int)targetColor];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            currentPlayer = collision.GetComponent<Player>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentPlayer = null;
        }
    }

    /// <summary>
    /// 対象の次元色を変更する。
    /// </summary>
    private void DimensionChange(Player player)
    {
        player.GetComponent<ColorSwitch>().SetDimensionColor(targetColor);
        player.GetComponent<LocalGravity>().SetGravityDirection(targetDirection);
    }
}
