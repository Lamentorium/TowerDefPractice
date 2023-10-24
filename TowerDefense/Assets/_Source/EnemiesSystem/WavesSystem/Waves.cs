using System;
using UnityEngine;

namespace EnemiesSystem.WavesSystem
{
    [Serializable]
    public class Waves
    {
        /*[SerializeField] private WaveSettings[] waveSettings;
        public WaveSettings[] WaveSettings => waveSettings;*/
        [SerializeField]private UnitsPool enemiesPool;
        public UnitsPool EnemiesPool => enemiesPool;

       


    }
}
