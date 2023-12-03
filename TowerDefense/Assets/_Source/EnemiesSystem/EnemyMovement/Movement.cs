using System;
using System.Collections;
using DG.Tweening;
using EnemiesSystem.Data;
using TMPro;
using UnityEngine;

namespace EnemiesSystem.EnemyMovement
{
    
    public class Movement: MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        private Transform[] _points;
        private Enemy _enemy;
        private Sequence _mySequence;
        private int _point;
        private Vector3 _initPos;

        /*public Movement(Transform[] points)
        {
            _points = points;
            _point = 0;
        }*/
        private void Start()
        {
            _initPos = transform.position;
        }

        public void Init(Transform[] points, Transform initPosition = null)
        {
            if(initPosition != null)
                _initPos = initPosition.position;
            _points = points;
            _point = 0;
            
        }

        private void OnDisable()
        {
            if (gameObject != null)
            {
                transform.position = _initPos;
                this.enabled = false;
            }
        }

        private void Update()
        {
            if(gameObject.activeSelf && _points != null)
                 FindDistance();
            
        }

        private void FixedUpdate()
        {
            if(gameObject.activeSelf && _points != null)
                Move();
        }

        private void FindDistance()
        {
            if (Vector2.Distance(_points[_point].position, transform.position) <= 0.1f)
            {
                if (_point < _points.Length - 1)
                {
                    _point++;
                }
              
            }
        }

        private void Move()
        {
            
            Vector2 direction = (_points[_point].position - transform.position).normalized;
            if(TryGetComponent(out Enemy enemy))
                rb.velocity = direction * enemy.Speed;
        }
        
    }
}
