using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField, Header("�C�x���g�p�I�u�W�F�N�g")] GameObject g;

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
            //1Player���[�h�֑J�ڂ���R�[�h�ǉ�
        }
        else if (g.name == "2Player")
        {
            //2Player���[�h�֑J�ڂ���R�[�h�ǉ�
        }
    }
}
