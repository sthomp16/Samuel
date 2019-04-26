using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

// MonoBehaviour.OnTriggerEnter

public class spawn_gen : MonoBehaviour
{
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 5f;            // configurable how long between each spawn.
    public float spawnLimit = 10;           // configurable how many spawns are allowed for the generator, default 10
    public Transform Spawn_Area;
    public GameObject Deactivator;

    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    //*
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
    }
    //*/

    void Spawn()
    {
        // Do not run if spawnpoints is depleted
        if (spawnLimit <= 0)
        {
            return;
        }
        // create enemy, on position of generator (empty object)
        Instantiate(enemy, Spawn_Area.position, Spawn_Area.rotation);
        spawnLimit = spawnLimit - 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Spawn();
            spawnLimit = spawnLimit + 10;
        }

        if (Deactivator.gameObject.tag == "End"  && Deactivator != null)
        {
            spawnLimit = 0;
        }

    }
    
}


