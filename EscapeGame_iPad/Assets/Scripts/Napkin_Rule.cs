using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Napkin_Rule : MonoBehaviour
{
    public GameObject rightArrow;
    string currentPanelStr = "Slide1";

    void Start()
    {
        rightArrow.SetActive(false);
    }

    public void OnClickStart(){
        this.transform.localPosition=new Vector2(-8800,1600);
        currentPanelStr = "Slide1";
        rightArrow.SetActive(true);
    }
    public void OnArrow(){
        if(currentPanelStr == "Slide1"){
            this.transform.localPosition = new Vector2(-8800,3200);
            currentPanelStr = "Slide2";
        }
        else if(currentPanelStr == "Slide2"){
            this.transform.localPosition = new Vector2(-8800,4800);
            currentPanelStr = "Slide3";   
        }
        else if(currentPanelStr == "Slide3"){
            this.transform.localPosition = new Vector2(-11000,1600);
            currentPanelStr = "Room6Panel5";
            rightArrow.SetActive(false);
        }
    }
}
