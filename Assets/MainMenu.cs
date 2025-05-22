using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void GoToEarthquake(){
        SceneManager.LoadScene("ETest");
    }

    public void GoToFire(){
        SceneManager.LoadScene("FTest");
    }

}
