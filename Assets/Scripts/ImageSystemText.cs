using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSystemText : MonoBehaviour
{
    // Cached References.
    GameObject textDisplay;
    GameObject textBoxText;
    TextOnly textOnly;

    // Background images.
    Image back1;
    Image back2;
    Image back3;

    // Character images.
    Image girl1;
    Image girl2;
    Image girl3;
    Image girl4;
    Image girl5;
    Image girl6;

    // Variables
    int page = 0;

    // Page numbers for when the "b"ackground or "g"irl image changes.
    [SerializeField] int b1 = 0;
    [SerializeField] int b2 = -1;
    [SerializeField] int b3 = -2;

    [SerializeField] int g1 = 0;
    [SerializeField] int g2 = -1;
    [SerializeField] int g3 = -2;
    [SerializeField] int g4 = -3;
    [SerializeField] int g5 = -4;
    [SerializeField] int g6 = -5;

    // Hides all images.
    public void StartImages()
    {
        back1.enabled = false;
        back2.enabled = false;
        back3.enabled = false;

        girl1.enabled = false;
        girl2.enabled = false;
        girl3.enabled = false;
        girl3.enabled = false;
        girl4.enabled = false;
        girl5.enabled = false;
        girl6.enabled = false;
    }
    
    // Changes the background image accroding to the "page" int.
    public void BackChange()
    {
        if (page == b1)
        {
            back1.enabled = true;
        }
        if (page == b2)
        {
            back1.enabled = false;
            back2.enabled = true;
        }

        if (page == b3)
        {
            back2.enabled = false;
            back3.enabled = true;
        }
    }

    // Changes the girl image accroding to the "page" int.
    public void GirlChange()
    {
        if (page == g1)
        {
            girl1.enabled = true;
        }
        if (page == g2)
        {
            girl1.enabled = false;
            girl2.enabled = true;
        }

        if(page == g3)
        {
            girl2.enabled = false;
            girl3.enabled = true;
        }
        if (page == g4)
        {
            girl3.enabled = false;
            girl4.enabled = true;
        }
        if (page == g5)
        {
            girl4.enabled = false;
            girl5.enabled = true;
        }
        if (page == g6)
        {
            girl5.enabled = false;
            girl6.enabled = true;
        }
    }

    // Start is called before the first frame update.
    void Start()
    {
        // Image references.
        back1 = GameObject.Find("Back1").GetComponent<Image>();
        back2 = GameObject.Find("Back2").GetComponent<Image>();
        back3 = GameObject.Find("Back3").GetComponent<Image>();
        girl1 = GameObject.Find("Girl1").GetComponent<Image>();
        girl2 = GameObject.Find("Girl2").GetComponent<Image>();
        girl3 = GameObject.Find("Girl3").GetComponent<Image>();
        girl4 = GameObject.Find("Girl4").GetComponent<Image>();
        girl5 = GameObject.Find("Girl5").GetComponent<Image>();
        girl6 = GameObject.Find("Girl6").GetComponent<Image>();

        StartImages();

        textDisplay = GameObject.Find("Text Display");
        textBoxText = textDisplay.transform.Find("TextBoxText").gameObject;
        textOnly = textBoxText.GetComponent<TextOnly>();
    }

    // Update is called once per frame.
    void Update()
    {
        // Copies the int value from the "TextOnly" script.
        page = textOnly.page;
        BackChange();
        GirlChange();
    }
}
