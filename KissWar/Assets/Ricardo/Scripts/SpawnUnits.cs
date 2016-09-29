using UnityEngine;
using System.Collections;

public class SpawnUnits : MonoBehaviour {

	public GameObject unitPrefab;
	public float spawnRate = 3f;
	public int upgradeState = 1;

	float spawnTimer;

	// Use this for initialization
	void Start () {
		spawnTimer = spawnRate;
	}
	
	// Update is called once per frame
	void Update () {
		SpawnUnit ();
	}

	public void SpawnUnit() {
		spawnTimer -= Time.deltaTime;

		if (spawnTimer <= 0) {
			Instantiate (unitPrefab,
				transform.position,
				transform.rotation);
			spawnTimer = spawnRate;
		}
	}

	public void Upgrade() {
		if (upgradeState >= 5) {
			upgradeState = 4;
		}

		switch (upgradeState) {
		case 1:
			spawnRate = 3f;
			break;
		case 2:
			spawnRate = 2f;
			break;
		case 3:
			spawnRate = 1f;
			break;
		case 4:
			spawnRate = 0.5f;
			break;
		default:
			break;
		}
	}
}
