using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AudioClipを保持し、音を鳴らす。
/// </summary>
public class SoundEffect : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = default;
    [SerializeField] private List<AudioClip> audioClips = default;

    /// <summary>
    /// clipsからランダムに選び、最大音量でひとつ再生する。
    /// </summary>
    public void PlaySound()
    {
        audioSource.volume = 1.0f;
        audioSource.pitch = 1.0f;
        int clipID = Random.Range(0, audioClips.Count);
        audioSource.PlayOneShot(audioClips[clipID]);
    }

    /// <summary>
    /// clipsから指定した番号のclipを、最大音量でひとつ再生する。
    /// </summary>
    public void PlaySound(int clipID)
    {
        audioSource.volume = 1.0f;
        audioSource.pitch = 1.0f;
        audioSource.PlayOneShot(audioClips[clipID]);
    }

    /// <summary>
    /// clipsから指定した番号のclipを、指定音量でひとつ再生する。
    /// </summary>
    public void PlaySound(int clipID, float volume)
    {
        audioSource.volume = volume;
        audioSource.pitch = 1.0f;
        audioSource.PlayOneShot(audioClips[clipID]);
    }

    /// <summary>
    /// clipsからランダムに選び、音量を指定してひとつ再生する。
    /// </summary>
    public void PlaySound(float volume)
    {
        audioSource.volume = volume;
        audioSource.pitch = 1.0f;
        int clipID = Random.Range(0, audioClips.Count);
        audioSource.PlayOneShot(audioClips[clipID]);
    }

    /// <summary>
    /// clipsからランダムに選び、音量を指定してピッチ幅からランダムピッチでひとつ再生する。
    /// </summary>
    public void PlaySoundRandomPitch(float volume, float min, float max)
    {
        audioSource.volume = volume;
        audioSource.pitch = Random.Range(min, max);
        int clipID = Random.Range(0, audioClips.Count);
        audioSource.PlayOneShot(audioClips[clipID]);
    }
}
