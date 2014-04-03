using UnityEngine;
using System.Collections;

public class ControlPlayer : MonoBehaviour {
	private RaycastHit movetarget;
	public GameObject debugObj;
	public GameObject hero;
	public float strength = 50f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Ray camray = Camera.main.ScreenPointToRay(Input.mousePosition);
		print(Input.mousePosition.x + ", " + Input.mousePosition.y);

		//RaycastHit(camray, Mathf.Infinity, movetarget, LayerMask.NameToLayer("TapCatch"));

		if(Physics.Raycast(camray, out movetarget, Mathf.Infinity)) {
			//Instantiate(debugObj, movetarget.point, Quaternion.LookRotation(Vector3.forward));
			//	This creates a debug object at the click point.

			hero.rigidbody.AddForce((movetarget.point - hero.transform.position) * strength );
		} 

	}
}
