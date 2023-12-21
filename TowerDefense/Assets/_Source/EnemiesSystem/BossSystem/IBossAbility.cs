using System;
using System.Collections;

namespace EnemiesSystem.BossSystem
{
     public interface IBossAbility
     {
          void CheckDmg();
          Action OnAbility { get; }
          IEnumerator AbilityActivator();

     }
}
