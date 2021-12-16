using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bodyblow : MonoBehaviour
{
    public static float dtime;

    GameObject m_PlayerObject; //プレイヤーオブジェクト
    public Transform m_Transform; //スクリプト先のトランスフォーム
    Vector3     pos; //置き場
    bool flag = true;　//フラグ
    private Vector3 velocity;
    Vector3 acce = Vector3.zero;//初期化
    public float period = 1.5f; //着弾時間
    public float sTime;//動き始めの時間

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerObject = GameObject.FindGameObjectWithTag("Player");//プレイヤーの情報取得
        //m_Transform = this.transform;
        dtime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dtime += Time.deltaTime;

        if(dtime>= sTime && flag==true)
        {
            flag = false;
            pos = m_PlayerObject.transform.position;
            Debug.Log("値："+(pos.x,pos.y,pos.z).ToString());
            Vector3 diff = pos - m_Transform.transform.position;
           
            acce += (diff - velocity * period) * 10 
                / (period * period);

        }
       
            m_Transform.position += acce * Time.deltaTime;


    }
}
