using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlot : MonoBehaviour
{
    public TutorialProgression tutorialProgression;
    private void OnMouseDown()
    {
        tutorialProgression.canContinue = true;
        Debug.Log("wwawa");
    }

}
