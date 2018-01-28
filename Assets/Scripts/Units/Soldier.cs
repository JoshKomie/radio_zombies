using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour {

	enum Direction
	{
		NONE, UP, RIGHT, DOWN, LEFT
	}

	private Animator animator;

	private Direction direction;

	private string state = "moving";

	public float speed = 1.0f;

	private GameObject target = null;
	public float engageDistance = 10.0f;
	public GameObject bullet = null;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		InvokeRepeating("findTarget", 0.0f, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			float dist = Vector2.Distance(transform.position, target.transform.position);
			if (dist < engageDistance) {
				state = "shoot";
			} else {
				state = "move";
			}
		}
		switch (state) {
			case "move":
				moveToTarget();
				break;
			case "shoot":
				shootAtTarget();
				break;
		}
		handleMove();
	}

	private void moveToTarget() {
		Debug.Log("moveToTarget");
		Vector2 vec2target = target.transform.position - transform.position;
		float absx = Mathf.Abs(vec2target.x);
		float absy = Mathf.Abs(vec2target.y);
		if (absx > absy) {
			if (vec2target.x > 0) {
				direction = Direction.RIGHT;
			} else {
				direction = Direction.LEFT;
			}
		} else {
			if (vec2target.y > 0) {
				direction = Direction.UP;
			} else {
				direction = Direction.DOWN;
			}
		}
		animator.speed = .5f;
		
	}

	private void shootAtTarget() {
		Debug.Log("shoot at target");
		direction = Direction.NONE;
		animator.speed = 0f;
	}

	private void findTarget() {
		GameObject[] targets = GameObject.FindGameObjectsWithTag("Zombie");
		if (targets.Length > 0) {
			target = targets[0];
		}
	}


	private void handleMove() {
		switch (direction) {
			case Direction.UP:
				transform.Translate(Vector2.up * speed * Time.deltaTime);
				animator.SetInteger("direction", 0);
				break;
			case Direction.RIGHT:
				transform.Translate(Vector2.right * speed * Time.deltaTime);
				animator.SetInteger("direction", 1);
				break;
			case Direction.DOWN:
				transform.Translate(Vector2.down * speed * Time.deltaTime);
				animator.SetInteger("direction", 2);
				break;
			case Direction.LEFT:
				transform.Translate(Vector2.left * speed * Time.deltaTime);
				animator.SetInteger("direction", 3);
				break;
		}
	}

	public void MoveLeft() {
		direction = Direction.LEFT;
	}
	public void MoveUp() {
		direction = Direction.UP;
	}
	public void MoveRight() {
		direction = Direction.RIGHT;
	}
	public void MoveDown() {
		direction = Direction.DOWN;
	}

}
