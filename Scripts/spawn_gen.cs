using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_gen : MonoBehaviour
{
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // configurable how long between each spawn.
    public float spawnLimit = 10;           // configurable how many spawns are allowed for the generator, default 10
    public GameObject endOnTrap;
    public GameObject activator;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        // Do not run if spawnpoints is depleted
        if (spawnLimit <= 0)
        {
            return;
        }
        // create enemy, on position of generator (empty object)
        Instantiate(enemy, transform.position, Quaternion.identity);
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
        /*
        if (activator == true)
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
        */

        /*
        if (endOnTrap == true || objectBroken == true)
        {
            spawnLimit = 0
            destroy gameObject SpawnGen
        }
        */
    }
}



