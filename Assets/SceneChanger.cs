using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    public void goToMainMenu()
    {
        SceneManager.LoadScene("New Pause UI");
    }

}
