using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {

	public Transform Player;
	Vector3 PlayerPos,Distance;

	// Use this for initialization
	void Start () {
		Distance = Player.position - transform.position;
	}

	// Update is called once per frame
	void Update () {
//		float d = Player.position.z - Distance.z;
//		transform.position = new Vector3 (Player.position.x,Player.position.y - Distance.y,Player.position.z - Distance.z);
				
		transform.position = Player.position - Distance;
	}
}
