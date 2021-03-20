using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    #region variables
    public GameObject bar;                   //the bar 
    
    public GameObject viewModelButton;       //bar buttons
    public GameObject productInfoButton;
    public GameObject placementButton;
    public GameObject colourButton;

    public GameObject helpContent;

    public GameObject descButton;   //product info option buttons
    public GameObject specButton;

    public GameObject descContent;  //content the info buttons show
    public GameObject specContent;

    public GameObject pinkButton;       //colour option buttons
    public GameObject greyButton;
    public GameObject sageButton;


    public Color pinkColour;    //colours for changing model colour
    public Color greyColour;
    public Color sageColour;

    public Material productMaterial;    //mouse material

    public bool hasItemSpawned;

    public GameObject placeVersion;     //place / move icons
    public GameObject moveVersion;

    public GameObject closeButton;      //main bar close button

    public GameObject startButton;      //starting UI launch scene buttons
    public GameObject startPlaceButton;

    public GameObject helpButton;       //app help button
    public GameObject helpCloseButton;  //close button for help button

    public static int counterTrackerA = 0;      //determines if B can be run 
    public static int counterTrackerB = 0;      //determines if launch or main screen showing

    private static bool movedBack;              

    public static bool forceAppButton = false;      //forces button press

   

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(counterTrackerA);       //debugging purposes

        hasItemSpawned = GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>().hasSpawned;
    }


    //first launch screen
    public void FirstScreen() 
     {
        startButton.SetActive(true);
        helpContent.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(counterTrackerB);   //debugging purposes

        movedBack = BackButton.moveBack;    //value is assigned from BackButton script (initially false)
     
        if (movedBack == true)
        {
            counterTrackerA = 0;            
            // Debug.Log("move back true");     //debugging purposes
            BackButton.moveBack = false;
        }

        if (counterTrackerA == 0)           //determines if B can be run (resets on scene reload)
        {
            if (counterTrackerB == 0)       //determines whether to display launch or main screen
            {
                //irst launch screen
                FirstScreen();
                counterTrackerB += 1;       //only displays first screen if B = 0;....
            }
            else
            {                               //.... otherwise displays normal screen
                //main screen
                //Debug.Log("help button showing");     //debugging purposes

                ShowBarButtons();

                helpButton.SetActive(true);
                GameObject.Find("HelpButton").SetActive(true);

                counterTrackerB += 1;
            }

            counterTrackerA += 1;
            BackButton.moveBack = false;
        }      

    }

    //first screen button function 
    public void TapToStartTapped()
    {
        startButton.SetActive(false);
        helpContent.SetActive(false);
        helpButton.SetActive(true);

        startPlaceButton.SetActive(true);
        
        //Debug.Log("TapToStartTapped");    //debugging purposes
    }

    //place screen button function
    public void StartPlaceButtonTapped()
    {
        ShowBarButtons();
        startPlaceButton.SetActive(false);
        helpButton.SetActive(true); //show the help button

        //Debug.Log("StartPlaceButtonTapped");      //debugging purposes
    }

    #region BarButtons
    //function to show the bar buttons
    public void ShowBarButtons()    
    {
        viewModelButton.SetActive(true);
        productInfoButton.SetActive(true);
        placementButton.SetActive(true);
        colourButton.SetActive(true);

        helpButton.SetActive(true);

        closeButton.SetActive(false);

        //Debug.Log("ShowBarButtons");      //debugging purposes
    }

    //hides all the bar buttons
    public void HideBarButtons()   
    {
        viewModelButton.SetActive(false);
        productInfoButton.SetActive(false);
        placementButton.SetActive(false);
        colourButton.SetActive(false);

        closeButton.SetActive(true);

        Debug.Log("HideBarButtons");
    }

    // closes all of the optional buttons
    public void CloseButtonTapped()     
    {
        descButton.SetActive(false);
        specButton.SetActive(false);

        descContent.SetActive(false);
        specContent.SetActive(false);

        pinkButton.SetActive(false);
        greyButton.SetActive(false);
        sageButton.SetActive(false);

        helpContent.SetActive(false);

        //Debug.Log("CloseButtonTapped");

        ShowBarButtons();       //shows the bar buttons
    }

    //shows the app content
    public void AppHelpTapped()     
    {
        CloseButtonTapped();
        HideBarButtons();

        helpContent.SetActive(true);
        helpButton.SetActive(false);
        helpCloseButton.SetActive(true);

        closeButton.SetActive(false);
        startPlaceButton.SetActive(false);
        bar.SetActive(false);

        //Debug.Log("AppHelpTapped");
    }

    //help close button function
    public void HelpCloseButtonTapped()
    {
        helpContent.SetActive(false);
        helpButton.SetActive(true);
        helpCloseButton.SetActive(false);

        bar.SetActive(true);

        CloseButtonTapped();
        HideBarButtons();

        //Debug.Log("HelpCloseButtonTapped");
    }

    //function for button toggle between place and move
    public void PlaceRemoveButtonSwitch()
    {
        hasItemSpawned = GameObject.Find("ObjectSpawner").GetComponent<ObjectSpawner>().hasSpawned;

        if (hasItemSpawned == true)         
        {
            placeVersion.SetActive(false);
            moveVersion.SetActive(true);
        }
        else if (hasItemSpawned == false)
        {
            placeVersion.SetActive(true);
            moveVersion.SetActive(false);
        }

        //Debug.Log("PlaceRemoveButtonSwitch");
    }
    #endregion

    #region ProductInfo
    //shows all the product info option buttons  
    public void ShowProductInfoButtons()         
    {
        closeButton.SetActive(true);
        descButton.SetActive(true);
        specButton.SetActive(true);

        descContent.SetActive(true);

        //closeButton.SetActive(true);

        HideBarButtons();   //hides all of the bar buttons so only the product info options are showing      

        //Debug.Log("ShowProductInfoButtons");
    }

    //product info buttons function
    public void ProductInfoOptionTapped()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;

        switch (buttonName)
        {
            case "DescriptionButton":
            descContent.SetActive(true);
            specContent.SetActive(false);
            break;


            case "SpecificationButton":
            descContent.SetActive(false);
            specContent.SetActive(true);
            break;

        }
        //Debug.Log("ProductInfoOptionTapped");
    }
    #endregion

    #region colour
    //shows the colour option buttons
    public void ShowColourOptions()     
    {
        pinkButton.SetActive(true);
        greyButton.SetActive(true);
        sageButton.SetActive(true);

        HideBarButtons();       //hides all of the bar buttons so only the colour options are showing

        //Debug.Log("Colour");
    }

    //colour option selected function
    public void ColourOptionTapped()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;

        switch (buttonName)
        {
            case "PinkButton":
            productMaterial.color = pinkColour;
            break;


            case "GreyButton":
            productMaterial.color = greyColour;
            break;

            case "SageButton":
            productMaterial.color = sageColour;
            break;
        }

        Debug.Log("ColourOptionTapped");
    }
    #endregion

    //function to change scene to model
    public void ChangeSceneToModel()
    {
        SceneManager.LoadScene("ModelView");

        Debug.Log("ChangeSceneToModel");
    }

}


