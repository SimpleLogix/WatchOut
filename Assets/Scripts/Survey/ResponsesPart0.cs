using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
*
* Script to handle intro page of survey feedback collection (survey information)
*
*/
public class ResponsesPart0 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextPg2()
    {
        SceneManager.LoadScene(10);
    }
}
