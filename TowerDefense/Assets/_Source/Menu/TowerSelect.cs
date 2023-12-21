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
        [SerializeField] private GameObject buffSlot1;
        [SerializeField] private GameObject buffSlot2;

        public int TowerIndex = 0;
        public TowerSaver towerSaver;
        public GameObject towerObj;
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
        public void ChooseTower()
        {
           towerObj = Instantiate(towers[TowerIndex], transform.position, Quaternion.identity);
           towerObj.SetActive(false);
           if (buffSlot1.GetComponent<SlotTrigger>().isOccupied)
           {
                buffSlot1.transform.Find("PageBuffSmall").parent = towerObj.transform;
           }
           if (buffSlot2.GetComponent<SlotTrigger>().isOccupied)
           {
                buffSlot2.transform.Find("PageBuffMedium").parent = towerObj.transform;
           }
           towerSaver.selectedTowers.Add(towerObj);
           
         
        }
    }
}

