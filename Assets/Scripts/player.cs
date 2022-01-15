using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public Transform objectToThrow;
    [Tooltip("vitesse de déplacement")]
    public float linearSpeed = 6;
    [Tooltip("vitesse de rotation")]
    public float angularSpeed = 1;
    public Transform playerCam;
    public bool isGrounded;
    public Transform tir;


    // Start is called before the first frame update
    void Start()
    {
        if (playerCam == null)
        {
            Camera cam = transform.GetComponentInChildren<Camera>();
            playerCam = cam.transform;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // Update is called once per frame
    private void Update()
    {

        // lancé 

         if(Input.GetButtonDown("Fire1"))
        {
            Transform obj = GameObject.Instantiate<Transform>(objectToThrow);
            obj.position = tir.position + tir.forward;
            obj.GetComponent<Rigidbody>().AddForce(tir.forward * 30, ForceMode.Impulse);
        }
      


        // sauve la rotation
        Quaternion lastRotation = playerCam.localRotation;

        // baise/lève la tete 
        float rot = Input.GetAxis("Mouse Y") * -10;

        Quaternion q = Quaternion.AngleAxis(rot, playerCam.right);
        playerCam.rotation = q * playerCam.rotation;

        // regarde droite gauche

        float rotx = Input.GetAxis("Mouse X") * 10;

        Quaternion qx = Quaternion.AngleAxis(rotx, transform.up);
        transform.rotation = qx * transform.rotation;

        // est ce qu'on à la tete a l'envers ? 

        Vector3 forwardCam = playerCam.forward;
        Vector3 forwardPlayer = transform.forward;

        float regardevant = Vector3.Dot(forwardCam, forwardPlayer);
        if (regardevant < 0.0f)
        {
            playerCam.localRotation = lastRotation;
        }


    }
    private void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        Vector3 horizontalVelocity = Vector3.zero;
        horizontalVelocity += vert * transform.forward * 10;
        horizontalVelocity += hori * transform.right * 10;
        rb.velocity = new Vector3(horizontalVelocity.x,
            rb.velocity.y,
            horizontalVelocity.z);

        isGrounded = false;
        RaycastHit infos;
        bool trouve = Physics.SphereCast(transform.position + transform.up * 0.1f,
            0.05f, -transform.up, out infos, 2);
        if (trouve && infos.distance < 0.15)
            isGrounded = true;

        if (Input.GetButton("Jump"))
        {
            if (isGrounded)
            {
                rb.AddForce(transform.up * 10, ForceMode.Impulse);
                isGrounded = false;
            }
            else
            {
                if (rb.velocity.y < 3)
                {
                    rb.AddForce(transform.up * 50);
                }
            }
        }
    }
}