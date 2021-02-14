using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

/// <summary>
/// エンディング用イベント。
/// </summary>
public class Ending : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCamera = default;
//    [SerializeField] private Player player = default;
    [SerializeField] private CharaControl charaControl = default;
    [SerializeField] private InputManager inputManager = default;
    [SerializeField] private Animator animator = default;
    [SerializeField] private SpriteRenderer targetIcon = default;
    [SerializeField] private Animator iconAnimator = default;
    [SerializeField] private GameManager gameManager = default;



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
        SetVirtualCamera();
        ForceControl();
        animator.SetTrigger("StartEnding");
    }

    /// <summary>
    /// 操作を禁止して右移動に固定。
    /// </summary>
    private void ForceControl()
    {
        inputManager.enabled = false;
        targetIcon.enabled = false;
        iconAnimator.enabled = false;
        charaControl.InputHorizontal = 1.0f;
    }


    /// <summary>
    /// カメラがプレイヤーを追従。
    /// </summary>
    private void SetVirtualCamera()
    {
        vCamera.Priority = 30;
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
