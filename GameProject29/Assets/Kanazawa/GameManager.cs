using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject originObject;

    public GameMode currentGameMode;

    public enum GameMode
    {
        SinglePlayer,
        LocalMultiplayer
    }

    // Start is called before the first frame update
    void Start()
    {
        switch (currentGameMode)
        {
            case GameMode.SinglePlayer:

                break;

            case GameMode.LocalMultiplayer:
                Instantiate(originObject, new Vector3(-1.0f, 0.0f, 0.0f), Quaternion.identity);
                break;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
