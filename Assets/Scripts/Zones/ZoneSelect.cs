using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSelect : MonoBehaviour {

	private GameObject player;
	private PlayerInput playerInput;
	public GameObject highlight;
	private ZoneGenerator zoneGenerator;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		playerInput = player.GetComponent<PlayerInput>();
		zoneGenerator = GameObject.Find("World").GetComponent<ZoneGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnMouseDown() {
		if ( playerInput.SelectHexModeEnabled() && highlight.activeInHierarchy) {
			Debug.Log("place");
			if (GetComponent<Zone>().BuildTower()) {
				playerInput.DisableSelectHexMode();
			}
		}
	}

	public void OnMouseOver() {
	}

	public void OnMouseEnter() {
		if (playerInput.SelectHexModeEnabled())
			transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
		// Debug.Log("mouse  enter");
		// if (playerInput && playerInput.SelectHexModeEnabled()) {

		// }
	}
	
	private void OnMouseExit() {
		if (playerInput.SelectHexModeEnabled())
			transform.localScale = Vector3.one;
	}

	public void ShowHighlight() {
		highlight.SetActive	(true);
	}

	public void HideHighlight() {
		highlight.SetActive(false);
		transform.localScale = Vector3.one;
	}
}
