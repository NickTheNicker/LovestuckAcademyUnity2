using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    // Cached References.
    // The first startingText.
    GameObject canvas1;
    // The second startingText.
    GameObject canvas2;
    // The saveNScene script.
    SavenSceneLoader saveNScene;
    bool secondPage;

    // Written as a method for invoke.
    private void NextDisplay()
    {
        secondPage = true;
    }

    // Start is called before the first frame update.
    void Start()
    {
        canvas1 = GameObject.Find("/Canvas1");
        canvas2 = GameObject.Find("/Canvas2");
        saveNScene = GameObject.Find("ScriptHolder").GetComponent<SavenSceneLoader>();

        // Hides the second startingText.
        canvas2.gameObject.SetActive(false);

        // Scene starts on the first startingText.
        secondPage = false;
    }

    // Update is called once per frame.
    void Update()
    {
        // Hides the first startingText and opens the second startingText.
        if ((Input.GetKeyDown(KeyCode.Alpha1) && !secondPage) || (Input.GetKeyDown(KeyCode.Alpha2) && !secondPage))
        {
            canvas1.gameObject.SetActive(false);
            canvas2.gameObject.SetActive(true);
            // A delay stops the key press from registering twice.
            Invoke("NextDisplay", 0.5f);
        }

        // Loads the "FirstDay" scene.
        if ((Input.GetKeyDown(KeyCode.Alpha1) && secondPage) || (Input.GetKeyDown(KeyCode.Alpha2) && secondPage))
        {
            saveNScene.FirstDay();
        }
    }
}
