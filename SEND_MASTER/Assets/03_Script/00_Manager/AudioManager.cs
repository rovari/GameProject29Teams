using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using AudioClipList         = System.Collections.Generic.List<UnityEngine.AudioClip>;
using AudioClipDictionary = System.Collections.Generic.Dictionary<string, UnityEngine.AudioClip>;

public enum SOUNDTYPE {
    MASTER,
    BGM,
    ENVIRONMENT,
    GAME,
    SYSTEM,
    JINGLE,
    VOICE
}

struct AudioLink {

    // Field
    private AudioSource         source;
    private AudioClipDictionary dictionary;

    // Method
    public void Fetch       (AudioSource audioSource = null, AudioClipDictionary clipDictionary = null) {

        source      = audioSource;
        dictionary  = clipDictionary;
    }
    public void Set         (string name) {
        source.clip = dictionary[name];
    }
    public void Play        () {
        source.Play();
    }
    public void PlayOneShot (string clipName) {
        source.PlayOneShot(dictionary[clipName]);
    }
    public void Stop        () {
        source.Stop();
    }
}

public class AudioManager : MonoBehaviour {

    // Field
    [SerializeField] private EffectSystem   effect;
    [SerializeField] private AudioMixer     mixer;
    [SerializeField] private AudioClipList  bgmClipList;
    [SerializeField] private AudioClipList  environmentClipList;
    [SerializeField] private AudioClipList  gameSeClipList;
    [SerializeField] private AudioClipList  systemSeClipList;
    [SerializeField] private AudioClipList  jingleClipList;
    [SerializeField] private AudioClipList  voiceClipList;
    
    private const float VOLUME_MAX = 1.0f;
    private const float VOLUME_MIN = 0.0f;

    static private AudioClipDictionary bgmDic;
    static private AudioClipDictionary gmeDic;
    static private AudioClipDictionary sysDic;
    static private AudioClipDictionary envDic;
    static private AudioClipDictionary jngDic;
    static private AudioClipDictionary voDic;

    static private EffectSystem ef;
    static private AudioMixer   mix;
    static private AudioSource  bgmSrc;
    static private AudioSource  gmeSrc;
    static private AudioSource  envSrc;
    static private AudioSource  seSrc;
    static private AudioSource  jngSrc;
    static private AudioSource  voSrc;
    
    // Property

    // Method
    private void InitializeAudio () {

        ef      = effect;
        mix     = mixer;
        bgmSrc  = transform.Find("BGM")         .GetComponent<AudioSource>();
        seSrc   = transform.Find("SE")          .GetComponent<AudioSource>();
        envSrc  = transform.Find("Environment") .GetComponent<AudioSource>();
        jngSrc  = transform.Find("Jingle")      .GetComponent<AudioSource>();
        voSrc   = transform.Find("Voice")       .GetComponent<AudioSource>();

        bgmDic  = new AudioClipDictionary();
        gmeDic  = new AudioClipDictionary();
        sysDic  = new AudioClipDictionary();
        envDic  = new AudioClipDictionary();
        jngDic  = new AudioClipDictionary();
        voDic   = new AudioClipDictionary();

        foreach (var gme in gameSeClipList)         gmeDic.Add(gme.name, gme);
        foreach (var sys in systemSeClipList)       sysDic.Add(sys.name, sys);
        foreach (var bgm in bgmClipList)            bgmDic.Add(bgm.name, bgm);
        foreach (var env in environmentClipList)    envDic.Add(env.name, env);
        foreach (var jng in jingleClipList)         jngDic.Add(jng.name, jng);
        foreach (var voc in voiceClipList)          voDic .Add(voc.name, voc);
    }

    static public  AudioMixer GetMixer() {
        return mix;
    }

    static public  void Play                (SOUNDTYPE soundType, string name) {
        GetAudioLink(soundType).Set(name);
        GetAudioLink(soundType).Play();
    }
    static public  void PlayOneShot         (SOUNDTYPE soundType, string name) {
        GetAudioLink(soundType).PlayOneShot(name);
    }
    static public  void Stop                (SOUNDTYPE soundType) {
        GetAudioLink(soundType).Stop();
    }

    static public  void Volume              (SOUNDTYPE soundType, float volume) {

        volume =
            VOLUME_MAX < volume ?
            VOLUME_MAX :
            VOLUME_MIN > volume ?
            VOLUME_MIN : volume;


        volume = volume * 100.0f - 80.0f;

        switch (soundType) {
            case SOUNDTYPE.MASTER:
                mix.SetFloat("MS_VL", volume); break;

            case SOUNDTYPE.BGM:
            case SOUNDTYPE.ENVIRONMENT:
                mix.SetFloat("BG_VL", volume); break;

            case SOUNDTYPE.SYSTEM:
            case SOUNDTYPE.GAME:
            case SOUNDTYPE.JINGLE:
                mix.SetFloat("SE_VL", volume); break;

            case SOUNDTYPE.VOICE:
                mix.SetFloat("VC_VL", volume); break;

            default: break;
        }
    }
    static public  void MasterLowPass       (bool enable) {

        if (!enable) {
            mix.SetFloat("MS_LP", 22000.0f);
        }
        else {
            mix.SetFloat("MS_LP", 1000.0f);
        }
    }
    static public  void ShmoothLowPass      (bool bgmOnly, bool lowPassOut, float time) {
        ef.SoundLowPassEffect(bgmOnly, lowPassOut, time);
    }
    static public  void ShmoothFade         (bool bgmOnly, float time, float volume) {

        volume =
            VOLUME_MAX < volume ?
            VOLUME_MAX :
            VOLUME_MIN > volume ?
            VOLUME_MIN : volume;
        
        volume = volume * 100.0f - 80.0f;

        ef.SoundFadeEffect(bgmOnly, time, volume);
    }
    static public  void SwapBGM             (float time, string nextBgmName) {
        ef.SwapBgmEffect(time, nextBgmName);
    }

    static private AudioLink GetAudioLink   (SOUNDTYPE soundType) {

        AudioLink link = default;

        switch (soundType) {
            case SOUNDTYPE.BGM:         link.Fetch(bgmSrc, bgmDic);   break;
            case SOUNDTYPE.ENVIRONMENT: link.Fetch(envSrc, envDic);   break;
            case SOUNDTYPE.SYSTEM:      link.Fetch(seSrc,  sysDic);   break;
            case SOUNDTYPE.GAME:        link.Fetch(seSrc,  gmeDic);   break;
            case SOUNDTYPE.JINGLE:      link.Fetch(jngSrc, jngDic);   break;
            case SOUNDTYPE.VOICE:       link.Fetch(voSrc,  voDic);    break;
            default: break;
        }

        return link;
    }

    // Unity
	private void Start() {
        InitializeAudio();
	}
}   