using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rezult_score : MonoBehaviour
{
    public Vector3 start_position;
    public Vector3 end_position;

    public Vector3 start_scale;
    public Vector3 end_scale;

    public float MoveTime;

    float MoveX, MoveY;

    // Start is called before the first frame update
    void Start()
    {
        Transform mytransform = this.transform;
       // mytransform.position = start_position;

        MoveX = start_position.x - end_position.x;
        MoveY = start_position.y - end_position.y;

        Debug.Log(mytransform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        Transform mytransform = this.transform;

        Vector3 pos = new Vector3(start_position.x + (MoveX / MoveTime * Time.deltaTime), start_position.y, start_position.z);

        mytransform.position = pos;


        //transform.position(start_position.x + (MoveX / MoveTime * Time.deltaTime), start_position.y, start_position.z);
        
    }
}
