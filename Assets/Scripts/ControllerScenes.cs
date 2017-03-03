using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScenes : MonoBehaviour {

	public void onAbout() {
		SceneManager.LoadScene("about");
	}

	public void onPlay() {
		SceneManager.LoadScene(1);
	}

	public void onMainMenu() {
		SceneManager.LoadScene(0);
	}
}
