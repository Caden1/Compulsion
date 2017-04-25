using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		
	}

	public void StartGame()
	{

		//Application.LoadLevel(Application.loadedLevel+1);
        SceneManager.LoadScene("MainScene2");
        Time.timeScale = 1;
        AudioListener.pause = false;

	}

	public void Quit()
	{
		Application.Quit ();
	}
	public void About()
	{
        SceneManager.LoadScene("About");
        //Application.LoadLevel ("About");
	}
}
