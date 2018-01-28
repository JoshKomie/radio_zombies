using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour {

	public GameObject RadioTowerPrefab;
    public GameObject CementaryPrefab;
    public GameObject RegularTurretPrefab;
    public GameObject[] BuildSites;
    public string zoneType = "empty";
    private PlayerResources resources;
    public int TowerCost;
    public PlayerResources playerResources;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void createTower() {
        zoneType = "RadioTower";
        GameObject g = Instantiate(RadioTowerPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;
        g.GetComponent<RadioTower>().zone = this;
    }

	public bool BuildTower() {
        Debug.Log(TowerCost + "" + playerResources.GetCurrency() + "" + zoneType);
        if (playerResources.GetCurrency() > TowerCost && zoneType == "empty") {
            createTower();
            playerResources.UseCurrency(TowerCost);
            return true;
        } else {
            return false;
        }
	}

    public void BuildCementary()
    {
        zoneType = "Cemetary";
        Instantiate(CementaryPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }

    // public void BuildRegularTurret(int buildSiteIndex)
    // {
    //     GameObject turret = Instantiate(RegularTurretPrefab, new Vector2(BuildSites[buildSiteIndex].transform.position.x, BuildSites[buildSiteIndex].transform.position.y), Quaternion.identity) as GameObject;
    //     // structures[buildSiteIndex] = turret;
    //     structures[buildSiteIndex] = new GameObject();
    //     BuildSites[i].GetComponent<BuildSite>().Build
    // }

    public void ShowAvailableBuildSites() {
        for (int i = 0; i < BuildSites.Length; i++) {
            if (BuildSites[i].GetComponent<BuildSite>().occupant == "empty") {
                BuildSites[i].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    public void hideAvailableBuildSites() {
        for (int i = 0; i < BuildSites.Length; i++) {
            BuildSites[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
