using UnityEngine;
using System.Collections;

public class ScrollingObject : MonoBehaviour {

	public float speed = 1.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Scroll ();
	}

	void Scroll()
	{
		float x = 0;
		x = transform.position.x - speed * Time.deltaTime; 
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);
	}
}
