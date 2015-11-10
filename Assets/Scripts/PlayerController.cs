using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public enum State { Attack, Defence, Idle, Run, Slash, Roll };
	Animator animator;
	float stateNeedsReset = 0;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Reset the state after a delay
		if (stateNeedsReset == 0)
		{
			animator.SetInteger("State", (int)State.Run);
		}
		else
		{
			stateNeedsReset = Mathf.Max(0, stateNeedsReset - Time.deltaTime);
		}

		// Debug change animaton
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			animator.SetInteger("State", (int)State.Attack);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			animator.SetInteger("State", (int)State.Defence);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			animator.SetInteger("State", (int)State.Idle);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			animator.SetInteger("State", (int)State.Run);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			animator.SetInteger("State", (int)State.Slash);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			animator.SetInteger("State", (int)State.Roll);
		}
	}

	public void ChangeState(State state)
	{
		animator.SetInteger("State", (int)state);
		stateNeedsReset = 1;
	}
}
