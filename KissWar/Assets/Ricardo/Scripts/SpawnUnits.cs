﻿using UnityEngine;
using System.Collections;

public class SpawnUnits : MonoBehaviour {

	public GameObject unitPrefab;

	float spawnRate = 3f;
	int upgradeState = 1;
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
			GameObject unit = Instantiate (unitPrefab,
				transform.position,
				transform.rotation) as GameObject;
			unit.transform.localScale = new Vector2 (2, 2);
			spawnTimer = spawnRate;
		}
	}

	public void Upgrade() {
		upgradeState++;

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
