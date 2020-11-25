using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    string currentPanelStr = "GameSlide2";
    public GameObject Slide1;
    public GameObject message6;
    [SerializeField] AudioClip correct;
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartButton(){
    this.transform.localPosition = new Vector2(-4400,8000);
    currentPanelStr = "GameSlide2";
    Slide1.SetActive(false);
    }
    public void Answer(){
    this.transform.localPosition = new Vector2(-4400,9600);
    currentPanelStr = "GameSlide3";
    audioSource.PlayOneShot(correct);
    }
    public void NextButton(){
    this.transform.localPosition = new Vector2(-4400,11200);
    currentPanelStr = "GameSlide4";
    message6.SetActive(true);
    }
    public void BackRoom3(){
        this.transform.localPosition = new Vector2(-4400,0);
        currentPanelStr = "Room3Panel1";
    }
}