using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tiletype
{
    BLACK,
    WHITE,
}

public class TileManager : MonoBehaviour
{
    public Tiletype type;
    public Sprite blackSprite;
    public Sprite whiteSprite;
    

    SpriteRenderer spriteRenderer;

    StageManager stageManager;
    Vector2Int intPosition;
    
    void Awake()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    public void SetInit(Tiletype tiletype,Vector2Int position,StageManager stageManager){
        intPosition=position;
        this.stageManager=stageManager;
        SetType(tiletype);
    }

    void SetType(Tiletype tiletype){
        type=tiletype;
        SetImage(type);
    }

    void SetImage(Tiletype type){
        if(type==Tiletype.BLACK){
            spriteRenderer.sprite=blackSprite;
        }else if(type==Tiletype.WHITE){
            spriteRenderer.sprite=whiteSprite;
        }
    }

    public void OnTile(){
        ReverseTile();
        stageManager.ClickedTile(intPosition);
    }

    public void ReverseTile(){
        if(type==Tiletype.BLACK){
            SetType(Tiletype.WHITE);
        }else if(type==Tiletype.WHITE){
            SetType(Tiletype.BLACK);
        }
    }
}