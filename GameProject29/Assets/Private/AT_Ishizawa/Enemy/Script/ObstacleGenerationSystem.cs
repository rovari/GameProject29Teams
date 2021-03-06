using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerationSystem : MonoBehaviour
{
    [SerializeField, Header("障害物召喚Enemy(左)")] GameObject _leftenemy;
    [SerializeField, Header("障害物召喚Enemy(右)")] GameObject _rightenemy;
    [SerializeField, Header("障害物(左右交互に割当)")] GameObject[] _obsobjects;
    [SerializeField, Header("障害物モデルサイズ")] float _modelsize;

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
        if(_leftenemy != null && _rightenemy != null)   //途中撃破check
        {
            if (Vector3.Distance(_rightenemy.GetComponent<Enemy>().GetSetPosition, _leftenemy.GetComponent<Enemy>().GetSetPosition) <= 2.4f) //2体の障害物召喚Enemyが接近したら障害物生成start
            {
                _setflag = true;
            }

            if (_setflag)
            {
                if (Vector3.Distance(_rightenemy.GetComponent<Enemy>().GetSetPosition, _leftenemy.GetComponent<Enemy>().GetSetPosition) >= _modelsize * 2 * _counter)   //2体の障害物召喚Enemyの距離に応じて障害物生成
                {
                    _obsobjects[(_counter - 1) * 2].SetActive(true);
                    _obsobjects[(_counter - 1) * 2 + 1].SetActive(true);
                    _counter++;
                }

                if (Vector3.Distance(_rightenemy.GetComponent<Enemy>().GetSetPosition, _leftenemy.GetComponent<Enemy>().GetSetPosition) >= 20.0f)   //2体の障害物召喚Enemyの距離が一定以上離れたら
                {
                    _setflag = false;
                }
            }
        }
    }
}
