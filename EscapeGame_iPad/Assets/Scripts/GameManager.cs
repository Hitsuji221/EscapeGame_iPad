using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // パネル取得
    public GameObject doorPanel;
    // ボタンを押したら該当するパネルを表示
    public void OnClickDoorTrigger()
    {
        doorPanel.SetActive(true);

    }
}
