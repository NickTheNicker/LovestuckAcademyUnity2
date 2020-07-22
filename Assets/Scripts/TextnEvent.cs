using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]

public class TextnEvent : MonoBehaviour
{
    // Cached References.
    Text iText;
    SavenSceneLoader saveNScene;

    // Variables.
    
    // Page number that corresponds to elements of the arrays.
    public int page = 0;

    // 0="startingText" 1="event1Text" 2="event2Text" 3="event3Text" 4="event4Text".
    public int currentEvent = 0;

    // Bool for if a choice has been made in the choice event.
    bool chosen = false;

    // The number of choices available.
    [SerializeField] int choices = 2;

    // Character you talk to in the scene, 1 = "Shiro" 2 = "Lilith" 3 = "Elora".
    [SerializeField] int character = 0;

    // Amounts of affection points added for choosing each event.
    [SerializeField] int affectionChange1 = 0;
    [SerializeField] int affectionChange2 = 0;
    [SerializeField] int affectionChange3 = 0;
    [SerializeField] int affectionChange4 = 0;

    // Array for pages of starting text that leads up to a choice event. 
    [TextArea(4, 50)]
    public string[] startingText;

    // Arrays for pages of text for events following the choice made at the choice event.
    [TextArea(4, 50)]
    public string[] event1Text;
    [TextArea(4, 50)]
    public string[] event2Text;
    [TextArea(4, 50)]
    public string[] event3Text;
    [TextArea(4, 50)]
    public string[] event4Text;

    // Displays the next page of text if not at a choice page.
    public void NextPage()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // For readibility sake by separating complex conditions.
            if ( (currentEvent != 0) || (page != startingText.Length - 1))
            {
                page += 1;
            }
        }

        // Required for the choice system to function.
        if (Input.GetKeyDown(KeyCode.Alpha1) && (startingText.Length - 1 == page) && (!chosen))
        {
            page += 1;
        }
        if ((Input.GetKeyDown(KeyCode.Alpha2)) && (startingText.Length - 1 == page) && (!chosen))
        {
            page += 1;
        }

        if ((Input.GetKeyDown(KeyCode.Alpha3)) && (startingText.Length - 1 == page) && (!chosen))
        {
            page += 1;
        }

        if ((Input.GetKeyDown(KeyCode.Alpha4)) && (startingText.Length - 1 == page) && (!chosen))
        {
            page += 1;
        }
    }

    // Gives choices which diverge into separate events.
    public void Choice()
    {
        if ((page == startingText.Length) && (!chosen))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentEvent = 1;
                page = 0;
                chosen = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentEvent = 2;
                page = 0;
                chosen = true;
            }
            if ((Input.GetKeyDown(KeyCode.Alpha3)) && (choices >= 3))
            {
                currentEvent = 3;
                page = 0;
                chosen = true;
            }
            if ((Input.GetKeyDown(KeyCode.Alpha4)) && (choices == 4))
            {
                currentEvent = 4;
                page = 0;
                chosen = true;
            }
        }
    }

    // Increases or decreases affection points based on the character and event selected;
    public void AffectionChange()
    {
       switch (character)
        {
            // Shiro
            case 1:
                switch (currentEvent)
                {
                    case 1:
                        saveNScene.save.sAffection += affectionChange1;
                        break;
                    case 2:
                        saveNScene.save.sAffection += affectionChange2;
                        break;
                    case 3:
                        saveNScene.save.sAffection += affectionChange3;
                        break;
                    case 4:
                        saveNScene.save.sAffection += affectionChange4;
                        break;
                }
                break;
                // Lilith
            case 2:
                switch (currentEvent)
                {
                    case 1:
                        saveNScene.save.lAffection += affectionChange1;
                        break;
                    case 2:
                        saveNScene.save.lAffection += affectionChange2;
                        break;
                    case 3:
                        saveNScene.save.lAffection += affectionChange3;
                        break;
                    case 4:
                        saveNScene.save.lAffection += affectionChange4;
                        break;
                }
                break;
                // Elora
            case 3:
                switch (currentEvent)
                {
                    case 1:
                        saveNScene.save.eAffection += affectionChange1;
                        break;
                    case 2:
                        saveNScene.save.eAffection += affectionChange2;
                        break;
                    case 3:
                        saveNScene.save.eAffection += affectionChange3;
                        break;
                    case 4:
                        saveNScene.save.eAffection += affectionChange4;
                        break;
                }
                break;
        }
    }

    // Displays text corresponding to the "page" number for elements in the currently used array.
    public void TextDisplay()
    {
        if (currentEvent == 0)
        {
            iText.text = startingText[page].ToString();
        }
        if (currentEvent == 1)
        {
            iText.text = event1Text[page].ToString();
        }
        if (currentEvent == 2)
        {
            iText.text = event2Text[page].ToString();
        }
        if (currentEvent == 3)
        {
            iText.text = event3Text[page].ToString();
        }
        if (currentEvent == 4)
        {
            iText.text = event4Text[page].ToString();
        }
    }

    // Loads next scene after "1" is pressed on the last page of an event array and adds affection points.
    public void NextScene()
    {
        if ((
            (event1Text.Length == page) && (currentEvent == 1) ||
            (event2Text.Length == page) && (currentEvent == 2) ||
            (event3Text.Length == page) && (currentEvent == 3) ||
            (event4Text.Length == page) && (currentEvent == 4)
           ))
        {
            AffectionChange();
            saveNScene.SaveToFile();
            saveNScene.LoadScene();
        }
    }

    // Loads the menu scene when the "Esc" key is pressed.
    public void LoadMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            saveNScene.Menu();
        }
    }

    // Start is called before the first frame update.
    void Start()
    {
        iText = GameObject.Find("TextBoxText").GetComponent<Text>();
        saveNScene = GameObject.Find("ScriptHolder").GetComponent<SavenSceneLoader>();
    }

    // Update is called once per frame.
    void Update()
    {
        TextDisplay();
        NextPage();
        Choice();
        NextScene();
        LoadMenu();
    }
}
