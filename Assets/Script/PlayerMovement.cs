using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public PlatformGameManager pgm;

    Rigidbody rb;

    public float speed = 2.0f;
    public float jumpSpeed = 5.0f;

    [SerializeField]
    int horRotSpeed = 3;
    [SerializeField]
    int vertRotSpeed = -3;
    [SerializeField]
    Transform LookUpDown;
    [SerializeField]
    Transform Cam;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        Ray r = new Ray(transform.position, Vector3.down);

        Vector3 camForward = Cam.forward;
        Vector3 camRight = Cam.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = (camForward * v * speed) + (camRight * h * speed);

        RaycastHit hit;

        //Orientation XY
        {
            //transform.Rotate(new Vector3(0, x* horRotSpeed, 0));
            //LookUpDown.Rotate(new Vector3(-y * vertRotSpeed, 0, 0));

            transform.rotation *= Quaternion.Euler(0, horRotSpeed * x, 0);
            LookUpDown.rotation *= Quaternion.Euler(vertRotSpeed * -y, 0, 0);
        }


        //Movement XY
        {
            rb.velocity = new Vector3(
                moveDirection.x,
                rb.velocity.y,
                moveDirection.z);
        }

        //Jump Validation
        if (Input.GetButtonDown("Jump")) {
            if (Physics.Raycast(r, out hit, 1f)) {
                if (hit.collider.CompareTag("Surface")) {
                    Jump(); }
            }
        }

/*        if (Input.GetMouseButtonDown(0)) {
            if (pgm.playerAmmo > 0) {
                pgm.playerAmmo--;
            }
        }*/
    }
    void Jump() {
        rb.velocity = new Vector3(
            rb.velocity.x,
            jumpSpeed,
            rb.velocity.y
            );
    }
} 
