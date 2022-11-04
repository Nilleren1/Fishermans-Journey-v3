using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAttack : MonoBehaviour
{
    
    public Animator animator;

    //public Transform attackPoint;
    //[SerializeField] public float attackRange = 0.5f;
    //public LayerMask enemyLayers;


    private void Awake()
    {
        
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //button = right mouse click
        if (Input.GetMouseButtonDown(1))
        {
            Attack();

        }
        if (Input.GetMouseButtonDown(2))
        {
            Attack2();

        }

        if (Input.GetKeyDown("q"))
        {
            Attack3();
        }

    }

    public void Attack()
    {
        //Play attack animation
        animator.SetTrigger("Attack");
        //Detect enemies in range of attack
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        ////Damage enemy
        //foreach (Collider2D enemy in hitEnemies)
        //{
        //    Debug.Log("We hit" + enemy.name);
        //}
    }
    public void Attack2()
    {
        //Play attack animation
        animator.SetTrigger("Attack2");
        //Detect enemies in range of attack
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        ////Damage enemy
        //foreach (Collider2D enemy in hitEnemies)
        //{
        //    Debug.Log("We hit" + enemy.name);
        //}
    }

    public void Attack3()
    {
        //Play attack animation
        animator.SetTrigger("Attack3");
        
    }

    //void OnDrawGizmosSelected()
    //{
    //    if (attackPoint == null)
    //    {
    //        return;
    //    }

    //    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    //}

}
