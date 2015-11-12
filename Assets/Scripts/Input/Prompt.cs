using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Prompt : MonoBehaviour {

	public enum PROMPT_TYPE				// Defines the different types of prompt
	{
		Rest, Up, Left, Down, Right
	}
	public PROMPT_TYPE myPromptType;		// This Prompt's type
	public float speed = 15.0f;				// Speed
	private RectTransform m_rectTransform;	// This prompt's rect transform component
	private Image m_image;					// This prompt's image
	public Sprite spriteCorrect;			
	public Sprite spriteWrong;				
	public Sprite spriteMiss;				
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
			m_promptmanager.SetCurrentPrompt(this);
			if (myPromptType != PROMPT_TYPE.Rest) {
				//ChangeColour ();
				if (m_image.sprite != spriteCorrect && m_image.sprite != spriteWrong)
				{
					//m_image.sprite = spriteMiss;
				}
			}
		} else if (m_image.color != Color.white) {
			//m_image.color = Color.white;
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

	public void Correct()
	{
		if (m_image.sprite != spriteWrong)
		{
			m_image.sprite = spriteCorrect;
		}
	}

	public void Wrong()
	{
		if (m_image.sprite != spriteWrong)
		{
			m_image.sprite = spriteWrong;
		}
	}

	public void ChangeColour()
	{
		m_image.color = Color.cyan;
	}
}
