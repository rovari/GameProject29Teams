using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject originObject;

    public GameMode currentGameMode;
    public int MultiplayerNumber;
    public float Posinterval = 0.5f;

    float nowinteval =0;

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
                Instantiate(originObject, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                break;

            case GameMode.LocalMultiplayer:
                for (float i = 0; MultiplayerNumber > i; i++)
                {
                    Instantiate(originObject, new Vector3(i+nowinteval, 0.0f, 0.0f), Quaternion.identity);
                    nowinteval = nowinteval + Posinterval;
                }
                break;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
