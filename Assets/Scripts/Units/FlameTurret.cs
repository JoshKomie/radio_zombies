using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTurret : MonoBehaviour {

    private List<GameObject> ZombiesList = new List<GameObject>();
    private int attack = 8;
    private float attackSpeed = 0.5f;
    private float Range = 1;
    SpriteRenderer GOImage;
    public Sprite SUp;
    public Sprite SDown;
    public Sprite SLeft;
    public Sprite SRight;


    private bool TurretFreeStatus = true;
    private string EnemyTag = "Zombie";
    // Use this for initialization
    void Start () {
        GOImage = this.GetComponent<SpriteRenderer>();
        InvokeRepeating("AttackCurrentTarget", 1, attackSpeed);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == EnemyTag)
        {
            ZombiesList.Add(other.gameObject);
        }
    }
    public void onTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == EnemyTag)
        {
            ZombiesList.Remove(other.gameObject);
        }
    }
    private void AttackCurrentTarget()
    {
        if (ZombiesList.Count > 0)
        {
            GameObject Target = ZombiesList[0];
            if (Target != null && Target.GetComponent<Combat>().Health > 0)
            {
                SetGameObjectImage(Target.transform.position.x, Target.transform.position.y);
                Target.GetComponent<Combat>().TakeDamage(attack);

            }
            else
            {
                ZombiesList.Remove(Target);
            }
        }
    }
    private void SetGameObjectImage(float x, float y)
    {
        float myX = transform.position.x;
        float myY = transform.position.y;
        if (myX < x)
        {
            if (myY < y && (y - myY > x - myX))
            {
                GOImage.sprite = SUp;
            }
            else if (myY > y && (myY - y > x - myX))
            {
                GOImage.sprite = SDown;
            }
            else
            {
                GOImage.sprite = SRight;
            }
        }
        else
        {
            if (myY < y && (y - myY > myX - x))
            {
                GOImage.sprite = SUp;
            }
            else if (myY > y && (myY - y > myX - x))
            {
                GOImage.sprite = SDown;
            }
            else
            {
                GOImage.sprite = SLeft;


            }
        }
    }
}
