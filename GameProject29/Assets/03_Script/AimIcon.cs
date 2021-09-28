using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class AimIcon : MonoBehaviour {

    [SerializeField]
    private GameObject      parent;
    private RectTransform   rectTransform;
    private new Camera      camera;
    private GameObject      aim;
    
    private Vector2         rightStick;
    private Vector3         aimPos;

    private Vector3         target;
    private float           length;
    
    void Start() {
       
        rectTransform   = GetComponent<RectTransform>();
        camera          = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        parent          = gameObject.transform.parent.gameObject;
        length          = 10.0f;
        aimPos          = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f);
    }
    
    private void Update() {
        AimTarget();
    }

    public  void OnAimPosition(InputAction.CallbackContext context) {
        rightStick = context.ReadValue<Vector2>();
    }

    private void AimTarget() {

        aimPos.x    += rightStick.x * 10.0f;
        aimPos.y    += rightStick.y * 10.0f;
        aimPos.z    =  length;

        this.GetComponent<Image>().enabled = false;
        aim = parent.GetComponent<PlayerUI>().GetPlayer().GetComponent<Player>().GetAim();

        if (aim.activeSelf) {
            this.GetComponent<Image>().enabled = true;
            rectTransform.transform.position = aimPos;
        }
        else {
            aimPos = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f);
        }

        aim.transform.position = camera.ScreenToWorldPoint(aimPos);
    }
}
