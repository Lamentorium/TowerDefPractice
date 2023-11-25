using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEBullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    public float dmg = 5f;
    public bool isMagic = false;
    public float aoeRange = 1f;

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
    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyMovement enemy = other.collider.GetComponent<EnemyMovement>();
        {
            if (enemy != null)
            {
                var hitColliders = Physics2D.OverlapCircleAll(transform.position, aoeRange, 1 << LayerMask.NameToLayer("Enemy"));
                Debug.Log("aoe dmg sent");
                foreach (var item in hitColliders)
                {
                    Debug.Log(123);
                    item.transform.GetComponent<EnemyMovement>().DamgeRecieved(dmg, isMagic);
                }
            }
            Destroy(gameObject);
        }

    }
}

