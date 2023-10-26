using TMPro;
using UnityEngine;

namespace EconomySystem
{
    public class GoldView : MonoBehaviour
    {
        private TMP_Text _text;
        public void Construct(TMP_Text text)
        {
            _text = text;
        }
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
            _text.text = "Gold: " + gold;
        }
    }
}
