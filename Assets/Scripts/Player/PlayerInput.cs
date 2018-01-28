using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	private bool selectHexMode = false;
	private bool selectBuildSiteMode = false;
	public GameObject world;
	public string structureType = "turret";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetStructureType(string s) {
		structureType = s;
	}

	public void EnableSelectHexMode() {
		selectHexMode = true;
		world.GetComponent<ZoneGenerator>().showAvailableTowerSpots();
	}

	public void DisableSelectHexMode() {
		selectHexMode = false;
		world.GetComponent<ZoneGenerator>().hideAllSelections();
	}

	public void EnableSelectBuildSiteMode() {
		selectBuildSiteMode = true;
		world.GetComponent<ZoneGenerator>().showAvailableStructureSpots();
		world.GetComponent<ZoneGenerator>().DisableZoneSelects();
	}
	public void DisableSelectBuildSiteMode() {
		selectBuildSiteMode = false;
		world.GetComponent<ZoneGenerator>().EnableZoneSelects();
		world.GetComponent<ZoneGenerator>().hideAllStructureSpots();
	}

	public bool selectBuildSiteModeEnabled() {
		return selectBuildSiteMode;
	}

	public bool SelectHexModeEnabled() {
		return selectHexMode;
	}
}
