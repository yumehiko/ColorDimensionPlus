using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

/// <summary>
/// ゲームの状態を管理。
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private ScreenFade screenFade = default;

    private void Start()
    {
        screenFade.ScreenFadeIn(0.5f);
    }

    /// <summary>
    /// シーンを再読み込み。
    /// </summary>
    public void ResetScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// 次のbuild番号のシーンを呼び出す。
    /// </summary>
    public void LoadNextStage()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// 指定したBuild IDのシーンをロードする。
    /// </summary>
    public void LoadScene(int index)
    {
        screenFade.ScreenFadeOut(0.5f);
        DOVirtual.DelayedCall(0.5f, () => SceneManager.LoadSceneAsync(index));
    }
}
