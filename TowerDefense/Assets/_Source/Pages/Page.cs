using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    [SerializeField] PageBase page;
   void Awake()
   {
        page.Apply(gameObject.transform.parent.gameObject);
   }
}
