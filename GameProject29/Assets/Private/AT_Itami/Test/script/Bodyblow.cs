using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bodyblow : MonoBehaviour
{
    public static float dtime;

    GameObject m_PlayerObject; //�v���C���[�I�u�W�F�N�g
    Transform m_Transform; //�X�N���v�g��̃g�����X�t�H�[��
    Vector3     pos; //�u����
    bool flag = true;�@//�t���O
    private Vector3 velocity;
    Vector3 acce = Vector3.zero;//������
    public float period = 1.5f; //���e����

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerObject = GameObject.FindGameObjectWithTag("Player");//�v���C���[�̏��擾
        m_Transform = this.transform;
        dtime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dtime += Time.deltaTime;

        if(dtime>=5&&flag==true)
        {
            flag = false;
            pos = m_PlayerObject.transform.position;
            Debug.Log("�l�F"+(pos.x,pos.y,pos.z).ToString());
            Vector3 diff = pos - m_Transform.transform.position;
           
            acce += (diff - velocity * period) * 10 
                / (period * period);

        }
       
            m_Transform.position += acce * Time.deltaTime;


    }
}
