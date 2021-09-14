using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRendar : MonoBehaviour {

    public Material mat;

    private void Update() { Graphics.Blit(null, null, mat); }
}
