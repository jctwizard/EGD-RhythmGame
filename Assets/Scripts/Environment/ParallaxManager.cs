using UnityEngine;
using System.Collections;

public class ParallaxManager : MonoBehaviour {

	public ScrollingObject[] parallaxObjects;
	private float m_startPosX = 19.2f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		// check for position of parallax object 0
		if ((reachedEdge(parallaxObjects[0])) && (parallaxObjects[1].transform.position.x <= 0)) {
			parallaxObjects [1].transform.position = new Vector3 (m_startPosX, parallaxObjects [1].transform.position.y, 0);
		}
		// check for position of parallax object 1
		if ((reachedEdge(parallaxObjects[1])) && (parallaxObjects[0].transform.position.x <= 0)) {
			parallaxObjects [0].transform.position = new Vector3 (m_startPosX, parallaxObjects [0].transform.position.y, 0);
		}

	}

	bool reachedEdge(ScrollingObject scrollingObj)
	{
		float nextPos;
		nextPos = scrollingObj.transform.position.x - scrollingObj.speed * Time.deltaTime; 
		if (nextPos <= 0)
			return true;
		else 
			return false;
	}
}
