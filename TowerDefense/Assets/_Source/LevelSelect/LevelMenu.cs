using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private string level = "TowerSelect";
    [SerializeField] AudioSource click;
    public void OnClick()
    {
        click.Play();
        SceneManager.LoadScene(level);
    }
}
