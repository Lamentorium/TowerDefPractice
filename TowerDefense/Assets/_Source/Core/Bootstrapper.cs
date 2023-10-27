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
        [SerializeField] private GoldView goldView;
        [SerializeField] private TMP_Text goldText;
        private void Awake()
        {
            wavesSpawner.Construct();
            goldView.Construct(goldText);
        }
    }
}
