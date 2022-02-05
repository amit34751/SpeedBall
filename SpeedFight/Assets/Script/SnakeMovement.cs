using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {
	public GameObject[] Snakes; 
	int SnakeSize;
	Vector3[] SnakePosition;
	// Use this for initialization
	void Start () {
		SnakeSize = Snakes.Length;
		SnakePosition=new Vector3[SnakeSize];
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<SnakeSize;i++){
			
		}
	}
}
