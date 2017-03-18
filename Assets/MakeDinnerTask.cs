using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeDinnerTask : MonoBehaviour {

	public HoldAndSetPlates HSP;
	public HoldAndSetForksKnives HSF;
	public bool OCDTasksActivated = false;

	private bool isTrue  = false;
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.FindGameObjectWithTag ("KeepThenSet");
		GameObject go = GameObject.FindGameObjectWithTag ("KeepThenSet");
		HSP = g.GetComponent<HoldAndSetPlates> ();
		HSF = go.GetComponent<HoldAndSetForksKnives> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(HSF.FKSet == true && HSP.setPlates == true)
		{
			GameObject.FindGameObjectWithTag ("OCDScrub").GetComponent<Text> ().enabled = false;

			//Debug.Log ("First task complete, moving on to second");
		
			if (isTrue == false) {
			StartCoroutine (MakeDinnerText ());
		}
		
		/*if (DisableTableText == true) {
			GameObject.FindGameObjectWithTag ("SetTable").GetComponent<Text> ().enabled = false;
		}*/
	}
	}

	public IEnumerator MakeDinnerText()
	{
		isTrue = true;

		StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text> ()));
		yield return null;
	}


	public IEnumerator FadeTextToFullAlpha(float t, Text i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
		while (i.color.a < 1.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
			yield return null;
		}
		StartCoroutine(WaitForTable());


	}
	public IEnumerator WaitForTable()
	{
		yield return new WaitForSeconds (1.5f);
		StartCoroutine(FadeTextToZeroAlpha (1f, GetComponent<Text> ()));

	}
		
	public IEnumerator FadeTextToZeroAlpha(float t, Text i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while (i.color.a > 0.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
			yield return null;
		}
		yield return new WaitForSeconds (1f);
		//Enables the OCD Tasks
		StartCoroutine (OCDTasks ());

	}
	public IEnumerator OCDTasks()
	{
		OCDTasksActivated = true;
		GameObject.FindGameObjectWithTag ("OCDWash").GetComponent<Text> ().enabled = true;
		GameObject.FindGameObjectWithTag ("OCDKnobs").GetComponent<Text> ().enabled = true;
		yield return null;
	}
}