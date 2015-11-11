using UnityEngine;
using System.Collections;
/* This class spawns an enemy when there is no active enemey.
 * The enemy is spawned on the objects position
 */

public class SpawnEnemy : MonoBehaviour {

	[SerializeField] private GameObject enemyPrefab;
	private GameObject enemy;
	// Use this for initialization
	void Start () {
		enemy = null;
	}
	
	// Update is called once per frame
	void Update () {


		if (enemy == null) {
			enemy = (GameObject)Instantiate(enemyPrefab);
			enemy.transform.position = gameObject.transform.position;
			enemy.transform.eulerAngles = new Vector3(0, 180, 0);
		}
	}
}
