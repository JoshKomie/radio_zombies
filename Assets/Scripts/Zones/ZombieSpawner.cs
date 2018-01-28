using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {


    public GameObject ZombiePrefab;
    public int start;
    public int rate;
    public int zombieCount;


	// Use this for initialization
	void Start () {
        start = 1;
        rate = 5;
        InvokeRepeating("BuildZombie", start, rate);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void BuildZombie()
    {
        Instantiate(ZombiePrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        zombieCount++;
        Debug.Log("Zombie Count = " + zombieCount);
    }

}
