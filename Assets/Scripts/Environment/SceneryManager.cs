using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SceneryManager : MonoBehaviour {

	public GameObject[] sceneryPrefabs;			
	public List<GameObject> PrefabsInScene;
	private const int m_minInterval = 180;
	private const int m_maxInterval = 360;
	private int m_intervalTimer = 0;
	private int m_nextInterval;

	private int m_destroyPosX = -12;

	// Use this for initialization
	void Start () {
		GetNextInterval ();
	}
	
	// Update is called once per frame
	void Update () {

		// handle interval timer for spawning new objects
		if (m_intervalTimer < m_nextInterval) {
			m_intervalTimer++;	// increment timer
		} else {
			SpawnPrefab ();
			GetNextInterval ();
			m_intervalTimer = 0;	// reset timer
		}

		// if there are any objects in the scene
		if (PrefabsInScene.Count > 0) {
			// handle object removal
			if (Offscreen (PrefabsInScene [0])) {
				DestroyPrefab(PrefabsInScene[0]);
			}
		}
	}

	void GetNextInterval()
	{
		// set random interval
		m_nextInterval = Random.Range (m_minInterval, m_maxInterval);
	}

	void SpawnPrefab()
	{
		Debug.Log ("Spawning a prefab");
		int random = Random.Range (0, sceneryPrefabs.Length);
		Debug.Log ("From position" + random);
		GameObject newPrefab = Instantiate (sceneryPrefabs [random]);
		PrefabsInScene.Add (newPrefab);
		newPrefab.transform.SetParent (this.transform);
	}

	bool Offscreen(GameObject prefab)
	{
		if (prefab.transform.position.x <= m_destroyPosX)
			return true;
		else 
			return false;
	}

	void DestroyPrefab(GameObject prefab)
	{
		PrefabsInScene.Remove (prefab);
		Destroy (prefab);
	}
}
