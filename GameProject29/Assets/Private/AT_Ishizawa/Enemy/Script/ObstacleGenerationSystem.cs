using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerationSystem : MonoBehaviour
{
    [SerializeField, Header("��Q������Enemy(��)")] GameObject _leftenemy;
    [SerializeField, Header("��Q������Enemy(�E)")] GameObject _rightenemy;
    [SerializeField, Header("��Q��(���E���݂Ɋ���)")] GameObject[] _obsobjects;
    [SerializeField, Header("��Q�����f���T�C�Y")] float _modelsize;

    private bool _setflag;
    private int _counter;

    // Start is called before the first frame update
    void Start()
    {
        _setflag = false;
        _counter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(_leftenemy != null && _rightenemy != null)   //�r�����jcheck
        {
            if (Vector3.Distance(_rightenemy.GetComponent<Enemy>().GetSetPosition, _leftenemy.GetComponent<Enemy>().GetSetPosition) <= 2.4f) //2�̂̏�Q������Enemy���ڋ߂������Q������start
            {
                _setflag = true;
            }

            if (_setflag)
            {
                if (Vector3.Distance(_rightenemy.GetComponent<Enemy>().GetSetPosition, _leftenemy.GetComponent<Enemy>().GetSetPosition) >= _modelsize * 2 * _counter)   //2�̂̏�Q������Enemy�̋����ɉ����ď�Q������
                {
                    _obsobjects[(_counter - 1) * 2].SetActive(true);
                    _obsobjects[(_counter - 1) * 2 + 1].SetActive(true);
                    _counter++;
                }

                if (Vector3.Distance(_rightenemy.GetComponent<Enemy>().GetSetPosition, _leftenemy.GetComponent<Enemy>().GetSetPosition) >= 20.0f)   //2�̂̏�Q������Enemy�̋��������ȏ㗣�ꂽ��
                {
                    _setflag = false;
                }
            }
        }
    }
}
