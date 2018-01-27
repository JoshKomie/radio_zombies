using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneGenerator : MonoBehaviour {

	public GameObject ZonePrefab;
	public int numInRow = 16;
	public float width = 1f;

	public int startingx = 8;
	public int startingy = 8;

	Zone[,] zones;

	// Use this for initialization
	void Start () {
		zones = new Zone[numInRow, numInRow];
		createZones();
		zones[startingx, startingy].GetComponent<Zone>().BuildTower();

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
				float offset = 0f;
				if (offsetThisRow) {
					offset = width / 2.0f;
				}
				Vector2 pos = new Vector2(x * width + offset, y * width * .75f);
				GameObject instance = Instantiate(ZonePrefab, pos, Quaternion.identity) as GameObject;
				zones[x, y] = instance.GetComponent<Zone>();
			}
		}
	}
}
