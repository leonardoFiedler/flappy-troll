using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerBahavior : MonoBehaviour {

	Transform player;
	float offsetX;

	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");

		if (player_go == null) {
			Debug.LogError ("Player não encontrado! Verifique a tag do Player se é 'Player' ");
			return;
		}

		player = player_go.transform;
		offsetX = transform.position.x - player.position.x;
	}
	

	void Update () {
		if (player != null) {
			Vector3 pos = transform.position;
			pos.x = player.position.x + offsetX;
			transform.position = pos;
		}

	}
}
