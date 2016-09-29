using UnityEngine;
using System.Collections;

public class MoveUnit : MonoBehaviour {


    public bool selected;
    public Vector3 targetPosition;

    public float MoveSpeed = 6;

    void Start ()
    {
        targetPosition = transform.position;
    }



    // Update is called once per frame
    void Update () {

        if (transform.position.sqrMagnitude != targetPosition.sqrMagnitude)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPosition.x, targetPosition.y, -5), Time.deltaTime * MoveSpeed);
        }

        if (selected)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }


   void OnMouseDown() {


        GameObject[] units;

        units = GameObject.FindGameObjectsWithTag("Unit");

        foreach (GameObject unit in units)
        {
            MoveUnit currentUnit = unit.GetComponent<MoveUnit>();

            if (currentUnit.selected == true)
            {
                currentUnit.selected = false;
            }

        }


        selected = true;

    }
}
