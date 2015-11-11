using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	[SerializeField] private int range;
	[SerializeField] private int damage;
	private GameObject player;

	public enum State { Attack, Flinch, Death, Idle };
	private Animator animatorRef;
	private float stateNeedsReset = 0;
	private float respawnTimer = 0;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		animatorRef = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// Reset the state after a delay
		if (stateNeedsReset == 0)
		{
			animatorRef.SetInteger("State", (int)State.Idle);
		}
		else
		{
			stateNeedsReset = Mathf.Max(0, stateNeedsReset - Time.deltaTime);
		}

		if (respawnTimer > 0)
		{ 
			respawnTimer -= Time.deltaTime;

			if (respawnTimer <= 0)
			{
				respawnTimer = 0;
				//Destroy (enemy);
				transform.position = new Vector3(10 + Random.Range(0, 5), transform.position.y, transform.position.z);
			}
		}

		if (Vector3.Distance (player.transform.position, gameObject.transform.position) > range) {

			transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, 1*Time.deltaTime);
		}
	}

	public void Respawn()
	{
		respawnTimer = 3.0f;
	}
	
	public void ChangeState(State state)
	{
		animatorRef.SetInteger("State", (int)state);
		stateNeedsReset = 1.0f;
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
