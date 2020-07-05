using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        PlayerAttack,
        PlayerJump,
        PlayerTeleport,
        PlayerHit,
        MinotaurStomp,
        MinotaurHammer,
        MinotaurRoar,
        PlayerShotHit,
        PortalSound,
        PlayerChargeUp,
    }
    public static void PlaySound(Sound sound)
    {
        GameObject soundObjectNoPos = new GameObject("no pos sound");
        AudioSource audioSource = soundObjectNoPos.AddComponent<AudioSource>();
        GameAssets.SoundAudioClip soundAudioClip = GameAssets.i.soundDict[sound];
        audioSource.volume = soundAudioClip.volume;
        audioSource.pitch = soundAudioClip.pitch;
        if (audioSource == null)
        {
            Debug.LogError("cannot play sound: " + sound.ToString());
            Object.Destroy(soundObjectNoPos);
        }
        else
        {
            audioSource.PlayOneShot(soundAudioClip.audioClip);
            Object.Destroy(soundObjectNoPos, audioSource.clip.length);
        }
    }

    public static void PlaySound(Sound sound, Vector3 position)
    {
        GameObject soundGameObject = new GameObject("Sound");
        soundGameObject.transform.position = position;
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        GameAssets.SoundAudioClip soundAudioClip = GameAssets.i.soundDict[sound];
        audioSource.volume = soundAudioClip.volume;
        audioSource.pitch = soundAudioClip.pitch;
        audioSource.clip = soundAudioClip.audioClip;
        if (audioSource == null)
        {
            Debug.LogError("cannot play sound: " + sound.ToString());
            Object.Destroy(soundGameObject);
        }
        else
        {
            audioSource.Play();
            Object.Destroy(soundGameObject, audioSource.clip.length);
        }
    }
}
