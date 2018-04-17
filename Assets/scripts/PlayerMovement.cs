using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody collisionSphereRigidBody;
	
	public float horizontalAccelerationMultiplier = 1.0f;
	public float jumpAccelerationMultiplier = 1.0f;
	public int maxNumberOfJumps = 2;
	public int currentNumberOfJumps = 2;

	public float maxHorizontalVelocity = 3.0f;
	public AudioSource jumpEffectAudioSource;

	private Vector3 movementOffset;

	// Use this for initialization
	void Start () {
		this.jumpEffectAudioSource = GetComponent<AudioSource>();
		this.collisionSphereRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		float horizontal = Input.GetAxis("Horizontal");

		this.collisionSphereRigidBody.AddForce(	1.0f * horizontal * this.horizontalAccelerationMultiplier,
																						0.0f,
																						0.0f,
																						ForceMode.Impulse);

		if (Input.GetKeyDown("space")) {
			if (this.currentNumberOfJumps > 0) {
				this.jumpEffectAudioSource.Play();
				this.currentNumberOfJumps -= 1;
				this.collisionSphereRigidBody.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
				this.collisionSphereRigidBody.velocity.Set(0.0f, 0.0f, 0.0f);
				this.collisionSphereRigidBody.AddForce(	0.0f,
																								1.0f * this.jumpAccelerationMultiplier,
																								0.0f,
																								ForceMode.Impulse);
			}
		}

	}

	void LateUpdate() {
		if (Mathf.Abs(this.collisionSphereRigidBody.velocity.x) > maxHorizontalVelocity) {
			this.collisionSphereRigidBody.velocity.Set( maxHorizontalVelocity,
																									this.collisionSphereRigidBody.velocity.y,
																									this.collisionSphereRigidBody.velocity.z);
		}
	}

	void OnCollisionEnter (Collision col)
	{
			if(col.gameObject.tag.Contains("floor"))
			{
				this.currentNumberOfJumps = this.maxNumberOfJumps;
			}
	}

}
