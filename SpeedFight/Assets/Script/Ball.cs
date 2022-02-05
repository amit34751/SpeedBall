using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ball : MonoBehaviour {

	public float Speed,TurnSpeed,turnSpeed,TempSpeed;
	bool Flag,TurnSide,AllowTap;
	Vector3 PlayerInitPos;
	public Transform[] Snakes;
	public GameObject RunningParticleEffect;

	float[] SnakeX;

	// Use this for initialization
	void Start () 
		{		
		
		//print ("Snakes.Length : "+Snakes.Length);
			SnakeX=new float[Snakes.Length*3];

			PlayerInitPos = transform.position;
			TempSpeed = Speed;	
			//RunningParticleEffect.SetActive (false);
		}


	void OnEnable()
		{
			Flag = true;
			RunningParticleEffect.SetActive (Flag);
		}
//	void OnDisable(){
//		
//		Flag = false;
//		TurnSide = false;
//		RunningParticleEffect.SetActive (Flag);
//
//	}
	// Update is called once per frame

	void Update () {

		if(Input.GetKeyDown("space") && !AllowTap)
			{

//			if(!Flag){
//				RunningParticleEffect.SetActive (true);
//			}
//				Flag = true;
				TurnSide = true;
				float x = PlayerInitPos.x;
				PlayerInitPos = transform.position;
				PlayerInitPos.x = -1*x;
				
			}


		Vector3 pos = Vector3.zero;
		//if(Snakes[Snakes.Length-1].position.x!=transform.position.x)
			SwitchValue (transform.position.x);
		
		if(!IsSnakeXEmpty() && Flag){
			// Side Change for snake

			for(int i=0;i<Snakes.Length;i++){
				
				pos.Set (SnakeX[i*2+1],Snakes[i].position.y,Snakes[i].position.z);
				Snakes[i].position = pos;
			}

		}

		if (TurnSide) 
			{
				 turnSpeed= TurnSpeed +(Speed * 10f / 100f);
				
				float x=Mathf.MoveTowards (transform.position.x, PlayerInitPos.x, turnSpeed * Time.deltaTime);

				pos.Set (x,transform.position.y,transform.position.z);
				transform.position = pos;
				
				if (PlayerInitPos.x<0 && (PlayerInitPos.x>=transform.position.x)) {
					TurnSide = false;
				}

				if (PlayerInitPos.x>0 && (PlayerInitPos.x<=transform.position.x)) {
					TurnSide = false;
				}
				
				
			}


		if(Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Ended && !AllowTap)
			{
//				if(!Flag){
//					RunningParticleEffect.SetActive (true);
//				}
//				Flag = true;
				TurnSide = true;
				float x = PlayerInitPos.x;
				PlayerInitPos = transform.position;
				PlayerInitPos.x = -1*x;
				//RunningParticleEffect.SetActive (true);
			}


		if(Flag)
			{
			transform.Rotate (new Vector3(Time.deltaTime*(450+Speed*5),0f,0f));

				 pos = transform.position;
				float speed = Time.deltaTime * Speed;
				pos.z += speed;
				transform.position = pos;
			MoveSnakez (speed);
			//find out speed rate to increase speed

			Speed = TempSpeed + ((pos.z - 1f) * .01f);
			}


	}

	/// <summary>
	/// Switchs the value.
	/// </summary>
	/// <param name="value">Value.</param>
	void SwitchValue(float value){
		
		float temp =value;

		for(int i=0;i<SnakeX.Length;i++){
			value = temp;
			temp = SnakeX [i];
			SnakeX [i] = value;
//			print("value Of "+i+" is "+SnakeX[i]);
		}
	}
	void MoveSnakez(float speed){
		Vector3 snakePos=Vector3.zero;
		//print ("hello "+Snakes.Length);
		for(int i=0;i<Snakes.Length;i++) {
			
			snakePos = Snakes[i].gameObject.transform.position;
			snakePos.z += speed;
			Snakes[i].gameObject.transform.position = snakePos;
		}
	}

	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter(Collision col)
	{
		//print ("this is collision");
		if (col.collider.CompareTag ("Stopper")) {
			Flag = false;
			TurnSide = false;
			AllowTap = true;
			RunningParticleEffect.SetActive (Flag);
			Invoke ("TapAllow", 1.2f);

		}
	}


	/// <summary>
	/// Determines whether this instance is snake X empty.
	/// </summary>
	/// <returns><c>true</c> if this instance is snake X empty; otherwise, <c>false</c>.</returns>
	bool IsSnakeXEmpty(){
		if (SnakeX.Length == 0) return true;
		int i = 0;
		foreach (float item in SnakeX) {			
			if (item != 0f)
				return false;			
		}
					return true;
	}

//	void OnTriggerEnter(Collider col)
//	{
//		
//		if (col.GetComponent<Collider>().CompareTag ("Stopper")) {
//			Flag = false;
//			AllowTap = true;
//			print ("this is trigger");
//			Invoke ("TapAllow", 1.2f);
//
//		}
//	}


	/// <summary>
	/// Taps the allow.
	/// </summary>
	void TapAllow()
	{
		//AllowTap =false ;
		SceneManager.LoadSceneAsync(0);

	}



}
