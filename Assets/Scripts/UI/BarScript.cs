using UnityEngine;
using System.Collections;

/*Code for scrolling bars
 * Should be assigned to a scaling game object at base of bar
 * see UI example scene for implementation
 */

public enum BarType {Health, Level};

public class BarScript : MonoBehaviour {
	[SerializeField] private GameObject record;
	[SerializeField] private BarType type = BarType.Health;
	[SerializeField] private float currentValue;
	[SerializeField] private float maxValue;
	// Use this for initialization
	void Start () {
	
	
	}

	// Update is called once per frame
	void Update () {
		/*gameObject.transform.localScale = new Vector3 ((currentValue/maxValue),
		                                               gameObject.transform.localScale.y,
		                                               gameObject.transform.localScale.z);*/
		switch (type) {
		case BarType.Health:
			currentValue = (float)record.GetComponent<PlayerStats> ().Health;
			maxValue = (float)record.GetComponent<PlayerStats>().MaxHealth;
			gameObject.transform.localScale = new Vector3 ((currentValue/maxValue),
			                                               gameObject.transform.localScale.y,
			                                               gameObject.transform.localScale.z);
			break;
		case BarType.Level:
			//TO DO: add level % completion
			break;
		}
	}
}

