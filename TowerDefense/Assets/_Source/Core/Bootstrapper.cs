using System;
using EnemiesSystem.WavesSystem;
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
