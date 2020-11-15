using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomacGirl : MonoBehaviour
{
    [SerializeField] GameObject keyImage;
    [SerializeField] GameObject alert2Text;
    [SerializeField] GameObject stomacImage;
    [SerializeField] GameObject selectedWater;
    [SerializeField] AudioClip itemaudio;
    AudioSource audioSource;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    //クリックしたときに、Playerがwaterを持っていれば、新たなアイテムをゲットする
    //タイミング：クリックしたとき
    //処理：新たなアイテムを手に入れる
    //条件:アイテムを持っているとき
    public void OnClickWater(){
            selectedWater.SetActive(true);
    }
    public void OnClickSelected(){
        if(selectedWater.activeSelf){
            selectedWater.SetActive(false);
        }
    }
    public void OnClick(){
        if(selectedWater.activeSelf){
            bool hasItem = ItemBox.instance.CanUseItem(Item.Type.Water); //TODO:アイテムBoxにペットボトルがあるか　=>　ItemとItemBoxをつくる
            if(hasItem== true){ //アイテムを持っていれば
                //アイテムを使う
                ItemBox.instance.UseItem(Item.Type.Water); 
                //処理：新たなアイテムゲット
                keyImage.SetActive(true);
                alert2Text.SetActive(true);
                ItemBox.instance.SetItem(Item.Type.Key2);            
                Debug.Log(Item.Type.Key2+"を取得");
                //ボトルの選択イメージを消す
                selectedWater.SetActive(false);
                
                bool hasItem2 = ItemBox.instance.CanUseItem(Item.Type.Key2); //TODO:アイテムBoxにペットボトルがあるか　=>　ItemとItemBoxをつくる
                if(hasItem2== true){   
                    stomacImage.SetActive(false);
                }
            }
        }
    }
    public void OnClickImage(){
        keyImage.SetActive(false);
        alert2Text.SetActive(false);
        audioSource.PlayOneShot(itemaudio);
    }
}
