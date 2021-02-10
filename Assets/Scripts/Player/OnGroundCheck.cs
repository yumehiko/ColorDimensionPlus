using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 設置判定。
/// </summary>
public class OnGroundCheck : MonoBehaviour
{
    [SerializeField] private Animator animator = default;
    private readonly string aKeyInTheAir = "InTheAir";
    //private readonly string aKeyStand = "Stand";

    [SerializeField] private int touchingObjects = 0;

    public bool OnGround { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        touchingObjects++;
        OnGround = true;
        animator.SetBool(aKeyInTheAir, false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touchingObjects--;
        if (touchingObjects <= 0)
        {
            touchingObjects = 0;
            OnGround = false;
            animator.SetBool(aKeyInTheAir, true);
        }
    }
}
