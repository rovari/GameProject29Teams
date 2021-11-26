using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Facade {

    // Hide  Field ================================================
    private enum    ITEMTYPE {
        None,
        Invincible,
        Spanner,
        TurboCharger,
        LifeBox,
    }
    private Facade  TargetFacade;
    private bool    _isEffect;

    // Show  Field ================================================
    [SerializeField] private ITEMTYPE itemType;
    
    [Header("<< Invincible >>")][Space(5)]
    [SerializeField] private AnimationCurve _InvincibleCurve;
    [SerializeField] private float          _invincibleTime;

    [Header("<< Spanner >>")][Space(5)]
    [SerializeField] private AnimationCurve _SpannerCurve;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float          _healValue;
    [SerializeField] private float          _healEffectTime;

    [Header("<< TurboChager >>")][Space(5)]
    [SerializeField] private AnimationCurve _TurboChagerCurve;
    [SerializeField] private float          _turboTime;

    // Unity Method ===============================================
    
    // User  Method ===============================================
    public  void CalcItemEvent  (ref Facade facade) {

        TargetFacade = facade;

        switch (itemType) {
            case ITEMTYPE.Invincible:   if (!_isEffect) StartCoroutine("InvincibleItem");   break;

            case ITEMTYPE.Spanner:      if (!_isEffect) StartCoroutine("SpannerItem");      break;

            case ITEMTYPE.TurboCharger: if (!_isEffect) StartCoroutine("TurboChagerItem");  break;

            case ITEMTYPE.LifeBox:      if (!_isEffect) StartCoroutine("LifeBoxItem");      break;
        }
    }

    private IEnumerator InvincibleItem  () {

        _isEffect = true;
        TargetFacade.GetFacade<Player>().GetSetIsInvin = true;
        TargetFacade._surface.SetRimEnable(true, Color.yellow);
        _effect.PlayEffect(Effect.EFFECT.VIGNETTE, _invincibleTime, _InvincibleCurve, 0, 0.0025f, Color.yellow);

        float inc = _invincibleTime * 0.25f;

        yield return new WaitForSeconds(inc * 3.0f);

        float count = inc / 0.05f;
        bool  sw = true;

        while (count > 0) {

            TargetFacade._surface.SetRimEnable(sw, Color.yellow);
            count -= 1.0f;
            sw = !sw;

            yield return new WaitForSeconds(0.05f);
        }

        TargetFacade._surface.SetRimEnable(false, Color.white);
        TargetFacade.GetFacade<Player>().GetSetIsInvin = false;
        _isEffect = false;
    }
    
    private IEnumerator SpannerItem     () {

        _isEffect = true;

        TargetFacade._surface.SetRimEnable(true, Color.green);
        TargetFacade.GetFacade<Player>().GetSetHp += _healValue;
        _effect.PlayEffect(Effect.EFFECT.VIGNETTE, _healEffectTime, _SpannerCurve, 0, 0.0025f, Color.green);

        yield return new WaitForSeconds(_healEffectTime);

        TargetFacade._surface.SetRimEnable(false, Color.white);
        _isEffect = false;
    }

    private IEnumerator TurboChagerItem () {

        _isEffect = true;

        TargetFacade.GetFacade<Player>().GetSetIsTHEW = true;
        TargetFacade._surface.SetRimEnable(true, Color.cyan);
        
        _effect.PlayEffect(Effect.EFFECT.SLOWMOTION, _turboTime, _TurboChagerCurve);
        _effect.PlayEffect(Effect.EFFECT.VIGNETTE, _turboTime * 0.1f, _TurboChagerCurve, 0, 0.0025f, Color.cyan);
        
        yield return new WaitForSeconds(_turboTime * 0.1f);
        TargetFacade.GetFacade<Player>().GetSetIsTHEW = false;
        TargetFacade._surface.SetRimEnable(false, Color.white);

        _isEffect = false;
        //_isDestory = true;
    }

    private IEnumerator LifeBoxItem     () {

        _isEffect = true;
        
        ++TargetFacade.GetFacade<Player>().GetSetLife;

        yield return null;
        
        _isEffect = false;
    }
}
