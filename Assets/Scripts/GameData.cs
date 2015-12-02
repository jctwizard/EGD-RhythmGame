using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameData : MonoBehaviour 
{
	public int[] inputs1;
	public GameObject[] promptPrefabs;
	public bool playing = false;
	public float progress;
	public bool win = false;

	// Use this for initialization
	void Start () 
	{
		GameObject.FindWithTag("GameOver").GetComponent<Text>().enabled = false;
		GameObject.FindWithTag("Win").GetComponent<Text>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playing)
		{
			progress += Time.deltaTime;
		}

		if (win)
		{
			GameObject.FindWithTag("Win").GetComponent<Text>().enabled = true;
		}

		if (GameObject.FindWithTag("Player").GetComponent<PlayerStats>().Health <= 0)
		{
			GameObject.FindWithTag("GameOver").GetComponent<Text>().enabled = true;
			playing = false;
			GameObject.FindWithTag("Player").GetComponent<PlayerController>().ChangeState(PlayerController.State.Death);
		}
	}

	public void SetScore(int newScore)
	{

	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Begin()
	{
		if (!playing)
		{
			if (GameObject.FindWithTag("Player").GetComponent<PlayerStats>().Health <= 0)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			else
			{
				playing = true;
				GameObject.FindWithTag("StartText").GetComponent<Text>().text = "Restart";
				Debug.Log ("restarted");
			}
		}
		else
		{
			//playing = false;
			Application.LoadLevel(Application.loadedLevel);

		}
	}
}
