using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KImage : MonoBehaviour
{
    // Cached References.
    KBattle battle;

    // Images.
    Image back;
    Image pic0;
    Image pic1;
    Image pic2;
    Image pic3;
    Image pic4;
    Image pic5;
    Image pic6;
    Image pic7;
    Image pic8;

    // Variables.
    int page;

    // Displays the image that corresponds to the "page" int from the "Battle" script.
    public void Images()
    {
        switch (page)
        {
            case 0:
                pic0.enabled = true;
                pic1.enabled = false;
                pic2.enabled = false;
                pic3.enabled = false;
                pic4.enabled = false;
                pic5.enabled = false;
                pic6.enabled = false;
                pic7.enabled = false;
                pic8.enabled = false;
                break;
            case 1:
                pic0.enabled = false;
                pic1.enabled = true;
                pic2.enabled = false;
                pic3.enabled = false;
                pic4.enabled = false;
                pic5.enabled = false;
                pic6.enabled = false;
                pic7.enabled = false;
                pic8.enabled = false;
                break;
            case 2:
                pic0.enabled = false;
                pic1.enabled = false;
                pic2.enabled = true;
                pic3.enabled = false;
                pic4.enabled = false;
                pic5.enabled = false;
                pic6.enabled = false;
                pic7.enabled = false;
                pic8.enabled = false;
                break;
            case 3:
                pic0.enabled = false;
                pic1.enabled = false;
                pic2.enabled = false;
                pic3.enabled = true;
                pic4.enabled = false;
                pic5.enabled = false;
                pic6.enabled = false;
                pic7.enabled = false;
                pic8.enabled = false;
                break;
            case 4:
                pic0.enabled = false;
                pic1.enabled = false;
                pic2.enabled = false;
                pic3.enabled = false;
                pic4.enabled = true;
                pic5.enabled = false;
                pic6.enabled = false;
                pic7.enabled = false;
                pic8.enabled = false;
                break;
            case 5:
                pic0.enabled = false;
                pic1.enabled = false;
                pic2.enabled = false;
                pic3.enabled = false;
                pic4.enabled = false;
                pic5.enabled = true;
                pic6.enabled = false;
                pic7.enabled = false;
                pic8.enabled = false;
                break;
            case 6:
                pic0.enabled = false;
                pic1.enabled = false;
                pic2.enabled = false;
                pic3.enabled = false;
                pic4.enabled = false;
                pic5.enabled = false;
                pic6.enabled = true;
                pic7.enabled = false;
                pic8.enabled = false;
                break;
            case 7:
                pic0.enabled = false;
                pic1.enabled = false;
                pic2.enabled = false;
                pic3.enabled = false;
                pic4.enabled = false;
                pic5.enabled = false;
                pic6.enabled = false;
                pic7.enabled = true;
                pic8.enabled = false;
                break;
            case 8:
                pic0.enabled = false;
                pic1.enabled = false;
                pic2.enabled = false;
                pic3.enabled = false;
                pic4.enabled = false;
                pic5.enabled = false;
                pic6.enabled = false;
                pic7.enabled = false;
                pic8.enabled = true;
                break;
        }
    }
    
    // Start is called before the first frame update.
    void Start()
    {
        back = GameObject.Find("Back").GetComponent<Image>();
        pic0 = GameObject.Find("Pic0").GetComponent<Image>();
        pic1 = GameObject.Find("Pic1").GetComponent<Image>();
        pic2 = GameObject.Find("Pic2").GetComponent<Image>();
        pic3 = GameObject.Find("Pic3").GetComponent<Image>();
        pic4 = GameObject.Find("Pic4").GetComponent<Image>();
        pic5 = GameObject.Find("Pic5").GetComponent<Image>();
        pic6 = GameObject.Find("Pic6").GetComponent<Image>();
        pic7 = GameObject.Find("Pic7").GetComponent<Image>();
        pic8 = GameObject.Find("Pic8").GetComponent<Image>();
        battle = GameObject.Find("TextBoxText").GetComponent<KBattle>();
    }

    // Update is called once per frame.
    void Update()
    {
        // Copies the int values from the "TextnEvent" script.
        page = battle.page;

        Images();
    }
}


