using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Text highscoreText;

	// Use this for initialization
	void Start () {
		highscoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat ("Highscore")).ToString ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void ToPlay(){
		SceneManager.LoadScene ("Game");
	}

	public void ToHelp(){
		SceneManager.LoadScene ("HowToPlay");
	}

	public void ToAbout(){
		SceneManager.LoadScene ("About");
	}
}
