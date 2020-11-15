using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonManager : MonoBehaviour
{
    bool forwardmove;
    bool backmove;
    bool rightmove;
    bool leftmove;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (forwardmove == true)
        {
            transform.position += new Vector3(0, 0, 1 * Time.deltaTime);
        }
        if (backmove == true)
        {
            transform.position += new Vector3(0, 0, -1 * Time.deltaTime);
        }
        if (rightmove == true)
        {
            transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
        }
        if (leftmove == true)
        {
            transform.position += new Vector3(-1 * Time.deltaTime, 0, 0);
        }
    }
    public void forwardButtonDown()
    {
        forwardmove = true;
    }
    public void forwardButtonUp()
    {
        forwardmove = false;
    }
    public void backButtonDown()
    {
        backmove = true;
    }
    public void backButtonUp()
    {
        backmove = false;
    }
    public void rightButtonDown()
    {
        rightmove = true;
    }
    public void rightButtonUp()
    {
        rightmove = false;
    }
    public void leftButtonDown()
    {
        leftmove = true;
    }
    public void leftButtonUp()
    {
        leftmove = false;
    }
}
