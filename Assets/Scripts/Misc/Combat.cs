using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {

	public int Health;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount)
    {

        Health -= amount;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
