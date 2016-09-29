using UnityEngine;
using System.Collections;

public class FightControl : MonoBehaviour {

    Transform target;
    public float speed = 3.0f;
    public float attackDamage = 1.0f;
    public float attackRange = 1.0f;
    public float attackRadius = 10.0f;

    public string targetTag;

    float hitRate;
    float timeBetweenAttacks = 3.0f;
    int hp = 100;

	Rigidbody2D rb;




    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform;
        hitRate = timeBetweenAttacks;

		rb = GetComponent<Rigidbody2D> ();
    }
    
    void Update()
    {
        MoveUnit();
        AttackEnemy();


    }

    void MoveUnit()
    {
        if(target != null)
        {
            if (Vector2.Distance(transform.position, target.position) <= attackRadius)
            {
                transform.LookAt(target.position);
                transform.Rotate(new Vector2(0, -90), Space.Self);

                if (Vector2.Distance(transform.position, target.position) > attackRange)
                {
                    transform.Translate(new Vector2(speed * Time.deltaTime, 0));
                }
            }
        }
        else
        {
            target = GameObject.FindGameObjectWithTag(targetTag).transform;
        }
       
        
    }

	public void MoveUnit(Transform target, float speed)
	{
		if(target != null)
		{
				transform.LookAt(target.position);
				transform.Rotate(new Vector2(0, -90), Space.Self);

				if (Vector2.Distance(transform.position, target.position) > attackRange)
				{
					rb.velocity = (new Vector2 (speed * Time.deltaTime, 0));
				}
		}
		else
		{
			target = GameObject.FindGameObjectWithTag(targetTag).transform;
		}


	}

     void AttackEnemy()
    {
        hitRate -= Time.deltaTime;
        if(Vector2.Distance(transform.position, target.position) <= 2.0f && hitRate <= 0 )
        {

            hp -= 25;
            hitRate = timeBetweenAttacks;

            if(hp <= 100)
            {
                Destroy(target.gameObject);
            }
            
            
        }

    }

 

   
}

