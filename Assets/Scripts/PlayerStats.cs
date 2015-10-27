using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	[SerializeField] private int health = 0;
	[SerializeField] private int maxHealth = 100;
	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0) {
			//END GAME;
		}
	}



	#region Properties
	public int Health
	{
		get { return health; }
		set { health = value; }
	}

	//read only
	public int MaxHealth
	{
		get { return maxHealth; }
	}

	#endregion
}
