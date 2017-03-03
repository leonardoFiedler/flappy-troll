using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public Vector3 flapVelocity;
	public Vector3 gravity;
	public float maxSpeed;
	public float forwardSpeed;
	public AudioClip clip;
	public KeyCode keyPress;

	bool didFlap = false;
	public bool hitted;

	void Start () {
		hitted = false;	
		keyPress = KeyCode.Space;
	}


	void Update() {
		if (!hitted) {
			//|| Input.GetMouseButtonDown(0) - Control touch on screen
			if (Input.GetKeyDown (keyPress)) {
				didFlap = true;
				AudioSource.PlayClipAtPoint(clip, new Vector3(transform.position.x, transform.position.y,0));
			}
		}
	}

	void FixedUpdate () {

		if (!hitted) {
			velocity.x = forwardSpeed;
			velocity += gravity * Time.deltaTime;

			if (didFlap) {
				didFlap = false;
				if (velocity.y < 0) {
					velocity.y = 0;
				}
				velocity += flapVelocity; 
			}
			velocity = Vector3.ClampMagnitude (velocity, maxSpeed);
			transform.position += velocity * Time.deltaTime;

			float angle = 0;
			if (velocity.y < 0) {
				angle = Mathf.Lerp (0, -20, -velocity.y / maxSpeed);
			}
			transform.rotation = Quaternion.Euler (0, 0, angle);
		} else {
			velocity.x = 0;
			velocity.y = 0;
		}
	}
}