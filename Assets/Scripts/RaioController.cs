using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaioController : MonoBehaviour {

	public GameObject respawn01;
	public GameObject respawn02;
	public GameObject raio;
	float timeLeft = 20.0f;
	bool respawn; //True = 01, False = 02


	void Start () {
		respawn = false;
	}

	void Update () {
		
	}

	void FixedUpdate() {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			raio.transform.Translate(new Vector3 (-2.0f, 0, 0));
			if (respawn) {
				respawn = false;
				Instantiate (raio, new Vector3(respawn01.transform.position.x,respawn01.transform.position.y,0), Quaternion.Euler(new Vector3(0,0,90)));
			} else {
				respawn = true;
				Instantiate (raio, new Vector3(respawn02.transform.position.x,respawn02.transform.position.y,0), Quaternion.Euler(new Vector3(0,0,90)));
			}
			timeLeft = 20.0f;
		}
	}
}
