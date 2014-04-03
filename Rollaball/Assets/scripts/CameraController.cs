using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject followTarget;
	private Vector3 offset;
	
	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	
	void LateUpdate () {
		transform.position = followTarget.transform.position + offset;	
	}
}
