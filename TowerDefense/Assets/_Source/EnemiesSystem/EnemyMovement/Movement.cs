using System;
using System.Collections;
using DG.Tweening;
using EnemiesSystem.Data;
using TMPro;
using UnityEngine;

namespace EnemiesSystem.EnemyMovement
{
    
    public class Movement
    {
         private Transform[] _points;
        private Enemy _enemy;
        private Sequence _mySequence;
        private int _point;

        public Movement(Transform[] points)
        {
            _points = points;
            _point = 0;
        }
        public void Move(Enemy enemy)
        {


            if (_point < _points.Length && enemy.gameObject.activeSelf) 
            {
                Debug.Log("Move");
                _mySequence.Append(enemy.transform.DOMove(_points[_point].position, enemy.Speed)
                    .SetEase(Ease.InOutSine)
                    .Play()
                    .OnComplete(() => Move(enemy)));
              _point++;
              

            }


        }
    }
}
