using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pages/RangeBuff")]
public class RangeBuff : PageBase
{
    [SerializeField] float RangeToBuff = 1.25f;
    public override void Apply(GameObject target)
    {
        if (target.TryGetComponent(out Tower tower))
        {
            tower.attackRange *= RangeToBuff;
        }
        else if (target.TryGetComponent(out AOETower aoeTower))
        {
            aoeTower.attackRange *= RangeToBuff;
        }
        else if (target.TryGetComponent(out SlowTower slowTower))
        {
            slowTower.attackRange *= RangeToBuff;
            Transform attackObj = target.transform.Find("Attack");
            attackObj.localScale += new Vector3(attackObj.localScale.x * RangeToBuff,attackObj.localScale.y * RangeToBuff);
        }
    }
}
