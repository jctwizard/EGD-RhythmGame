using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public enum State { Attack, Defence, Idle, Run, Slash, Roll };
	private Animator animatorRef;
	private float stateNeedsReset = 0;

	// Use this for initialization
	void Start () 
	{
		animatorRef = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Reset the state after a delay
		if (stateNeedsReset == 0)
		{
			animatorRef.SetInteger("State", (int)State.Run);
		}
		else
		{
			stateNeedsReset = Mathf.Max(0, stateNeedsReset - Time.deltaTime);
		}

		// Debug change animaton
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			animatorRef.SetInteger("State", (int)State.Attack);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			animatorRef.SetInteger("State", (int)State.Defence);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			animatorRef.SetInteger("State", (int)State.Idle);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			animatorRef.SetInteger("State", (int)State.Run);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			animatorRef.SetInteger("State", (int)State.Slash);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			animatorRef.SetInteger("State", (int)State.Roll);
		}
	}

	public void ChangeState(State state)
	{
		animatorRef.SetInteger("State", (int)state);
		stateNeedsReset = 1.0f;
	}
}
