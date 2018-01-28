using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTower : MonoBehaviour {

	private GameObject player;
	public float tickRate = 3.0f;
	public int startingCurrencyPerTick = 1;
	public Zone zone;
	private int currencyPerTick;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		currencyPerTick = startingCurrencyPerTick;
		InvokeRepeating("AddCurrency", tickRate, tickRate);
	}
	
	public void AddCurrency() {
		player.GetComponent<PlayerResources>().AddCurrency(currencyPerTick);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
