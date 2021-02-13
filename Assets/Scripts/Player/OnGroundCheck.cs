using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 接地判定。
/// </summary>
public class OnGroundCheck : MonoBehaviour
{
    [SerializeField] private Animator animator = default;
    private readonly string aKeyInTheAir = "InTheAir";

    [SerializeField] private int touchingObjects = 0;

    public bool OnGround { get; private set; } = false;

    private Tween getOffGroundTweener = default;

    /// <summary>
    /// 地面から離れた判定の猶予時間。
    /// </summary>
    private readonly float coyoteTime = 0.15f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        touchingObjects++;
        OnGround = true;
        animator.SetBool(aKeyInTheAir, false);
        getOffGroundTweener.Kill();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touchingObjects--;
        if (touchingObjects <= 0)
        {
            touchingObjects = 0;
            getOffGroundTweener = DOVirtual.DelayedCall(coyoteTime, () => GetOffGround());
        }
    }

    /// <summary>
    /// 地面から離れる。
    /// </summary>
    public void GetOffGround()
    {
        OnGround = false;
        animator.SetBool(aKeyInTheAir, true);
    }
}
