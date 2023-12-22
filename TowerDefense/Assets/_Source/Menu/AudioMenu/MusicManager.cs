using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] public AudioClip menuBgm;
    [SerializeField] public AudioClip Level1track1;
    [SerializeField] public AudioClip Level1track2;
    [SerializeField] public AudioClip Level2track1;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        musicSource.clip = menuBgm;
        musicSource.Play();
    }
    public void Level1(){
        musicSource.clip = Level1track1;
        musicSource.Play();
    } 
    public void Level1Boss(){
        musicSource.clip = Level1track2;
        musicSource.Play();
    }  
     public void Level2(){
        musicSource.clip = Level2track1;
        musicSource.Play();
    }      
}
