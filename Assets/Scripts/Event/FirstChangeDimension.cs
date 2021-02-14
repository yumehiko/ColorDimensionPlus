using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初めて次元色変換器に触れた時のイベント。
/// </summary>
public class FirstChangeDimension : DimensionChanger
{
    [SerializeField] private AudioClip music = default;

    private void Update()
    {
        CheckInteract();
    }

    /// <summary>
    /// インタラクトチェック。
    /// </summary>
    protected override void CheckInteract()
    {
        if (Input.GetKeyDown(KeyCode.F) == false)
        {
            return;
        }

        if (currentPlayer != null && currentPlayer.IsControlActive)
        {
            DimensionChange(currentPlayer);
            GameObject.Find("MusicJockey").GetComponent<MusicJockey>().PlayMusic(music, 1.0f);
        }
    }
}
