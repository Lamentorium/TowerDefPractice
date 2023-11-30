using System;
using EconomySystem;
using EnemiesSystem.WavesSystem;
using TMPro;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private WavesSpawner wavesSpawner;
       
        private void Awake()
        {
            wavesSpawner.Construct();
            
        }
    }
}
