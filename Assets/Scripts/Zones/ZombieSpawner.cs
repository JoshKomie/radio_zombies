using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {


    public GameObject ZombiePrefab;
    public int start = 1;
    private float rate = 0.2f;
    private int currentWave = 0;
    private float waveRate = 30f;
    public int zombieCount;


	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnWave", start, 30f);
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    private void SpawnWave()
    {
        zombieCount = 0;
        int numZombies = numberZombies(currentWave++);
        for (int i = 0; i < numZombies; i++) {
            float variance = 10.0f;
            float xoffset = Random.value * variance;
            float yoffset = Random.value * variance;
            Instantiate(ZombiePrefab, new Vector2(transform.position.x + xoffset, transform.position.y + yoffset), Quaternion.identity);
        }
        // InvokeRepeating("BuildZombie", 0f, 0.2f);
    }

    private int numberZombies(int currentWave) {
        return (int)Mathf.Floor(Mathf.Pow(2.0f, (float)currentWave));
    }

    public void BuildZombie()
    {
        float variance = 10.0f;
        float xoffset = Random.value * variance;
        float yoffset = Random.value * variance;



        if (zombieCount <= (numberZombies(currentWave)))
        {
            Instantiate(ZombiePrefab, new Vector2(transform.position.x + xoffset, transform.position.y + yoffset), Quaternion.identity);
            zombieCount++;
        }
    }

}
