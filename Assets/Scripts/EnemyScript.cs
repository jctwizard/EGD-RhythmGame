using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{
	[SerializeField] private int range;
	[SerializeField] private int damage;
	
	private const float offScreen = -20.0f;
	public float speed = 1.1f;
	public bool hit = false;

	public enum State { Attack, Flinch, Death, Idle };
	private Animator animator;
	private GameObject player;

	void Start() 
	{
		animator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update() 
	{
		if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
		{
			ChangeState(State.Idle);
		}

		if (transform.position.x <= offScreen)
		{
			Destroy(gameObject);
		}
		else if (transform.position.x < player.transform.position.x)
		{
			gameObject.tag = "Untagged";
			
			if (!hit)
			{
				hit = true;
				player.GetComponent<PlayerStats>().TakeDamage(damage);
				player.GetComponent<PlayerController>().ChangeState(PlayerController.State.Defence);
			}
		}
		
		transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(offScreen, gameObject.transform.position.y, gameObject.transform.position.z), speed * Time.deltaTime);
	}
	
	public void ChangeState(State state)
	{
		animator.SetInteger("State", (int)state);
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