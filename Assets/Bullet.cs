using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour    
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        Vector3 playerPos = player.transform.position;
        transform.rotation = Quaternion.LookRotation(playerPos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * 10 * Time.deltaTime;
    }
}
