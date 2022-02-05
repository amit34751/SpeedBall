using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {
	public Transform Player;
	// Use this for initialization
	void Start () {
		
		//StartCoroutine ("CheckCloudPosition");
		SetCloudPosition ();
	}
//	void OnDestroy(){
//		StopCoroutine ("CheckCloudPosition");
//	}

	void Update(){

		if (Player.position.z > transform.position.z + 100f) {
			SetCloudPosition ();

			transform.position = new Vector3 (0f,0f,Player.position.z+200f);
			//StartCoroutine ("CheckCloudPosition");
		}

	}

//	IEnumerator CheckCloudPosition(){
//		print ("this is checkCloudPos");
//		yield return new WaitForSeconds (Random.Range (1f, 2f));
//		if (Player.position.z > transform.position.z + 150f) {
//			SetCloudPosition ();
//			print ("this is checkCloudPos");
//			transform.position = new Vector3 (0f,0f,Player.position.z+100f);
//			StartCoroutine ("CheckCloudPosition");
//		}
//	}

	void SetCloudPosition(){
		
		foreach (Transform cloud in transform) {
			Vector3 newPos =Vector3.zero;
			newPos.x = Random.Range (-10f, 10f);
			newPos.y=Random.Range (6f, 7.5f);
			newPos.z=Random.Range (10f, 90.0f);
			cloud.localPosition = newPos;

			newPos.x = Random.Range (1f, 2.5f);
			newPos.y=Random.Range (1f, 2.5f);
			newPos.z=Random.Range (1f,2.5f);
			cloud.localScale = newPos;


		}
	}
}
