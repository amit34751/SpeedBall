using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePlayScreen : AbstractScreen {

	public static GamePlayScreen gamePlayScreen;
	Text Score,CurrentScore,BestScore,ScoreTxt;
	public override void ShowScreen(){
	}
	public override void HideScreen(){
	}
	// Use this for initialization
	void Start () {
		Event.AddScore += AddScore;
		gamePlayScreen = this;
		Score = transform.Find ("Score").GetComponent<Text>();
		ScoreTxt = transform.Find ("ScoreTxt").GetComponent<Text>();
		CurrentScore=transform.Find ("CurrentScore").GetComponent<Text>();
		GetScore(CurrentScore);
		SetScore(CurrentScore,0);
		BestScore=transform.Find ("BestScore").GetComponent<Text>();
		GetScore(BestScore);
	}

	void Update(){
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit ();
			if (CurrentScore != null) {
				SetScore (CurrentScore, 0);
			}
		}
	}
	/// <summary>
	/// Gets the score.
	/// </summary>
	/// <param name="score">Score.</param>
	void GetScore(Text score){
		score.text = PlayerPrefs.GetInt(score.name).ToString();
			
	}

	void OnDestroy(){
		Event.AddScore -= AddScore;
	}


	/// <summary>
	/// Raises the tap event.
	/// </summary>
	public void OnTap(GameObject btn){
		btn.SetActive (false);

		GameObject player=GameObject.Find("Player");

		player.GetComponent<Ball> ().enabled = true;

		HideMenuElements();
	}

	/// <summary>
	/// Shows the menu elements.
	/// </summary>
	void ShowMenuElements(){

		CurrentScore.gameObject.SetActive (true);
		BestScore.gameObject.SetActive (true);
		ScoreTxt.gameObject.SetActive (true);
	}


	/// <summary>
	/// Hides the menu elements.
	/// </summary>
	void HideMenuElements(){
		//print ("HideMenuElements-------------");
		CurrentScore.gameObject.SetActive (false);
		BestScore.gameObject.SetActive (false);
		ScoreTxt.gameObject.SetActive (false);
		Score.gameObject.SetActive (true);
	}

	/// <summary>
	/// Adds the score.
	/// </summary>
	void AddScore(){
		Score.text=(int.Parse(Score.text)+5).ToString();
			SetScore (CurrentScore,int.Parse (Score.text));
		if (int.Parse (Score.text) > int.Parse (BestScore.text)) {
			SetScore (BestScore,int.Parse (Score.text));
		}
	}

	void SetScore(Text score,int value){
		PlayerPrefs.SetInt (score.name, value);
	}
}
