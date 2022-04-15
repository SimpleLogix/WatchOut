using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/**
*
* Script to handle page one of survey feedback collection
* handles saving/loading data from scene to scene
*
*/
public class ResponsePart1 : MonoBehaviour
{
    public Slider Q1Slider, Q2Slider;
    public TMP_Text answer1, answer2;
    public Toggle answer3, answer4;
    //static variable to move data from scene to scene upon switching
    public static string[] responses = new string[4];
    private static bool saved = false;

    // Start is called before the first frame update
    void Start()
    {
        if (saved)
        {
            loadFirstResponses();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        answer1.SetText(Q1Slider.value.ToString());
        answer2.SetText(Q2Slider.value.ToString());
    }

    // button function to go back to page 1
    public void backToPg1()
    {
        saveFirstResponses();
        SceneManager.LoadScene(9);
    }

    // button function to go forward to page 3
    public void nextPg3()
    {
        saveFirstResponses();
        SceneManager.LoadScene(11);
        //loadSecondResponses();
    }

    void saveFirstResponses()
    {
        responses[0] = answer1.text;
        responses[1] = answer2.text;
        if (answer3.isOn)
        {
            responses[2] = "yes";
        }
        else
        {
            responses[2] = "no";
        }
        if (answer4.isOn)
        {
            responses[3] = "yes";
        }
        else
        {
            responses[3] = "no";
        }
        saved = true;
    }

    void loadFirstResponses()
    {
        answer1.SetText(responses[0]);
        Q1Slider.value =  float.Parse(responses[0], CultureInfo.InvariantCulture.NumberFormat); //string > float
        answer2.SetText(responses[1]);
        Q2Slider.value =  float.Parse(responses[1], CultureInfo.InvariantCulture.NumberFormat);
        if (responses[2] == "yes")
        {
            answer3.isOn = true;
        }
        else
        {
            answer3.isOn = false;
        }
        if (responses[3] == "yes")
        {
            answer4.isOn = true;
        }
        else
        {
            answer4.isOn = false;
        }
    }
}
