using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //種類がある：列挙型
public class Item : MonoBehaviour
{

    //クリックしたときに、アイテムボックスに格納され、非表示になる
    //タイミング：クリックしたとき
    //処理：アイテムボックスに格納され、非表示になる
    public enum Type{
        Map=0,
        Key=1,
        Water=2,
        Key2=3,
        Sewing=4
    }

    public Type type;
    //タイミング：クリックしたとき
    public void OnThis(){
        ItemBox.instance.SetItem(type); //アイテムボックスに格納する
        gameObject.SetActive(false);
        Debug.Log(type+"を取得");
    }
}
