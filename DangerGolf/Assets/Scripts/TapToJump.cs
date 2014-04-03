using UnityEngine;
using System.Collections;

public class TapToJump : MonoBehaviour {

	public float jump = 10f;
	public float maxheight = 4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		if(transform.position.y < maxheight) {
			rigidbody.AddForce(Vector3.up * jump);
		}
		//print ("jump!");
	}
}
