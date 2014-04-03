using UnityEngine;
using System.Collections;

public class ManageGame : MonoBehaviour {

	public static float p1_score;
	public static float secs;		//For scripting
	public float seconds = 60f;		//For setting in the Unity editor

	public GUIText guiTime;
	public GUIText guiP1Win;
	public GUIText guiP1Lose;

	public GameObject tapCatcher;

	private float seccollect;	//when this exceeds one, subtract a second
	private bool gameon;		//whether game is active

	// Use this for initialization
	void Start () {
		gameon = true;
		secs = seconds;
		guiTime.text = secs.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameon) {
			if (secs < 1) {	//If out of time, 
				secs = 0;
				P1Lose();
			}

			seccollect += Time.deltaTime;
			if (seccollect >= 1f) {
				secs--;
				seccollect = 0;
				guiTime.text = secs.ToString();
			}
		}
	}

	void P1Win() {
		EndGame();
		guiP1Win.enabled = true;
		print ("Player 1 wins!");
	}

	void P1Lose() {
		EndGame();
		guiP1Lose.enabled = true;
		print ("Player 1 loses!");
	}

	private void EndGame() {
		gameon = false;
	}
}
