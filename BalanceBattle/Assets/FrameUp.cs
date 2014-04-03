using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FrameUp : MonoBehaviour {
	public Camera cam;
	public List<GameObject> subjects;
	public float adjustInterval = 0.1f;
	public float moveSmooth = 10f;

	private float countdown;
	private Vector3 targscale; //for lerping
	private Vector3 targpos;

	// Use this for initialization
	void Start () {
		countdown = 0f;
		Enbound();
		GrabCam();
	}

	void GrabCam() {
		cam.transform.parent = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		countdown += Time.deltaTime;
		if (countdown > adjustInterval) {
			countdown = 0;
			Enbound();
		}

		transform.localScale = Vector3.Lerp(transform.localScale, targscale, moveSmooth * Time.deltaTime);
		transform.position = Vector3.Lerp(transform.position, targpos, moveSmooth * Time.deltaTime);

	}

	private void Enbound() {

		//Sets the size and position of this object to the bounding box of the provided objects in the list
		float top		= subjects[0].transform.position.y;
		float bottom	= subjects[0].transform.position.y;
		float left		= subjects[0].transform.position.x;
		float right		= subjects[0].transform.position.x;

		foreach(GameObject i in subjects) {
			print (i.name);
			if (i.transform.position.y > top) {
				print ("top " + i.transform.position.y);
				top 	= i.transform.position.y;
			}
			if (i.transform.position.y < bottom) {
				print ("bottom " + i.transform.position.y);
				bottom	= i.transform.position.y;
			}
			if (i.transform.position.x < right) {
				print ("right " + i.transform.position.x);
				right	= i.transform.position.x;
			}
			if (i.transform.position.y > left) {
				print ("right " + i.transform.position.x);
				left	= i.transform.position.x;
			}
		}

		print (top + " " + bottom + " " + left + " " + right);

		targscale = new Vector3(Mathf.Abs(left-right), Mathf.Abs(top-bottom), (Mathf.Abs(left-right)+Mathf.Abs(top-bottom))/2);
		targpos = new Vector3((left+right)/2, (top+bottom)/2, 1);
	}
}
