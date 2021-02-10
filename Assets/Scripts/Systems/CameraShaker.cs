using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Camera myCamera = default;

    private readonly float magnitude = 0.03f;
    private readonly int shakeVibrato = 24;

    private Vector3 initPosition = default;

    private void Start()
    {
        initPosition = transform.position;
    }

    /// <summary>
    /// カメラを揺らす。
    /// </summary>
    public void ShakeCamera(float shakeDuration)
    {
        float shakeStrength = magnitude * myCamera.orthographicSize;
        transform.DOShakePosition(shakeDuration, shakeStrength, shakeVibrato)
            .OnComplete(() => ResetPosition());
    }

    /// <summary>
    /// カメラを元の位置に戻す。
    /// </summary>
    private void ResetPosition()
    {
        transform.position = initPosition;
    }


}
