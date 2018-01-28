using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour {

	private int currency = 0;
	public int startingCurrency;
	// Use this for initialization
	void Start () {
		currency = startingCurrency;
	}
	
	public void AddCurrency(int amount) {
		currency += amount;
	}

	public int GetCurrency() {
		return currency;
	}

	public void UseCurrency(int amount) {
		currency -= amount;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
