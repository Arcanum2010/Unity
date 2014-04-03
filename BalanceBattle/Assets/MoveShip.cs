using UnityEngine;
using System.Collections;

public class MoveShip : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	
	void FixedUpdate () {
	//FixedUpdate is called before physics on each frame
		if(Input.GetMouseButton(0)) {	//Left button down
			Vector3 newpos = new Vector3(Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"), 0);
			transform.position += newpos;
		}
	}
	
	void Update () {
		//Debug.Log(Input.GetAxis("Mouse X") + ", " + Input.GetAxis("Mouse Y"));
	}
}
