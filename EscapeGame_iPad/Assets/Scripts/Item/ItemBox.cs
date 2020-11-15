using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
   // public GameObject box0;
    public GameObject[] boxs;
    //処理
    //TODO:ボックスにアイテムボックスに格納する：画像を表示させる
    //特定のアイテムを持っているかどうかを調べる
    //アイテムを使用する：画像を非表示にする

    //static化して、どのファイルからでも参照できるようにする
    public static ItemBox instance;
    private void Awake(){
        instance = this;
    }

    public void SetItem(Item.Type type){
        int index=(int)type;
        boxs[index].SetActive(true);
    }
    public bool CanUseItem(Item.Type type){
        //アイテムを使えるかどうかは表示されているかどうか分かればいい
        //表示差ているかどうかは、activeSelfを使えばいい
        int index=(int)type;
        return boxs[index].activeSelf;
        return false;
    }
    public void UseItem(Item.Type type){
        int index=(int)type;
        boxs[index].SetActive(false);
    }
}
