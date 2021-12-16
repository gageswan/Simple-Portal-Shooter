using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulMovement : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 3f;


    public GameObject player;
    GameObject ghoul;

    public float ghoulSpeed = .02F;

    private float startTime;

    public float distance; 
    private float distanceToP; 
    private float distanceToP1; 
    private float distanceFromPlayerToP; 
    private float distanceFromPlayerToP1;
    public float distThruP;
    public float distThruP1;

    private bool playerClosest;
    private bool pClosest;
    private bool p1Closest;
    float shotTime = 0.0f;

    public GameObject portal;
    public GameObject portal1;




    void Fire() {
        GameObject instBullet = Instantiate(projectile, transform.position, Quaternion.identity);
        Rigidbody instBulletRB = instBullet.GetComponent<Rigidbody>();

        instBulletRB.AddForce(ghoul.transform.forward * speed);
        Destroy(instBullet, 3f);
    }
        // Start is called before the first frame update
    void Start()
    {
        ghoul = this.gameObject;

        portal = GameObject.Find("Portal");
        portal1 = GameObject.Find("Portal1");

        startTime = Time.time;

    }

    // Update is called once per frame
    void Update() {
        if (shotTime >= 1.0) {
            Fire();
            shotTime = 0;
        }
        else {
            shotTime += Time.deltaTime;
        }

        transform.LookAt(player.transform.position);

        float distCovered = (Time.time - startTime) * ghoulSpeed;

        //float fractionOfJourney = distCovered / distance;
        distance = Vector3.Distance(ghoul.transform.position, player.transform.position);

        distanceToP = Vector3.Distance(ghoul.transform.position, portal.transform.position);
        distanceToP1 = Vector3.Distance(ghoul.transform.position, portal1.transform.position); 

        distanceFromPlayerToP = Vector3.Distance(player.transform.position, portal.transform.position);
        distanceFromPlayerToP1 = Vector3.Distance(player.transform.position, portal1.transform.position);

        distThruP = distanceToP + distanceFromPlayerToP1;
        distThruP1 = distanceToP1 + distanceFromPlayerToP;

        if(distance < distThruP && distance < distThruP1) {
            playerClosest = true;
            pClosest = false;
            p1Closest = false;
        }        
        if(distThruP < distance && distThruP < distThruP1) {
            playerClosest = false;
            pClosest = true;
            p1Closest = false;
        }        
        if(distThruP1 < distance && distThruP1 < distThruP) {
            playerClosest = false;
            pClosest = false;
            p1Closest = true;
        }

        //ghoul.transform.position = Vector3.Lerp(ghoul.transform.position, player.transform.position, fractionOfJourney);
        if (playerClosest) {
            ghoul.transform.position = Vector3.MoveTowards(ghoul.transform.position, player.transform.position, ghoulSpeed);
        }
        else if (pClosest) {
            ghoul.transform.position = Vector3.MoveTowards(ghoul.transform.position, portal.transform.position, ghoulSpeed);

        }
        else {
            ghoul.transform.position = Vector3.MoveTowards(ghoul.transform.position, portal1.transform.position, ghoulSpeed);
        }
    }
}
