using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private string level = "FirstLevel";
    public void OnClick()
    {
        SceneManager.LoadScene(level);
    }
}
