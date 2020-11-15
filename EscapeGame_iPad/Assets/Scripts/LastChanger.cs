using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastChanger : MonoBehaviour
{
    public GameObject backArrow;
    string currentPanelStr = "Panel0";
    void Start()
    {
        backArrow.SetActive(true);
    }
    public void OnBackArrow(){
        backArrow.SetActive(false);

        this.transform.localPosition=new Vector2(-1200,0);
        currentPanelStr = "Panel1";
    }
}
