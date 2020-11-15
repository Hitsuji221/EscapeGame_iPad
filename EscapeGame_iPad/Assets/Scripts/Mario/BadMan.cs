using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMan : MonoBehaviour
{
    [SerializeField] GameObject BadNapukin;
    [SerializeField] GameObject BadFukidashi;
    // Start is called before the first frame update

    public void OnClick()
    {
        BadNapukin.SetActive(true);
        Destroy(this.gameObject);
        Destroy(BadFukidashi);
    }
}
