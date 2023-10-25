using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private GameObject _base;

    private Transform target;
    private int pathIndex = 0;
    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
    }
    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            
            if (pathIndex == LevelManager.main.path.Length)
            {
                Base baseScript = _base.GetComponent<Base>();
                baseScript.OnEnemyArrival();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }
}
