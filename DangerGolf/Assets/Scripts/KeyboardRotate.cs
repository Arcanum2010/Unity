using UnityEngine;
using System.Collections;

public class KeyboardRotate : MonoBehaviour {
	public float turnSpeed = 100f;
	public GameObject bullet;
	public GameObject firePt;
	public float coolDown = .5f;
	public float bulletLife = .25f;
	public float bulletStrength = 200f;

	private float firewait;

	// Use this for initialization
	void Start () {
		firewait = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)) {
			transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D)) {
			transform.Rotate(Vector3.down * turnSpeed * Time.deltaTime);
		}
		if(Input.GetKeyDown(KeyCode.W) && firewait <= 0) {
				firewait = coolDown;
				GameObject firedbul = Instantiate(bullet, firePt.transform.position,transform.rotation) as GameObject;
				firedbul.transform.Rotate(Vector3.forward*90);
				firedbul.rigidbody.AddForce(firedbul.transform.rotation * Vector3.up * bulletStrength);
				Destroy(firedbul, bulletLife);
		}

		if (firewait > 0) {
			firewait -= Time.deltaTime;
		}

	}
}
