using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Preparation : MonoBehaviour
{   
    public bool done_ans;
    public GameObject maru;
    public GameObject batu;
    public GameObject next_button;
    public GameObject Slider0;
    public GameObject Slider1;
    public GameObject Slider2;
    public GameObject exSlider0;
    public GameObject exSlider1;
    public GameObject exSlider2;
    public GameObject AmBb;
    public GameObject AbBm;
    public GameObject Howtoimage;

    public float choice;


    Color c0 = new Color(235f/255f,97f/255f,32f/255f); // 赤
    Color c1 = new Color(255f/255f,241f/255f,0f/255f); // 黄色
    Color c2 = new Color(4f/255f,175f/255f,122f/255f); // 緑
    Color c3 = new Color(107f/255f,200f/255f,243f/255f); // 空色

    //色を仮置きするCube
    Color[] prev_cube = new Color[8];
    Color[] next_cube = new Color[8];

    GameObject[] cube0 = new GameObject[8];
    GameObject[] cube1 = new GameObject[8];
    GameObject[] cube2 = new GameObject[8];


    // Start is called before the first frame update
    void Start()
    {
        cube0[0] = GameObject.Find("Cube0_0");
        cube0[1] = GameObject.Find("Cube0_1");
        cube0[2] = GameObject.Find("Cube0_2");
        cube0[3] = GameObject.Find("Cube0_3");
        cube0[4] = GameObject.Find("Cube0_4");
        cube0[5] = GameObject.Find("Cube0_5");
        cube0[6] = GameObject.Find("Cube0_6");
        cube0[7] = GameObject.Find("Cube0_7");

        cube1[0] = GameObject.Find("Cube1_0");
        cube1[1] = GameObject.Find("Cube1_1");
        cube1[2] = GameObject.Find("Cube1_2");
        cube1[3] = GameObject.Find("Cube1_3");
        cube1[4] = GameObject.Find("Cube1_4");
        cube1[5] = GameObject.Find("Cube1_5");
        cube1[6] = GameObject.Find("Cube1_6");
        cube1[7] = GameObject.Find("Cube1_7");

        cube2[0] = GameObject.Find("Cube2_0");
        cube2[1] = GameObject.Find("Cube2_1");
        cube2[2] = GameObject.Find("Cube2_2");
        cube2[3] = GameObject.Find("Cube2_3");
        cube2[4] = GameObject.Find("Cube2_4");
        cube2[5] = GameObject.Find("Cube2_5");
        cube2[6] = GameObject.Find("Cube2_6");
        cube2[7] = GameObject.Find("Cube2_7");

        // 回答済みかどうか
        done_ans = false;
        Color color;
        // Main Cubes に色を設定
        if(Scene_Load.is_answer_mode()) Scene_Load.get_mondai3_cube0_color(Scene_Load.get_mondai_num(), cube0);
        else{
                

                for(int i = 0; i < 8; i++){
                    int n = (int)(Random.Range (0.0f, 6.0f));
                    switch(n){
                        case 0:
                            color = c0;
                            break;
                        case 1:
                            color = c1;
                            break;
                        case 2:
                            color = c2;
                            break;
                        case 3:
                            color = c3;
                            break;
                        default:
                            color = Color.clear;
                            break;
                    }
                    cube0[i].GetComponent<Renderer>().material.color = color;
                    prev_cube[i] = color;
                }
            }

            // どちらかのcubeに複製しランダムに回転
            choice = Random.Range(0.0f, 1.0f);
            if(Scene_Load.is_answer_mode()) choice = Scene_Load.get_mondai3_choice(Scene_Load.get_mondai_num());
            else{
            float Rotate_v = Random.Range(0.0f, 4.0f);
            float Rotate_h = Random.Range(0.0f, 4.0f);
            int numv, numh;
            
            // 回転しないことを防止
            while(Rotate_h < 1.0f && Rotate_v < 1.0f){
                Rotate_v = Random.Range(0.0f, 4.0f);
                Rotate_h = Random.Range(0.0f, 4.0f);
            }

            if(Rotate_v < 1.0f) numv = 0;
            else if(Rotate_v < 2.0f) numv = 1;
            else if(Rotate_v < 3.0f) numv = 2;
            else numv = 3;

            if(Rotate_h < 1.0f) numh = 0;
            else if(Rotate_h < 2.0f) numh = 1;
            else if(Rotate_h < 3.0f) numh = 2;
            else numh = 3;
            
            // v 回転
            for(int i = 0; i < numv; i++){
                next_cube[0] = prev_cube[2];
                next_cube[1] = prev_cube[3];
                next_cube[2] = prev_cube[6];
                next_cube[3] = prev_cube[7];
                next_cube[4] = prev_cube[0];
                next_cube[5] = prev_cube[1];
                next_cube[6] = prev_cube[4];
                next_cube[7] = prev_cube[5];
                for(int j = 0; j < 8; j++){
                    prev_cube[j] = next_cube[j];
                }
            }
            
            // h 回転
            for(int i = 0; i < numh; i++){
                next_cube[0] = prev_cube[1];
                next_cube[1] = prev_cube[3];
                next_cube[2] = prev_cube[0];
                next_cube[3] = prev_cube[2];
                next_cube[4] = prev_cube[5];
                next_cube[5] = prev_cube[7];
                next_cube[6] = prev_cube[4];
                next_cube[7] = prev_cube[6];
                for(int j = 0; j < 8; j++){
                    prev_cube[j] = next_cube[j];
                }
            }
        }
 
        // cube1のとき
        if(choice < 0.5f){
            // cubeに色をセット
            if(Scene_Load.is_answer_mode()){
                Scene_Load.get_mondai3_cube1_color(Scene_Load.get_mondai_num(), cube1);
                Scene_Load.get_mondai3_cube2_color(Scene_Load.get_mondai_num(), cube2);
            }else{
                for(int i = 0; i < 8; i++){
                    cube1[i].GetComponent<Renderer>().material.color = next_cube[i];

                    // ダミーに色を設定
                    int n = (int)(Random.Range (0.0f, 6.0f));
                    switch(n){
                        case 0:
                            color = c0;
                            break;
                        case 1:
                            color = c1;
                            break;
                        case 2:
                            color = c2;
                            break;
                        case 3:
                            color = c3;
                            break;
                        default:
                            color = Color.clear;
                            break;
                    }
                    cube2[i].GetComponent<Renderer>().material.color = color;

                }
            }


        }else{
            // cubeに色をセット
            if(Scene_Load.is_answer_mode()){
                Scene_Load.get_mondai3_cube1_color(Scene_Load.get_mondai_num(), cube1);
                Scene_Load.get_mondai3_cube2_color(Scene_Load.get_mondai_num(), cube2);
            }else{
                for(int i = 0; i < 8; i++){
                    cube2[i].GetComponent<Renderer>().material.color = next_cube[i];

                    // ダミーに色を設定
                    int n = (int)(Random.Range (0.0f, 6.0f));
                    switch(n){
                        case 0:
                            color = c0;
                            break;
                        case 1:
                            color = c1;
                            break;
                        case 2:
                            color = c2;
                            break;
                        case 3:
                            color = c3;
                            break;
                        default:
                            color = Color.clear;
                            break;
                    }
                    cube1[i].GetComponent<Renderer>().material.color = color;
                }
            }

        }
        // 見直しモードのセット
        if(!Scene_Load.is_answer_mode()){
            Scene_Load.set_mondai3_choice(Scene_Load.get_mondai_num(), choice);
            Scene_Load.set_mondai3_cube0_color(Scene_Load.get_mondai_num(), cube0);
            Scene_Load.set_mondai3_cube1_color(Scene_Load.get_mondai_num(), cube1);
            Scene_Load.set_mondai3_cube2_color(Scene_Load.get_mondai_num(), cube2);
        }




    }
    public void onClick_back(){
        SceneManager.LoadScene("Title");
    }
    public void onClick_Howto(){
        Howtoimage.SetActive(true);
    }
    public void onClick_endHowto(){
        Howtoimage.SetActive(false);
    }
    public void onclick_next(){
        // 10問終わったら or 見直しモードのとき問題終了
        if(Scene_Load.get_mondai_num() > 9 || Scene_Load.is_answer_mode()) SceneManager.LoadScene("Result");
        else SceneManager.LoadScene("mondai03");
    }
    public void onClick_A(){
        if(choice < 0.5f){
            if(done_ans){

            }else{
                // 正解
                done_ans = true;
                maru.SetActive(true);
                next_button.SetActive(true);
                Slider0.SetActive(false);
                Slider1.SetActive(false);
                Slider2.SetActive(false);
                exSlider0.SetActive(true);
                exSlider1.SetActive(true);
                exSlider2.SetActive(true);
                AmBb.SetActive(true);
                if(!Scene_Load.is_answer_mode()){
                    Scene_Load.seikai(Scene_Load.get_mondai_num());
                    Scene_Load.add_mondai_num();
                    Scene_Load.add_point();
                }
            }
        }else{
            if(done_ans){

            }else{
                done_ans = true;
                batu.SetActive(true);
                next_button.SetActive(true);
                Slider0.SetActive(false);
                Slider1.SetActive(false);
                Slider2.SetActive(false);
                exSlider0.SetActive(true);
                exSlider1.SetActive(true);
                exSlider2.SetActive(true);
                AbBm.SetActive(true);
                if(!Scene_Load.is_answer_mode()) Scene_Load.add_mondai_num();
            }
        }
    }
    public void onClick_B(){
        if(choice < 0.5f){
            if(done_ans){

            }else{
                done_ans = true;
                batu.SetActive(true);
                next_button.SetActive(true);
                Slider0.SetActive(false);
                Slider1.SetActive(false);
                Slider2.SetActive(false);
                exSlider0.SetActive(true);
                exSlider1.SetActive(true);
                exSlider2.SetActive(true);
                AmBb.SetActive(true);
                if(!Scene_Load.is_answer_mode()) Scene_Load.add_mondai_num();
            }
        }else{
            if(done_ans){

            }else{
                // 正解
                done_ans = true;
                maru.SetActive(true);
                next_button.SetActive(true);
                Slider0.SetActive(false);
                Slider1.SetActive(false);
                Slider2.SetActive(false);
                exSlider0.SetActive(true);
                exSlider1.SetActive(true);
                exSlider2.SetActive(true);
                AbBm.SetActive(true);
                if(!Scene_Load.is_answer_mode()){
                    Scene_Load.seikai(Scene_Load.get_mondai_num());
                    Scene_Load.add_mondai_num();
                    Scene_Load.add_point();
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
