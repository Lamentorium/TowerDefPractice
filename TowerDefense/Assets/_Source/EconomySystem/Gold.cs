using System;

namespace EconomySystem
{
    public class Gold
    {
       
        public static Action<float> AddAction;
        public static float GoldCount { get; private set; }
      
   

        public static void AddGold()
        {
            GoldCount++;
            AddAction?.Invoke(GoldCount);
        }
    }
}
