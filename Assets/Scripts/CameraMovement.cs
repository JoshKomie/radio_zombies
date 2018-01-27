using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public float speed = 1.0f;
		// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newpos = transform.position;
		newpos.z = -10.0f;
		if (Input.GetKey(KeyCode.W)) {
			newpos.y += speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.S)) {
			newpos.y -= speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A)) {
			newpos.x -= speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.D)) {
			newpos.x += speed * Time.deltaTime;
		}
		transform.position = newpos;
	}
}
