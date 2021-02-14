using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LocalGravityDirection
{
    Down,
    Top,
    Left,
    Right,
}

/// <summary>
/// 重力をキャラそれぞれに設定する。
/// </summary>
public class LocalGravity : MonoBehaviour
{
    

    [SerializeField] private Rigidbody2D myBody = default;
    [SerializeField] private LocalGravityDirection gravityDirection = LocalGravityDirection.Down;
    public LocalGravityDirection GravityDirection => gravityDirection;

    /// <summary>
    /// 重力の強さ。
    /// </summary>
    private readonly float force = 5.0f;

    /// <summary>
    /// 重力。
    /// </summary>
    private Vector3 gravity;

    /// <summary>
    /// 重力の記憶用変数。
    /// </summary>
    private Vector3 gravityHold;

    private void Start()
    {
        SetGravityDirection(gravityDirection);
    }


    /// <summary>
    /// 重力の向きをセットする。
    /// </summary>
    /// <param name="targetDirection">向き</param>
    public void SetGravityDirection(LocalGravityDirection targetDirection)
    {
        switch(targetDirection)
        {
            case LocalGravityDirection.Down:
                gravity = new Vector3(0.0f, -force, 0.0f);
                gravityDirection = targetDirection;
                transform.localScale = new Vector3(transform.localScale.x, 1.0f, transform.localScale.z);
                break;
            case LocalGravityDirection.Top:
                gravity = new Vector3(0.0f, force, 0.0f);
                gravityDirection = targetDirection;
                transform.localScale = new Vector3(transform.localScale.x, -1.0f, transform.localScale.z);
                break;
            case LocalGravityDirection.Right:
                gravity = new Vector3(force, 0.0f, 0.0f);
                break;
            case LocalGravityDirection.Left:
                gravity = new Vector3(-force, 0.0f, 0.0f);
                break;
            default:
                throw new System.Exception("GravityParameterNotFound");
        }
        gravityHold = gravity;
    }

    private void FixedUpdate()
    {
        myBody.AddForce(gravity);
    }

    /// <summary>
    /// 重力を消す。
    /// </summary>
    public void ZeroGravity()
    {
        myBody.velocity = Vector2.zero;
        gravity = Vector3.zero;
    }

    /// <summary>
    /// 重力を戻す。
    /// </summary>
    public void ReturnGravity()
    {
        gravity = gravityHold;
    }
}
