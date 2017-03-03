using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCollider : MonoBehaviour {

	GameObject player;
	public Object pontuacao;
	Animator anim;
	public bool godMode = false;


	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
		anim = player.GetComponent<Animator>();
	}


	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("TRIGGERED " + collider.tag);
		if (!godMode) {
			if (collider.tag.Equals ("Floor") || collider.tag.Equals ("Enemy")) {
				Debug.Log ("Jogador tocou o solo ou tocou o inimigo");
				anim.SetTrigger ("hitted");
				Object.DontDestroyOnLoad (pontuacao);
				player.GetComponent<PlayerMovement> ().hitted = true;
				SceneManager.LoadScene ("endGame");
			}
		}

		if (collider.tag.Equals ("Checkpoint")) {
			GameObject gm = GameObject.FindGameObjectWithTag("GameController");
			gm.GetComponent<GameController> ().points++;
		}
	}
}
