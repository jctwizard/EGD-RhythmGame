using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour 
{	
	[SerializeField] private int range;
	[SerializeField] private int damage;

	private const float offScreen = -20.0f;
	public float speed = 1.1f;
	public bool hit = false;
	private GameObject player;
	
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
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
				player.GetComponent<PlayerController>().ChangeState(PlayerController.State.Roll);
			}
		}

		transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(offScreen, gameObject.transform.position.y, gameObject.transform.position.z), speed * Time.deltaTime);
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
