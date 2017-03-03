using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour {

	public Text txtPontuacaoFinal;
	GameObject gm;

	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameController");
		txtPontuacaoFinal.text = gm.GetComponent<GameController>().points.ToString();
		Object.Destroy (gm);
	}

	void Update () {
		
	}

	public void onEndGame(string pontuacao) {
		txtPontuacaoFinal.text = pontuacao;
	}
}
