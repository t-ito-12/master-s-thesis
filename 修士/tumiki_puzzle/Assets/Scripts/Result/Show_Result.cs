using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Show_Result : MonoBehaviour
{   
    public string[] marubatu = new string[10];

    // Start is called before the first frame update
    void Start()
    {
        Text result_text = this.GetComponent<Text>();
        for(int i = 0; i < 10; i++){
            if(Scene_Load.isseikai(i)) marubatu[i] = "○";
            else marubatu[i] = "×";
            result_text.text += marubatu[i] + "\n";
        }
        Scene_Load.answer_mode_on();
    }

    public void onClick_b0(){
        Scene_Load.set_mondai_num(0);
        SceneManager.LoadScene(Scene_Load.get_mondai_name());
    }
    public void onClick_b1(){
        Scene_Load.set_mondai_num(1);
        SceneManager.LoadScene(Scene_Load.get_mondai_name());
    }
    public void onClick_b2(){
        Scene_Load.set_mondai_num(2);
        SceneManager.LoadScene(Scene_Load.get_mondai_name());
    }
    public void onClick_b3(){
        Scene_Load.set_mondai_num(3);
        SceneManager.LoadScene(Scene_Load.get_mondai_name());
    }
    public void onClick_b4(){
        Scene_Load.set_mondai_num(4);
        SceneManager.LoadScene(Scene_Load.get_mondai_name());
    }
    public void onClick_b5(){
        Scene_Load.set_mondai_num(5);
        SceneManager.LoadScene(Scene_Load.get_mondai_name());
    }
    public void onClick_b6(){
        Scene_Load.set_mondai_num(6);
        SceneManager.LoadScene(Scene_Load.get_mondai_name());
    }
    public void onClick_b7(){
        Scene_Load.set_mondai_num(7);
        SceneManager.LoadScene(Scene_Load.get_mondai_name());
    }
    public void onClick_b8(){
        Scene_Load.set_mondai_num(8);
        SceneManager.LoadScene(Scene_Load.get_mondai_name());
    }
    public void onClick_b9(){
        Scene_Load.set_mondai_num(9);
        SceneManager.LoadScene(Scene_Load.get_mondai_name());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
