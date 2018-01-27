using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneGenerator : MonoBehaviour {

	public GameObject ZonePrefab;
	public int numInRow = 16;
	public float width = 1f;

	// Use this for initialization
	void Start () {
		createZones();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void createZones() {
		Debug.Log("create zones");
		bool offsetThisRow = false;
		for (int y = 0; y < numInRow; y++) {
			offsetThisRow = !offsetThisRow;
			for (int x = 0; x < numInRow;  x++) {
				Debug.Log(".");
				float offset = 0f;
				if (offsetThisRow) {
					offset = width / 2.0f;
				}
				Vector2 pos = new Vector2(x * width + offset, y * width * 0.66f);
				GameObject instance = Instantiate(ZonePrefab, pos, Quaternion.identity) as GameObject;
			}
		}
	}
}
