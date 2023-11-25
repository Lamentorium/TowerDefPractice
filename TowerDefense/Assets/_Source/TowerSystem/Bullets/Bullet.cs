using System.Collections;
using System.Collections.Generic;
using EnemiesSystem.Data;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    public  float dmg = 5f;
    public bool isMagic = false;

    private Transform target;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    private void FixedUpdate()
    {
        if (!target)
        {
            return;
        }
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;//probably better to use transform translate
    }
    private void  OnCollisionEnter2D(Collision2D other)
    {
        EnemyMovement enemy = other.collider.GetComponent<EnemyMovement>();
       // Debug.Log("dmg sent");
        if (enemy != null)
        {
            enemy.DamgeRecieved(dmg,isMagic);
        }
        Destroy(gameObject);
    }
}
