using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Pages/DamagePage")]
public class DamageBuff : PageBase
{
    [SerializeField] float damageToBuff = 1.25f;
    public override void Apply(GameObject target)
    {
        if (target.TryGetComponent(out Tower tower))
        {
            tower.damage *= damageToBuff;
        }
        else if (target.TryGetComponent(out AOETower aoeTower))
        {
            aoeTower.damage *= damageToBuff;
        }
        else if (target.TryGetComponent(out SlowTower slowTower))
        {
            slowTower.damage *= damageToBuff;
        }
    }
}
