using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour {

	float speed = 0.5f;
	GameObject player;

	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate() {
		if (!player.GetComponent<PlayerMovement> ().hitted) {
			Vector3 pos = transform.position;

			pos.x += speed * Time.deltaTime;
			transform.position = pos;
		}

	}
}
