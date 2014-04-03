using UnityEngine;
using System.Collections;

public class ManageCube : MonoBehaviour {
	
	public int lives;
	public float point_timer;
	public int point_value;
	public int punishment;	//multiplyer for dropping the ball
		
	public GUIText gtxLives;
	public GUIText gtxScoreP1;
	public GUIText gtxScoreP2;
	
	private int scoreP1 = 0;
	private int scoreP2 = 0;
	private int lastToucher = 0; //The player who last touched the cube
	private bool gameOver = false;
	private float timecollect = 0;	//Collects the amount of time a player has been touching the ball
	
	// Use this for initialization
	void Start () {
		gtxLives.text = "■ x " + lives;
		gtxScoreP1.text = scoreP1.ToString();
		gtxScoreP2.text = scoreP2.ToString();
	}
	
	
	void FixedUpdate () {
		if (transform.position.y < -12f || transform.position.y > 30f) {	//If the ball falls or goes out of bounds
			if (lives > 0) {
				transform.position = new Vector3(0,10,0);
				lives--;
				gtxLives.text = "■ x " + lives;		
				if (lastToucher == 1) { scoreP1 -= point_value * punishment; }
				if (lastToucher == 2) { scoreP2 -= point_value * punishment; }
				lastToucher = 0;
			} else {
				endGame();
			}
		}
		
		if (!gameOver) {
			gtxScoreP1.text = scoreP1.ToString();
			gtxScoreP2.text = scoreP2.ToString();
		}
		
	}
	
	void OnCollisionStay (Collision colinfo) {
		timecollect += Time.deltaTime;
		//Debug.Log(timecollect + " / " + point_timer + " : " + Time.deltaTime);
		
		if (timecollect > point_timer) {
			if (colinfo.gameObject.name == "ShipP1") {
				scoreP1 += point_value;
				lastToucher = 1;
			}
			if (colinfo.gameObject.name == "ShipP2") {
				scoreP2 += point_value;
				lastToucher = 2;
			}
			
			timecollect = 0;
		}
	}
	
	
	private void endGame() {
		gameOver = true;
		enabled = false;
		
		if(scoreP1 > scoreP2) {
			gtxScoreP1.text = scoreP1.ToString() + "\nWIN!!!";
			gtxScoreP2.text = scoreP2.ToString() + "\nLose.";
		} else if (scoreP1 < scoreP2) {
			gtxScoreP1.text = scoreP1.ToString() + "\nLose.";
			gtxScoreP2.text = scoreP2.ToString() + "\nWIN!!!";
		} else {
			gtxScoreP1.text = scoreP1.ToString() + "\nTIE!";
			gtxScoreP2.text = scoreP2.ToString() + "\nTIE!";
		}
	}
}
