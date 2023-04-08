using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu: MonoBehaviour {
    void Start() {
        
    }

    void Update() {
        
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void HyperLink(string url) {
        Application.OpenURL(url);
    }
}
