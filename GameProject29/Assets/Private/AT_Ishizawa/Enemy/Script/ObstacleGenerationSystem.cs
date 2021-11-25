using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerationSystem : MonoBehaviour
{
    [SerializeField, Header("áŠQ•¨¢Š«Enemy(¶)")] GameObject _leftenemy;
    [SerializeField, Header("áŠQ•¨¢Š«Enemy(‰E)")] GameObject _rightenemy;
    [SerializeField, Header("áŠQ•¨(¶‰EŒğŒİ‚ÉŠ„“–)")] GameObject[] _obsobjects;
    [SerializeField, Header("áŠQ•¨ƒ‚ƒfƒ‹ƒTƒCƒY")] float _modelsize;

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
        if(_leftenemy != null && _rightenemy != null)   //“r’†Œ‚”jcheck
        {
            if (Vector3.Distance(_rightenemy.GetComponent<Enemy>().GetSetPosition, _leftenemy.GetComponent<Enemy>().GetSetPosition) <= 2.4f) //2‘Ì‚ÌáŠQ•¨¢Š«Enemy‚ªÚ‹ß‚µ‚½‚çáŠQ•¨¶¬start
            {
                _setflag = true;
            }

            if (_setflag)
            {
                if (Vector3.Distance(_rightenemy.GetComponent<Enemy>().GetSetPosition, _leftenemy.GetComponent<Enemy>().GetSetPosition) >= _modelsize * 2 * _counter)   //2‘Ì‚ÌáŠQ•¨¢Š«Enemy‚Ì‹——£‚É‰‚¶‚ÄáŠQ•¨¶¬
                {
                    _obsobjects[(_counter - 1) * 2].SetActive(true);
                    _obsobjects[(_counter - 1) * 2 + 1].SetActive(true);
                    _counter++;
                }

                if (Vector3.Distance(_rightenemy.GetComponent<Enemy>().GetSetPosition, _leftenemy.GetComponent<Enemy>().GetSetPosition) >= 20.0f)   //2‘Ì‚ÌáŠQ•¨¢Š«Enemy‚Ì‹——£‚ªˆê’èˆÈã—£‚ê‚½‚ç
                {
                    _setflag = false;
                }
            }
        }
    }
}
