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
    public void Set         (AudioSource audioSource = null, AudioClipDictionary clipDictionary = null) {

        source      = audioSource;
        dictionary  = clipDictionary;
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
    [SerializeField] private AudioMixer     mixer;
    [SerializeField] private AudioClipList  bgmClipList;
    [SerializeField] private AudioClipList  environmentClipList;
    [SerializeField] private AudioClipList  gameSeClipList;
    [SerializeField] private AudioClipList  systemSeClipList;
    [SerializeField] private AudioClipList  jingleClipList;
    [SerializeField] private AudioClipList  voiceClipList;
    
    private const float VOLUME_MAX = 2.0f;
    private const float VOLUME_MIN = 0.0f;

    static private AudioClipDictionary bgmDic;
    static private AudioClipDictionary gmeDic;
    static private AudioClipDictionary sysDic;
    static private AudioClipDictionary envDic;
    static private AudioClipDictionary jngDic;
    static private AudioClipDictionary voDic;

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

    static private AudioLink GetAudioLink   (SOUNDTYPE soundType) {

        AudioLink link = default;

        switch (soundType) {
            case SOUNDTYPE.BGM:         link.Set(bgmSrc, bgmDic);   break;
            case SOUNDTYPE.ENVIRONMENT: link.Set(envSrc, envDic);   break;
            case SOUNDTYPE.SYSTEM:      link.Set(seSrc,  gmeDic);   break;
            case SOUNDTYPE.GAME:        link.Set(seSrc,  sysDic);   break;
            case SOUNDTYPE.JINGLE:      link.Set(jngSrc, jngDic);   break;
            case SOUNDTYPE.VOICE:       link.Set(voSrc,  voDic);    break;
            default: break;
        }

        return link;
    }
    static public  void Play                (SOUNDTYPE soundType) {
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
            VOLUME_MAX > volume ?
            VOLUME_MAX :
            VOLUME_MIN < volume ?
            VOLUME_MIN : volume;

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
    
    // Unity
	private void Start() {
        InitializeAudio();
	}
}   