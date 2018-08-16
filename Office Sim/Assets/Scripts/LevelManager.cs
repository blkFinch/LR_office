using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadGameOver(){
		SceneManager.LoadScene("GameOver");
	}

	public void StartGame(){
		SceneManager.LoadScene("MainGame");
	}

	public void LoadTitle(){
		SceneManager.LoadScene("Title");
	}

	public void LoadControls(){
		SceneManager.LoadScene("Controls");
	}
}
