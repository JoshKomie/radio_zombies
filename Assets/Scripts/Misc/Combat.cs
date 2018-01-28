using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZombiesKilled {
    public static int num = 0;
}

public class Combat : MonoBehaviour {

	public int Health;

    public AudioClip[] damageTakenSounds;

    private AudioSource audioSource;


    public bool healthbarEnabled = true;
    public GameObject HealthBarPrefab;
    private GameObject healthBar;
    private int maxHealth;
    // Use this for initialization
    void Start () {
        maxHealth = Health;
        audioSource = GetComponent<AudioSource>();
        if (HealthBarPrefab) {
            GameObject g = GameObject.Find("WorldSpaceCanvas");
            healthBar = Instantiate(HealthBarPrefab) as GameObject;
            healthBar.transform.SetParent(g.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (healthBar) {
            healthBar.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, 0f);
            healthBar.GetComponent<Slider>().value = (float)Health / (float)maxHealth;
        }
	}

    private AudioClip randomClip() {
        return damageTakenSounds[Random.Range(0, damageTakenSounds.Length)];
    }



    public void TakeDamage(int amount)
    {
        if (audioSource && damageTakenSounds.Length > 0) {
            audioSource.clip = randomClip();
            audioSource.Play();
        }
        Health -= amount;
        if (Health <= 0)
        {
            if (GetComponent<ZombieController>()) {
                Debug.Log("ZOMBIE DIE");
                GameObject textObj = GameObject.Find("ZombiesKilledText");
                if (textObj);
                    textObj.GetComponent<Text>().text = (++ZombiesKilled.num).ToString();
            } else if (GetComponent<RadioTower>()) {
                GetComponent<RadioTower>().DestroyZoneBuildSites();
                Debug.Log("Radio tower die!");
                GameObject[] towers = GameObject.FindGameObjectsWithTag("RadioTower");
                Debug.Log("towers length" + towers.Length.ToString());
                if (towers.Length - 1 <= 0) {
                    SceneManager.LoadScene("game over",LoadSceneMode.Single);
                }
                GetComponent<RadioTower>().zone.zoneType = "empty";
                Debug.Log("set zonetype=" + GetComponent<RadioTower>().zone.zoneType);
            }
            Destroy(gameObject);
            if (healthBar) {
                Destroy(healthBar);
            }
        }
    }
}
