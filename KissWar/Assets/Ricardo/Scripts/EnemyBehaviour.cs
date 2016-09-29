using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public float buyRate = 10f;
	public float unitMovementRate = 2f;
	public GameObject factoryPrefab;

	ArrayList factoryPositions = new ArrayList ();

	int unitCount;
	float buyTimer;
	int factoryCounter = 0;
	float unitMovementTimer;

	// Use this for initialization
	void Start () {
		buyTimer = buyRate;
		unitMovementTimer = unitMovementRate;

		factoryPositions.Add (new Vector3 (-9, 0, 0));
		factoryPositions.Add (new Vector3 (-9, 1, 0));
		factoryPositions.Add (new Vector3 (-9, 2, 0));
		factoryPositions.Add (new Vector3 (-9, -1, 0));
		factoryPositions.Add (new Vector3 (-9, -2, 0));
	}
	
	// Update is called once per frame
	void Update () {
		unitCount = GameObject.FindGameObjectsWithTag ("Enemy").Length;

		buyFactory ();
	}

	void FixedUpdate() {
		unitMovementTimer -= Time.deltaTime;

		if (unitMovementTimer <= 0) {
			MoveUnit ();
			unitMovementTimer = unitMovementRate;
		}
	}

	public float CheckResources() {
		unitCount = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		return unitCount;
	}

	public void buyFactory() {
		buyTimer -= Time.deltaTime;

		if (buyTimer <= 0) {
			if (CheckResources() >= 10) {
				CreateFactory (factoryCounter++);
				for (int i = 0; i < 10; i++) {
					Destroy (GameObject.FindGameObjectWithTag ("Enemy"));
				}
				CheckResources ();
				buyTimer = buyRate;
			}
		}
	}

	public void CreateFactory(int positionPlacement) {
		Instantiate (factoryPrefab,
			(Vector3)factoryPositions[positionPlacement],
			transform.rotation);
	}

	public void MoveUnit() {
		Debug.Log ("MoveUnit called");
		GameObject[] units = GameObject.FindGameObjectsWithTag ("Enemy");
		GameObject unit = units [(int)(Random.value * units.Length)];
		GameObject playerUnit = GameObject.FindGameObjectWithTag ("Unit");

		unit.GetComponent<FightControl> ().MoveUnit (playerUnit.transform, 20);
	}
}
