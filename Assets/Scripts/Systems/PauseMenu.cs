using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = default;
    [SerializeField] private Canvas pauseMenuCanvas = default;

    /// <summary>
    /// ポーズ時サブジェクト。
    /// </summary>
    private Subject<bool> pauseSubject = new Subject<bool>();

    /// <summary>
    /// ポーズ時イベント。
    /// </summary>
    public IObservable<bool> OnPause => pauseSubject;


    private void Update()
    {
        CheckPauseKeyInput();
    }

    /// <summary>
    /// ポーズ キーの入力を待機。
    /// </summary>
    private void CheckPauseKeyInput()
    {
        if(gameManager.isSceneSwapping)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(pauseMenuCanvas.enabled == false)
            {
                ActiveMenu();
            }
            else
            {
                InActiveMenu();
            }
        }
    }

    /// <summary>
    /// PauseMenuを起動。
    /// </summary>
    public void ActiveMenu()
    {
        Time.timeScale = 0.0f;
        pauseMenuCanvas.enabled = true;
        pauseSubject.OnNext(true);
    }

    /// <summary>
    /// PauseMenuを終了。
    /// </summary>
    public void InActiveMenu()
    {
        Time.timeScale = 1.0f;
        pauseMenuCanvas.enabled = false;
        pauseSubject.OnNext(false);
    }
}
