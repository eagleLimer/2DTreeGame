using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;
    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _i;
        }
    }

    public SoundAudioClip[] soundAudioClipArray = new SoundAudioClip[Enum.GetValues(typeof(SoundManager.Sound)).Length];
    public Dictionary<SoundManager.Sound, SoundAudioClip> soundDict /*= new Dictionary<SoundManager.Sound, SoundAudioClip>()*/;

    private void Awake()
    {
        soundDict = new Dictionary<SoundManager.Sound, SoundAudioClip>();
        foreach (SoundAudioClip soundAudioClip in soundAudioClipArray)
        {
            if (soundDict.ContainsKey(soundAudioClip.sound))
            {
                soundDict[soundAudioClip.sound] = soundAudioClip;
            }
            else
            {
                soundDict.Add(soundAudioClip.sound, soundAudioClip);
            }
        }
    }

    [Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
        [Range(0f, 1.0f)]
        public float volume = 1.0f;
        [Range(-3.0f, 3.0f)]
        public float pitch = 1.0f;
    }

}
