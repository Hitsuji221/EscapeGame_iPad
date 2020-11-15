using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pText : MonoBehaviour
{
  
  public GameObject it;
  Transform oya;
  public GameObject can;
    void Start()
    { 
      oya = can.transform;
      it.transform.SetParent(oya); 
    }
}