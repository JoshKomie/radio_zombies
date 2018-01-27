using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour {

	public GameObject RadioTowerPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BuildTower() {
		Instantiate(RadioTowerPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
	}
}
