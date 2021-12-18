using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class EnemyMarkerReceiver : MonoBehaviour, INotificationReceiver {
    
    private EnemyMove enemyMove;
    private EnemyFire enemyFire;

    private void Start() {
        enemyMove = GetComponent<EnemyMove>();
        enemyFire = GetComponent<EnemyFire>();
    }

    public void OnNotify(Playable origin, INotification notification, object context) {

        var element = notification as EnemyMarker;
        if (element == null)
            return;
        
        switch (element.type) {

            case ENEMY_MARKER.MOVE:
                enemyMove.ConstantMove(element.move);
                break;
                
            case ENEMY_MARKER.FIRE:
                enemyFire.LunchMarker(element.index);
                break;

            default: break;
        }

    }
}