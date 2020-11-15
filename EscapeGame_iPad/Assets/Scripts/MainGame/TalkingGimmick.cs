using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingGimmick : MonoBehaviour
{
    public static TalkingGimmick instance;
    [SerializeField] GameObject Hukidashi1Image;
    [SerializeField] GameObject Talking1Text;
    [SerializeField] GameObject Hukidashi2Image;
    [SerializeField] GameObject Talking2Text;
    [SerializeField] GameObject HaraitaImage;
    [SerializeField] GameObject NotHaraitaImage;
    [SerializeField] GameObject selectedWater;

    // Start is called before the first frame update
    void Start()
    {
        Hukidashi1Image.SetActive(true);
        Talking1Text.SetActive(true);
        HaraitaImage.SetActive(true);
        Hukidashi2Image.SetActive(false);
        Talking2Text.SetActive(false);
        NotHaraitaImage.SetActive(false);
    }

    public void OnClick(){
        if(selectedWater.activeSelf){
            bool getItem = ItemBox.instance.CanUseItem(Item.Type.Water); //TODO:アイテムBoxにペットボトルがあるか　=>　ItemとItemBoxをつくる
            if(getItem== true){
                Hukidashi1Image.SetActive(false);
                Talking1Text.SetActive(false);
                HaraitaImage.SetActive(false);
                Hukidashi2Image.SetActive(true);
                Talking2Text.SetActive(true);
                NotHaraitaImage.SetActive(true);
            }
        }
   }
}
