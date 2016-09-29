using UnityEngine;
using System.Collections;

public class AnderGebouw2Script : MonoBehaviour {
    int health;

	// Use this for initialization
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
        if (health == 0)
        {
            Destroy(gameObject);
        }
	}
}
