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


    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
                Debug.Log("Radio tower die!");
                GameObject[] towers = GameObject.FindGameObjectsWithTag("RadioTower");
                Debug.Log("towers length");
                if (towers.Length <= 0) {
                    SceneManager.LoadScene("game over",LoadSceneMode.Single);
                }
            }
            Destroy(gameObject);
        }
    }
}
