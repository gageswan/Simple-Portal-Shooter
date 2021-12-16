using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public PlatformGameManager pgm;
    public GameObject portal;
    public GameObject portal1;

    // Start is called before the first frame update
    void Start() {
        portal = GameObject.Find("Portal");
        portal1 = GameObject.Find("Portal1");
    }

    // Update is called once per frame
    void Update() {

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 50;

        Ray r = new Ray(transform.position, forward);

        ///Debug.DrawRay(transform.position, forward, Color.green);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(r, out hit, 100f)) {
                if (hit.collider.CompareTag("Surface")) {
                    portal.transform.localPosition = new Vector3(hit.point.x + .01f, 
                        hit.point.y +.01f, hit.point.z + .01f);
                    if (portal.transform.eulerAngles.y < 180) {
                        portal.transform.localPosition = new Vector3(hit.point.x - .01f,
                        hit.point.y - .01f, hit.point.z - .01f);
                    }
                    portal.transform.forward = -hit.normal;
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            if (Physics.Raycast(r, out hit, 100f)) {
                if (hit.collider.CompareTag("Surface")) {
                    portal1.transform.position = new Vector3(hit.point.x + .01f,
                        hit.point.y + .01f, hit.point.z + .01f);
                    if (portal1.transform.eulerAngles.y < 180) {
                        portal1.transform.localPosition = new Vector3(hit.point.x - .01f,
                        hit.point.y - .01f, hit.point.z - .01f);
                    }
                    portal1.transform.forward = -hit.normal;
                }
            }

        }
    }
}
/*
if (Input.GetMouseButtonDown(0)) {
    //if (pgm.playerAmmo > 0) {
    //pgm.playerAmmo--;
    if (Physics.Raycast(r, out hit, 100f)) {
        if (hit.collider.CompareTag("Surface")) {
            portal.transform.localPosition = hit.point;
            *//*                    portal.transform.localPosition =  new Vector3(portal.transform.localPosition.x,
                                    hit.transform.localPosition.y + 1, portal.transform.localPosition.z);*//*
            portal.transform.forward = hit.normal;

            *//*                    portal.transform.eulerAngles = new Vector3(portal.transform.eulerAngles.x,
                                    hit.normal.y, portal.transform.eulerAngles.z);*//*
        }
        *//*                    if (hit.collider.CompareTag("Token")) {
                                Destroy(hit.collider.gameObject);
                                pgm.tokenCollection++;
                            }*//*
        ///Debug.Log("Hit " + hit.collider.gameObject.name, hit.collider.gameObject);
    }

    // }
}

if (Input.GetMouseButtonDown(1)) {
    *//*            if (pgm.playerAmmo > 0) {
                    pgm.playerAmmo--;*//*
    if (Physics.Raycast(r, out hit, 100f)) {
        if (hit.collider.CompareTag("Surface")) {
            portal1.transform.localPosition = hit.point;
            portal1.transform.forward = -hit.normal;
            //Destroy(hit.collider.gameObject);
        }
        *//*                    if (hit.collider.CompareTag("Token")) {
                                Destroy(hit.collider.gameObject);
                                pgm.tokenCollection++;
                            }*//*
    }
    //}
}
    }
*/