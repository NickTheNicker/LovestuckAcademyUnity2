using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]

public class Lore : MonoBehaviour
{
    // Cached References.
    Text iText;
    SavenSceneLoader saveNScene;

    // Variables.

    // Page number that corresponds to an element of the "text" array.
    int page = 0;

    // Array for pages of text.
    [TextArea(20, 260)]
    public string[] text;


    // Displays the next page of text "page" is smaller than the maximum index of "text".
    public void NextPage()
    {
        if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Space)) && (page < text.Length-1))
        {
                page += 1;
        }
    }

    // Displays the previous page of text when "page" is bigger than 0.
    public void PreviousPage()
    {
        if ((Input.GetKeyDown(KeyCode.Alpha1)) && (page > 0))
        {
                page -= 1;
        }
    }
    // Displays text corresponding to the "page" number for elements in the text array.
    public void TextDisplay()
    {
        if (page <= text.Length)
        {
            iText.text = text[page].ToString();
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
        PreviousPage();
        LoadMenu();
    }
}