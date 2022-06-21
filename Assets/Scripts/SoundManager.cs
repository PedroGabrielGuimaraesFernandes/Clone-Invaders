using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        PlayerShoot,
        EnemyMovement,
        EnemyShoot,
        EnemyDeath,
        MenuConfirm,
        MenuCancel,
    }

    public static void PlaySound(Sound sound)
    {
        AudioSource audioSource = SoundPlayerPool.Instance.GetObject();

       
        audioSource.gameObject.SetActive(true);
        audioSource.PlayOneShot(GetAudioClip(sound));
        SoundPlayerPool.Instance.ReturnObjectToPoolDelayed(audioSource);
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.instance.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found");
        return null;
    }

}
