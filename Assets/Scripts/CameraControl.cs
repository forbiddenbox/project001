using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.position = new Vector3 (this.player.transform.position.x, this.player.transform.position.y, -10);
		//Vector3 offset = this.player.transform.position - this.transform.position;
		//Vector3 moveCamera = this.transform.position + offset;

		//if(moveCamera.x > 5 && moveCamera.x < 75){
		//	this.transform.position = new Vector3(moveCamera.x, this.transform.position.y, -10);
		//}
	}
}
