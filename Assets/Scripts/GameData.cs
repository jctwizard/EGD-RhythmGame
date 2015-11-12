using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameData : MonoBehaviour 
{
	public int[] inputs1;
	public GameObject[] promptPrefabs;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void SetScore(int newScore)
	{

	}

	public void Quit()
	{
		Application.Quit ();
	}
}
