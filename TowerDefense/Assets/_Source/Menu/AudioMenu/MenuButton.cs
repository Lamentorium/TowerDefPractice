using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] AudioSource sound;
    private bool isOpen = false;
    public void OnClick()
    {
        sound.Play();
        if(isOpen == false){
            menu.SetActive(true);
            isOpen = true;
        }
        else
        {
            isOpen = false;
            menu.SetActive(false);
        }
    }
}
