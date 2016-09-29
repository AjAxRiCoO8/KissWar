using UnityEngine;
using System.Collections;

public class moveTo : MonoBehaviour {

    public GameObject[] units;
    public Camera camara;
	
	// Update is called once per frame
	void Update () {
	if (Input.GetMouseButtonDown(1))
        {
            units = GameObject.FindGameObjectsWithTag("Unit");

            foreach (GameObject unit in units)
            {
                MoveUnit currentUnit = unit.GetComponent<MoveUnit>();

                if (currentUnit.selected == true)
                {
                    unit.GetComponent<MoveUnit>().targetPosition = camara.ScreenToWorldPoint(Input.mousePosition);
                }


            }
        }
	}
}
