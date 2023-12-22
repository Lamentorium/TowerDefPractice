using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Pages/MediumPage2")]
public class MediumPage2 : PageBase
{
    [SerializeField] float fireRateToBuff = 1.25f;
    [SerializeField] float damageToBuff = 1.25f;
    [SerializeField] float rangeToBuff = 1.25f;
      public override void Apply(GameObject target)
    {
        if (target.TryGetComponent(out Tower tower))
        {
            tower.fireRate *= fireRateToBuff;
            tower.damage *= damageToBuff;
            tower.attackRange *= rangeToBuff;
        }
        else if (target.TryGetComponent(out AOETower aoeTower))
        {
            aoeTower.fireRate *= fireRateToBuff;
            aoeTower.damage *= damageToBuff;
            aoeTower.attackRange *= rangeToBuff;
        }
        else if (target.TryGetComponent(out SlowTower slowTower))
        {
            slowTower.fireRate *= fireRateToBuff;
            slowTower.damage *= damageToBuff;
            slowTower.attackRange *= rangeToBuff;
        }
    }
}
