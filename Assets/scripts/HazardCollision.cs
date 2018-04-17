using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardCollision : MonoBehaviour {

	public GameObject respawnLoacation;

	private AudioSource collisionEffectAudioSource;

	// Use this for initialization
	void Start () {
		this.collisionEffectAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col)
	{
			if(col.gameObject.tag.Contains("Player"))
			{
				col.gameObject.transform.position = this.respawnLoacation.transform.position;
				this.collisionEffectAudioSource.Play();
			}
	}

}
