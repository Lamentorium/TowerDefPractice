using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquaLevel : MonoBehaviour
{
    private MusicManager music;
    void Start()
    {
        music = FindObjectOfType<MusicManager>();
        music.Level2();
    }


}
