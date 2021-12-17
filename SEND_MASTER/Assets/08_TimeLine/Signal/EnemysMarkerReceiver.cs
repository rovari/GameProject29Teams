using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EnemysMarkerReceiver : MonoBehaviour, INotificationReceiver {

    private EnemysSystem enemysSystem;

    private void Start() {
        enemysSystem = GetComponent<EnemysSystem>();
    }

    public void OnNotify(Playable origin, INotification notification, object context) {

        var element = notification as PopMarker;
        if (element == null)
            return;

        enemysSystem.PopMarker(element.indexes);
    }
}