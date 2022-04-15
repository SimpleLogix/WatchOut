using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/**
*
* Script to handle page two of survey feedback collection
* handles saving/loading data from scene to scene
*
*/
namespace GoogleSheetsForUnity
{
    public class ResponsePart2 : MonoBehaviour
    {
        public TMP_Text answer5, answer6, answer7;
        public static string[] responses = new string[3];
        
        // Simple struct to be able to easily parse response from drive
        [System.Serializable]
        public struct TableFields
        {
            public string PlayTime, Rating, WouldYouRecommend, IsItEducational, FavoriteAspect, LeastFavoriteAspect, Bugs;
        }
        private string _table = "User Feedback";


        // Start is called before the first frame update
        void Start()
        {
            loadSecondResponses();
        }

        // Update is called once per frame
        void Update()
        {
            saveSecondResponses();
        }

        // button function to go back to page 2
        public void backToPg2()
        {
            saveSecondResponses();
            SceneManager.LoadScene(10);
            //loadFirstResponses();
        }

        // button function to submit survey
        public void submit()
        {
            saveSecondResponses();

            //construct data to send
            //string[] data = {ResponsePart1.responses[0], ResponsePart1.responses[1], ResponsePart1.responses[2], ResponsePart1.responses[3], 
            //    responses[0], responses[1], responses[2]};

            TableFields _userData = new TableFields{ PlayTime = ResponsePart1.responses[0] + " mins", Rating = ResponsePart1.responses[1] + "/10", WouldYouRecommend = ResponsePart1.responses[2], IsItEducational = ResponsePart1.responses[3], FavoriteAspect = ResponsePart2.responses[0], LeastFavoriteAspect = ResponsePart2.responses[1], Bugs = ResponsePart2.responses[2]};
            string jsonPlayer = JsonUtility.ToJson(_userData);

            Drive.CreateObject(jsonPlayer, _table, true);
            
            //return data;
        }

        public void backToMenu()
        {
            saveSecondResponses();
            SceneManager.LoadScene(0);
        }

        void saveSecondResponses()
        {
            responses[0] = answer5.text.ToString();
            responses[1] = answer6.text.ToString();
            responses[2] = answer7.text.ToString(); 
            Debug.Log(responses[0]+ responses[1]+ responses[2]);
        }

        void loadSecondResponses()
        {
            answer5.text = responses[0];
            answer6.text = responses[1];
            answer7.text = responses[2];
        }

    }
}
