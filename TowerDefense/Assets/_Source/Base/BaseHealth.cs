using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] public float health = 100;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject gameOver;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        UpdateText(health);
        if (health <= 0)
        {
            gameOver.SetActive(true);
        }
    }
    private void UpdateText(float _health)
    {
        text.text = "Base HP: " + health;
    }

}
