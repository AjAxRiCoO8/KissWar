using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour
{
    public GameObject healthBar;

    public float maxHealth = 100;
    public float curHealth;
     
	// Use this for initialization
	void Start ()
    {
        curHealth = maxHealth;
	}

    void Update()
    {
        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            float originalValue = healthBar.GetComponent<SpriteRenderer>().bounds.min.x;
            float healthRatio = curHealth / maxHealth;

            healthBar.transform.localScale = new Vector3(1 * healthRatio, 1, 1);

            float newValue = healthBar.GetComponent<SpriteRenderer>().bounds.min.x;
            float difference = newValue - originalValue;

            healthBar.transform.Translate(new Vector3(-difference, 0f, 0f));
        }
    }
}
