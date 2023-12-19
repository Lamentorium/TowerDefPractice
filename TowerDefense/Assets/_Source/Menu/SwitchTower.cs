using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerMenu
{
    public class SwitchTower : MonoBehaviour
    {
        [SerializeField] bool isRight;
        public TowerSelect towerSelect;

        public void OnClick()
        {
            if (isRight == true)
            {
                if (towerSelect.TowerIndex < 3)
                {
                    towerSelect.TowerIndex++;
                    towerSelect.ChangeTower();
                    
                }
                else if(towerSelect.TowerIndex == 3){
                    
                    towerSelect.TowerIndex = 0;
                    towerSelect.ChangeTower();
                }
            }
            else if(isRight == false){
                 if (towerSelect.TowerIndex > 0)
                {
                    towerSelect.TowerIndex--;
                    towerSelect.ChangeTower();
                }
                else if(towerSelect.TowerIndex == 0){
                    towerSelect.TowerIndex = 3;
                    towerSelect.ChangeTower();
                }
            }



        }
    }
}

