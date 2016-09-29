using UnityEngine;
using System.Collections;

public class FightControl : MonoBehaviour {

    public Transform target;
    public float speed = 3.0f;
    public float attackDamage = 1.0f;
    public float attackRange = 1.0f;
    public float timeBetweenAttacks;
    public string targetTag;
    bool attack;
   

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform;
        attack = false;
    }
    
    void Update()
    {
        MoveUnit();
        AttackEnemy();


    }

    void MoveUnit()
    {
        if(Vector2.Distance(transform.position, target.position) <= 10f)
        {
            transform.LookAt(target.position);
            transform.Rotate(new Vector2(0, -90), Space.Self);

            if (Vector2.Distance(transform.position, target.position) > attackRange)
            {
                transform.Translate(new Vector2(speed * Time.deltaTime, 0));
            }
        }
        
    }

     void AttackEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.left);
        

        if(Vector2.Distance(transform.position, target.position) == attackRange)
        {
            attack = true;
        }

        if(attack == true)
        {
            if(hit)
            {
                
                Destroy(hit.collider.gameObject);
            }
        }


    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -Vector2.left );
    }

   
}

