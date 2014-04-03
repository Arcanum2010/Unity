using UnityEngine;
using System.Collections;

public class MoveShipKeyboard : MonoBehaviour {
	
	public float speed;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	
	void FixedUpdate () {
	//FixedUpdate is called before physics on each frame
		
		if(Input.GetKey(KeyCode.UpArrow)) {
			transform.position = new Vector3(transform.position.x,transform.position.y + speed, transform.position.z);
		}
		
		if(Input.GetKey(KeyCode.DownArrow)) {
			transform.position = new Vector3(transform.position.x,transform.position.y - speed, transform.position.z);
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)) {
			transform.position = new Vector3(transform.position.x - speed,transform.position.y, transform.position.z);
		}
		
		if(Input.GetKey(KeyCode.RightArrow)) {
			transform.position = new Vector3(transform.position.x + speed,transform.position.y, transform.position.z);
		}
		
	}
	
	void Update () {
		//Debug.Log(Input.GetAxis("Mouse X") + ", " + Input.GetAxis("Mouse Y"));
	}
}
