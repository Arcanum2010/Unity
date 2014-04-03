using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManageGame : MonoBehaviour {
	public List<GameObject> players;
	public GUIText p1WinText;
	public GUIText p2WinText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void VictoryP1() {
		StopPlaying();
		p1WinText.enabled = true;
	}

	void VictoryP2() {
		StopPlaying();
		p2WinText.enabled = true;
	}

	void StopPlaying() {
		foreach (GameObject i in players) {
			i.SendMessage("StopPumping");
		}
	}
}
