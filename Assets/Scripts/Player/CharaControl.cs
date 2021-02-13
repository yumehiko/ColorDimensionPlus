using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;

/// <summary>
/// Protagonistを操作する。
/// </summary>
public class CharaControl : MonoBehaviour
{

    [SerializeField] private Rigidbody2D myBody = default;

    [SerializeField] private Animator animator = default;
    private int aSpeedParamID;

    /// <summary>
    /// 接地判定。
    /// </summary>
    [SerializeField] private OnGroundCheck onGroundCheck = default;

    [SerializeField] private LocalGravity localGravity = default;

    [SerializeField] private JumpSound jumpSound = default;

    /// <summary>
    /// 最大速度。
    /// </summary>
    private readonly float moveSpeed = 1.0f;

    /// <summary>
    /// ジャンプ力。
    /// </summary>
    private readonly float jumpForce = 2.0f;

    /// <summary>
    /// 左右入力値。
    /// </summary>
    public float InputHorizontal = 0.0f;

    /// <summary>
    /// 上下入力値。
    /// </summary>
    public float InputVertical = 0.0f;

    private void Start()
    {
        aSpeedParamID = Animator.StringToHash("Speed");
    }

    private void Update()
    {
        Animation();
    }

    private void FixedUpdate()
    {
        if (localGravity.GravityDirection == LocalGravityDirection.Down
           || localGravity.GravityDirection == LocalGravityDirection.Top)
        {
            WalkHorizontal(InputHorizontal);
        }
        else
        {
            WalkVertical(InputVertical);
        }
    }

    /// <summary>
    /// キャラクターの画面上での挙動。
    /// </summary>
    private void Animation()
    {
        if (localGravity.GravityDirection == LocalGravityDirection.Down
           || localGravity.GravityDirection == LocalGravityDirection.Top)
        {
            animator.SetFloat(aSpeedParamID, Mathf.Abs(InputHorizontal));
            CheckSpriteDirectionHorizontal();
        }
        else
        {
            animator.SetFloat(aSpeedParamID, Mathf.Abs(InputVertical));
            CheckSpriteDirectionVertical();
        }
    }

    /// <summary>
    /// キャラの向きをチェックし、必要なら反転。左右版
    /// </summary>
    private void CheckSpriteDirectionHorizontal()
    {
        if(InputHorizontal == 0.0f)
        {
            return;
        }

        if (InputHorizontal < 0.0f)
        {
            transform.localScale = new Vector2(-1.0f, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(1.0f, transform.localScale.y);
        }
    }

    /// <summary>
    /// キャラの向きをチェックし、必要なら反転。上下版。
    /// </summary>
    private void CheckSpriteDirectionVertical()
    {
        if (InputVertical == 0.0f)
        {
            return;
        }

        if (InputVertical < 0.0f)
        {
            transform.localScale = new Vector2(-1.0f, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(1.0f, transform.localScale.y);
        }
    }

    /// <summary>
    /// 左右に歩く。
    /// </summary>
    public void WalkHorizontal(float vector)
    {
        myBody.velocity = new Vector2(vector * moveSpeed, myBody.velocity.y);
    }

    /// <summary>
    /// 上下に歩く。
    /// </summary>
    public void WalkVertical(float vector)
    {
        myBody.velocity = new Vector2(myBody.velocity.x, vector * moveSpeed);
    }

    /// <summary>
    /// ジャンプする。
    /// </summary>
    public void Jump()
    {
        if (onGroundCheck.OnGround == false)
        {
            return;
        }

        jumpSound.PlaySoundRandomPitch(0.7f, 0.7f, 1.1f);

        Vector2 jumpDirection = Vector2.up;

        if(localGravity.GravityDirection == LocalGravityDirection.Down)
        {
            jumpDirection = Vector2.up;
            myBody.velocity = new Vector2(myBody.velocity.x, 0.0f);
        }
        else if(localGravity.GravityDirection == LocalGravityDirection.Top)
        {
            jumpDirection = Vector2.down;
            myBody.velocity = new Vector2(myBody.velocity.x, 0.0f);
        }
        else if(localGravity.GravityDirection == LocalGravityDirection.Right)
        {
            jumpDirection = Vector2.left;
            myBody.velocity = new Vector2(0.0f, myBody.velocity.y);
        }
        else if(localGravity.GravityDirection == LocalGravityDirection.Left)
        {
            jumpDirection = Vector2.right;
            myBody.velocity = new Vector2(0.0f, myBody.velocity.y);
        }

        myBody.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
        onGroundCheck.GetOffGround();
    }

    /// <summary>
    /// 移動を即座に完全停止。
    /// </summary>
    public void Brake()
    {
        InputHorizontal = 0.0f;
        InputVertical = 0.0f;
        myBody.velocity = Vector2.zero;
    }

    /// <summary>
    /// コントロール権を失い、操作不能になる。
    /// </summary>
    public void LoseInitiative()
    {
        InputHorizontal = 0.0f;
        InputVertical = 0.0f;
        animator.SetFloat(aSpeedParamID, 0.0f);
        GetComponent<Player>().LoseControl();
    }
}
