using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField, Header("イベント用オブジェクト")] GameObject g;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EventSystem ev = EventSystem.current;
        g = ev.currentSelectedGameObject;
        
        if (g.name == "1Player")
        {
            //1Playerモードへ遷移するコード追加
        }
        else if (g.name == "2Player")
        {
            //2Playerモードへ遷移するコード追加
        }
    }
}
