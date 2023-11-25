using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject point1;
    [SerializeField] private GameObject point2;
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float Health = 100f;
    [SerializeField] private float MRes = 0.3f;
    [SerializeField] private float PhRes = 0f;

    private Transform target;
   
    private void Start()
    {
        target = point1.transform;
    }
    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            if (target == point1.transform)
            {
                target = point2.transform;
            }
            else
            {
                target = point1.transform;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }
     public void DamgeRecieved(float dmg,bool isMagic)
         {
            Debug.Log("dmg taken");
            if (isMagic == true)
            {
                Debug.Log("Magic resisted");
                Health -= dmg * MRes;
            }
            else
            {
                Debug.Log("Physical resisted");
                Health -= dmg * PhRes;
            }
             
             if (Health <= 0)
             {
                 gameObject.SetActive(false);
             }
             
         }
}
