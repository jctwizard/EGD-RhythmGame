using UnityEngine;
using System.Collections;

public class PromptWindow : MonoBehaviour {

	private RectTransform m_rectTransform;			// This object's rect transform component
	private Listener m_listener;					// This object's listener component
	private Vector2 m_startingSize = new Vector2(60, 60);

	// Use this for initialization
	void Start () {
		m_rectTransform = GetComponent<RectTransform> ();
		m_listener = GetComponent<Listener> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	if (m_listener.halfBeat) {
			BeatAction();
		}
		if (m_rectTransform.sizeDelta.x > m_startingSize.x) {
			float x = m_rectTransform.sizeDelta.x - 1.0f;
			float y = m_rectTransform.sizeDelta.y - 1.0f;
			Vector2 newsize = new Vector2 (x,y);
			m_rectTransform.sizeDelta = newsize;
		}
	}

	void BeatAction()
	{
		Vector2 newsize = new Vector2 (100,100);
		m_rectTransform.sizeDelta = newsize;
	}
}
