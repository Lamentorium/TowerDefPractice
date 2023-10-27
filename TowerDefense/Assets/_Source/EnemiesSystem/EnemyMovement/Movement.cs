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
        private Sequence _mySequence;

        private int _point = 0;
    

        private void OnDisable()
        {
            _point = 0;
           
            

        }


        public void Move(Enemy enemy)
        {


            if (_point < points.Length && gameObject.activeSelf == true) 
            {
                _mySequence.Append(transform.DOMove(points[_point].position, enemy.Speed)
                    .SetEase(Ease.InOutSine)
                    .Play()
                    .OnComplete(() => Move(enemy)));
              _point++;
                  

            }


        }
    }
}
