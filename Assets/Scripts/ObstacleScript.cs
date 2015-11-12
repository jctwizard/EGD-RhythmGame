using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour 
{	
	[SerializeField] private int range;
	[SerializeField] private int damage;

	private const float offScreen = -20.0f;
	public float speed = 1.1f;
	public bool hit = false;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.x <= offScreen)
		{
			Destroy(gameObject);
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
