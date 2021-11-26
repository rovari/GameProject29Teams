using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using AudioClipList         = System.Collections.Generic.List<UnityEngine.AudioClip>;
using AudioClipDictionary   = System.Collections.Generic.Dictionary<string, UnityEngine.AudioClip>;

struct AudioLink {

    public void Set(AudioSource source = null, AudioClipDictionary dictionary = null) {
        _source     = source;
        _dictionary = dictionary;
    }

    AudioSource         _source;
    AudioClipDictionary _dictionary;

    public void Play() {
        _source.Play();
    }

    public void PlayOneShot(string name) {
        _source.PlayOneShot(_dictionary[name]);
    }
    
    public void Stop() {
        _source.Stop();
    }
}

public class AudioManager : MonoBehaviour {

   
    // Hide  Field ================================================
    private static AudioClipDictionary  _bgmDic;
    private static AudioClipDictionary  _gmeDic;
    private static AudioClipDictionary  _sysDic;
    private static AudioClipDictionary  _envDic; 
    private static AudioClipDictionary  _jngDic;
    private static AudioClipDictionary  _vocDic;
    
    // Show  Field ================================================

    public enum SOUNDTYPE {
        MASTER,
        BGM,
        ENVIRONMENT,
        GAME,
        SYSTEM,
        JINGLE,
        VOICE
    }

    [SerializeField] private AudioMixer         mixer;

    [Space()]
    [SerializeField] private AudioClipList      _bgmList;
    [SerializeField] private AudioClipList      _environmentList;
    [SerializeField] private AudioClipList      _gameList;
    [SerializeField] private AudioClipList      _systemList;
    [SerializeField] private AudioClipList      _jngleList;
    [SerializeField] private AudioClipList      _voiceList;
    [Space()]

    private static AudioMixer   mix;
    private static AudioSource  bgm;
    private static AudioSource  env;
    private static AudioSource  se;
    private static AudioSource  jng;
    private static AudioSource  voc;
    
    // Unity Method ===============================================
    private void Start() {
        if(StateManager.GetSetState != STATE.LOAD) InitializeAudio();
    }
    
    // User  Method ===============================================

    private void InitializeAudio () {

        mix    = mixer;
        bgm    = transform.Find("BGM")         .GetComponent<AudioSource>();
        se     = transform.Find("SE")          .GetComponent<AudioSource>();
        env    = transform.Find("Environment") .GetComponent<AudioSource>();
        jng    = transform.Find("Jingle")      .GetComponent<AudioSource>();
        voc    = transform.Find("Voice")       .GetComponent<AudioSource>();

        _bgmDic = new AudioClipDictionary();
        _gmeDic = new AudioClipDictionary();
        _sysDic = new AudioClipDictionary();
        _envDic = new AudioClipDictionary();
        _jngDic = new AudioClipDictionary();
        _vocDic = new AudioClipDictionary();

        foreach (var gme in _gameList)          _gmeDic.Add(gme.name, gme);
        foreach (var sys in _systemList)        _sysDic.Add(sys.name, sys);
        foreach (var bgm in _bgmList)           _bgmDic.Add(bgm.name, bgm);
        foreach (var env in _environmentList)   _envDic.Add(env.name, env);
        foreach (var jng in _jngleList)         _jngDic.Add(jng.name, jng);
        foreach (var voc in _voiceList)         _jngDic.Add(voc.name, voc);
    }
    
    private static AudioLink GetAudioLink(SOUNDTYPE soundType) {

        AudioLink link = new AudioLink();

        switch (soundType) {
            case SOUNDTYPE.MASTER:      link.Set(null, null);    break;
            case SOUNDTYPE.BGM:         link.Set(bgm, _bgmDic); break;
            case SOUNDTYPE.ENVIRONMENT: link.Set(env, _envDic); break;
            case SOUNDTYPE.SYSTEM:      link.Set(se , _gmeDic); break;
            case SOUNDTYPE.GAME:        link.Set(se , _sysDic); break;
            case SOUNDTYPE.JINGLE:      link.Set(jng, _jngDic); break;
            case SOUNDTYPE.VOICE:       link.Set(voc, _vocDic); break;
        }

        return link;
    }
    
    public  static void Play        (SOUNDTYPE type) {
        GetAudioLink(type).Play();
    }
    public  static void PlayOneShot (SOUNDTYPE type, string name) {
        GetAudioLink(type).PlayOneShot(name);
    }
    public  static void Stop        (SOUNDTYPE type) {
        GetAudioLink(type).Stop();
    }
    public  static void Volume      (SOUNDTYPE type, float vol) {

        switch (type) {
            case SOUNDTYPE.MASTER:
                mix.SetFloat("MS_VL", vol); break;

            case SOUNDTYPE.BGM:
            case SOUNDTYPE.ENVIRONMENT:
                mix.SetFloat("BG_VL", vol); break;

            case SOUNDTYPE.SYSTEM:
            case SOUNDTYPE.GAME:
            case SOUNDTYPE.JINGLE:
                mix.SetFloat("SE_VL", vol); break;

            case SOUNDTYPE.VOICE:
                mix.SetFloat("VC_VL", vol); break;
        }
    }
    
    public  static void CrossFade   () { 

    }


}
