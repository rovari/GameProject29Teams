using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour {
    

    // Show  Property =============================================
    [SerializeField] private int                _sequensNumber;
    [SerializeField] private SceneObject        _loadingScene;
    [SerializeField] private List<SceneObject>  _sceneSequens;

    private void Start() {
        
        if(_sceneSequens.Count > 0)SceneManager.LoadScene(_sceneSequens[_sequensNumber]);
    }
    
    // User  Method ===============================================




}
