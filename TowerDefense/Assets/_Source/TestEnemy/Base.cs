using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Base : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] int hp = 5;

    public  void OnEnemyArrival(){
        Debug.Log(hp);
        hp--;
        hpText.text = $"Здоровье базы : {hp}";
    }
}
