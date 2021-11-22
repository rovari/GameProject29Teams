using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Effekseer;

public class CustomEffectPlayer : MonoBehaviour {

    private EffekseerEmitter _emitter;

    [SerializeField] private string  _PlaySoundName = null;
    [SerializeField] private bool    _playOnAwake;
    [SerializeField] private bool    _isLoop;
    [SerializeField] private float   _SoundDelayTime;
    [SerializeField] private float   _EffectDelayTime;

    [SerializeField] private ParticleSystem         _unityParticle;
    [SerializeField] private EffekseerEffectAsset   _effekseerParticle;

    private void OnEnable() {
        Initialize();
    }

    void Update () {
        
    }

    private void Initialize() {

        if (!_unityParticle && _effekseerParticle) {
            if(_emitter) _emitter = new EffekseerEmitter();
        }
    }

    private void EffectPlay() {

        if (_unityParticle) {

            ParticleSystem.MainModule main = _unityParticle.main;
            main.loop = _isLoop;
            _unityParticle.Play();
        }
        if (_emitter) {
            _emitter.isLooping = _isLoop;
            _emitter.Play();
        }
    }

    private void EffectStop() {

        if (_unityParticle) _unityParticle.Stop();
        if (_emitter)       _emitter.Stop();
    }

    public void SoundPlay() {
        if (_PlaySoundName != null) AudioManager.PlayOneShot(AudioManager.SOUNDTYPE.GAME, _PlaySoundName);
    }
    
    private IEnumerator Cast() {

        float   count          = 0.0f;
        bool    isPlayEffect   = false;
        bool    isPlaySound    = false;

        while (isPlayEffect || isPlaySound) {
            count += Time.deltaTime;
            
            if(count >= _EffectDelayTime) {
                EffectPlay();
                isPlayEffect = true;
            }

            if(count >= _SoundDelayTime) {
                SoundPlay();
                isPlaySound = true;
            }

            yield return null;
        }
    }
}
