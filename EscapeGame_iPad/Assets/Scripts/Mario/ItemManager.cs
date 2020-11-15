using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    GameManage gameManage;
    [SerializeField] GameObject Check1;
    [SerializeField] GameObject Check2;
    [SerializeField] GameObject Check3;


    private void Start()
    {
        gameManage = GameObject.Find("GameManager").GetComponent<GameManage>();
    }
    public void GetZoukin()
    {
        gameManage.ReduceScore(30);
        Destroy(this.gameObject);
    }
    public void GetShinbun()
    {
        gameManage.ReduceScore(20);
        Destroy(this.gameObject);
    }
    public void GetBadNapukin()
    {
        gameManage.ReduceScore(10);
        Destroy(this.gameObject);
    }
    public void GetTowel()
    {
        Check1.SetActive(true);
        Destroy(this.gameObject);
    }
    public void GetHandkerchief()
    {
        Check2.SetActive(true);
        Destroy(this.gameObject);
    }
    public void GetNapkin()
    {
        Check3.SetActive(true);
        Destroy(this.gameObject);
    }
}
