using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	public float scenefloor = -10f;
	public GameObject spawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < scenefloor) {
			transform.position = spawnPoint.transform.position;
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
	}
}
