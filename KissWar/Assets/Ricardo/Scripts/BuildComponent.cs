using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildComponent : MonoBehaviour {

	public GameObject factoryPrefab;

	Selectable buttonScript;


	// Use this for initialization
	void Start () {
		buttonScript = GetComponent<Selectable> ();
	}

	public void CreateFactory() {
		Instantiate (factoryPrefab,
			transform.position, 
			transform.rotation);

		buttonScript.interactable = false;
	}
}
