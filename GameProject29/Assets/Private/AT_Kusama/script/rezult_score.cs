using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class rezult_score : MonoBehaviour
{
    //public RectTransform TextDate;

    public Vector3 start_position;
    public Vector3 end_position;

    public Vector3 start_scale;
    public Vector3 end_scale;

    public float MoveTime;

    float MoveX, MoveY;

    // Start is called before the first frame update
    void Start()
    {
        Transform myTransform = this.transform;

        start_position += new Vector3(960, 540, 0);
        end_position += new Vector3(960, 540, 0);

        myTransform.position = start_position;

        myTransform.localScale = start_scale;
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;

        myTransform.DOMove(end_position, MoveTime);//.SetEase(Ease.InOutQuint);
        myTransform.DOScale(end_scale, MoveTime);//.SetEase(Ease.InOutQuint);

        
    }
}
