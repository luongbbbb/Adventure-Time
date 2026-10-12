using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer_Combat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public StatsUI statsUI;
    public Animator animator;

    public float cooldown = 2;
    public float timer;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (timer <= 0)
        {
            animator.SetBool("isAttacking", true);
            timer = cooldown;
        }
    }

    public void DealDamage()
    {
        //StatManager.Instance.damage += 1;
        statsUI.UpdateDamage();

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, StatManager.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHealth(-StatManager.Instance.damage);
            enemies[0].GetComponent<Enemy_KnockBack>().KnockBack(transform, StatManager.Instance.knockbackForce, StatManager.Instance.knockbackTime, StatManager.Instance.stunTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, StatManager.Instance.weaponRange);
    }

    public void FinishAttacking()
    {
        animator.SetBool("isAttacking", false);
    }
}
