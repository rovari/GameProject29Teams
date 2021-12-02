using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum HUKIDASHI {

    NORMAL,
    ROUND,
    THORN,
    THINK,
}

[System.Serializable]
public struct ChatData {

    HUKIDASHI   _type;
    float       _ActiveInterval;
    string      _chatString;
}

public class TalkSystem : MonoBehaviour {

    // [ Hide Field   ] ===============================================

    // [ Show Field   ] ===============================================
    [SerializeField] private List<string> chatDatas;

    // [ Property     ] ===============================================

    // [ Unity Method ] ===============================================

    // [ User  Method ] ===============================================
}
