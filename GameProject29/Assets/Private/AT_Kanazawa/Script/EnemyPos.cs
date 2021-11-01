using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPos : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos;
        pos.x = 0;
        pos.y = 0;
        pos.z = 5f;
        Transform myTransform = this.transform;

        myTransform.position = Player.transform.position + pos;

       
    }
}
