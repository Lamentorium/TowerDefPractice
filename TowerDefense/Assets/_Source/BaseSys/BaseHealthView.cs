using System;
using TMPro;
using UnityEngine;

namespace BaseSys
{
    public class BaseHealthView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private GameObject gameOver;
        private BaseHealth _baseHealth;

        public void Construct(BaseHealth baseHealth)
        {
            _baseHealth = baseHealth;
        }
        private void Start()
        {
            _baseHealth.TakeDmg += UpdateText;
            _baseHealth.GameOver += GameOverPanel;
        }

        private void OnDisable()
        {
            _baseHealth.TakeDmg -= UpdateText;
            _baseHealth.GameOver -= GameOverPanel;
        }

        private void UpdateText(float health)
        {
            text.text = " " + health;
            Debug.Log(text.text);
        }

        private void GameOverPanel()
        {
            gameOver.SetActive(true);
        }
    }
}
