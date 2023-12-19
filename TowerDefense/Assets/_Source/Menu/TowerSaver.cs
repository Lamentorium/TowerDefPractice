using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSaver : MonoBehaviour
{
    [SerializeField] GameObject[] selectedTowers;
    public static TowerSaver instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void ConfirmTowers(){
        
    }
    
}
