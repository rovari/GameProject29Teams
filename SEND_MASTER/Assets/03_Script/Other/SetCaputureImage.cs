using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SetCaputureImage : MonoBehaviour {

    private void Start() {

        byte[] image = File.ReadAllBytes("Assets/00_System/capture.png");

        Texture2D tex = new Texture2D(0, 0);
        tex.LoadImage(image);

        Sprite texture_sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
    
        GetComponent<Image>().sprite = texture_sprite;
    }
}
