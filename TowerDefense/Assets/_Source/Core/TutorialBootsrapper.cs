using System;
using BaseSys;
using EconomySystem;
using EnemiesSystem.WavesSystem;
using TMPro;
using UnityEngine;

namespace Core
{
    public class TutorialBootsrapper : MonoBehaviour
    {
        [SerializeField] private WavesSpawner wavesSpawner;
       
        private void Awake()
        {
            wavesSpawner.Construct();
            
            
        }
    }
}
