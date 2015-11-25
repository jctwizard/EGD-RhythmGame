using UnityEngine;
using System.Collections;

public class ParallaxManager : MonoBehaviour {

	public ScrollingObject[] parallaxObjects;

	// Use this for initialization
	void Start () 
	{
		parallaxObjects[1].transform.position = parallaxObjects[0].transform.position + new Vector3(parallaxObjects[0].GetComponent<Renderer>().bounds.extents.x * 2.0f, 0, 0);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// check for position of parallax object 0
		if ((reachedEdge(parallaxObjects[0])) && (parallaxObjects[1].transform.position.x <= 0)) {
			parallaxObjects[1].transform.position = parallaxObjects[0].transform.position + new Vector3(parallaxObjects[0].GetComponent<Renderer>().bounds.extents.x * 2.0f - parallaxObjects[0].speed * Time.deltaTime, 0, 0);	
		}
		// check for position of parallax object 1
		if ((reachedEdge(parallaxObjects[1])) && (parallaxObjects[0].transform.position.x <= 0)) {
			parallaxObjects[0].transform.position = parallaxObjects[1].transform.position + new Vector3(parallaxObjects[1].GetComponent<Renderer>().bounds.extents.x * 2.0f - parallaxObjects[0].speed * Time.deltaTime, 0, 0);	
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
