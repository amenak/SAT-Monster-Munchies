using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Text ScoreText;
	public Text HighScoreText;
	public int score;
	public int highscore;

	// Use this for initialization
	void Start () {
		score = 0;
		highscore = PlayerPrefs.GetInt("HighScore");
		UpdateScore ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "word") {
			//print ("good word gets a point");
			score++; 
			GameObject.Find ("GameController").GetComponent<GameControl> ().Set_n (); //increments question
		}

		if (other.tag == "bad word") //used for debugging, remove 
			
		

		if (score > highscore) {
			highscore = score;
			PlayerPrefs.SetInt ("HighScore", highscore);
		}
		UpdateScore ();
	}

	// Update is called once per frame
	public void UpdateScore () 
	{
		ScoreText.text = "Score: " + score;
		HighScoreText.text = "HighScore: " + highscore;
	}
}
