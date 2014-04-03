using UnityEngine;
using System.Collections;

public class MoveShipWASD : MonoBehaviour {
	
	public float speed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	
	void FixedUpdate () {
		//FixedUpdate is called before physics on each frame
		
		if(Input.GetKey(KeyCode.W)) {
			transform.position = new Vector3(transform.position.x,transform.position.y + speed, transform.position.z);
		}
		
		if(Input.GetKey(KeyCode.S)) {
			transform.position = new Vector3(transform.position.x,transform.position.y - speed, transform.position.z);
		}
		
		if(Input.GetKey(KeyCode.A)) {
			transform.position = new Vector3(transform.position.x - speed,transform.position.y, transform.position.z);
		}
		
		if(Input.GetKey(KeyCode.D)) {
			transform.position = new Vector3(transform.position.x + speed,transform.position.y, transform.position.z);
		}
		
	}
}
