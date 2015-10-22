using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// The Prompt Manager handles the generation and deletion of the input prompts

public class PromptManager : MonoBehaviour {

	private GameObject m_gameData;					// Game Data object ref
	private GameData m_gameDataRef;					// Game Data script reference 

	public List<GameObject> Prompts;				// The list of prompts

	private RectTransform m_rectTransform;			// This object's rect transform component
	private Listener m_listener;					// This object's listener component

	private const int PROMPTLIMIT = 16;				// The maximum number of prompts that exist at any time
	public int m_promptCount = 0;					// The current number of prompts
	public Prompt.PROMPT_TYPE currentPromptType;	// The current prompt being asked for

	private Vector3 m_spawnPos;						// The spawning position for prompts
	
	void Start () {
		m_gameData = GameObject.Find ("GameData");
		m_gameDataRef = m_gameData.GetComponent<GameData> ();
		m_rectTransform = GetComponent<RectTransform> ();
		m_listener = GetComponent<Listener> ();
		m_spawnPos = new Vector3(m_rectTransform.position.x+800, m_rectTransform.position.y, m_rectTransform.position.z);
	}

	void FixedUpdate () {

		// Check for beat and call beat action if true
		if (m_listener != null) {
			if (m_listener.beat) {
				BeatAction ();
			}
		}
	}

	// Beat Action performs an action related to a beat
	void BeatAction()
	{
		//Debug.Log ("Called Beat Action.");

		// Check for deletions
		if (Prompts.Count >= PROMPTLIMIT)
		{
			GameObject destroyPrompt = Prompts[0];
			Prompts.RemoveAt(0);
			Destroy(destroyPrompt);
		}

		// Determine type of prompt to spawn...
		int nextPromptType = GetNextPromptType ();

		// Then spawn
		SpawnNextPrompt (nextPromptType);

	}

	// Determine next type of prompt to spawn
	// Returns an int value which relates to the list of prefabs held in gamedata
	int GetNextPromptType()
	{
		int promptType = m_gameDataRef.inputs1[m_promptCount];
		if (m_promptCount < PROMPTLIMIT - 1) {
			m_promptCount++;
		} else {
			m_promptCount = 0;
		}
		return promptType;
	}

	// Spawns prompt as a game object, assigns it as a child of this object, then adds it to the prompts list
	void SpawnNextPrompt(int promptType)
	{
		//Debug.Log ("Spawning Prompt Type: " + promptType);
		GameObject newPrompt;
		newPrompt = (GameObject)Instantiate (m_gameDataRef.promptPrefabs[promptType], m_spawnPos, Quaternion.identity);
		newPrompt.transform.SetParent (m_rectTransform);
		Prompts.Add(newPrompt);
	}

	public void SetCurrentPrompt(Prompt.PROMPT_TYPE currPrompt)
	{
		currentPromptType = currPrompt;
	}
}
