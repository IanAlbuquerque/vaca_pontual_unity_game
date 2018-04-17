using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovementSnapper : MonoBehaviour {

	public Rigidbody referenceRotationRigidBody;
	private int lastRotationStep;

	private AudioSource snapEffectAudioSource;

	int calculateRotationStep() {
		return (int) (this.referenceRotationRigidBody.transform.eulerAngles.z / 90.0f) % 4;
	}

	// Use this for initialization
	void Start () {
		this.snapEffectAudioSource = GetComponent<AudioSource>();
		this.lastRotationStep = calculateRotationStep();
	}
	
	// Update is called once per framed
	void Update () {
		int rotationStep = calculateRotationStep();
		if (rotationStep != this.lastRotationStep) {
			this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationStep * 90.0f);
			this.lastRotationStep = rotationStep;
			this.snapEffectAudioSource.Play();
		}
	}
}
