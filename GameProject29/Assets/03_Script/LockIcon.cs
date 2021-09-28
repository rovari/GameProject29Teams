using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockIcon : MonoBehaviour {
    [SerializeField]
    private GameObject      parent;
    private RectTransform   rectTransform;
    private new Camera      camera;
    [SerializeField]
    private GameObject      target;

    public  int             listNum;

    void Start() {
        GetComponent<Image>().enabled = false;

        rectTransform   = GetComponent<RectTransform>();
        camera          = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        parent          = gameObject.transform.parent.gameObject;
    }
    
    void Update() {
        ForcasTarget();
    }

    void ForcasTarget() {

        target = null;
        GetComponent<Image>().enabled = false;

        GameObject targetList = parent.GetComponent<PlayerUI>().GetPlayer().transform.Find("TargetList").gameObject;

        if (targetList.activeSelf) {
            target = targetList.GetComponent<TargetList>().GetTarget(listNum);
            GetComponent<Image>().enabled = true;
        }

        if (target != null) rectTransform.position = RectTransformUtility.WorldToScreenPoint(camera, target.transform.position);
    }
}
