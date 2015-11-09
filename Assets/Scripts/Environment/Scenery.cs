using UnityEngine;
using System.Collections;

public class Scenery : MonoBehaviour {

	private SpriteRenderer m_sRenderer;
	private const float m_boundsRight = 19.2f;
	private const float m_groundHeight = -2.1f;

	// Use this for initialization
	void Start () {
		m_sRenderer = GetComponent<SpriteRenderer> ();
		float startPosX = m_boundsRight - m_sRenderer.bounds.size.x;
		float startPosY = m_groundHeight + m_sRenderer.bounds.size.y * 0.5f;
		this.transform.position = new Vector3(startPosX, startPosY, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}