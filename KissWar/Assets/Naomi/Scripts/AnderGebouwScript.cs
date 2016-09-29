using UnityEngine;
using System.Collections;

public class AnderGebouwScript : MonoBehaviour {
    int health;
	// Use this for initialization
	void Start () {
       health = 0;
    }

    // Update is called once per frame
    void Update () {
    if (health == 0)
    {
            Destroy(gameObject);
    }
	}
}
