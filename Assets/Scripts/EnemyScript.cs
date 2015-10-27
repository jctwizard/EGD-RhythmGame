using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	[SerializeField] private int range;
	[SerializeField] private int damage;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.transform.position, gameObject.transform.position) > range) {

			transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, 1*Time.deltaTime);
		}
	}
	
	#region Properties
	//read only
	public int Range
	{
		get { return range; }
	}
	
	//read only
	public int Damage
	{
		get { return damage; }
	}
	#endregion
}
