using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初めて次元色変換器に触れた時のイベント。
/// </summary>
public class FirstChangeDimension : MonoBehaviour
{
    [SerializeField] private AudioClip music = default;
    [SerializeField] private SpriteRenderer targetMark = default;
    [SerializeField] private DimensionColor targetColor = default;
    [SerializeField] private LocalGravityDirection targetDirection = default;
    private bool isDone = false;

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
        if(isDone)
        {
            return;
        }
        if (currentPlayer == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            DimensionChange(currentPlayer);
            GameObject.Find("MusicJockey").GetComponent<MusicJockey>().PlayMusic(music, 1.0f);
            isDone = true;
        }
    }

    [ContextMenu("SetTarget")]
    public void SetTarget()
    {
        targetMark.color = ColorSwitch.DimensionPalette[(int)targetColor];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
