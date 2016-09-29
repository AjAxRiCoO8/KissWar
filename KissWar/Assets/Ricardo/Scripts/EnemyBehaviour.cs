using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public float buyRate = 10f;
	public GameObject factoryPrefab;

	int unitCount;
	float buyTimer;

	// Use this for initialization
	void Start () {
		buyTimer = buyRate;
	}
	
	// Update is called once per frame
	void Update () {
		unitCount = GameObject.FindGameObjectsWithTag ("Enemy").Length;

		buyFactory ();
	}

	public float CheckResources() {
		unitCount = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		return unitCount;
	}

	public void buyFactory() {
		buyTimer -= Time.deltaTime;

		if (buyTimer <= 0) {
			if (CheckResources() >= 10) {
				CreateFactory ();
				for (int i = 0; i < 10; i++) {
					Destroy (GameObject.FindGameObjectWithTag ("Enemy"));
				}
				CheckResources ();
				buyTimer = buyRate;
			}
		}
	}

	public void CreateFactory() {
		Instantiate (factoryPrefab,
			transform.position,
			transform.rotation);
	}
}
