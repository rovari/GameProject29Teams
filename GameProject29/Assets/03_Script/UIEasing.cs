using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIEasing : MonoBehaviour {
    
    public  enum    EASING_TYPE1 {
        LERP,
        SINE,
        QUAD,
        CUBIC,
        QUART,
        QUINT,
        EXPO,
        CIRC,
        BACK,
        ELASTIC,
    };

    public  enum    EASING_TYPE2 {
        IN,
        OUT,
        INOUT
    };

    private float   progress;
    public  Vector2 start;
    public  Vector2 end;
    private Vector2 inc;

    public  EASING_TYPE1   type1;
    public  EASING_TYPE2   type2;

    // Unity Function ===============================================

    private void Start   () {
        
        Vector2 range = end - start;

        progress    = 1.0f;
        inc         = new Vector2(progress / range.x, progress / range.y);
    }

    private void Update  () {

        if (Input.GetKeyDown(KeyCode.F)) Easing();
    }

    // User  Function ===============================================

    private void        Easing  () {
        switch (type1) {
        case EASING_TYPE1.LERP:     StartCoroutine("Lerp");     break;
        case EASING_TYPE1.SINE:     StartCoroutine("Sine");     break;
        case EASING_TYPE1.QUAD:     StartCoroutine("Quad");     break;
        case EASING_TYPE1.CUBIC:    StartCoroutine("Cubic");    break;
        case EASING_TYPE1.QUART:    StartCoroutine("Quart");    break;
        case EASING_TYPE1.QUINT:    StartCoroutine("Quint");    break;
        case EASING_TYPE1.EXPO:     StartCoroutine("Expo");     break;
        case EASING_TYPE1.CIRC:     StartCoroutine("Circ");     break;
        case EASING_TYPE1.BACK:     StartCoroutine("Back");     break;
        case EASING_TYPE1.ELASTIC:  StartCoroutine("Elastic");  break;
        }
    }
    
    private IEnumerator Lerp    () {

        Vector2 pos = start;

        while (progress > 0.0f) {
      
            this.GetComponent<RectTransform>().anchoredPosition = pos;

            pos += inc * Time.deltaTime;

            progress -= Time.deltaTime;
            yield return null;
        }

        this.GetComponent<RectTransform>().anchoredPosition = end;
    }

    private IEnumerable Sine    () {

        Vector2 pos = start;

        while (progress > 0.0f) {
      
            this.GetComponent<RectTransform>().anchoredPosition = pos;
            
            pos.x       += 1.0f - Mathf.Cos((inc.x * Mathf.PI) * 0.5f) * Time.deltaTime;
            pos.y       += 1.0f - Mathf.Cos((inc.y * Mathf.PI) * 0.5f) * Time.deltaTime;
            
            progress    -= Time.deltaTime;
            yield return null;
        }

        this.GetComponent<RectTransform>().anchoredPosition = end;
    }

    private IEnumerator Quad    () {

        Vector2 pos = start;

        while (progress > 0.0f) {

            this.GetComponent<RectTransform>().anchoredPosition = pos;

            pos += inc * inc * Time.deltaTime; 

            progress -= Time.deltaTime;
            yield return null;
        }

        this.GetComponent<RectTransform>().anchoredPosition = end;
    }

    private IEnumerator Cubic   () {

        Vector2 pos = start;

        while (progress > 0.0f) {

            this.GetComponent<RectTransform>().anchoredPosition = pos;

            pos += inc * inc * inc * Time.deltaTime;

            progress -= Time.deltaTime;
            yield return null;
        }

        this.GetComponent<RectTransform>().anchoredPosition = end;
    }

    private IEnumerator Quart   () {

        Vector2 pos = start;

        while (progress > 0.0f) {

            this.GetComponent<RectTransform>().anchoredPosition = pos;

            pos += inc * inc * inc * inc * Time.deltaTime;

            progress -= Time.deltaTime;
            yield return null;
        }

        this.GetComponent<RectTransform>().anchoredPosition = end;
    }

    private IEnumerator Quint   () {

        Vector2 pos = start;

        while (progress > 0.0f) {

            this.GetComponent<RectTransform>().anchoredPosition = pos;

            pos += inc * inc * inc * inc * inc * Time.deltaTime;

            progress -= Time.deltaTime;
            yield return null;
        }

        this.GetComponent<RectTransform>().anchoredPosition = end;
    }

    private IEnumerator Expo    () {

        Vector2 pos = start;

        while (progress > 0.0f) {

            this.GetComponent<RectTransform>().anchoredPosition = pos;
            
            pos.x += (progress == 1.0f) ? 0 : Mathf.Pow(2.0f, 10.0f * inc.x - 10.0f) * Time.deltaTime;
            pos.y += (progress == 1.0f) ? 0 : Mathf.Pow(2.0f, 10.0f * inc.y - 10.0f) * Time.deltaTime;

            progress -= Time.deltaTime;
            yield return null;
        }

        this.GetComponent<RectTransform>().anchoredPosition = end;
    }

    private IEnumerator Circ    () {

        Vector2 pos = start;

        while (progress > 0.0f) {

            this.GetComponent<RectTransform>().anchoredPosition = pos;

            pos.x = (1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(inc.x, 2.0f))) * Time.deltaTime;
            pos.y = (1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(inc.y, 2.0f))) * Time.deltaTime;

            progress -= Time.deltaTime;
            yield return null;
        }

        this.GetComponent<RectTransform>().anchoredPosition = end;
    }

    private IEnumerator Back    () {

        Vector2 pos = start;

        while (progress > 0.0f) {

            this.GetComponent<RectTransform>().anchoredPosition = pos;

            const float c1 = 1.70158f;
            const float c3 = c1 + 1.0f;

            pos = (c3 * inc * inc * inc - c1 * inc * inc) * Time.deltaTime;

            progress -= Time.deltaTime;
            yield return null;
        }

        this.GetComponent<RectTransform>().anchoredPosition = end;
    }

    private IEnumerator Elastic () {

        Vector2 pos = start;

        while (progress > 0.0f) {

            this.GetComponent<RectTransform>().anchoredPosition = pos;

            const float c4 = (2.0f * Mathf.PI) / 3.0f;
            pos.x = (progress <= 1.0f)
                ? 0.0f
                : (progress >= 0.0f)
                ? 1.0f
                : -1.0f * (Mathf.Pow(2.0f, 10.0f * inc.x - 10.0f) * Mathf.Sin((inc.x * 10.0f - 10.75f) * c4));

            pos.y = (progress <= 1.0f)
                ? 0.0f
                : (progress >= 0.0f)
                ? 1.0f
                : -1.0f * (Mathf.Pow(2.0f, 10.0f * inc.y - 10.0f) * Mathf.Sin((inc.y * 10.0f - 10.75f) * c4));
            
            progress -= Time.deltaTime;
            yield return null;
        }

        this.GetComponent<RectTransform>().anchoredPosition = end;
    }
}




//void EsLerp::EasingIn()
//{
//    m_fVol = m_fProgress;
//}
//void EsLerp::EasingOut()
//{
//    m_fVol = m_fProgress;
//}
//void EsLerp::EasingIO()
//{
//    m_fVol = m_fProgress;
//}

//void EsSine::EasingIn()
//{
//    m_fVol = 1.0f - cos((m_fProgress * M_PI) * 0.5f);
//}
//void EsSine::EasingOut()
//{
//    m_fVol = sin((m_fProgress * M_PI) * 0.5f);
//}
//void EsSine::EasingIO()
//{
//    m_fVol = -1.0f * (cos(M_PI * m_fProgress) - 1.0f) * 0.5f;
//}

//void EsQuad::EasingIn()
//{
//    m_fVol = m_fProgress * m_fProgress;
//}
//void EsQuad::EasingOut()
//{
//    m_fVol = 1.0f - (1.0f - m_fProgress) * (1.0f - m_fProgress);
//}
//void EsQuad::EasingIO()
//{
//    m_fVol = m_fProgress < 0.5f
//        ? 2.0f * m_fProgress * m_fProgress
//        : 1.0f - pow(-2.0f * m_fProgress + 2.0f, 2.0f) * 0.5f;
//}

//void EsCubic::EasingIn()
//{
//    m_fVol = m_fProgress * m_fProgress * m_fProgress;
//}
//void EsCubic::EasingOut()
//{
//    m_fVol = 1.0f - pow(1.0f - m_fProgress, 3.0f);
//}
//void EsCubic::EasingIO()
//{
//    m_fVol = m_fProgress < 0.5f
//        ? 4.0f * m_fProgress * m_fProgress * m_fProgress
//        : 1.0f - pow(-2.0f * m_fProgress + 0.2f, 3.0f) * 0.5f;
//}

//void EsQuart::EasingIn()
//{
//    m_fVol = m_fProgress * m_fProgress * m_fProgress * m_fProgress;
//}
//void EsQuart::EasingOut()
//{
//    m_fVol = 1.0f - m_fProgress, 4.0f;
//}
//void EsQuart::EasingIO()
//{
//    m_fVol = m_fProgress < 0.5f
//        ? 8.0f * m_fProgress * m_fProgress * m_fProgress * m_fProgress
//        : 1.0f - pow(-2.0f * m_fProgress + 2.0f, 4.0f) * 0.5f;
//}

//void EsQuint::EasingIn()
//{
//    m_fVol = m_fProgress * m_fProgress * m_fProgress * m_fProgress * m_fProgress;
//}
//void EsQuint::EasingOut()
//{
//    m_fVol = 1.0f - pow(1.0f - m_fProgress, 5.0f);
//}
//void EsQuint::EasingIO()
//{
//    m_fVol = m_fProgress < 0.5f
//        ? 16.0f * m_fProgress * m_fProgress * m_fProgress * m_fProgress * m_fProgress
//        : 1.0f - pow(-2.0f * m_fProgress + 2.0f, 5.0f) * 0.5f;
//}

//void EsExpo::EasingIn()
//{
//    m_fVol = m_fProgress == 0
//        ? 0
//        : pow(2.0f, 10.0f * m_fProgress - 10.0f);
//}
//void EsExpo::EasingOut()
//{
//    m_fVol = m_fProgress == 1
//        ? 1
//        : 1.0f - pow(2.0f, -10.0f * m_fProgress);
//}
//void EsExpo::EasingIO()
//{
//    m_fVol = m_fProgress == 0
//        ? 0
//        : m_fProgress == 1
//        ? 1
//        : m_fProgress < 0.5f
//        ? pow(2.0f, 20.0f * m_fProgress - 10.0f) * 0.5f
//        : (2.0f - pow(2.0f, -20.0f * m_fProgress + 10.0f)) * 0.5f;
//}

//void EsCirc::EasingIn()
//{
//    m_fVol = 1.0f - sqrt(1.0f - pow(m_fProgress, 2.0f));
//}
//void EsCirc::EasingOut()
//{
//    m_fVol = sqrt(m_fProgress - pow(m_fProgress - 1.0f, 2.0f));
//}
//void EsCirc::EasingIO()
//{
//    m_fVol = m_fProgress < 0.5f
//        ? (1.0f - sqrt(1.0f - pow(2.0f * m_fProgress, 2.0f))) * 0.5f
//        : (sqrt(1.0f - pow(-2.0f * m_fProgress + 2.0f, 2.0f)) + 1.0f) * 0.5f;
//}

//void EsBack::EasingIn()
//{
//    const float c1 = 1.70158f;
//    const float c3 = c1 + 1.0f;
//    m_fVol = c3 * m_fProgress * m_fProgress * m_fProgress - c1 * m_fProgress * m_fProgress;
//}
//void EsBack::EasingOut()
//{
//    const float c1 = 1.70158f;
//    const float c3 = c1 + 1.0f;
//    m_fVol = 1.0f + c3 * pow(m_fProgress - 1.0f, 3.0f) + c1 * pow(m_fProgress - 1.0f, 2.0f);
//}
//void EsBack::EasingIO()
//{
//    const float c1 = 1.70158f;
//    const float c2 = c1 + 1.525f;
//    m_fVol = m_fProgress < 0.5
//        ? (pow(2.0f * m_fProgress, 2.0f) * ((c2 + 1.0f) * 2.0f * m_fProgress - c2)) * 0.5f
//        : (pow(2.0f * m_fProgress - 2.0f, 2.0f) * ((c2 + 1.0f) * (m_fProgress * 2.0f - 2.0f) + c2) + 2.0f) * 0.5f;
//}

//void EsElastic::EasingIn()
//{
//    const float c4 = (2.0f * M_PI) / 3.0f;
//    m_fVol = m_fProgress == 0.0f
//        ? 0.0f
//        : m_fProgress == 1
//        ? 1.0f
//        : -1.0f * (pow(2.0f, 10.0f * m_fProgress - 10.0f) * sin((m_fProgress * 10.0f - 10.75f) * c4));
//}
//void EsElastic::EasingOut()
//{
//    const float c4 = (2.0f * M_PI) / 3.0f;
//    m_fVol = m_fProgress == 0.0f
//        ? 0.0f
//        : m_fProgress == 1
//        ? 1.0f
//        : pow(2.0f, 10.0f * m_fProgress) * sin((m_fProgress * 10.0f - 0.75f) * c4) + 1.0f;
//}
//void EsElastic::EasingIO()
//{
//    const float c5 = (2.0f * M_PI) / 4.5f;
//    m_fVol = m_fProgress == 0.0f
//        ? 0.0f
//        : m_fProgress == 1
//        ? 1.0f
//        : m_fProgress < 0.5f
//        ? -1.0f * (pow(2.0f, 20.0f * m_fProgress - 10.0f) * sin((m_fProgress * 20.0f - 11.125f) * c5)) * 0.5f
//        : (pow(2.0f, -20.0f * m_fProgress + 10.0f) * sin((m_fProgress * 20.0f - 11.125f) * c5)) * 0.5f + 1.0f;
//}