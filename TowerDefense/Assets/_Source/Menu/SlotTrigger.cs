using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotTrigger : MonoBehaviour
{
    public bool isOccupied = false;
    private string startTag;

    const string OCCUPIED = "Occupied";
    void Start()
    {
        startTag = gameObject.tag;
    }
   
    public void Occupied()
    {
        gameObject.tag = OCCUPIED;
        

    }
    public void UnOccupied()
    {
        gameObject.tag = startTag;
       
    }
}
