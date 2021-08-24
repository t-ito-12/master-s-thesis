using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGetColor : MonoBehaviour
{
    GameObject[] cube = new GameObject[8];
    ChangeColorName[] script = new ChangeColorName[8];
    // Start is called before the first frame update
    void Start()
    {   
        cube[0] = GameObject.Find("Cube0");
        cube[1] = GameObject.Find("Cube1");
        cube[2] = GameObject.Find("Cube2");
        cube[3] = GameObject.Find("Cube3");
        cube[4] = GameObject.Find("Cube4");
        cube[5] = GameObject.Find("Cube5");
        cube[6] = GameObject.Find("Cube6");
        cube[7] = GameObject.Find("Cube7");

        for(int i=0;i<8;i++) script[i] = cube[i].GetComponent<ChangeColorName>();
    
    }

    // Update is called once per frame
    void Update()
    {   
        //for(int i=0;i<8;i++) Debug.Log("Cube"+i+"は"+script[i].c);
    }
}
