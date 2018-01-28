using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSite : MonoBehaviour {
	public GameObject TurretPrefab;
	private GameObject player;
	private PlayerInput playerInput;
	private ZoneGenerator zoneGenerator;
	public string occupant = "empty";
	private GameObject structure;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		playerInput = player.GetComponent<PlayerInput>();
		zoneGenerator = GameObject.Find("World").GetComponent<ZoneGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool BuildTurret() {
		structure = Instantiate(TurretPrefab, transform.position, Quaternion.identity) as GameObject;
		occupant = "turret";
		return true;
	}

	public void OnMouseDown() {
		Debug.Log("build site mouse down!");
		if ( playerInput.selectBuildSiteModeEnabled() && GetComponent<SpriteRenderer>().enabled) {
			if (BuildTurret()) {
				// playerInput.DisableSelectHexMode();
				playerInput.DisableSelectBuildSiteMode();
			}
		}
	}
}
