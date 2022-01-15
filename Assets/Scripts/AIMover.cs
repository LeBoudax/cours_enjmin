using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMover : MonoBehaviour
{
    [Tooltip("vitesse de déplacement")]
    public float linearSpeed = 6;
    [Tooltip("vitesse de rotation")]
    public float angularSpeed = 1;
    private Transform player;
    public float life = 100;
    // Start is called before the first frame update
    void Start()
    {
        GameObject goPlayer = GameObject.FindGameObjectWithTag("Player");
        player = goPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        { 
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 dirPlayer = player.position - transform.position;
            dirPlayer = dirPlayer.normalized;

            float angle = Vector3.SignedAngle(dirPlayer, transform.forward, transform.up);

           
               

          
                rb.AddTorque(transform.up* 5 );

             Animator anim = GetComponent<Animator>();
                if(anim !=null)
            {
                anim.SetFloat("speed", rb.velocity.magnitude);
            }
        }
    }
}
