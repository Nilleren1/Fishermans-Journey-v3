using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAttack : MonoBehaviour
{
    [SerializeField] public float attackRange = 0.7f;
    [SerializeField] public int attackDamage = 50;

    public Animator animator;
    public LayerMask enemyLayers;
    public Transform attackPoint;

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
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        ////Damage enemy
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    public void Attack2()
    {
        //Play attack animation
        animator.SetTrigger("Attack2");
        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        ////Damage enemy
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    public void Attack3()
    {
        //Play attack animation
        animator.SetTrigger("Attack3");
        
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }
  

}
