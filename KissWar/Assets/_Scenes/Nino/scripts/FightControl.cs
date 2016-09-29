using UnityEngine;
using System.Collections;

public class FightControl : MonoBehaviour {

    Transform target;
    public float speed = 3.0f;
    public float attackDamage = 1.0f;
    public float attackRange = 1.0f;
    public float timeBetweenAttacks;
    public float attackRadius;
    public string targetTag;


   

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform;

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

     void AttackEnemy()
    {

        if(Vector2.Distance(transform.position, target.position) <= 2.0f )
        {
          
            Destroy(target.gameObject);
            
        }

    }

 

   
}

