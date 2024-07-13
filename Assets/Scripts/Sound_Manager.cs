using System;
using UnityEngine;

public enum SoundsName
{
    BackgroundMusic,
    ButtonClick,
    PlayerMove,
    PlayerJump,
    PlayerDeath,
    EnemyAttack,
    KeyPickup,
    LevelComplete
}

[Serializable]
public class SoundType
{
    public SoundsName soundType;
    public AudioClip soundClip;
}

public class Sound_Manager : MonoBehaviour
{
    private static Sound_Manager instance;
    public static Sound_Manager Instance { get { return instance; } }

    [SerializeField] private AudioSource soundBGM;
    [SerializeField] private AudioSource soundSFX;
    [SerializeField] private SoundType[] Sounds;
   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        PlayBG(SoundsName.BackgroundMusic);
    }

    public void PlayBG(SoundsName sound)
    {
        AudioClip audio = getSoundClip(sound);

        if(audio != null)
        {
            soundBGM.clip = audio;
            soundBGM.Play();
        }

    }

    public void Play(SoundsName sound)
    {
        AudioClip audioClip = getSoundClip(sound);

        if(audioClip != null)
        {
            soundSFX.PlayOneShot(audioClip);
        }
        else
        {
            Debug.Log("Audioclip not found");
        }

    }

    private AudioClip getSoundClip(SoundsName sound)
    {

        SoundType audioClip = Array.Find(Sounds, item=>item.soundType == sound);
        if(audioClip != null)
           return audioClip.soundClip;
        return null;
    }
} 

