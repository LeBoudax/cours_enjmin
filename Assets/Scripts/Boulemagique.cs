using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulemagique : MonoBehaviour

{
    public float puissance = 100;
    public void OnCollisionEnter(Collision collision)
    {
        AIMover other = collision.gameObject.GetComponent<AIMover>();
        if(other != null)
        {
            other.life -= puissance;
            ScoreScript.ScoreValue += 1;
        
            

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
