using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    [SerializeField] private AudioSource source;  //play sound effect for UI button
    [SerializeField] private AudioSource BGMSource; //play background music
    [SerializeField] private AudioSource Music2Source; // fading out and in music
    [SerializeField] private string introBGMLocation;
    [SerializeField] private string level1BGMLocation;
    [SerializeField] private string level2BGMLocation;
    [SerializeField] private string level3BGMLocation;

    private NetworkService _service;
    private AudioSource _activeMusic;
    private AudioSource _inactiveMusic;
    public float crossFadeRate = 1.5f;
    private bool _crossFading;
    public ManagerStatus status { get; private set; }


    //I am very confused about this syntax 
    //Why can I just call AudioListener. Not Gameobject.Getconponent<>()
    public float soundVolume { get { return AudioListener.volume; } set { AudioListener.volume = value; } }
    public bool soundMute { get { return AudioListener.pause; } set { AudioListener.pause = value; } }
    private float _BGMVolume;
    public float BGMVolume
    {
        get { return _BGMVolume; }
        set
        {
            _BGMVolume = value;
            if(BGMSource != null && !_crossFading)
            {
                BGMSource.volume = _BGMVolume;
                Music2Source.volume = _BGMVolume;
            }
        }

    }

    public bool MuteBGM
    {
        get
        {
            if(BGMSource != null)
            {
                return BGMSource.mute;
            }
            return false;
        }

        set
        {
            if(BGMSource != null)
            {
                BGMSource.mute = value;
                Music2Source.mute = value;
            }
        }
    }

   

    public void PlayIntroMusic()
    {
        PlayBGM(Resources.Load(introBGMLocation) as AudioClip);

    }

    public void PlayLevelMusic(int level)
    {
        string location;
        switch (level)
        {
            case 1:
                location = level1BGMLocation;
                break;
            case 2:
                location = level2BGMLocation;
                break;
            case 3:
                location = level3BGMLocation;
                break;
            default:
                location = introBGMLocation;
                break;
        }


        PlayBGM(Resources.Load(location) as AudioClip);
    }

    public void PlayBGM(AudioClip music)
    {   //normally the below will do, but we are doing cross fading here
        //BGMSource.clip = music;
        //BGMSource.Play();

        if (_crossFading) { return; }
        StartCoroutine(CrossFadeMusic(music));
    }
    private IEnumerator CrossFadeMusic(AudioClip clip)
    {
        _crossFading = true;
        _inactiveMusic.clip = clip;
        _inactiveMusic.volume = 0;
        _inactiveMusic.Play();

        float scaledRate = crossFadeRate * _BGMVolume;
        while (_activeMusic.volume > 0)
        {
            _activeMusic.volume -= scaledRate * Time.deltaTime;
            _inactiveMusic.volume += scaledRate * Time.deltaTime;

            yield return null;
        }

        AudioSource temp = _activeMusic;
        _activeMusic = _inactiveMusic;
        _activeMusic.volume = _BGMVolume;

        _inactiveMusic = temp;
        _inactiveMusic.Stop();
        _crossFading = false;

    }
    public void StopMusic()
    {
        BGMSource.Stop();
        Music2Source.Stop();
    }


   
    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

    public void Startup(NetworkService service)
    {
        _service = service;

        BGMSource.ignoreListenerPause = true;
        BGMSource.ignoreListenerVolume = true;
        Music2Source.ignoreListenerPause = true;
        Music2Source.ignoreListenerVolume = true;

        soundVolume = 1f;
        BGMVolume = 1f;
        // Initialize music sources here

        _activeMusic = BGMSource;
        _inactiveMusic = Music2Source;

        status = ManagerStatus.Started;
    }
}
