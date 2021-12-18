using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public enum ENEMY_MARKER {
    MOVE,
    FIRE
}

[System.Serializable]
public class EnemyMarker : Marker, INotification {

    public ENEMY_MARKER type;
    public ENEMY_MOVE   move;
    public int          index;

    public PropertyName id {

        get { return new PropertyName("method"); }
    }
}