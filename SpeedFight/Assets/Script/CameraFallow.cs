using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour {
	public Transform Player;
	public  Vector3 Distance;
	[Range(.01f,1.0f)]
	public float SmoothFactor=1;

	// Use this for initialization
	void Start () {
		Distance = Player.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
//		Vector3 newPos = new Vector3 (transform.position.x,transform.position.y,Player.position.z - Distance.z);
//		transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);


		Vector3 pos=Player.position - Distance;
		pos.x = 0;
		transform.position = pos;
	}
}
