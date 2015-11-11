using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	[SerializeField] private int range;
	[SerializeField] private int damage;
	private GameObject player;

	public enum State { Attack, Flinch, Death, Idle };
	private Animator animatorRef;
	private float stateNeedsReset = 0;
	private bool dead = false;
	private const float offScreen = -20.0f;
	public float speed = 1.1f;

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

		if (transform.position.x < offScreen)
		{
			Destroy(gameObject);
		}

		//if (Vector3.Distance (player.transform.position, gameObject.transform.position) > range || dead) 
		//{
			transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position + new Vector3(offScreen, 0, 0), speed*Time.deltaTime);
		//}
	}

	public void Kill()
	{
		dead = true;
	}

	public bool Dead()
	{
		return dead;
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
