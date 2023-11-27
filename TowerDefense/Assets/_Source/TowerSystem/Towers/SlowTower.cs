using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class SlowTower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject attackAnim;
    [Header("Attribute")]
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private float fireRate = 4f;
    [SerializeField] private float damage = 5f;
    [SerializeField] private float slow = 0.5f;
    [SerializeField] private float slowTime = 1f;
    [SerializeField] private bool isMagic = false;


    private float timeUntilFire;
    private void Update()
    {

        timeUntilFire += Time.deltaTime;
        if (timeUntilFire >= 1f / fireRate)
        {
            Attack();
            timeUntilFire = 0f;
        }
    }
    private void Attack()
    {

        var enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, 1 << LayerMask.NameToLayer("Enemy"));
        if (enemies.Length > 0)
        {
            attackAnim.SetActive(true);
            StartCoroutine(AttackHide());
            foreach (var item in enemies)
            {
                item.transform.GetComponent<EnemyMovement>().DamgeRecieved(damage, isMagic);
                item.transform.GetComponent<EnemyMovement>().Slowed(slow, slowTime);
            }
        }
    }
    private IEnumerator AttackHide()
    {
        yield return new WaitForSeconds(0.3f);
        attackAnim.SetActive(false);
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, transform.forward, attackRange);
    }
}

