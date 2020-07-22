using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSystemExtended : MonoBehaviour
{
    // Cached References.
    TextnEvent textnEvent;

    // Background images.
    Image back01;
    Image back02;
    Image back03;
    Image back04;
    Image back05;

    Image back11;
    Image back12;
    Image back13;
    Image back14;
    Image back15;

    Image back21;
    Image back22;
    Image back23;
    Image back24;
    Image back25;

    Image back31;
    Image back32;
    Image back33;
    Image back34;
    Image back35;

    Image back41;
    Image back42;
    Image back43;
    Image back44;
    Image back45;

    // Character images.
    Image girl01;
    Image girl02;
    Image girl03;
    Image girl04;
    Image girl05;

    Image girl11;
    Image girl12;
    Image girl13;
    Image girl14;
    Image girl15;

    Image girl21;
    Image girl22;
    Image girl23;
    Image girl24;
    Image girl25;

    Image girl31;
    Image girl32;
    Image girl33;
    Image girl34;
    Image girl35;

    Image girl41;
    Image girl42;
    Image girl43;
    Image girl44;
    Image girl45;

    int currentEvent;

    // Variables
    int page = 0;

    // Page numbers for when the "b"ackground image changes when "currentEvent" = 0.
    [SerializeField] int b01 = 0;
    [SerializeField] int b02 = -1;
    [SerializeField] int b03 = -2;
    [SerializeField] int b04 = -3;
    [SerializeField] int b05 = -4;

    // Page numbers for when the "b"ackground image changes when "currentEvent" = 1.
    [SerializeField] int b11 = 0;
    [SerializeField] int b12 = -1;
    [SerializeField] int b13 = -2;
    [SerializeField] int b14 = -3;
    [SerializeField] int b15 = -4;

    // Page numbers for when the "b"ackground image changes when "currentEvent" = 2.
    [SerializeField] int b21 = 0;
    [SerializeField] int b22 = -1;
    [SerializeField] int b23 = -2;
    [SerializeField] int b24 = -3;
    [SerializeField] int b25 = -4;

    // Page numbers for when the "b"ackground image changes when "currentEvent" = 3.
    [SerializeField] int b31 = 0;
    [SerializeField] int b32 = -1;
    [SerializeField] int b33 = -2;
    [SerializeField] int b34 = -3;
    [SerializeField] int b35 = -4;

    // Page numbers for when the "b"ackground image changes when "currentEvent" = 4.
    [SerializeField] int b41 = 0;
    [SerializeField] int b42 = -1;
    [SerializeField] int b43 = -2;
    [SerializeField] int b44 = -3;
    [SerializeField] int b45 = -4;

    // Page numbers for when the "g"irl image changes when "currentEvent" = 0.
    [SerializeField] int g01 = 0;
    [SerializeField] int g02 = -1;
    [SerializeField] int g03 = -2;
    [SerializeField] int g04 = -3;
    [SerializeField] int g05 = -4;

    // Page numbers for when the "g"irl image changes when "currentEvent" = 1.
    [SerializeField] int g11 = -1;
    [SerializeField] int g12 = -2;
    [SerializeField] int g13 = -3;
    [SerializeField] int g14 = -3;
    [SerializeField] int g15 = -4;

    // Page numbers for when the "g"irl image changes when "currentEvent" = 2.
    [SerializeField] int g21 = -1;
    [SerializeField] int g22 = -2;
    [SerializeField] int g23 = -3;
    [SerializeField] int g24 = -3;
    [SerializeField] int g25 = -4;

    // Page numbers for when the "g"irl image changes when "currentEvent" = 3.
    [SerializeField] int g31 = -1;
    [SerializeField] int g32 = -2;
    [SerializeField] int g33 = -3;
    [SerializeField] int g34 = -3;
    [SerializeField] int g35 = -4;

    // Page numbers for when the "g"irl image changes when "currentEvent" = 4.
    [SerializeField] int g41 = -1;
    [SerializeField] int g42 = -2;
    [SerializeField] int g43 = -3;
    [SerializeField] int g44 = -3;
    [SerializeField] int g45 = -4;

    // Hides all images except "back1".
    public void StartImages()
    {
        back01.enabled = false;
        back02.enabled = false;
        back03.enabled = false;
        back04.enabled = false;
        back05.enabled = false;

        back11.enabled = false;
        back12.enabled = false;
        back13.enabled = false;
        back14.enabled = false;
        back15.enabled = false;

        back21.enabled = false;
        back22.enabled = false;
        back23.enabled = false;
        back24.enabled = false;
        back25.enabled = false;

        back31.enabled = false;
        back32.enabled = false;
        back33.enabled = false;
        back34.enabled = false;
        back35.enabled = false;

        back41.enabled = false;
        back42.enabled = false;
        back43.enabled = false;
        back44.enabled = false;
        back45.enabled = false;

        girl01.enabled = false;
        girl02.enabled = false;
        girl03.enabled = false;
        girl04.enabled = false;
        girl05.enabled = false;

        girl11.enabled = false;
        girl12.enabled = false;
        girl13.enabled = false;
        girl14.enabled = false;
        girl15.enabled = false;

        girl21.enabled = false;
        girl22.enabled = false;
        girl23.enabled = false;
        girl24.enabled = false;
        girl25.enabled = false;

        girl31.enabled = false;
        girl32.enabled = false;
        girl33.enabled = false;
        girl34.enabled = false;
        girl35.enabled = false;

        girl41.enabled = false;
        girl42.enabled = false;
        girl43.enabled = false;
        girl44.enabled = false;
        girl45.enabled = false;
    }

    // Turns off the images that appear when "currentScene" = 0. 
    public void StopZeroImages()
    {
        girl01.enabled = false;
        girl02.enabled = false;
        girl03.enabled = false;
        girl04.enabled = false;
        girl05.enabled = false;

        back01.enabled = false;
        back02.enabled = false;
        back03.enabled = false;
        back04.enabled = false;
        back05.enabled = false;
    }

    // Changes the background image accroding to the "page" int and "currentScene" int.
    public void BackChange()
    {
        switch (currentEvent)
        {
            case 0:
                if (page == b01)
                {
                    back01.enabled = true;
                }
                if (page == b02)
                {
                    back01.enabled = false;
                    back02.enabled = true;
                }
                if (page == b03)
                {
                    back02.enabled = false;
                    back03.enabled = true;
                }
                if (page == b04)
                {
                    back03.enabled = false;
                    back04.enabled = true;
                }
                if (page == b05)
                {
                    back04.enabled = false;
                    back05.enabled = true;
                }
                break;

            case 1:
                if (page == b11)
                {
                    StopZeroImages();
                    back11.enabled = true;
                }
                if (page == b12)
                {
                    back11.enabled = false;
                    back12.enabled = true;
                }
                if (page == b13)
                {
                    back12.enabled = false;
                    back13.enabled = true;
                }
                if (page == b14)
                {
                    back13.enabled = false;
                    back14.enabled = true;
                }
                if (page == b15)
                {
                    back14.enabled = false;
                    back15.enabled = true;
                }
                break;

            case 2:
                if (page == b21)
                {
                    // Hides previous images.
                    StopZeroImages();
                    back21.enabled = true;
                }
                if (page == b22)
                {
                    back21.enabled = false;
                    back22.enabled = true;
                }
                if (page == b23)
                {
                    back22.enabled = false;
                    back23.enabled = true;
                }
                if (page == b24)
                {
                    back23.enabled = false;
                    back24.enabled = true;
                }
                if (page == b25)
                {
                    back24.enabled = false;
                    back25.enabled = true;
                }
                break;

            case 3:
                if (page == b31)
                {
                    StopZeroImages();
                    back31.enabled = true;
                }
                if (page == b32)
                {
                    back31.enabled = false;
                    back32.enabled = true;
                }
                if (page == b33)
                {
                    back32.enabled = false;
                    back33.enabled = true;
                }
                if (page == b34)
                {
                    back33.enabled = false;
                    back34.enabled = true;
                }
                if (page == b35)
                {
                    back34.enabled = false;
                    back35.enabled = true;
                }
                break;

            case 4:
                if (page == b41)
                {
                    StopZeroImages();
                    back41.enabled = true;
                }
                if (page == b42)
                {
                    back41.enabled = false;
                    back42.enabled = true;
                }
                if (page == b43)
                {
                    back42.enabled = false;
                    back43.enabled = true;
                }
                if (page == b44)
                {
                    back43.enabled = false;
                    back44.enabled = true;
                }
                if (page == b45)
                {
                    back44.enabled = false;
                    back45.enabled = true;
                }
                break;
        }
        
    }

    // Changes the girl image accroding to the "page" int.
    public void GirlChange()
    {
        switch (currentEvent)
        {
            case 0:
                if (page == g01)
                {
                    girl01.enabled = true;
                }
                if (page == g02)
                {
                    girl01.enabled = false;
                    girl02.enabled = true;
                }
                if (page == g03)
                {
                    girl02.enabled = false;
                    girl03.enabled = true;
                }
                if (page == g04)
                {
                    girl03.enabled = false;
                    girl04.enabled = true;
                }
                if (page == g05)
                {
                    girl04.enabled = false;
                    girl05.enabled = true;
                }
                break;

            case 1:
                if (page == g11)
                {
                    girl11.enabled = true;
                }
                if (page == g12)
                {
                    girl11.enabled = false;
                    girl12.enabled = true;
                }
                if (page == g13)
                {
                    girl12.enabled = false;
                    girl13.enabled = true;
                }
                if (page == g14)
                {
                    girl13.enabled = false;
                    girl14.enabled = true;
                }
                if (page == g15)
                {
                    girl14.enabled = false;
                    girl15.enabled = true;
                }
                break;

            case 2:
                if (page == g21)
                {
                    girl21.enabled = true;
                }
                if (page == g22)
                {
                    girl21.enabled = false;
                    girl22.enabled = true;
                }
                if (page == g23)
                {
                    girl22.enabled = false;
                    girl23.enabled = true;
                }
                if (page == g24)
                {
                    girl23.enabled = false;
                    girl24.enabled = true;
                }
                if (page == g25)
                {
                    girl24.enabled = false;
                    girl25.enabled = true;
                }
                break;

            case 3:
                if (page == g31)
                {
                    girl31.enabled = true;
                }
                if (page == g32)
                {
                    girl31.enabled = false;
                    girl32.enabled = true;
                }
                if (page == g33)
                {
                    girl32.enabled = false;
                    girl33.enabled = true;
                }
                if (page == g34)
                {
                    girl33.enabled = false;
                    girl34.enabled = true;
                }
                if (page == g35)
                {
                    girl34.enabled = false;
                    girl35.enabled = true;
                }
                break;

            case 4:
                if (page == g41)
                {
                    girl41.enabled = true;
                }
                if (page == g42)
                {
                    girl41.enabled = false;
                    girl42.enabled = true;
                }
                if (page == g43)
                {
                    girl42.enabled = false;
                    girl43.enabled = true;
                }
                if (page == g44)
                {
                    girl43.enabled = false;
                    girl44.enabled = true;
                }
                if (page == g45)
                {
                    girl44.enabled = false;
                    girl45.enabled = true;
                }
                break;
        }
    }

    // Start is called before the first frame update.
    void Start()
    {
        // Image references.
        back01 = GameObject.Find("Back01").GetComponent<Image>();
        back02 = GameObject.Find("Back02").GetComponent<Image>();
        back03 = GameObject.Find("Back03").GetComponent<Image>();
        back04 = GameObject.Find("Back04").GetComponent<Image>();
        back05 = GameObject.Find("Back05").GetComponent<Image>();

        back11 = GameObject.Find("Back11").GetComponent<Image>();
        back12 = GameObject.Find("Back12").GetComponent<Image>();
        back13 = GameObject.Find("Back13").GetComponent<Image>();
        back14 = GameObject.Find("Back14").GetComponent<Image>();
        back15 = GameObject.Find("Back15").GetComponent<Image>();

        back21 = GameObject.Find("Back21").GetComponent<Image>();
        back22 = GameObject.Find("Back22").GetComponent<Image>();
        back23 = GameObject.Find("Back23").GetComponent<Image>();
        back24 = GameObject.Find("Back24").GetComponent<Image>();
        back25 = GameObject.Find("Back25").GetComponent<Image>();

        back31 = GameObject.Find("Back31").GetComponent<Image>();
        back32 = GameObject.Find("Back32").GetComponent<Image>();
        back33 = GameObject.Find("Back33").GetComponent<Image>();
        back34 = GameObject.Find("Back34").GetComponent<Image>();
        back35 = GameObject.Find("Back35").GetComponent<Image>();

        back41 = GameObject.Find("Back41").GetComponent<Image>();
        back42 = GameObject.Find("Back42").GetComponent<Image>();
        back43 = GameObject.Find("Back43").GetComponent<Image>();
        back44 = GameObject.Find("Back44").GetComponent<Image>();
        back45 = GameObject.Find("Back45").GetComponent<Image>();

        girl01 = GameObject.Find("Girl01").GetComponent<Image>();
        girl02 = GameObject.Find("Girl02").GetComponent<Image>();
        girl03 = GameObject.Find("Girl03").GetComponent<Image>();
        girl04 = GameObject.Find("Girl04").GetComponent<Image>();
        girl05 = GameObject.Find("Girl05").GetComponent<Image>();

        girl11 = GameObject.Find("Girl11").GetComponent<Image>();
        girl12 = GameObject.Find("Girl12").GetComponent<Image>();
        girl13 = GameObject.Find("Girl13").GetComponent<Image>();
        girl14 = GameObject.Find("Girl14").GetComponent<Image>();
        girl15 = GameObject.Find("Girl15").GetComponent<Image>();

        girl21 = GameObject.Find("Girl21").GetComponent<Image>();
        girl22 = GameObject.Find("Girl22").GetComponent<Image>();
        girl23 = GameObject.Find("Girl23").GetComponent<Image>();
        girl24 = GameObject.Find("Girl24").GetComponent<Image>();
        girl25 = GameObject.Find("Girl25").GetComponent<Image>();

        girl31 = GameObject.Find("Girl31").GetComponent<Image>();
        girl32 = GameObject.Find("Girl32").GetComponent<Image>();
        girl33 = GameObject.Find("Girl33").GetComponent<Image>();
        girl34 = GameObject.Find("Girl34").GetComponent<Image>();
        girl35 = GameObject.Find("Girl35").GetComponent<Image>();

        girl41 = GameObject.Find("Girl41").GetComponent<Image>();
        girl42 = GameObject.Find("Girl42").GetComponent<Image>();
        girl43 = GameObject.Find("Girl43").GetComponent<Image>();
        girl44 = GameObject.Find("Girl44").GetComponent<Image>();
        girl45 = GameObject.Find("Girl45").GetComponent<Image>();

        StartImages();

        textnEvent = GameObject.Find("TextBoxText").GetComponent<TextnEvent>();
    }

    // Update is called once per frame.
    void Update()
    {
        // Copies the int values from the "TextnEvent" script.
        page = textnEvent.page;
        currentEvent = textnEvent.currentEvent;

        BackChange();
        GirlChange();
    }
}
