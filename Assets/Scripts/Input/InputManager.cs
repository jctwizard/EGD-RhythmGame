using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	private GameObject m_promptManager;
	private PromptManager m_promptManagerRef;
	private GameObject m_gameData;
	private GameData m_gameDataRef;
	private GameObject playerRef;
	// TO DO, hand in damage from the object that does damage. -GC
	private int damage = 10;
	// Use this for initialization
	void Start () {
		m_promptManager = GameObject.Find("PromptManager");
		m_promptManagerRef = m_promptManager.GetComponent<PromptManager> ();

		m_gameData = GameObject.Find ("GameData");
		m_gameDataRef = m_gameData.GetComponent<GameData>();

		playerRef = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			//Debug.Log ("Pressed Up.");
			if (m_promptManagerRef.currentPromptType == Prompt.PROMPT_TYPE.Up)
			{
				Debug.Log ("Pressed Up in time!");
				CorrectInput();
			}
			else 
			{
				WrongInput();
			}
		}

		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			//Debug.Log ("Pressed Down.");
			if (m_promptManagerRef.currentPromptType == Prompt.PROMPT_TYPE.Down)
			{
				Debug.Log ("Pressed Down in time!");
				CorrectInput();
			}
			else 
			{
				WrongInput();
			}
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			//Debug.Log ("Pressed Left.");
			if (m_promptManagerRef.currentPromptType == Prompt.PROMPT_TYPE.Left)
			{
				Debug.Log ("Pressed Left in time!");
				CorrectInput();
			}
			else 
			{
				WrongInput();
			}
		}

		if (Input.GetKeyDown(KeyCode.RightArrow)){
			//Debug.Log ("Pressed Right.");
			if (m_promptManagerRef.currentPromptType == Prompt.PROMPT_TYPE.Right)
			{
				Debug.Log ("Pressed Right in time!");
				CorrectInput();
			}
			else 
			{
				WrongInput();
			}
		}


	}

	void CorrectInput()
	{
		int newScore = m_gameDataRef.score + 100;
		m_gameDataRef.SetScore(newScore);

		//If an enemey is near, do kill it
		GameObject enemy = GameObject.FindGameObjectWithTag ("Enemy");
		if (enemy) {
			if (Vector3.Distance (playerRef.transform.position, enemy.transform.position) <= enemy.GetComponent<EnemyScript> ().Range) {
				Destroy (enemy);
			}
		}
	}

	void WrongInput()
	{
		int newScore = m_gameDataRef.score - 100;
		m_gameDataRef.SetScore (newScore);

		//If an enemey is near, do damage
		GameObject enemy = GameObject.FindGameObjectWithTag ("Enemy");
		if (enemy) {
			if (Vector3.Distance (playerRef.transform.position, enemy.transform.position) <= enemy.GetComponent<EnemyScript> ().Range) {
				playerRef.GetComponent<PlayerStats> ().TakeDamage (enemy.GetComponent<EnemyScript> ().Damage);
			}
		}
	}


}
