using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickImage4 : MonoBehaviour
{
    public static OnClickImage4 instance;
    public GameObject mkizi;
    public GameObject mkizi2;
    void Start(){
        mkizi.SetActive(true);
        mkizi2.SetActive(false);
    }
    public void OnKizi(){
        mkizi.SetActive(false);
        mkizi2.SetActive(true);
    }
}
