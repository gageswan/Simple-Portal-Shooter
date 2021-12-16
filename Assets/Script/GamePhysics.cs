using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePhysics : MonoBehaviour {

    GameObject playerBox;

    public PlayerMovement playerMovement;
    public PlatformGameManager pfGM;

    // Start is called before the first frame update
    void Start(){
        playerBox = this.gameObject;
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(playerBox){

            if (collision.gameObject.CompareTag("Token")) {
                Destroy(collision.gameObject);
                pfGM.tokenCollection++;
            }

            if (collision.gameObject.CompareTag("Bullets")) {
                Destroy(collision.gameObject);
                pfGM.playerAmmo += 30;
            }

            if (collision.gameObject.CompareTag("Hazard")) {
                pfGM.playerHealth--;
            }

            if (collision.gameObject.CompareTag("KillZone")) {
                playerBox.transform.position = new Vector3(-49, 16, 19);
            }
        }
    }
}
