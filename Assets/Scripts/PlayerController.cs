using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public enum State { Attack, Defence, Idle, Run, Slash, Roll, Death };
	private Animator animator;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Reset the state
		if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("Run"))
		{
			ChangeState(State.Run);
		}
	}

	public void ChangeState(State state)
	{
		animator.SetInteger("State", (int)state);
	}
}
