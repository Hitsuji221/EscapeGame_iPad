using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialLocker : MonoBehaviour
{
    [SerializeField] AudioClip clickButton;
    [SerializeField] AudioClip clear;
    AudioSource audioSource;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    public Image[] buttons;

    public Sprite[] markSources;

    enum Mark{
        Maru = 0,
        Sankaku = 1,
        Hosi = 2,
        Max = 3,
    }
    Mark[] currentMarks = 
    {
        Mark.Maru,
        Mark.Maru,
        Mark.Maru,
    };

    Mark[] clearMarks =
    {
        Mark.Hosi,
        Mark.Maru,
        Mark.Sankaku,
    };

    public UnityEvent ClearedAction;//クリアした時に実行したいことを登録する(外部用)

    public void OnClickButton(int position){
        ChangeMark(position);
        ShowMarkImage(position);
        audioSource.PlayOneShot(clickButton);

        if(IsClear() == true){
           Cleared();
           audioSource.PlayOneShot(clear);
        }
    }

    bool IsClear(){
        if(currentMarks[1] == clearMarks[1]
        && currentMarks[2] == clearMarks[2]
        && currentMarks[0] == clearMarks[0]){
            return true;
        }
        return false;
    }

    void Cleared(){
        Debug.Log("クリアしたよ");
        ClearedAction.Invoke();
    }

    void ChangeMark(int position){
        currentMarks[position]++;
        if(currentMarks[position] >= Mark.Max){
            currentMarks[position] = Mark.Maru;
        }
    }

    void ShowMarkImage(int position){
        buttons[position].sprite = GetSource(currentMarks[position]);
    }
    Sprite GetSource(Mark mark){
        int markIndex = (int)mark;
        return markSources[markIndex];
    }
}