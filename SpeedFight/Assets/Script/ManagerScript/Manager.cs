using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
	public List<AbstractScreen> Screens;
	public List<PopUpName> PopUps;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public enum ScreenName{
		None,
		Splash,
		LoginScreen,
		MainMenuScreen,
		GamePlayScreen
	}

	public enum PopUpName{
		None,
		Notification,
		PopUp
	}

	public class Screen{
		public ScreenName screenName;
		public GameObject AScreen;
	}
}
