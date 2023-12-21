using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using EnemiesSystem.Data;

public class AOEBullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject explosion;
    [SerializeField] private SpriteRenderer projectileSprite;
    [SerializeField] private Collider2D projectileCollider;



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
        if (target.gameObject.activeSelf == false)
        {
            Destroy(gameObject);
        }
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;//probably better to use transform translate
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.collider.GetComponent<Enemy>();
        {
            Debug.Log(target.name);
            if (enemy != null)
            {
                rb.velocity = Vector2.zero;
                projectileCollider.enabled = false;
                projectileSprite.enabled = false;
                explosion.SetActive(true);
                StartCoroutine(AttackEnd());
                var enemies = Physics2D.OverlapCircleAll(transform.position, aoeRange, 1 << LayerMask.NameToLayer("Enemy"));
                Debug.Log("aoe dmg sent");
                foreach (var item in enemies)
                {
                    Debug.Log(123);
                    item.transform.GetComponent<Enemy>().DamgeRecieved(dmg, isMagic);
                }
            }

        }

    }

    private IEnumerator AttackEnd()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}

