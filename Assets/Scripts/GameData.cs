using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameData : MonoBehaviour {

	public int[] inputs1;
	public GameObject[] promptPrefabs;

	public int score = 0;
	public Text scoreText; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetScore(int newScore)
	{
		score = newScore;
		scoreText.text = "" + score;
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
