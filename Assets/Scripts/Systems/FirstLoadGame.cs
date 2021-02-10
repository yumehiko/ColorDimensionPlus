using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLoadGame : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(StartGame), 0.2f);
    }

    /// <summary>
    /// ゲームを開始。
    /// </summary>
    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
