using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{

    public int backCounter = 1;         //has the back button been pressed

    public static bool moveBack = false;

    private static bool forcingAppButton;

    //chanes the scene back to the main screen
    public void ChangeSceneToAR()
    {
        moveBack = true;

        Buttons.forceAppButton = true;

        SceneManager.LoadScene("SampleScene");      //load main scene
    }
}
