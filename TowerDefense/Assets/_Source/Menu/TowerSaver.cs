using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSaver : MonoBehaviour
{
    [SerializeField] public List<GameObject> selectedTowers = new List<GameObject>();
    public GameObject[] towersArray;
    public static TowerSaver instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void ConfirmTowers(){
       towersArray = selectedTowers.ToArray();
       for (int i = 0; i < towersArray.Length; i++)
       {
            DontDestroyOnLoad(towersArray[i]);
       }
    }
    
}
