using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGetCubeColor : MonoBehaviour
{   
    GameObject[] cube = new GameObject[8];
    Color[] cube_color = new Color[8];

    // Start is called before the first frame update
    void Start()
    {
        float n = Random.Range(0.0f, 1.0f);
        if(n < 0.5f){
            cube[0] = GameObject.Find("Cube0_0");
            cube[1] = GameObject.Find("Cube0_1");
            cube[2] = GameObject.Find("Cube0_2");
            cube[3] = GameObject.Find("Cube0_3");
            cube[4] = GameObject.Find("Cube0_4");
            cube[5] = GameObject.Find("Cube0_5");
            cube[6] = GameObject.Find("Cube0_6");
            cube[7] = GameObject.Find("Cube0_7");
        }else{
            cube[0] = GameObject.Find("Cube1_0");
            cube[1] = GameObject.Find("Cube1_1");
            cube[2] = GameObject.Find("Cube1_2");
            cube[3] = GameObject.Find("Cube1_3");
            cube[4] = GameObject.Find("Cube1_4");
            cube[5] = GameObject.Find("Cube1_5");
            cube[6] = GameObject.Find("Cube1_6");
            cube[7] = GameObject.Find("Cube1_7");
        }
        for(int i = 0; i < 8; i++) /*cube_color[i] =*/ print(cube[i].GetComponent<Renderer>().material.color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
