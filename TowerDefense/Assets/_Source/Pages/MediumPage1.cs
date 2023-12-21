using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pages/MediumPage1")]
public class MediumPage1 : PageBase
{
    [SerializeField] float FireRateToBuff = 2f;
    [SerializeField] float DamageToDebuff = 0.4f;
    
    public override void Apply(GameObject target)
    {
        if (target.TryGetComponent(out Tower tower))
        {
            tower.fireRate *= FireRateToBuff;
            tower.damage *= DamageToDebuff;
        }
        else if (target.TryGetComponent(out AOETower aoeTower))
        {
            aoeTower.fireRate *= FireRateToBuff;
            aoeTower.damage *= DamageToDebuff;
        }
        else if (target.TryGetComponent(out SlowTower slowTower))
        {
            slowTower.fireRate *= FireRateToBuff;
            slowTower.damage *= DamageToDebuff;
        }
    }
}
