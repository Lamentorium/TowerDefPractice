using System;
using System.Collections;
using System.Collections.Generic;
using EnemiesSystem.WavesSystem;
using UnityEngine;

public class TestWaveSystem : MonoBehaviour
{
    
    public static Action<int> Action;


    private void OnDestroy()
    {
        Action?.Invoke(-1);
    }
}
