using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Pages/FireRateBuff")]
public class FireRateBuff : PageBase
{
    [SerializeField] float FireRateToBuff = 1.25f;
    public override void Apply(GameObject target)
    {
        if (target.TryGetComponent(out Tower tower))
        {
            tower.fireRate *= FireRateToBuff;
        }
        else if (target.TryGetComponent(out AOETower aoeTower))
        {
            aoeTower.fireRate *= FireRateToBuff;
        }
        else if (target.TryGetComponent(out SlowTower slowTower))
        {
            slowTower.fireRate *= FireRateToBuff;
        }
    }
}
