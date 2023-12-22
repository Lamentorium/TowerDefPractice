using UnityEngine;

namespace EnemiesSystem.BossSystem
{
    public interface INautilusAbility : IBossAbility
    {
        void CheckDmgOn1000();
        void CheckDmgOn2000();
        void CheckDmgOn3000();
    }
}
