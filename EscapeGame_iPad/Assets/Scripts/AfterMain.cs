using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class AfterMain : MonoBehaviour
{
    public static MainGameChanger instance;
    public GameObject itemBox;
    //矢印の表示・非表示
    public GameObject rightArrow;
    public GameObject leftArrow;
    public GameObject backArrow;
    public GameObject exitArrow;
    public GameObject message4;
    public GameObject message6;
    public GameObject sewing;
    public GameObject sewingImage;

    [SerializeField] AudioClip clickDoor;
    [SerializeField] AudioClip exit;
    AudioSource audioSource;

    string currentPanelStr = "Room5Copy";
    // Start is called before the first frame update
    void Start()
    {
        HideArrow();
        //HideItem();
        itemBox.SetActive(true);
        audioSource = GetComponent<AudioSource>();
    }

    void HideArrow(){
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
        backArrow.SetActive(false);
    }

    //Room1
    public void OnRoom1Door(){
        HideArrow();
        //panle1を表示
            //ItemBox.instance.UseItem(Item.Type.Key2);
        this.transform.localPosition=new Vector2(-2200,0);
        currentPanelStr = "Room2Panel1";
        rightArrow.SetActive(true);
        audioSource.PlayOneShot(clickDoor);
    }

    //Room2
    public void OnToRoom2Panel1Door(){
        HideArrow();
        //panle3を表示
            this.transform.localPosition=new Vector2(-4400,0);
            currentPanelStr = "Room3Panel1";
            rightArrow.SetActive(true);
            leftArrow.SetActive(true);
            audioSource.PlayOneShot(clickDoor);
    }
    public void OnToRoom2Panel2Door(){
        HideArrow();
        this.transform.localPosition=new Vector2(0,-1600);
        currentPanelStr = "Room1Panel0";
        audioSource.PlayOneShot(clickDoor);
    }

    //Room3
    public void OnRoom3Panel2Door(){
        HideArrow();
        this.transform.localPosition=new Vector2(-2200,1600);
        currentPanelStr = "Room2Panel2";
        leftArrow.SetActive(true);
        audioSource.PlayOneShot(clickDoor);
    }
    public void OnRoom3Panel3Door(){
        HideArrow();
        this.transform.localPosition=new Vector2(-6600,0);
        currentPanelStr = "Room4Panel1";
        leftArrow.SetActive(true);
        audioSource.PlayOneShot(clickDoor);
    }
    public void OnRoom3Panel4Door(){
        HideArrow();
        bool hasItem = ItemBox.instance.CanUseItem(Item.Type.Sewing); //TODO:アイテムBoxにkeyがあるか　=>　ItemとItemBoxをつくる
        if(hasItem == true){
            this.transform.localPosition=new Vector2(-11000,0);
            currentPanelStr = "Room6Panel1";
            backArrow.SetActive(true);
            message4.SetActive(true);
            audioSource.PlayOneShot(clickDoor);
        }
        else
        {
            this.transform.localPosition=new Vector2(-4400,4800);
            currentPanelStr = "Room3Panel4";
            rightArrow.SetActive(true);
            leftArrow.SetActive(true);
        }
    }

    //Room4
    public void OnRoom4Panel1Door(){
        HideArrow();
        //panle1を表示
        this.transform.localPosition=new Vector2(0,0);
        currentPanelStr = "Room5Copy";
        audioSource.PlayOneShot(clickDoor);
    }
    public void OnRoom4Panel2Door(){
        HideArrow();    
        this.transform.localPosition=new Vector2(-4400,0);
        currentPanelStr = "Room3Panel1";
        rightArrow.SetActive(true);
        leftArrow.SetActive(true);
        audioSource.PlayOneShot(clickDoor);
    }
    //Room5
    public void OnRoom5Door(){
        this.transform.localPosition=new Vector2(-6600,1600);
        currentPanelStr = "Room4Panel2";
        rightArrow.SetActive(true);
        audioSource.PlayOneShot(clickDoor);
    }
     //Room6
    public void OnStatu(){
        HideArrow();
        itemBox.SetActive(false);
        this.transform.localPosition=new Vector2(-11000,1600);
        currentPanelStr = "Room6Panel2";
    }
    public void NapkinGameStart(){
        HideArrow();
        if(currentPanelStr == "Room6Panel2"){
            this.transform.localPosition=new Vector2(-13200,3200);
            currentPanelStr = "Room6Image1";
        }
    }
    public void OnClickBackRoom(){
        this.transform.localPosition=new Vector2(-15400,0);
        currentPanelStr = "Room6After";
        exitArrow.SetActive(true);
    } 

    public void ExitArrow(){
        this.transform.localPosition=new Vector2(-15400,1600);
        currentPanelStr = "Slide1";
        audioSource.PlayOneShot(exit);
        message6.SetActive(true);
        exitArrow.SetActive(false);
    }


    public void OnClickSewing(){
        sewing.SetActive(false);
        sewingImage.SetActive(true);
    } 
    public void OnClickSewingPanel(){
        sewingImage.SetActive(false);
    } 

     //Arrows
    public void OnBackArrow(){
        HideArrow();
        if(currentPanelStr == "Room1Panel1"){
            this.transform.localPosition=new Vector2(0,-1600);
            currentPanelStr = "Room1Panel0";
            backArrow.SetActive(false);
        }
        else if(currentPanelStr == "Room2Panel11"){
            this.transform.localPosition=new Vector2(-2200,0);
            currentPanelStr = "Room2Panel1";
            rightArrow.SetActive(true);
        }
        else if(currentPanelStr == "Room4Panel3"){
            this.transform.localPosition=new Vector2(-6600,1600);
            currentPanelStr = "Room4Panel2";
            rightArrow.SetActive(true);
        }
        else if(currentPanelStr == "Room6Panel1"){
            this.transform.localPosition=new Vector2(-4400,4800);
            currentPanelStr = "Room3Panel4";
            rightArrow.SetActive(true);
            leftArrow.SetActive(true);
        }
    }
    public void OnLeftArrow(){
        HideArrow();
        if(currentPanelStr=="Room2Panel2")
        {
            this.transform.localPosition=new Vector2(-2200,0);
            currentPanelStr = "Room2Panel1";
            rightArrow.SetActive(true);
        }
        else if(currentPanelStr=="Room3Panel1"){
            this.transform.localPosition=new Vector2(-4400,3200);
            currentPanelStr = "Room3Panel3";
            rightArrow.SetActive(true);
            leftArrow.SetActive(true);
        }
        else if(currentPanelStr=="Room3Panel2"){
            this.transform.localPosition=new Vector2(-4400,0);
            currentPanelStr = "Room3Panel1";
            rightArrow.SetActive(true);
            leftArrow.SetActive(true);
        }
        else if(currentPanelStr=="Room3Panel3"){
            this.transform.localPosition=new Vector2(-4400,4800);
            currentPanelStr = "Room3Panel4";
            rightArrow.SetActive(true);
            leftArrow.SetActive(true);
        }
        else if(currentPanelStr=="Room3Panel4"){
            this.transform.localPosition=new Vector2(-4400,1600);
            currentPanelStr = "Room3Panel2";
            rightArrow.SetActive(true);
            leftArrow.SetActive(true);
        }
        else if(currentPanelStr=="Room4Panel1"){
            this.transform.localPosition=new Vector2(-6600,1600);
            currentPanelStr = "Room4Panel2";
            rightArrow.SetActive(true);
        }
    }
    public void OnRighttArrow(){
        HideArrow();
        if(currentPanelStr=="Room2Panel1")
        {
            this.transform.localPosition=new Vector2(-2200,1600);
            currentPanelStr = "Room2Panel2";
            leftArrow.SetActive(true);
        }
        else if(currentPanelStr=="Room3Panel1"){
            this.transform.localPosition=new Vector2(-4400,1600);
            currentPanelStr = "Room3Panel2";
            leftArrow.SetActive(true);
            rightArrow.SetActive(true);
        }
        else if(currentPanelStr=="Room3Panel2"){
            this.transform.localPosition=new Vector2(-4400,4800);
            currentPanelStr = "Room3Panel4";
            rightArrow.SetActive(true);
            leftArrow.SetActive(true);
        }
        else if(currentPanelStr=="Room3Panel3"){
            this.transform.localPosition=new Vector2(-4400,0);
            currentPanelStr = "Room3Panel1";
            rightArrow.SetActive(true);
            leftArrow.SetActive(true);
        }
        else if(currentPanelStr=="Room3Panel4"){
            this.transform.localPosition=new Vector2(-4400,3200);
            currentPanelStr = "Room3Panel3";
            rightArrow.SetActive(true);
            leftArrow.SetActive(true);
        }
        else if(currentPanelStr=="Room4Panel2"){
            this.transform.localPosition=new Vector2(-6600,0);
            currentPanelStr = "Room4Panel1";
            leftArrow.SetActive(true);
        }
    }
}
