using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialProgression : MonoBehaviour
{
    [SerializeField] GameObject[] tutorials;
    [SerializeField] GameObject[] plots;
    [SerializeField] GameObject tutorialBg1;
    [SerializeField] GameObject baseObject;
    [SerializeField] GameObject tutorialPlot;
    [SerializeField] GameObject waves;
    public bool canContinue = false;
    private bool tutor4pass = false;
    private MusicManager music;
    private int tutorialStage = 0;
    private void Start()
    {
        music = FindObjectOfType<MusicManager>();
        music.Level1();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && tutorialStage < 4)
        {
            if (tutorialStage == 1)
            {
                //baseOutline.SetActive(false);
                baseObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
                //baseOutline.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            if (tutorialStage == 2)
            {
                tutorialPlot.GetComponent<SpriteRenderer>().sortingOrder = 0;
                tutorialBg1.SetActive(false);
            }
            tutorials[tutorialStage].SetActive(false);
            tutorialStage++;
            tutorials[tutorialStage].SetActive(true);
        }
        if (tutorialStage == 1)
        {
            //baseOutline.SetActive(true);
            baseObject.GetComponent<SpriteRenderer>().sortingOrder = 4;
           // baseOutline.GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
        if (tutorialStage == 2)
        {
            tutorialPlot.GetComponent<SpriteRenderer>().sortingOrder = 4;
        }
        if (Input.GetButtonDown("Fire1") && tutorialStage == 4 && tutor4pass == false)
        {
            tutorials[tutorialStage].SetActive(false);
            for (int i = 0; i < plots.Length; i++)
            {
                plots[i].GetComponent<BoxCollider2D>().enabled = true;
            }
            tutor4pass = true;

        }
        if (canContinue == true && tutorialStage == 4)
        {
            tutorials[tutorialStage].SetActive(true);
            tutorialBg1.SetActive(true);
            for (int i = 0; i < plots.Length; i++)
            {
                plots[i].GetComponent<BoxCollider2D>().enabled = false;
            }
            canContinue = false;
            StartCoroutine(LatsTutor());

        }
        if (Input.GetButtonDown("Fire1") && tutorialStage == 5)
        {
            for (int i = 0; i < plots.Length; i++)
            {
                plots[i].GetComponent<BoxCollider2D>().enabled = true;
            }
            tutorials[4].SetActive(false);
            tutorialBg1.SetActive(false);
            waves.SetActive(true);
            Destroy(this);

        }
        IEnumerator LatsTutor()
        {

            yield return new WaitForSeconds(0.1f);
            tutorialStage++;
        }

    }
}
