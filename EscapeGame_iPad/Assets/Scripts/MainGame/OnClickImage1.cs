using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickImage1 : MonoBehaviour
{
   public static OnClickImage1 instance;
    public GameObject kizi;
    public GameObject kizi2;
    public GameObject pori;
    public GameObject pori2;
    public GameObject cotton;
    public GameObject cotton2;
    //イメージをクリックしたら、イメージを切り替える

    void Start(){
        kizi.SetActive(true);
        pori.SetActive(true);
        cotton.SetActive(true);
        kizi2.SetActive(false);
        pori2.SetActive(false);
        cotton2.SetActive(false);
    }
    public void OnKizi(){
        kizi.SetActive(false);
        kizi2.SetActive(true);
    }
    public void OnPori(){
        pori.SetActive(false);
        pori2.SetActive(true);
    }
    public void OnCotton(){
        cotton.SetActive(false);
        cotton2.SetActive(true);
    }
}
