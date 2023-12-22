using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    //[SerializeField] private GameObject[] towerPrefabs; 
    [SerializeField] private Shop[] towers;


    private int selectedTower = 0;
    private void Awake()
    {
        main = this;
        /*for (int i = 0; i < TowerSaver.instance.towersArray.Length; i++)
        {
            towers[i].prefab = TowerSaver.instance.towersArray[i];
        }*/
    }

    public Shop GetSelectedTower()
    {
        return towers[selectedTower];
    }
    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
    }
}
