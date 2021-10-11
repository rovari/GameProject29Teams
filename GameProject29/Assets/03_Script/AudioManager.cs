using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using AudioClipList         = System.Collections.Generic.List<UnityEngine.AudioClip>;
using AudioClipDictionary   = System.Collections.Generic.Dictionary<string, UnityEngine.AudioClip>;

public class AudioManager : MonoBehaviour {

    // Hide  Property =============================================
    static private bool                 isLoaded;
    static private AudioClipDictionary  _bgmDic;
    static private AudioClipDictionary  _gseDic;
    static private AudioClipDictionary  _mseDic;
    static private AudioClipDictionary  _envDic; 
    static private AudioClipDictionary  _jngDic;
    
    // Show  Property =============================================
    [SerializeField] private AudioMixer         _mixer;

    [Space()]
    [SerializeField] private AudioClipList      _bgmList;
    [SerializeField] private AudioClipList      _gameSEList;
    [SerializeField] private AudioClipList      _menuSEList;
    [SerializeField] private AudioClipList      _environmentList;
    [SerializeField] private AudioClipList      _jngleList;

    [Space()]
    static private AudioSource _bgm;
    static private AudioSource _se;
    static private AudioSource _env;
    static private AudioSource _jng;
    static private AudioSource _vic;

    // Unity Method ===============================================
    private void Start() {

        if(!isLoaded)CreateDictionary();
    }
    
    // User  Method ===============================================

    private void CreateDictionary () {

        _bgm    = transform.Find("BGM")         .GetComponent<AudioSource>();
        _se     = transform.Find("SE")          .GetComponent<AudioSource>();
        _env    = transform.Find("Environment") .GetComponent<AudioSource>();
        _jng    = transform.Find("Jingle")      .GetComponent<AudioSource>();
        _vic    = transform.Find("Voice")       .GetComponent<AudioSource>();

        _bgmDic = new AudioClipDictionary();
        _gseDic = new AudioClipDictionary();
        _mseDic = new AudioClipDictionary();
        _envDic = new AudioClipDictionary();
        _jngDic = new AudioClipDictionary();

        foreach (var gse in _gameSEList)        _gseDic.Add(gse.name, gse);
        foreach (var mse in _menuSEList)        _mseDic.Add(mse.name, mse);
        foreach (var bgm in _bgmList)           _bgmDic.Add(bgm.name, bgm);
        foreach (var env in _environmentList)   _envDic.Add(env.name, env);
        foreach (var jng in _jngleList)         _jngDic.Add(jng.name, jng);

        isLoaded = true;
    }
    
    static public void PlayBGM          (string name) {
        _bgm.PlayOneShot(_bgmDic[name]);
    }
    static public void PlayEnv          (string name) {
        _env.PlayOneShot(_envDic[name]);
    }
    static public void PlayMenuSE       (string name) {
        _se .PlayOneShot(_mseDic[name]);
    }
    static public void PlaySE           (string name) {
        _se .PlayOneShot(_gseDic[name]);
    }
}
