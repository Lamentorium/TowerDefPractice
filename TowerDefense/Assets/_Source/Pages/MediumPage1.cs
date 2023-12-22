using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pages/MediumPage1")]
public class MediumPage1 : PageBase
{
    [SerializeField] float fireRateToBuff = 2f;
    [SerializeField] float damageToDebuff = 0.4f;
    
    public override void Apply(GameObject target)
    {
        if (target.TryGetComponent(out Tower tower))
        {
            tower.fireRate *= fireRateToBuff;
            tower.damage *= damageToDebuff;
        }
        else if (target.TryGetComponent(out AOETower aoeTower))
        {
            aoeTower.fireRate *= fireRateToBuff;
            aoeTower.damage *= damageToDebuff;
        }
        else if (target.TryGetComponent(out SlowTower slowTower))
        {
            slowTower.fireRate *= fireRateToBuff;
            slowTower.damage *= damageToDebuff;
        }
    }
}
