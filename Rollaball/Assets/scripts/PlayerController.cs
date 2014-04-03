using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public GUIText countText;
	public GUIText VictoryText;
	private int count;
	
	void Start() {
		count = 0;
		SetCountText();
		VictoryText.text = "";
	}
	
	void FixedUpdate () {
	//called before physics updates
		float moveHorizontal = Input.GetAxis("Horizontal"); 
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal,0,moveVertical);
		
		rigidbody.AddForce(movement * speed * Time.deltaTime);
	}
	
    void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "PickUp"){
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}
    }
	
	void SetCountText() {
		countText.text = "Score: " + count.ToString();
		if (count >= 2) {
			Victory();
		}
	}
	
	void Victory() {
		VictoryText.text = "YOU WIN";
	}
}