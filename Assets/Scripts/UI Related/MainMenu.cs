using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//Manages Main Menu
public class MainMenu : MonoBehaviour
{
    //user input
    public TMP_Text Password_field;
    //username input field 
    public TMP_Text Username_field;   
    //displays if user inputs wrong password
    public TextMeshProUGUI Incorrect_Pass;
    //displays if user does't input username
    public TextMeshProUGUI Missing_User;
    //username collected from main menu as a reference
    public static string username;
    
    // Start is called before the first frame update
    void Start()
    {
    Incorrect_Pass.enabled = false;
    Missing_User.enabled = false;
    }

        // Awake is called when the script instance is being loaded.
    void Awake()
    {
    Incorrect_Pass.enabled = false;
    Missing_User.enabled = false;
    }

    //Play Button Function - Starts game
   public void PlayGame()
   {    
       Debug.Log(Username_field.text.ToString().Length);
        //username check
        if (Username_field.text.ToString().Length-1 < 1 )
        {
            Missing_User.enabled = true;
        }
        else
        {   
            Missing_User.enabled = false;
            //grab password input + username
            string key = Password_field.text.ToString();
            key = key.Substring(0, key.Length-1);

            //password check
            if (string.Equals(key, "WITGames")) 
            {
                username = Username_field.text;
                SceneManager.LoadScene(3);
                PlayerStats.resetStats();  
            }
            else
            {
            Incorrect_Pass.enabled = true;
            }
        }
   }

   public string getUsername()
   {
       return username;
   }

    //Exits application
   public void QuitGame()
   {
       Debug.Log("QUIT");
       Application.Quit();
   }
}
