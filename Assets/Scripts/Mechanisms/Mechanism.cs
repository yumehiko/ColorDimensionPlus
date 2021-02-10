using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// MoveZoneを動かすメカニズムのベース。
/// </summary>
public class Mechanism : MonoBehaviour
{
    [SerializeField] private List<SwapZone> swapZones = default;
    //[SerializeField] private float duration = 1.0f;

    //Shake用
    private CameraShaker cameraShaker = default;

    [SerializeField] private float shakeDuration = 0.2f;

    private void Start()
    {
        cameraShaker = GameObject.FindWithTag("MainCamera").GetComponent<CameraShaker>();
    }

    /// <summary>
    /// スイッチから動力が繋がる。
    /// 担当するMoveZoneをすべて動かす。
    /// </summary>
    protected void PowerOn()
    {
        cameraShaker.ShakeCamera(shakeDuration);
        for (int i = 0; i < swapZones.Count; i++)
        {
            //moveZones[i].duration = duration;
            swapZones[i].MoveWallOn();
        }
    }

    /// <summary>
    /// スイッチからの動力が切れる。
    /// 担当するMoveZoneの位置を元に戻す。
    /// </summary>
    protected void PowerOff()
    {
        cameraShaker.ShakeCamera(shakeDuration);
        for (int i = 0; i < swapZones.Count; i++)
        {
            swapZones[i].MoveWallOff();
        }
    }
}
