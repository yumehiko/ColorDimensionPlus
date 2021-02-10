using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 足音を鳴らす。
/// </summary>
public class Footstep : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = default;
    [SerializeField] private List<AudioClip> audioClips = default;

    /// <summary>
    /// 足音を鳴らす。アニメーションから呼び出す。
    /// </summary>
    public void FootstepSound()
    {
        int clipID = Random.Range(0, audioClips.Count);
        audioSource.pitch = Random.Range(0.8f,1.2f);
        audioSource.PlayOneShot(audioClips[clipID]);
    }
}
