using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingNapkin : MonoBehaviour
{
    public GameObject pen;
    public GameObject hasami;
    public GameObject mishin;
    public GameObject selectpen;
    public GameObject selecthasami;
    public GameObject selectmishin;
    public static MakingNapkin instance;
    [SerializeField] GameObject answerisno;
    [SerializeField] GameObject answerpanel;
    public GameObject kizi;
    public GameObject pori;
    public GameObject cotton;
    public GameObject kizi2;
    public GameObject pori2;
    public GameObject cotton2;
    public GameObject mkizi1;
    public GameObject mkizi2;
    public GameObject mkizi3;
    public GameObject message1;
    public GameObject message2;
    public GameObject message3;
    public GameObject toolBox;

    public GameObject rightArrow;
    string currentPanelStr = "Image1";

    void Start(){
        answerisno.SetActive(false);
        answerpanel.SetActive(false);
        toolBox.SetActive(false);
        message1.SetActive(false);
        message2.SetActive(false);
        rightArrow.SetActive(false);
    }

    void HideSelect(){
        selectpen.SetActive(false);
        selecthasami.SetActive(false);
        selectmishin.SetActive(false);
    }

    public void OnClickStart(){
        toolBox.SetActive(true);
        this.transform.localPosition=new Vector2(-11000,3200);
        currentPanelStr = "Image1";
    }
    public void OnClickPen(){
        HideSelect();
        selectpen.SetActive(true);
        if(currentPanelStr == "Image1"){ //Panel0のstomacgirlを表示
            this.transform.localPosition=new Vector2(-11000,4800);
            currentPanelStr = "Image11";
            OnClickCorrectOne();
        }else if(currentPanelStr == "Image11" && (kizi.activeSelf == false || pori.activeSelf == false || cotton.activeSelf == false)){
            OnClickCorrectOne();
        }else if(currentPanelStr == "Image6"){
            this.transform.localPosition=new Vector2(-13200,4800);
            currentPanelStr = "Image61";
            OnClickCorrectOne();
        }else if(currentPanelStr == "Image4"||currentPanelStr == "Image0"){
            OnClickCorrectOne();   
        }else if(currentPanelStr == "Image61" && (mkizi1.activeSelf == false)){
            OnClickCorrectOne();
        }else{
            OnClickOtherOne();
        }
    }
     public void OnClickHasami(){
        HideSelect();
        selecthasami.SetActive(true);
        if(currentPanelStr == "Image11"&& (kizi.activeSelf == true && pori.activeSelf == true && cotton.activeSelf == true)){ //Panel0のstomacgirlを表示
            this.transform.localPosition=new Vector2(-11000,6400);
            currentPanelStr = "Image21";
            OnClickCorrectOne();
        }else if(currentPanelStr == "Image21" && (kizi2.activeSelf == false || pori2.activeSelf == false || cotton2.activeSelf == false)){
            OnClickCorrectOne();
        }else if(currentPanelStr == "Image61"&& (mkizi1.activeSelf == true)){
            this.transform.localPosition=new Vector2(-13200,6400);
            currentPanelStr = "Image62";
            OnClickCorrectOne();
        }else if(currentPanelStr == "Image62" && (mkizi2.activeSelf == false)){
            OnClickCorrectOne();
        }else if(currentPanelStr == "Image4"||currentPanelStr == "Image0"){
            OnClickCorrectOne();
        }else{        
            OnClickOtherOne();
        }
    }
     public void OnClickMishin(){
        HideSelect();
        selectmishin.SetActive(true);
        if(currentPanelStr == "Image21" && kizi2.activeSelf == true && pori2.activeSelf == true && cotton2.activeSelf == true ){ //Panel0のstomacgirlを表示
            this.transform.localPosition=new Vector2(-11000,8000);
            currentPanelStr = "Image41";
            OnClickCorrectOne();
        }else if(currentPanelStr == "Image62"&& (mkizi2.activeSelf == true)){
            this.transform.localPosition=new Vector2(-13200,8000);
            currentPanelStr = "Image63";
            OnClickCorrectOne();
        }else if(currentPanelStr == "Image63" && (mkizi3.activeSelf == false)){
            OnClickCorrectOne();
        }else if(currentPanelStr == "Image41"||currentPanelStr == "Image0" ||currentPanelStr == "Image4"){
            OnClickCorrectOne();
        }else{
            OnClickOtherOne();
        }
    }
    void OnClickOtherOne(){
        answerisno.SetActive(true);
        answerpanel.SetActive(true);
    }
    void OnClickCorrectOne(){
        answerisno.SetActive(false);
        answerpanel.SetActive(false);
    }
    public void OnClickMiss(){
        answerisno.SetActive(false);
        answerpanel.SetActive(false);
    }
    public void OnClickPanel(){
        this.transform.localPosition=new Vector2(-11000,9600);
        currentPanelStr = "Image4";
        toolBox.SetActive(false);
        rightArrow.SetActive(true);
        OnClickCorrectOne();
    }
    public void OnClickNapkin(){
        if(currentPanelStr == "Image4"){
            this.transform.localPosition=new Vector2(-13200,1600);
            currentPanelStr = "Image5";
            toolBox.SetActive(false);
            message1.SetActive(true);
            OnClickCorrectOne();
            rightArrow.SetActive(false);
        }
    }
    public void OnClickGameStart2(){
        this.transform.localPosition=new Vector2(-13200,3200);
        currentPanelStr = "Image6";
        toolBox.SetActive(true);
        HideSelect();
        OnClickCorrectOne();
    }
    public void OnClickMawashi(){
        if(currentPanelStr == "Image63"){
            this.transform.localPosition=new Vector2(-13200,9600);
            currentPanelStr = "Image7";
            toolBox.SetActive(false);
            message2.SetActive(true);
            OnClickCorrectOne();
            rightArrow.SetActive(false);
        }
    }
    public void OnClickGattai(){
        this.transform.localPosition=new Vector2(-13200,11200);
        currentPanelStr = "Image71";
        toolBox.SetActive(false);
        rightArrow.SetActive(true);
        OnClickCorrectOne();
    }
    public void OnClickNapMaw(){
        if(currentPanelStr == "Image71"){
            message3.SetActive(true);
            rightArrow.SetActive(false);
        }
    }
    public void OnClickBackRoom(){
        this.transform.localPosition=new Vector2(-15400,0);
        currentPanelStr = "Room6After";
    }
}