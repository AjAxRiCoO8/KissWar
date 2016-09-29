using UnityEngine;
using System.Collections;

public class AnderGebouwScript : MonoBehaviour {
    public int health;
    private int Scale;

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        health = 0;
        Scale = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer = null)
            spriteRenderer.sprite = sprite1;
    }

    // Update is called once per frame
    void Update ()
    {
        if (health < 100 * Scale && health > 88 * Scale)
        {
            if (spriteRenderer.sprite == sprite1)
            {
                spriteRenderer.sprite = sprite2;
            }
            else
            {
                spriteRenderer.sprite = sprite1;
            }
        }

        if (health < 88 * Scale && health > 75 * Scale)
        {
            if (spriteRenderer.sprite == sprite2)
            {
                spriteRenderer.sprite = sprite3;
            }
            else
            {
                spriteRenderer.sprite = sprite2;
            }
        }

        if (health < 75 * Scale && health > 63 * Scale)
        {
            if (spriteRenderer.sprite == sprite3)
            {
                spriteRenderer.sprite = sprite4;
            }
            else
            {
                spriteRenderer.sprite = sprite3;
            }
        }

        if (health < 63 * Scale && health > 50 * Scale)
        {
            if (spriteRenderer.sprite == sprite4)
            {
                spriteRenderer.sprite = sprite5;
            }
            else
            {
                spriteRenderer.sprite = sprite4;
            }
        }

        if (health < 50 * Scale && health > 38 * Scale)
        {
            if (spriteRenderer.sprite == sprite5)
            {
                spriteRenderer.sprite = sprite6;
            }
            else
            {
                spriteRenderer.sprite = sprite5;
            }
        }

        if (health < 38 * Scale && health > 25 * Scale)
        {
            if (spriteRenderer.sprite == sprite6)
            {
                spriteRenderer.sprite = sprite7;
            }
            else
            {
                spriteRenderer.sprite = sprite6;
            }
        }

        if (health < 25 * Scale && health > 13 * Scale)
        {
            if (spriteRenderer.sprite == sprite7)
            {
                spriteRenderer.sprite = sprite8;
            }
            else
            {
                spriteRenderer.sprite = sprite7;
            }
        }

        if (health < 13 * Scale && health > 0 * Scale)
        {
            if (spriteRenderer.sprite == sprite8)
            {
                spriteRenderer.sprite = sprite9;
            }
            else
            {
                spriteRenderer.sprite = sprite8;
            }
        }
        if (health == 0)
    {
            Destroy(gameObject);
            
    }
	}
}
