using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeColorName : MonoBehaviour {
    public string c;
    // Use this for initialization

    Color c0 = new Color(235f/255f,97f/255f,32f/255f); // 赤
    Color c1 = new Color(255f/255f,241f/255f,0f/255f); // 黄色
    Color c2 = new Color(4f/255f,175f/255f,122f/255f); // 緑
    Color c3 = new Color(107f/255f,200f/255f,243f/255f); // 空色


    void Start () {
        Color color = GetComponent<Renderer>().material.color;
        

        if(!Scene_Load.is_answer_mode()){
        int n = (int)(Random.Range (0.0f, 6.0f));
        
        
        switch(n){
            case 0:
                color = c0;
                c = "red";
                break;
            case 1:
                color = c1;
                c = "yellow";
                break;
            case 2:
                color = c2;
                c = "green";
                break;
            case 3:
                color = c3;
                c = "blue";
                break;
            default:
                color = Color.clear;
                c = "clear";
                break;

        }
        }
        GetComponent<Renderer>().material.color = color;
        //print(n);


    }
    // Update is called once per frame
    void Update () {

    }
    public class Getcolor{
        private string c;
        public Getcolor(string c){
            this.c = c;
        }
    }
}