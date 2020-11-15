using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Rule : MonoBehaviour
{
    public GameObject rightArrow;
    string currentPanelStr = "Slide1";

    void Start()
    {
        rightArrow.SetActive(false);
    }

    public void OnClickStart(){
        this.transform.localPosition=new Vector2(0,1600);
        currentPanelStr = "Slide1";
        rightArrow.SetActive(true);
    }
    public void OnArrow(){
        if(currentPanelStr == "Slide1"){
            this.transform.localPosition = new Vector2(0,3200);
            currentPanelStr = "Slide2";
        }
        else if(currentPanelStr == "Slide2"){
            this.transform.localPosition = new Vector2(0,0);
            currentPanelStr = "Room1Panel1"; 
            rightArrow.SetActive(false);
        }
    }
}
