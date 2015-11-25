using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
	private GameObject m_promptManager;
	private PromptManager m_promptManagerRef;
	private GameObject playerRef;
	private PlayerController playerControllerRef;

	// Use this for initialization
	void Start() 
	{
		m_promptManager = GameObject.Find("PromptManager");
		m_promptManagerRef = m_promptManager.GetComponent<PromptManager> ();

		playerRef = GameObject.FindGameObjectWithTag("Player");
		playerControllerRef = playerRef.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (Input.GetKeyDown(KeyCode.UpArrow)) 
		{
			//Debug.Log ("Pressed Up.");
			if (m_promptManagerRef.currentPrompt.myPromptType == Prompt.PROMPT_TYPE.Up)
			{
				Debug.Log ("Pressed Up in time!");
				CorrectInput();
			}
			else 
			{
				WrongInput();
			}
		}

		if (Input.GetKeyDown(KeyCode.DownArrow)) 
		{
			//Debug.Log ("Pressed Down.");
			if (m_promptManagerRef.currentPrompt.myPromptType == Prompt.PROMPT_TYPE.Down)
			{
				Debug.Log ("Pressed Down in time!");
				CorrectInput();
			}
			else 
			{
				WrongInput();
			}
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			//Debug.Log ("Pressed Left.");
			if (m_promptManagerRef.currentPrompt.myPromptType == Prompt.PROMPT_TYPE.Left)
			{
				Debug.Log ("Pressed Left in time!");
				CorrectInput();
			}
			else 
			{
				WrongInput();
			}
		}

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			//Debug.Log ("Pressed Right.");
			if (m_promptManagerRef.currentPrompt.myPromptType == Prompt.PROMPT_TYPE.Right)
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
		m_promptManagerRef.currentPrompt.Correct();

		// If an enemey is near, do kill it
		GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
		if (enemy) 
		{
			EnemyScript enemyScript = enemy.GetComponent<EnemyScript>();

			if (!enemyScript.hit && enemy.transform.position.x > playerRef.transform.position.x && enemy.transform.position.x - playerRef.transform.position.x <= enemy.GetComponent<EnemyScript>().Range) 
			{
				enemyScript.ChangeState(EnemyScript.State.Death);
				enemyScript.hit = true;

				// Change player animation to attack
				playerControllerRef.ChangeState(PlayerController.State.Slash);
			}
		}
		
		// If an obstacle is near, do damage
		GameObject obstacle = GameObject.FindGameObjectWithTag("Obstacle");
		if (obstacle) 
		{
			ObstacleScript obstacleScript = obstacle.GetComponent<ObstacleScript>();
			
			if (!obstacleScript.hit && obstacle.transform.position.x > playerRef.transform.position.x && obstacle.transform.position.x - playerRef.transform.position.x <= obstacle.GetComponent<ObstacleScript>().Range) 
			{
				obstacleScript.hit = true;
			}
		}
	
		playerRef.GetComponent<PlayerStats>().Heal();
	}

	void WrongInput()
	{
		m_promptManagerRef.currentPrompt.Wrong();

		// If an enemey is near, do damage
		GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
		if (enemy) 
		{
			EnemyScript enemyScript = enemy.GetComponent<EnemyScript>();

			if (!enemyScript.hit && enemy.transform.position.x > playerRef.transform.position.x && enemy.transform.position.x - playerRef.transform.position.x <= enemy.GetComponent<EnemyScript>().Range) 
			{
				enemyScript.hit = true;
				enemyScript.hurt = true;

				//PlayerStats playerStats = playerRef.GetComponent<PlayerStats>();
				//playerStats.TakeDamage (enemyScript.Damage);

				// Change player animation to attack
				//playerControllerRef.ChangeState(PlayerController.State.Defence);
			}
		}
		
		// If an obstacle is near, do damage
		GameObject obstacle = GameObject.FindGameObjectWithTag("Obstacle");
		if (obstacle) 
		{
			ObstacleScript obstacleScript = obstacle.GetComponent<ObstacleScript>();
			
			if (!obstacleScript.hit && obstacle.transform.position.x > playerRef.transform.position.x && obstacle.transform.position.x - playerRef.transform.position.x <= obstacle.GetComponent<ObstacleScript>().Range) 
			{
				obstacleScript.hit = true;
				obstacleScript.hurt = true;

				//PlayerStats playerStats = playerRef.GetComponent<PlayerStats>();
				//playerStats.TakeDamage (obstacleScript.Damage);
				
				// Change player animation to attack
				//playerControllerRef.ChangeState(PlayerController.State.Roll);
			}
		}
	}
}
