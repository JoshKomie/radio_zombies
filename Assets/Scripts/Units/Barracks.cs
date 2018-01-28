using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour {
	public GameObject UnitPrefab;
	public float spawnRate = 5.0f;
	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnUnit", 0.0f, spawnRate);
	}

	public void SpawnUnit() {
		Instantiate(UnitPrefab, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
