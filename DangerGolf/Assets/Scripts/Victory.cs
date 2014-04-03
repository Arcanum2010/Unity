using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour {
	public GameObject hero;
	public GameObject gameManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		if(col.collider.tag == "Player") {
			print ("Victory!");
			hero.rigidbody.AddForce(Vector3.up * 800);
			gameManager.BroadcastMessage("P1Win");
			Invoke("killhero", 1f);
		}
	}

	private void killhero() {
		hero.SetActive(false);
	}
}
