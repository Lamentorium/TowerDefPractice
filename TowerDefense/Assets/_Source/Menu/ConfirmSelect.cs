using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace TowerMenu
{
    public class ConfirmSelect : MonoBehaviour
    {
        [SerializeField] private string[] level;
        public TowerSelect[] towerSelect;
        [SerializeField] AudioSource click;
        public int levelIndex = 0;

        public void OnClick()
        {
            click.Play();
            for (int i = 0; i < towerSelect.Length; i++)
            {
                towerSelect[i].ChooseTower();
            }
            TowerSaver.instance.ConfirmTowers();
            for (int i = 0; i < TowerSaver.instance.towersArray.Length; i++)
            {
                Debug.Log(TowerSaver.instance.towersArray[i].name);
            }
            SceneManager.LoadScene(level[levelIndex]);
        }
    }
}