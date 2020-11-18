using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    string currentPanelStr = "GameSlide2";
    public GameObject Slide1;

    public void StartButton(){
    this.transform.localPosition = new Vector2(-4400,8000);
    currentPanelStr = "GameSlide2";
    Slide1.SetActive(false);
    }
    public void Answer(){
    this.transform.localPosition = new Vector2(-4400,9600);
    currentPanelStr = "GameSlide3";
    }
    public void NextButton(){
    this.transform.localPosition = new Vector2(-4400,11200);
    currentPanelStr = "GameSlide4";
    }
    public void BackRoom3(){
        this.transform.localPosition = new Vector2(-4400,0);
        currentPanelStr = "Room3Panel1";
    }
}