using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 接地判定。
/// </summary>
public class OnGroundCheck : MonoBehaviour
{
    [SerializeField] private Player player = default;
    [SerializeField] private LocalGravity localGravity = default;
    [SerializeField] private Animator animator = default;
    private readonly string aKeyInTheAir = "InTheAir";

    [SerializeField] private int touchingObjects = 0;

    public bool OnGround { get; private set; } = false;

    private Tween coyoteTimeTween = default;
    private Tween tomTimeTween = default;

    /// <summary>
    /// 地面から離れた判定の猶予時間。
    /// </summary>
    private readonly float coyoteTime = 0.15f;

    /// <summary>
    /// 地面が突然なくなったときの、重力が反映されるまでの猶予時間。
    /// </summary>
    private readonly float tomTime = 0.65f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        touchingObjects++;
        OnGround = true;
        animator.SetBool(aKeyInTheAir, false);
        coyoteTimeTween.Kill();
        tomTimeTween.Kill(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touchingObjects--;
        if (touchingObjects <= 0)
        {
            touchingObjects = 0;

            //操作対象なら、コヨーテタイム。
            if (player.IsControlActive)
            {
                CoyoteTime();
            }
            //操作対象でないなら、トムタイム。
            else
            {
                TomTime();
                GetOffGround();
            }
        }
    }

    /// <summary>
    /// プレイヤーがコントロールを得たとき。
    /// </summary>
    public void OnGetControl()
    {
        tomTimeTween.Complete();
        localGravity.ReturnGravity();
    }

    /// <summary>
    /// 地面が突然なくなったとき、重力をいったん消す。
    /// </summary>
    private void TomTime()
    {
        animator.Play("TomTime");
        localGravity.ZeroGravity();
        //指定時間後に重力を戻す。
        tomTimeTween = DOVirtual.DelayedCall(tomTime, () => localGravity.ReturnGravity());
    }

    /// <summary>
    /// 地面から離れた判定をほんの少しだけ遅らせ、ジャンプの猶予を与える。
    /// </summary>
    private void CoyoteTime()
    {
        coyoteTimeTween = DOVirtual.DelayedCall(coyoteTime, () => GetOffGround());
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
