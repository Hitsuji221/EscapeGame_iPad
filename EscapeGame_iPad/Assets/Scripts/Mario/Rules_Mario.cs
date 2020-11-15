using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules_Mario : MonoBehaviour
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
            this.transform.localPosition = new Vector2(-8800,6400);
            currentPanelStr = "Slide4";
        }
        else if(currentPanelStr == "Slide4"){
            this.transform.localPosition = new Vector2(-8800,8000);
            currentPanelStr = "Slide5";
        }
        else if(currentPanelStr == "Slide5"){
            this.transform.localPosition = new Vector2(-8800,9600);
            currentPanelStr = "Slide6";
        }
        else if(currentPanelStr == "Slide6"){
            this.transform.localPosition = new Vector2(-8800,11200);
            currentPanelStr = "Slide7";
        }
        else if(currentPanelStr == "Slide7"){
            this.transform.localPosition = new Vector2(-8800,12800);
            currentPanelStr = "Slide8";
        }
        else if(currentPanelStr == "Slide8"){
            this.transform.localPosition = new Vector2(-8800,14400);
            currentPanelStr = "Slide9";
        }
        else if(currentPanelStr == "Slide9"){
            this.transform.localPosition = new Vector2(-8800,16000);
            currentPanelStr = "SlideStart";
            rightArrow.SetActive(false);
        }
    }

    public void OnLookRule(){
        if(currentPanelStr == "SlideStart"){
            this.transform.localPosition = new Vector2(-8800,1600);
            currentPanelStr = "Slide1";
            rightArrow.SetActive(true);
        }
    }
}
