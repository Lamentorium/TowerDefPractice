using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace EconomySystem
{
    public class GoldView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        
        private void OnEnable()
        {
            Gold.AddAction += UpdateTextView;
        }

        private void OnDisable()
        {
            Gold.AddAction -= UpdateTextView;
        }

        private void UpdateTextView(float gold)
        {
            text.text = "Gold: " + gold;
        }
    }
}
