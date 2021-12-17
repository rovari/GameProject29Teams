using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[System.Serializable]
public class PopMarker : Marker, INotification {

    public List<int> indexes;
        
    public PropertyName id {
        get { return new PropertyName("method"); }
    }
}
