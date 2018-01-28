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

	public GameObject World;
	public GameObject Player;

	//For setting zone terrains
    public SpriteRenderer zoneRenderer;
    public Sprite[] myTerrains;

	// Use this for initialization
	void Start () {
		myTerrains = Resources.LoadAll<Sprite>("terrain_assets");
		zones = new Zone[numInRow, numInRow];
		createZones();
		zones[startingx, startingy].GetComponent<Zone>().createTower();
		Camera.main.transform.position = zones[startingx, startingy].transform.position;
        //zones[startingx, startingy].GetComponent<Zone>().BuildRegularTurret(1);
        //zones[startingx, startingy].GetComponent<Zone>().BuildRegularTurret(5);
        // zones[7, 7].GetComponent<Zone>().BuildCementary();

		 zones[0, 0].GetComponent<Zone>().BuildCementary();
        zones[15, 0].GetComponent<Zone>().BuildCementary();
        zones[15, 7].GetComponent<Zone>().BuildCementary();
        zones[15, 15].GetComponent<Zone>().BuildCementary();
        zones[8, 0].GetComponent<Zone>().BuildCementary();
        zones[0, 15].GetComponent<Zone>().BuildCementary();
        zones[8, 15].GetComponent<Zone>().BuildCementary();
        zones[0, 8].GetComponent<Zone>().BuildCementary();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void hideAllSelections() {
		for (int x = 0; x < numInRow; x++) {
			for (int y = 0; y < numInRow; y++) {
				ZoneSelect zoneSelect = zones[x, y].GetComponent<ZoneSelect>();
				zoneSelect.HideHighlight();
			}
		}
	}

	public void showAvailableTowerSpots() {
		Debug.Log("showAvailableTowerSpots");
		bool offsetThisRow = false;
		for (int y = 0; y < numInRow; y++) {
			offsetThisRow = !offsetThisRow;
			for (int x = 0; x < numInRow; x++) {
				Zone zone = zones[x, y].GetComponent<Zone>();
				ZoneSelect zoneSelect = zones[x, y].GetComponent<ZoneSelect>();
				Debug.Log(zone.zoneType);
				if (zone.zoneType == "RadioTower") {
					Debug.Log("tower!");
					int leftx = x - 1;
					int rightx  = x + 1;
					if (leftx > 0 && leftx < numInRow) {
						zones[leftx, y].GetComponent<ZoneSelect>().ShowHighlight();
					} 
					if (rightx > 0 && rightx < numInRow) {
						zones[rightx, y].GetComponent<ZoneSelect>().ShowHighlight();
					}
					int upy = y + 1;
					int downy = y - 1;
					if (upy > 0 && upy < numInRow) {
						zones[x, upy].GetComponent<ZoneSelect>().ShowHighlight();
						if (offsetThisRow) {
							if (rightx > 0 && rightx < numInRow) {
								zones[rightx, upy].GetComponent<ZoneSelect>().ShowHighlight();
							}
						} else {
							if (leftx > 0 && leftx < numInRow) {
								zones[leftx, upy].GetComponent<ZoneSelect>().ShowHighlight();
							}
						}
					}
					if (downy > 0 && downy < numInRow) {
						zones[x, downy].GetComponent<ZoneSelect>().ShowHighlight();
						if (offsetThisRow) {
							if (rightx > 0 && rightx < numInRow) {
								zones[rightx, downy].GetComponent<ZoneSelect>().ShowHighlight();
							}
						} else {
							if (leftx > 0 && leftx < numInRow) {
								zones[leftx, downy].GetComponent<ZoneSelect>().ShowHighlight();
							}
						}
					}
				}
			}
		}
	}

	public void showAvailableStructureSpots() {
		for (int x = 0; x < numInRow; x++) {
			for (int y = 0; y < numInRow; y++) {
				Zone zone = zones[x, y].GetComponent<Zone>();
				if (zone.zoneType == "RadioTower") {
					zone.ShowAvailableBuildSites();
				}
			}
		}
	}

	public void hideAllStructureSpots() {
		for (int x = 0; x < numInRow; x++) {
			for (int y = 0; y < numInRow; y++) {
				Zone zone = zones[x, y].GetComponent<Zone>();
				if (zone.zoneType == "RadioTower") {
					zone.hideAvailableBuildSites();
				}
			}
		}
	}

	public void DisableZoneSelects() {
		for (int x = 0; x < numInRow; x++) {
			for (int y = 0; y < numInRow; y++) {
				ZoneSelect zone = zones[x, y].GetComponent<ZoneSelect>();
				zone.enabled = false;
				zones[x, y].GetComponent<Collider2D>().enabled = false;
			}
		}
	}

	public void EnableZoneSelects() {
		for (int x = 0; x < numInRow; x++) {
			for (int y = 0; y < numInRow; y++) {
				ZoneSelect zone = zones[x, y].GetComponent<ZoneSelect>();
				zone.enabled = true;
				zones[x, y].GetComponent<Collider2D>().enabled = true;
				
			}
		}
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
				instance.transform.SetParent(World.transform);
				zones[x, y] = instance.GetComponent<Zone>();
				zones[x, y].playerResources = Player.GetComponent<PlayerResources>();
				instance.GetComponent<SpriteRenderer>().sprite = getTerrain();

			}
		}
	}

	//Gets a random terrain from Sprite List
    private Sprite getTerrain()
    {
        Sprite sp;

        int count = myTerrains.Length;

        sp = myTerrains[Random.Range(0,count)];


        return sp;
    }
}
