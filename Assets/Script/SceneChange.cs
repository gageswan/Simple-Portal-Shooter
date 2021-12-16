using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    public int sceneToGoTo;


    public void GoToNewScene() {
        SceneManager.LoadScene(sceneToGoTo);
    }

    public void Exit() { 
        Application.Quit();
    }
}
