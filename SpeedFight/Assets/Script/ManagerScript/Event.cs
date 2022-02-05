using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event : MonoBehaviour {

	public static Event Events;
	// Use this for initialization
	void Start () {
		Events = this;
	}

	public static event Action AddScore; 
	public void FireAddScore(){
		if (AddScore != null)
			AddScore ();
	}
}
