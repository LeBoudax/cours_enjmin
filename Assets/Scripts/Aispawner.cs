using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aispawner : MonoBehaviour
{
    [Tooltip("préfabspawn")]
    public Transform character;
    [Tooltip("point spawn")]
    public Transform spawnPoint;
    private float timeSpawn = 0;
    public float timeNextSpawn = 1;
    private int nbSpawned = 0;
    [Range(1,3)]
    public int[] vagues = new int[0];
    private int currentVague = 0;
    [Range(30,50)]
    private float timeVague = 0;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    Transform SpawnAI()
    {
        Transform ai = GameObject.Instantiate<Transform>(character);
        ai.position = transform.position;
        ai.rotation = transform.rotation;
        return ai;
    }

    void AddPichenette(Transform ai,Vector3 pichenette)
    { Rigidbody rb = ai.GetComponent<Rigidbody>();
        rb.AddForce(pichenette, ForceMode.Impulse);

    }
    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time > timeNextSpawn)
        {
            Transform ai = SpawnAI();
            Vector3 Pichenette = ai.forward * 10;
            AddPichenette(ai, Pichenette);

            time = 0;
        }
    }

    

}
