using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudySikyu : MonoBehaviour
{
    public GameObject rightArrow;
    public GameObject leftArrow;
    string currentPanelStr = "Sikyu1";

    void Start()
    {
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
    }

    public void OnClickStart(){
        this.transform.localPosition=new Vector2(-2200,4800);
        currentPanelStr = "Sikyu1";
        rightArrow.SetActive(true);
    }
    public void OnArrow(){
        if(currentPanelStr == "Sikyu1"){
            this.transform.localPosition = new Vector2(-2200,6400);
            currentPanelStr = "Sikyu2";
            leftArrow.SetActive(true);
        }
        else if(currentPanelStr == "Sikyu2"){
            this.transform.localPosition = new Vector2(-2200,8000);
            currentPanelStr = "Sikyu3";   
        }
        else if(currentPanelStr == "Sikyu3"){
            this.transform.localPosition = new Vector2(-2200,9600);
            currentPanelStr = "Sikyu4";
        }
        else if(currentPanelStr == "Sikyu4"){
            this.transform.localPosition = new Vector2(-2200,11200);
            currentPanelStr = "Sikyu5";
        }
        else if(currentPanelStr == "Sikyu5"){
            this.transform.localPosition = new Vector2(-2200,12800);
            currentPanelStr = "Sikyu6";
        }
        else if(currentPanelStr == "Sikyu6"){
            this.transform.localPosition = new Vector2(-2200,14400);
            currentPanelStr = "SikyuEND";
            rightArrow.SetActive(false);
            leftArrow.SetActive(false);
        }
    }

    public void OnBackArrow(){
        if(currentPanelStr == "Sikyu3"){
            this.transform.localPosition = new Vector2(-2200,6400);
            currentPanelStr = "Sikyu2";
        }
        else if(currentPanelStr == "Sikyu4"){
            this.transform.localPosition = new Vector2(-2200,8000);
            currentPanelStr = "Sikyu3";   
        }
        else if(currentPanelStr == "Sikyu5"){
            this.transform.localPosition = new Vector2(-2200,9600);
            currentPanelStr = "Sikyu4";
        }
        else if(currentPanelStr == "Sikyu6"){
            this.transform.localPosition = new Vector2(-2200,11200);
            currentPanelStr = "Sikyu5";
        }
        else if(currentPanelStr == "Sikyu7"){
            this.transform.localPosition = new Vector2(-2200,12800);
            currentPanelStr = "Sikyu6";
        }
        else if(currentPanelStr == "Sikyu2"){
            this.transform.localPosition = new Vector2(-2200,4800);
            currentPanelStr = "Sikyu1";
            leftArrow.SetActive(false);
        }
    }

    public void OnUnderstand(){
        if(currentPanelStr == "SikyuEND"){
            this.transform.localPosition = new Vector2(-2200,0);
            currentPanelStr = "Room2Panel2";
        }
    }
    public void OnNotUnderstand(){
        if(currentPanelStr == "SikyuEND"){
            this.transform.localPosition = new Vector2(-2200,4800);
            currentPanelStr = "Sikyu1";
            rightArrow.SetActive(true);
        }
    }
}
