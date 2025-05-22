using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class NewGameMenuManager : MonoBehaviour
{
    public Transform head;
    public float spawnDistance = 2;
    public GameObject pauseMenu;
    public GameObject controlsMenu;
    public GameObject infoMenu;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject uiLeft;
    public GameObject uiRight;
    public InputActionProperty showButton;
    public bool pause = true;
    public bool controls = false;
    public bool info = false;
    
    // Update is called once per frame
    void Update()
    {
        if(showButton.action.WasPressedThisFrame())
        {
            if(controls){
                controlsMenu.SetActive(!controlsMenu.activeSelf);
                pause = true;
                controls = false;
                info = false;
            }

            else if(info){
                infoMenu.SetActive(!infoMenu.activeSelf);
                pause = true;
                controls = false;
                info = false;
            }

            else {
                pauseMenu.SetActive(!pauseMenu.activeSelf);
                pauseMenu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
            }

            leftHand.SetActive(!leftHand.activeSelf);
            rightHand.SetActive(!rightHand.activeSelf);
            uiLeft.SetActive(!uiLeft.activeSelf);
            uiRight.SetActive(!uiRight.activeSelf);
        }
        
        if(pause){
            pauseMenu.transform.LookAt(new Vector3(head.position.x, pauseMenu.transform.position.y, head.position.z));
            pauseMenu.transform.forward *= -1;
        }

        if(controls){
            controlsMenu.transform.LookAt(new Vector3(head.position.x, controlsMenu.transform.position.y, head.position.z));
            controlsMenu.transform.forward *= -1;
        }

        if(info){
            infoMenu.transform.LookAt(new Vector3(head.position.x, infoMenu.transform.position.y, head.position.z));
            infoMenu.transform.forward *= -1;
        }
    }

    public void controlsPressed(){
        controls = true;
        info = false;
        pause = false;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        controlsMenu.SetActive(!controlsMenu.activeSelf);
        controlsMenu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
    }

    public void infoPressed(){
        info = true;
        controls = false;
        pause = false;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        infoMenu.SetActive(!infoMenu.activeSelf);
        infoMenu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
    }

    public void backPressed(){
        if(controls){
            controlsMenu.SetActive(!controlsMenu.activeSelf);
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
        if(info){
            infoMenu.SetActive(!infoMenu.activeSelf);
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
        controls = false;
        info = false;
        pause = true;
    }
}