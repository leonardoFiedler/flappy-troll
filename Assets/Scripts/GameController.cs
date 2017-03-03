using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int points;
	public Text txtPontuacao;
	public Text txtBtnPress;
	float timeLeft = 3.0f;
	float timeLeftRandom = 10.0f;
	public GameObject muteObj;
	public GameObject unmuteObj;
	public bool liberado;

	void Start () {
		points = 0;	
		txtBtnPress.text = "Press Space to Fly";
		liberado = false;

		if (AudioListener.pause) {
			muteObj.SetActive (false);
			unmuteObj.SetActive (true);
		} else {
			unmuteObj.SetActive (false);
			muteObj.SetActive (true);
		}
	}

	void Update () {
		txtPontuacao.text = points.ToString();
	}

	void FixedUpdate() {

		if (!liberado) {
			timeLeft -= Time.deltaTime;

			if (timeLeft < 0) {
				txtBtnPress.text = "";
				txtBtnPress.enabled = false;
				liberado = true;
				timeLeftRandom = Random.value * 10.5f;
				Debug.Log ("TimeLeftRandom" + timeLeftRandom);
			}
		}

		if (liberado) {
			
			timeLeftRandom -= Time.deltaTime;

			if (timeLeftRandom < 0) {
				liberado = false;
				GameObject gm = GameObject.FindGameObjectWithTag ("Player");
				gm.GetComponent<PlayerMovement> ().keyPress = generateKeyCode ();
			}
		}
	}


	public void OnMute() {
		AudioListener.pause = true;
		muteObj.SetActive (false);
		unmuteObj.SetActive (true);

	}

	public void OnUnMute() {
		AudioListener.pause = false;
		unmuteObj.SetActive (false);
		muteObj.SetActive (true);
	}


	public KeyCode generateKeyCode() {
		float value = Random.value;
		timeLeft = 3.0f;
		txtBtnPress.enabled = true;
		Debug.Log ("GENERATED value random " + value);
		if (value < 0.10f) {
			txtBtnPress.text = "Press A to Fly Now!!!";
			return KeyCode.A;
		} else if (value < 0.20f) {
			txtBtnPress.text = "Press U to Fly Now!!!";
			return KeyCode.U;
		} else if (value < 0.30f) {
			txtBtnPress.text = "Press Space to Fly Now!!!";
			return KeyCode.Space;
		} else if (value < 0.40f) {
			txtBtnPress.text = "Press P to Fly Now!!!";
			return KeyCode.P;
		} else if (value < 0.50f) {
			txtBtnPress.text = "Press F5 to Fly Now!!!";
			return KeyCode.F5;
		} else if (value < 0.60f) {
			txtBtnPress.text = "Press W to Fly Now!!!";
			return KeyCode.W;
		} else if (value < 0.70f) {
			txtBtnPress.text = "Press Left Button Mouse to Fly Now!!!";
			return KeyCode.Mouse0;
		} else if (value < 0.80f) {
			txtBtnPress.text = "Press Left Control to Fly Now!!!";
			return KeyCode.LeftControl;
		} else if (value < 0.90f) {
			txtBtnPress.text = "Press Up Arrow to Fly Now!!!";
			return KeyCode.UpArrow;
		} else {
			txtBtnPress.text = "Press G to Fly Now!!!";
			return KeyCode.G;
		}
	}
}