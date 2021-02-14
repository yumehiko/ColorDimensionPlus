using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Mechanismの一種。感圧板。
/// </summary>
public class PressurePlate : Mechanism
{
    [SerializeField] private Animator animator = default;
    [SerializeField] private SoundEffect soundEffect = default;
    private int touchObjects = 0;
    private bool isOn = false;

    /// <summary>
    /// 感圧板に何かが触れたとき。
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        touchObjects++;
        if (isOn == false)
        {
            animator.Play("On");
            soundEffect.PlaySound(1.0f);
            PowerOn();
            isOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touchObjects--;
        if (touchObjects <= 0)
        {
            touchObjects = 0;
            animator.Play("Off");
            soundEffect.PlaySound(1.0f);
            PowerOff();
            isOn = false;
        }
    }
}
