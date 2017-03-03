using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {
	
	float numBgPanelsFloor = 13.0f;

	void OnTriggerEnter2D(Collider2D collider) {

		//Debug.Log ("Collider TAG " + collider.tag);

		//Debug.Log ("Triggered " + collider.name);

		float widthOfBGObject = ((BoxCollider2D)collider).size.x;
		Vector3 pos = collider.transform.position;

		if (collider.tag.Equals ("Floor")) {
			pos.x += widthOfBGObject * numBgPanelsFloor;
		} else if (collider.tag.Equals ("Background")) {
			pos.x += widthOfBGObject * 0.1f;
		} else if (collider.tag.Equals ("Obstacle")) {
			pos.x += widthOfBGObject * 6.0f;
		}
			
		collider.transform.position = pos;
	}
}