using UnityEngine;
using System.Collections;

public class Pumping : MonoBehaviour {
	public KeyCode LeftButton;
	public KeyCode RightButton;
	public Texture popTexture;
	public float speed = 3f;
	public float bounceback = 8f;
	public float leakspeed = 0.1f;
	public float pumpeffect = 10f;
	public float goal = 8;
	public GameObject balloon;
	public GameObject gameManager;

	private float pump;
	private bool pumpfinished;	//When true, pump in the other direction
	private float maxthispump;	//The highest angle you've reached before the pump ended. If not exceeded, no pump reward
	private bool gameOn;
	private Vector3 balloonpos;

	// Use this for initialization
	void Start () {
		pump = 1;
		pumpfinished = false;
		maxthispump = 0;
		gameOn = true;
		balloonpos = balloon.transform.position;
	}

	void FixedUpdate() {
		if(gameOn) {
			//Reset the pump at the middle when changing directions
			if (pumpfinished && transform.rotation.z < 0.03 && transform.rotation.z > -0.03) {
				pumpfinished = false;
				maxthispump = 0;
			}
		
			pump -= leakspeed * Time.deltaTime;

			if (Input.GetKey(LeftButton)) {
				//pump left
				rigidbody.AddTorque(speed * Vector3.forward);
			}

			if(transform.rotation.z > 0.47f) {
				//pump left reaches its limit
				rigidbody.AddTorque(Vector3.back * bounceback * transform.rotation.z * 2);
				pumpfinished = true;
			}

			if (Input.GetKey(RightButton)) {
				//pump right
				rigidbody.AddTorque(speed * Vector3.back);
			}
			
			if(transform.rotation.z < -0.47f) {
				//pump right reaches its limit
				rigidbody.AddTorque(Vector3.forward * bounceback * transform.rotation.z * -2);
				pumpfinished = true;
			}

			float pumpmore = 0;

			/*If not finished pumping toward this side, inflate the balloon by the current angle.
			 *But the angle hasn't increased since the last update, don't reward with more inflation*/
			if (!pumpfinished) {
				pumpmore = pumpeffect * Mathf.Abs(rigidbody.angularVelocity.z);
				if (pumpmore > maxthispump) {
					maxthispump = pumpmore;
				} else {
					pumpmore = 0;
				}
			}
			//print(pumpmore.ToString());

			pump += pumpmore;

			balloon.transform.localScale = new Vector3(pump,pump,pump);
			balloon.transform.position = new Vector3(balloonpos.x,balloonpos.y+pump*0.5f,balloonpos.z);

			if (pump >= goal) {
				Victory();
			}
		}
	}
	
	void Victory() {
		balloon.renderer.material.mainTexture = popTexture;
		gameManager.SendMessage("Victory" + gameObject.tag.ToString());
	}

	void StopPumping() {
		gameOn = false;
	}

}
