using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]

public class Classes : MonoBehaviour
{
    // Cached References.
    Text iText;
    SavenSceneLoader saveNScene;

    // Variables.

    // Page number that corresponds to an element of the "text" array.
    public int page = 0;

    // Array for pages of text.
    [TextArea(4, 50)]
    public string[] text;

    // Displays text corresponding to the "page" number for elements in the text array.
    public void TextDisplay()
    {
            iText.text = text[page].ToString();
    }

    // Sets "page" as a random interger number between 1 and the page length(inclusive) when conditions are met.
    public void Next()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (page == 0)
            {
                page = UnityEngine.Random.Range(1, text.Length);
            }
            else
            {
                // Loads a random lunch scene selected at start.
                saveNScene.LoadScene();
            }
        }
    }

    // Resets "lunchCount" when it is larger than the number of dictionary keys.
    public void Reset()
    {
        if (saveNScene.save.lunchCount > addScene.Count)
        {
            saveNScene.save.lunchCount = 2;
        }
    }

    // Start is called before the first frame update.
    void Start()
    {
        iText = GameObject.Find("TextBoxText").GetComponent<Text>();
        saveNScene = GameObject.Find("ScriptHolder").GetComponent<SavenSceneLoader>();

        // Updates the "lunchCount".
        saveNScene.save.lunchCount += 1;
    }

    // Contains the the names of all lunch scenes.
    Dictionary<int, string>
        addScene = new Dictionary<int, string>
        {
                { 1, "LunchMeet" },
                { 2, "Disappearance" },
                { 3, "Fornication" },
                { 4, "Sexes" },
                { 5, "Eliza and Prisca" },
                { 6, "The Prodigy" },
                { 7, "Uniforms" },
                { 8, "Chase" },
                { 9, "Knight" },
                { 10, "You" },
                { 11, "Lonely"},
        };


    // Update is called once per frame.
    void Update()
    {
        TextDisplay();
        Next();
        Reset();

        // Selects a the next lunch scene based on "lunchCount".
        saveNScene.loadName = addScene[saveNScene.save.lunchCount];
    }
}