using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//テキストデータを二次元配列に変換
public class StageManager : MonoBehaviour
{

    [SerializeField] AudioClip tileAudio;
    [SerializeField] AudioClip clearAudio;
    AudioSource audioSource;
    public TextAsset stageFile;
    Tiletype[,] tileTable;

    public TileManager tilePrefab;
    TileManager[,] tileTableObj;

     public UnityEvent ClearedAction;//クリアした時に実行したいことを登録する(外部用)

    void Start()
    {
        LoadStageFromText();
        CreateStage();
        audioSource = GetComponent<AudioSource>();
    }

    void CreateStage(){

        Vector2 centerPosition;
        float tileSize=tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        centerPosition.x=tileSize*(tileTable.GetLength(0)/2);
        centerPosition.y=tileSize*(tileTable.GetLength(1)/2);

        for(int y=0;y<tileTable.GetLength(1);y++){
            for(int x=0;x<tileTable.GetLength(0);x++){
                TileManager tile=Instantiate(tilePrefab);
                Vector2Int position=new Vector2Int(x,y);
                tile.SetInit(tileTable[x,y],position,this);
                Vector2 setPosition=(Vector2)position*tileSize-centerPosition;
                setPosition.y*=-1;
                tile.transform.position=setPosition;
                tileTableObj[x,y]=tile;
            }
        }
    }

    void LoadStageFromText()
    {
        string[] lines=stageFile.text.Split(new[] {'\n','\r'}, System.StringSplitOptions.RemoveEmptyEntries);
        int columns=3;
        int rows=3;

        tileTable=new Tiletype[columns,rows];
        tileTableObj=new TileManager[columns,rows];
        for(int y=0;y<rows;y++){
            string[] values=lines[y].Split(new[] {','});
            for(int x=0;x<columns;x++){
                if(values[x]=="0"){
                    tileTable[x,y]=Tiletype.BLACK;
                }else if(values[x]=="11"){
                    tileTable[x,y]=Tiletype.WHITE;
                }
            }
        }
    }

    public void ClickedTile(Vector2Int center){
        ReverseTiles(center);
        audioSource.PlayOneShot(tileAudio);
        if(IsClear() == true){
            //クリアした後の処理
            Cleared();
            ResetStage();
            audioSource.PlayOneShot(clearAudio);
        }
    }
    void Cleared(){
        Debug.Log("クリアしたよ");
        ClearedAction.Invoke();
    }

    void ReverseTiles(Vector2Int center){
        Vector2Int[] around={
            center+Vector2Int.up,
            center+Vector2Int.down,
            center+Vector2Int.right,
            center+Vector2Int.left,
        };
        foreach(Vector2Int position in around){
            if(position.x<0||tileTableObj.GetLength(0)<=position.x){
                continue;
            }
            if(position.y<0||tileTableObj.GetLength(1)<=position.y){
                continue;
            }
            tileTableObj[position.x,position.y].ReverseTile();
        }
    }

    bool IsClear(){
        for(int y=0;y<tileTableObj.GetLength(1);y++){
            for(int x=0;x<tileTableObj.GetLength(0);x++){
                if(tileTableObj[x,y].type==Tiletype.BLACK){
                    return false;
                }
            }
        }
        return true;
    }
    void ResetStage(){
        for(int y=0;y<tileTableObj.GetLength(1);y++){
            for(int x=0;x<tileTableObj.GetLength(0);x++){
                Destroy(tileTableObj[x,y].gameObject);
                }
            }
        CreateStage();
    }
}