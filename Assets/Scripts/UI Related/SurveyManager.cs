using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SurveyManager : MonoBehaviour
{
    public Slider Q1Slider, Q2Slider;
    public TMP_Text answer1, answer2, answer5, answer6, answer7;
    public Toggle answer3, answer4;

    // stored answers/vars (a1: response to q1, etc...)
    private string user, a1, a2, a3, a4, a5, a6, a7, sceneName;

    
    // Start is called before the first frame update
    void Start()
    {
        user = MainMenu.username;
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneName == "SurveyPg2")
        {
            answer1.SetText(Q1Slider.value.ToString());
            answer2.SetText(Q2Slider.value.ToString());
        }
    }

    // button function to go back to menu from survey page 1
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }

    // button function to go forward to page 2 
    public void nextPg2()
    {
        SceneManager.LoadScene(10);
    }

    // button function to go back to page 2
    public void backToPg2()
    {
        saveSecondResponses();
        SceneManager.LoadScene(10);
        loadFirstResponses();
    }
    // button function to go forward to page 3
    public void nextPg3()
    {
        saveFirstResponses();
        SceneManager.LoadScene(11);
        loadSecondResponses();
    }



    // button function to submit survey
    public void submit()
    {
        saveSecondResponses();
        SceneManager.LoadScene(0);
    }

    void saveFirstResponses()
    {
        a1 = answer1.text;
        a2 = answer2.text;
        if (answer3.isOn)
        {
            a3 = "yes";
        }
        else
        {
            a3 = "no";
        }
        if (answer4.isOn)
        {
            a4 = "yes";
        }
        else
        {
            a4 = "no";
        }

    }

    void saveSecondResponses()
    {
        a5 = answer5.text;
        a6 = answer6.text;
        a7 = answer7.text;
    }

    void loadFirstResponses()
    {
        answer1.SetText(a1);
        //answer1.text = a1;
        answer2.text = a2;
        if (a3 == "yes")
        {
            answer3.isOn = true;
        }
        else
        {
            answer3.isOn = false;
        }
        if (a4 == "yes")
        {
            answer4.isOn = true;
        }
        else
        {
            answer4.isOn = false;
        }
    }

    void loadSecondResponses()
    {
        answer5.text = a5;
        answer6.text = a6;
        answer7.text = a7;
    }

    // implement load first and second responses
}
