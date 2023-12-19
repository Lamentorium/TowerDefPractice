using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

namespace TowerMenu
{
    public class TowerSelect : MonoBehaviour
    {
        [SerializeField] private GameObject[] towers;
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private String[] towerNames;
        [SerializeField] private TextMeshProUGUI towerName;
        [SerializeField] private String[] descriptions;
        [SerializeField] private TextMeshProUGUI towerDescription;
        
        public int TowerIndex = 0;
        private void Start()
        {
            sprite.sprite = towers[TowerIndex].transform.GetComponent<SpriteRenderer>().sprite;
            towerName.text = towerNames[TowerIndex];
            towerDescription.text = descriptions[TowerIndex];
        }
        public void ChangeTower()
        {
            sprite.sprite = towers[TowerIndex].transform.GetComponent<SpriteRenderer>().sprite;
            towerName.text = towerNames[TowerIndex];
            towerDescription.text = descriptions[TowerIndex];
        }
    }
}

