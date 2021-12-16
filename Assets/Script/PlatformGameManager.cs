using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformGameManager : MonoBehaviour
{
    public int tokenCollection = 0;
    public int playerAmmo = 30;
    public int playerMaxHealth = 10;
    public int playerHealth = 10;

   /* public static PlatformGameManager instance;

    private void Start() {
        if (instance == null) {
            instance = this;
        }

        if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }*/

    private void Update() {
        if (tokenCollection == 3) {
            SceneManager.LoadScene(2);
        }

        if (playerHealth == 0) {
            SceneManager.LoadScene(2);
        }
    }
}

