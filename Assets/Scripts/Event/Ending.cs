using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// エンディング用イベント。
/// </summary>
public class Ending : MonoBehaviour
{
    [SerializeField] private Camera mainCamera = default;
    [SerializeField] private Player player = default;
    [SerializeField] private CharaControl charaControl = default;
    [SerializeField] private InputManager inputManager = default;
    [SerializeField] private Animator animator = default;
    [SerializeField] private GameManager gameManager = default;
    private bool isEndingStart = false;


    private void Update()
    {
        if(isEndingStart == false)
        {
            return;
        }

        CameraChase();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EndingStart();
        }
    }

    /// <summary>
    /// エンディング開始。
    /// </summary>
    private void EndingStart()
    {
        Debug.Log("EndingStart");
        isEndingStart = true;
        inputManager.enabled = false;
        charaControl.InputHorizontal = 1.0f;
        animator.SetTrigger("StartEnding");
    }

    /// <summary>
    /// カメラがプレイヤーを追従。
    /// </summary>
    private void CameraChase()
    {
        mainCamera.transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            mainCamera.transform.position.z);
    }

    /// <summary>
    /// クレジット表記を終える。
    /// </summary>
    public void CreditsEnd()
    {
        charaControl.Brake();

        DOVirtual.DelayedCall(4.0f, () => EndEnding());
    }

    /// <summary>
    /// エンディングを終え、1面に戻る。
    /// </summary>
    private void EndEnding()
    {
        gameManager.LoadScene(1);
    }
}
