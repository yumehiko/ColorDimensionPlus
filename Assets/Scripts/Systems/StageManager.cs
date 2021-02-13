using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;

/// <summary>
/// ステージの状態を管理。
/// </summary>
public class StageManager : MonoBehaviour
{
    private GameManager gameManager = default;
    [SerializeField] private Canvas stageUICanvas = default;
    [SerializeField] private InputManager inputManager = default;
    [SerializeField] private AudioClip music = default;
    private bool isWon = false;

    private void Start()
    {
        LoadGameManager();
    }

    /// <summary>
    /// GameManagerを読み込む。
    /// </summary>
    private void LoadGameManager()
    {
        GameObject gameManagerObject = GameObject.Find("GameManager");
        
        gameManager = gameManagerObject.GetComponent<GameManager>();

        _ = GameObject.Find("PauseMenu").GetComponent<PauseMenu>().OnPause
            .Subscribe(isActive =>
            {
                SwitchActiveStageUI(!isActive);
            });

        GameObject musicJockeyObject = GameObject.Find("MusicJockey");
        if (musicJockeyObject != null)
        {
            musicJockeyObject.GetComponent<MusicJockey>().PlayMusic(music, 1.0f);
        }
    }

    /// <summary>
    /// ステージをクリアし、次のステージへ移る。
    /// </summary>
    public void WinStage()
    {
        if (isWon)
        {
            //勝利判定が2度起きないように
            return;
        }
        isWon = true;
        inputManager.LosePlayerControl();
        gameManager.LoadNextStage();
    }

    /// <summary>
    /// ステージをリスタート。
    /// </summary>
    public void RestartStage()
    {
        inputManager.LosePlayerControl();
        gameManager.ResetScene();
    }

    /// <summary>
    /// StageUIの表示を切り替える。
    /// </summary>
    public void SwitchActiveStageUI(bool doActive)
    {
        if(doActive)
        {
            stageUICanvas.enabled = true;
        }
        else
        {
            stageUICanvas.enabled = false;
        }
    }
}
