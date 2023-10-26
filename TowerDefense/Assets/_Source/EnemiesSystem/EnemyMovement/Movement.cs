using System;
using System.Collections;
using DG.Tweening;
using EnemiesSystem.Data;
using UnityEngine;

namespace EnemiesSystem.EnemyMovement
{
    [RequireComponent(typeof(Enemy))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Transform[] points;
        private Enemy _enemy;
        private Rigidbody2D rb;

        private int _point = 0;
        // Start is called before the first frame update
        void Start()
        {
            /*TryGetComponent(out Enemy enemy);
            _enemy = enemy;*/
            
            
        }

        

       

        public void Move(Enemy enemy)
        {
           
            if (_point < points.Length)
            {
                transform.DOMove(points[_point].position, enemy.Speed).SetEase(Ease.InOutSine).OnComplete((() => Move(enemy)));
                _point++;
                  

            }


        }
    }
}
