using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


[Serializable]

public class Homeroom : MonoBehaviour
{
    // Cached References.
    Text iText;
    SavenSceneLoader saveNScene;

    string shiro1 = "1)Talk to the person with cat ears.";
    string shiro2 = "1)Talk to Shiro";
    string lilith1 = "2)Talk to the person with ketchup on her face.";
    string lilith2 = "2)Talk to Lilith";
    string elora1 = "3)Talk to the person with a multi-gem bracelet.";
    string elora2 = "3)Talk to Elora";
    string skip = "4)Keep to yourself";

    // Variables.

    // Determines which character mood scene is loaded: 1=sad 2=normal 3=happy.
    int mood;

    // Methods that change text based on bools in "Save".
    private string ShiroText()
    {
        if (saveNScene.save.sMeet)
        {
            return shiro2;
        }
        else
        {
            return shiro1;
        }
    }
    private string LilithText()
    {
        if(saveNScene.save.lMeet)
        {
            return lilith2;
        }
        else
        {
            return lilith1;
        }
    }
    private string EloraText()
    {
        if (saveNScene.save.eMeet)
        {
            return elora2;
        }
        else
        {
            return elora1;
        }
    }

    // Selects Shiro Homeroom scenes based on "mood".
    public void Shiro()
    {
        if (!saveNScene.save.sMeet)
        {
            saveNScene.loadName = "ShiroMeet";
        }
        else switch (mood)
            {
                case 1:
                    saveNScene.loadName = "ShiroSad";
                    break;
                case 2:
                    saveNScene.loadName = "ShiroNormal";
                    break;
                case 3:
                    saveNScene.loadName = "ShiroNormal";
                    break;
                case 4:
                    saveNScene.loadName = "ShiroHappy";
                    break;
            }
    }

    // Selects Lilith Homeroom scenes based on "mood".
    public void Lilith()
    {
        if (!saveNScene.save.lMeet)
        {
            saveNScene.loadName = "LilithMeet";
        }
        else switch (mood)
            {
                case 1:
                    saveNScene.loadName = "LilithSad";
                    break;
                case 2:
                    saveNScene.loadName = "LilithNormal";
                    break;
                case 3:
                    saveNScene.loadName = "LilithNormal";
                    break;
                case 4:
                    saveNScene.loadName = "LilithHappy";
                    break;
            }
    }

    // Selects Elora Homeroom scenes based on "mood".
    public void Elora()
    {
        if(!saveNScene.save.eMeet)
        {
            saveNScene.loadName = "EloraMeet";
        }
        else switch (mood)
            {
                case 1:
                    saveNScene.loadName = "EloraSad";
                    break;
                case 2:
                    saveNScene.loadName = "EloraNormal";
                    break;
                case 3:
                    saveNScene.loadName = "EloraNormal";
                    break;
                case 4:
                    saveNScene.loadName = "EloraHappy";
                    break;
            }

    }

    // Gives choices which diverge into separate events.
    public void Choice()
    {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
            Shiro();
            saveNScene.LoadScene();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
            Lilith();
            saveNScene.LoadScene();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
            Elora();
            saveNScene.LoadScene();
            }
      
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
            saveNScene.loadName = "Classes"; 
            saveNScene.LoadScene();
            }
    }

    // Displays text corresponding to the "page" number for elements in the currently used array.
    public void TextDisplay()
    {
        string displayedText 
            = ShiroText() + Environment.NewLine 
            + LilithText() + Environment.NewLine 
            + EloraText() + Environment.NewLine 
            + skip;
        iText.text = displayedText;
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

        // Sets mood as a interger number between 1(including) and 5(excluding).
        mood = UnityEngine.Random.Range(1, 5);
    }

    // Update is called once per frame.
    void Update()
    {
        TextDisplay();
        Choice();
        LoadMenu();
    }
}
