using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

	private GameObject target;
	private float lerpTime = 5;
	private float currLerpTime = 0;
	private int attack = 1;
    public float speed = 5;
	private bool attacking = false;
	public float attackRate = 2.0f;
	public float engageDist = 3.0f;

	private AudioSource audioSource;
	void Start () {
		//AssignTarget ();
		audioSource = GetComponent<AudioSource>();
		InvokeRepeating("Attack", 0.0f, attackRate);
	}
	
	// Update is called once per frame
	void Update () {
        currLerpTime = 0;
        GameObject[] radioTowers = GameObject.FindGameObjectsWithTag("RadioTower");
        target = findClosestTower(radioTowers);
        if (target != null)
        {
            if ((transform.position - target.transform.position).magnitude > engageDist)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
				attacking = false;
            }
            else
            {
                
				attacking = true;
            }
        }
	}

	public void Attack() {
		if (!attacking)
			return;
		AttackRadioTower();
	}

	private GameObject findClosestTower(GameObject[] radioTowers) {

		GameObject closest = null;
		float closestDist= Mathf.Infinity;

		

		for (int i = 0; i < radioTowers.Length; i++) {

			float dist = Vector3.Distance(transform.position, radioTowers[i].transform.position);
			

			if (dist < closestDist && radioTowers[i].GetComponent<Combat>().Health != null) {
				closestDist = dist;
				closest = radioTowers[i];
			}
		}

		return closest;
	}

    private void AttackRadioTower(){
		if (target && target.GetComponent<Combat> ().Health != null) {
			target.GetComponent<Combat> ().TakeDamage (attack);
		} 

		else {
			AssignTarget ();
		}
	}

    private void AssignTarget(){
		currLerpTime = 0;
		GameObject[] radioTowers = GameObject.FindGameObjectsWithTag("RadioTower");
		target = findClosestTower(radioTowers);
	}


}
