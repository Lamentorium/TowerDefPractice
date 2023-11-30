using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    
    public int currency;


    private void Awake()
    {
        main = this;
    }
    private void Start()
    {
        currency = 100;
    }
    public bool SpendCurrency(int amount){
        if(amount <=currency){
            currency-= amount;
            return true;
        }
        else{
            Debug.Log("denied");
            return false;
        }
    }
}
