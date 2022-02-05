using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {
	public int TotalBrigdes;
	float BridgeShiftPos;
	int CurrentBrigde,BridgeNum,SideSwitcher;
	GameObject Player;
	bool FirstStopper=false;
	// Use this for initialization
	void Start () {
		TotalBrigdes = transform.childCount;
		BridgeShiftPos = (TotalBrigdes * 61) ;
		Player = GameObject.Find ("Player");
		BridgeNum = 2;
		CurrentBrigde = 0;
		for(int i=0;i<TotalBrigdes;i++){
			SetStopperPos (i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.transform.position.z > BridgeNum * 61) 
		{
			BridgeNum++;
			Vector3 newPos=transform.GetChild (CurrentBrigde).transform.localPosition;
			newPos.z = BridgeShiftPos;
			transform.GetChild (CurrentBrigde).transform.localPosition = newPos;
			BridgeShiftPos += 61;
			SetStopperPos (CurrentBrigde);
			if (CurrentBrigde == TotalBrigdes - 1)
				CurrentBrigde = 0;
			else
				CurrentBrigde++;

			Event.Events.FireAddScore ();
		}
	}


	/// <summary>
	/// Sets the stopper position on each brigde.
	/// </summary>
	/// <param name="currentChild">Current child.</param>

	void SetStopperPos(int currentChild)
	{
		foreach(Transform child in transform.GetChild (currentChild).transform)
		{
			
			int flag = 0;
			Vector3 stopperPos = child.Find ("Stopper").localPosition;
			stopperPos.z = Random.Range (-.3f, .3f);
			int rno = Random.Range (3, 10);
			if (rno % 2 == 0) 
				flag = -1 ;
			else
				flag = 1 ;
			
			SideSwitcher += flag;

			if (SideSwitcher == -4 || SideSwitcher == 4) {
				flag = -1 * flag;
				SideSwitcher = 0;
			}

				stopperPos.x = flag * .2f;
			Transform stopper = child.Find ("Stopper");
			stopper.localPosition = stopperPos;
			if (FirstStopper == true) 
				stopper.gameObject.SetActive (FirstStopper);
			else
				FirstStopper = true;
				
		}
	}
}
