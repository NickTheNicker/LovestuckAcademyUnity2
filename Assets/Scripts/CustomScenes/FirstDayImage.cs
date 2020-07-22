using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstDayImage : MonoBehaviour
{
    // Cached References.
    FirstDay firstDay;

    // Background images.
    Image back1;
    Image back2;
    Image back3;

    // Character images.
    Image girl01;
    Image girl02;
    Image girl03;

    Image girl11;
    Image girl12;
    Image girl13;

    Image girl21;
    Image girl22;
    Image girl23;

    Image girl31;
    Image girl32;
    Image girl33;

    Image girl41;
    Image girl42;
    Image girl43;

    int currentEvent;

    // Variables
    int page = 0;

    // Page numbers for when the "b"ackground image changes when "currentEvent" = 0.
    [SerializeField] int b1 = 0;
    [SerializeField] int b2 = -1;
    [SerializeField] int b3 = -2;

    // Page numbers for when the "g"irl image changes when "currentEvent" = 0.
    [SerializeField] int g01 = 0;
    [SerializeField] int g02 = -1;
    [SerializeField] int g03 = -2;

    // Page numbers for when the "g"irl image changes when "currentEvent" = 1.
    [SerializeField] int g11 = -1;
    [SerializeField] int g12 = -2;
    [SerializeField] int g13 = -3;

    // Page numbers for when the "g"irl image changes when "currentEvent" = 2.
    [SerializeField] int g21 = -1;
    [SerializeField] int g22 = -2;
    [SerializeField] int g23 = -3;

    // Page numbers for when the "g"irl image changes when "currentEvent" = 3.
    [SerializeField] int g31 = -1;
    [SerializeField] int g32 = -2;
    [SerializeField] int g33 = -3;

    // Page numbers for when the "g"irl image changes when "currentEvent" = 4.
    [SerializeField] int g41 = -1;
    [SerializeField] int g42 = -2;
    [SerializeField] int g43 = -3;

    // Hides all images except "back1".
    public void StartImages()
    {
        back1.enabled = false;
        back2.enabled = false;
        back3.enabled = false;

        girl01.enabled = false;
        girl02.enabled = false;
        girl03.enabled = false;

        girl11.enabled = false;
        girl12.enabled = false;
        girl13.enabled = false;

        girl21.enabled = false;
        girl22.enabled = false;
        girl23.enabled = false;

        girl31.enabled = false;
        girl32.enabled = false;
        girl33.enabled = false;

        girl41.enabled = false;
        girl42.enabled = false;
        girl43.enabled = false;
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

    // Turns off the images "Girl01" "Girl02" "Girl03". 
    public void StopZeroImages()
    {
        girl01.enabled = false;
        girl02.enabled = false;
        girl03.enabled = false;
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
                break;
            case 1:
                if (page == g11)
                {
                    StopZeroImages();
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
                break;
            case 2:
                if (page == g21)
                {
                    StopZeroImages();
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
                break;
            case 3:
                if (page == g31)
                {
                    StopZeroImages();
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
                break;
            case 4:
                if (page == g41)
                {
                    StopZeroImages();
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
                break;
        }
    }

    // Start is called before the first frame update.
    void Start()
    {
        // Image references.
        back1 = GameObject.Find("Back1").GetComponent<Image>();
        back2 = GameObject.Find("Back2").GetComponent<Image>();
        back3 = GameObject.Find("Back3").GetComponent<Image>();

        girl01 = GameObject.Find("Girl01").GetComponent<Image>();
        girl02 = GameObject.Find("Girl02").GetComponent<Image>();
        girl03 = GameObject.Find("Girl03").GetComponent<Image>();

        girl11 = GameObject.Find("Girl11").GetComponent<Image>();
        girl12 = GameObject.Find("Girl12").GetComponent<Image>();
        girl13 = GameObject.Find("Girl13").GetComponent<Image>();

        girl21 = GameObject.Find("Girl21").GetComponent<Image>();
        girl22 = GameObject.Find("Girl22").GetComponent<Image>();
        girl23 = GameObject.Find("Girl23").GetComponent<Image>();

        girl31 = GameObject.Find("Girl31").GetComponent<Image>();
        girl32 = GameObject.Find("Girl32").GetComponent<Image>();
        girl33 = GameObject.Find("Girl33").GetComponent<Image>();

        girl41 = GameObject.Find("Girl41").GetComponent<Image>();
        girl42 = GameObject.Find("Girl42").GetComponent<Image>();
        girl43 = GameObject.Find("Girl43").GetComponent<Image>();

        StartImages();

        firstDay = GameObject.Find("TextBoxText").GetComponent<FirstDay>();
    }

    // Update is called once per frame.
    void Update()
    {
        // Copies the int values from the "TextnEvent" script.
        page = firstDay.page;
        currentEvent = firstDay.currentEvent;

        BackChange();
        GirlChange();
    }
}
