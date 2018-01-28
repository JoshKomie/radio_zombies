using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject target;
	public float travelTime = 1.0f;

	private float progress = 0;
	public int damage;
	private Vector3 start;
	// Use this for initialization
	void Start () {
		start = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (progress >= travelTime) {
			target.GetComponent<Combat>().TakeDamage(damage);
			if (gameObject)
				Destroy(gameObject);
		}
		transform.position = Vector3.Lerp(start, target.transform.position, progress / travelTime);
		progress += Time.deltaTime;
	}
}
