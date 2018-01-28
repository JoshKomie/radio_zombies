using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Destroy(gameObject);
        }
    }
}
