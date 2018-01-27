using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public float speed = 1.0f;
	public float zoomSpeed = 1.0f;

	private float startingSize;
	public GameObject world;

	private Camera camera;
		// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
		startingSize = camera.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		float speedAfterZoom = speed * camera.orthographicSize;
		Vector3 newpos = transform.position;
		newpos.z = -10.0f;
		if (Input.GetKey(KeyCode.W)) {
			newpos.y += speedAfterZoom * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.S)) {
			newpos.y -= speedAfterZoom * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A)) {
			newpos.x -= speedAfterZoom * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.D)) {
			newpos.x += speedAfterZoom * Time.deltaTime;
		}
		transform.position = newpos;
		float scroll = 1.0f + Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * -1;
		camera.orthographicSize *= scroll;
	}

}
