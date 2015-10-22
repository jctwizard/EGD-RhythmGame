using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Prompt : MonoBehaviour {

	public enum PROMPT_TYPE				// Defines the different types of prompt
	{
		Rest, Up, Down, Left, Right
	}
	public PROMPT_TYPE myPromptType;		// This Prompt's type
	public float speed = 15.0f;				// Speed
	private RectTransform m_rectTransform;	// This prompt's rect transform component
	private Image m_image;					// This prompt's image
	private Vector3 m_position;				// This prompt's position
	private PromptManager m_promptmanager;	// Prompt Manager Reference

	void Start () {
		m_promptmanager = GetComponentInParent<PromptManager> ();
		m_rectTransform = GetComponent<RectTransform> ();
		m_image = GetComponent<Image> ();
		m_position = m_rectTransform.localPosition;
	}

	void Update()
	{
		if ((m_position.x < -250) && (m_position.x > -350)) {
			m_promptmanager.SetCurrentPrompt(myPromptType);
			if (myPromptType != PROMPT_TYPE.Rest) {
				ChangeColour ();
			}
		} else if (m_image.color != Color.white) {
			m_image.color = Color.white;
		}
	}

	void FixedUpdate () {
		MoveMe ();
	}
	
	// Move the prompt left by it's speed
	void MoveMe()
	{
		m_position.x -= speed;
		m_rectTransform.localPosition = m_position;
	}

	public void ChangeColour()
	{
		m_image.color = Color.cyan;
	}
}
