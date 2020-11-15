using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleControl : MonoBehaviour
{
    string currentPanelStr = "StartPanel";
    public GameObject message1;

    void Start(){
        message1.SetActive(false);
        this.transform.localPosition=new Vector2(0,0);
        currentPanelStr = "StartPanel";
    }

    public void OnClickIntro(){
        this.transform.localPosition=new Vector2(-1200,0);
        currentPanelStr = "Intro1";
        message1.SetActive(true);
    }

    public void OnClickGameStart(){
        this.transform.localPosition=new Vector2(-2400,0);
        currentPanelStr = "Room1";
    }
}
