using UnityEngine;
using System.Collections;

public class Listener : MonoBehaviour
{
	private GameObject m_soundtrack;
	private Metronome m_metronome;
	private bool m_beat;			// true if there is a beat this frame
	public bool beat
	{
		get { return m_beat; }
	}
	private bool m_halfBeat;			// true if there is a beat this frame
	public bool halfBeat
	{
		get { return m_halfBeat; }
	}
	private int m_currAccent = 0;	// reference to the metronome count this frame
	private int m_oldAccent = 0;	// reference to the metronome count last frame

	// Use this for pre-initialization
	void Awake ()
	{
		m_soundtrack = GameObject.Find ("Soundtrack");
		m_metronome = m_soundtrack.GetComponent<Metronome> ();
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		// If metronome accent has changed, that's a beat
		m_currAccent = m_metronome.Accent;

	
			if (m_currAccent != m_oldAccent) {
				if (m_currAccent % 2 == 1) {
					m_beat = true;
				}
			} else {
				m_beat = false;
			}

			if (m_currAccent != m_oldAccent) {
				if (m_currAccent % 4 == 1) {
					m_halfBeat = true;
				}
			} else {
				m_halfBeat = false;
			}
	
		m_oldAccent = m_currAccent;
	}
}
