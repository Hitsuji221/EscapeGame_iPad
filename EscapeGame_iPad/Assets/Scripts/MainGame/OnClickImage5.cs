using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickImage5 : MonoBehaviour
{
    public static OnClickImage5 instance;
    public GameObject mkizi;
    public GameObject mkizi2;
    public GameObject toolBox;
    public GameObject rightArrow;
    [SerializeField] AudioClip complete;
    AudioSource audioSource;

    void Start(){
        mkizi.SetActive(true);
        mkizi2.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }
    public void OnKizi(){
        mkizi.SetActive(false);
        mkizi2.SetActive(true);
        toolBox.SetActive(false);
        rightArrow.SetActive(true);
        audioSource.PlayOneShot(complete);
    }
}
