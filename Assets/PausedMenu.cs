using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausedMenu : MonoBehaviour {
	public Button PauseButton;
	public GameObject PauseMenu;
	// Use this for initialization
	void Start () {
		PauseButton.enabled = true;
		PauseMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPauseButtonClicked()
	{
		Time.timeScale =0;
		PauseButton.enabled = false;
		PauseMenu.SetActive (true);
	}
	public void OnRestartButtonClicked()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	public void OnResumeButtonClicked()
	{
		Time.timeScale =1;
		PauseButton.enabled = true;
		PauseMenu.SetActive (false);
	}
	public void OnExitButtonClicked()
	{
		Application.Quit ();
	}
}
