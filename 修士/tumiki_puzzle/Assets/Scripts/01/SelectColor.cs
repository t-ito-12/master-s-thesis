using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class SelectColor : MonoBehaviour
{   
    public bool done_ans;
    public Color now_color;
    public GameObject maru;
    public GameObject batu;
    public GameObject next_button;
    public GameObject answers;
    public GameObject howto;
    public Color[] ans_col = new Color[4];
    public GameObject[] ans = new GameObject[4];
    public GameObject xSlider;
    public GameObject ySlider;
    public GameObject ex_xSlider;
    public GameObject ex_ySlider;


    GameObject[] cb = new GameObject[4];
    Color[] c = new Color[4];

    GameObject[] cp = new GameObject[4];
    Color[] bc = new Color[4];

    GameObject[] cube = new GameObject[8];

    GameObject Arrows;
    SetArrow script;

    bool[] check = new bool[4];

    Color c0 = new Color(235f/255f,97f/255f,32f/255f); // 赤
    Color c1 = new Color(255f/255f,241f/255f,0f/255f); // 黄色
    Color c2 = new Color(4f/255f,175f/255f,122f/255f); // 緑
    Color c3 = new Color(107f/255f,200f/255f,243f/255f); // 空色


    // Start is called before the first frame update
    void Start()
    {
        cb[0] = GameObject.Find("c0b");
        cb[1] = GameObject.Find("c1b");
        cb[2] = GameObject.Find("c2b");
        cb[3] = GameObject.Find("c3b");

        c[0] = cb[0].GetComponent<Image>().color;
        c[1] = cb[1].GetComponent<Image>().color;
        c[2] = cb[2].GetComponent<Image>().color;
        c[3] = cb[3].GetComponent<Image>().color;

        

        cp[0] = GameObject.Find("b0c");
        cp[1] = GameObject.Find("b1c");
        cp[2] = GameObject.Find("b2c");
        cp[3] = GameObject.Find("b3c");

        cube[0] = GameObject.Find("Cube0");
        cube[1] = GameObject.Find("Cube1");
        cube[2] = GameObject.Find("Cube2");
        cube[3] = GameObject.Find("Cube3");
        cube[4] = GameObject.Find("Cube4");
        cube[5] = GameObject.Find("Cube5");
        cube[6] = GameObject.Find("Cube6");
        cube[7] = GameObject.Find("Cube7");

        Arrows = GameObject.Find("Arrows");
        script = Arrows.GetComponent<SetArrow>();
        done_ans = false;

        now_color = Color.clear;
        // カラーパネル初期化
        for(int i = 0; i < 4; i++) cp[i].GetComponent<Image>().color = now_color;
        // 見直しモードのとき
        if(Scene_Load.is_answer_mode()) Scene_Load.get_mondai1_cubes_color(Scene_Load.get_mondai_num(),cube);
        else{
            Color color;
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
            cube[i].GetComponent<Renderer>().material.color = color;
            }
        }
    }

    public void onClick_c0(){
        now_color = c[0];
    }
    public void onClick_c1(){
        now_color = c[1];
    }
    public void onClick_c2(){
        now_color = c[2];
    }
    public void onClick_c3(){
        now_color = c[3];
    }
    public void onClick_b0(){
        if(cp[0].GetComponent<Image>().color != Color.clear && cp[0].GetComponent<Image>().color == now_color) cp[0].GetComponent<Image>().color = Color.clear;
        else cp[0].GetComponent<Image>().color = now_color;
    }
    public void onClick_b1(){
        if(cp[1].GetComponent<Image>().color != Color.clear && cp[1].GetComponent<Image>().color == now_color) cp[1].GetComponent<Image>().color = Color.clear;
        else cp[1].GetComponent<Image>().color = now_color;
    }
    public void onClick_b2(){
        if(cp[2].GetComponent<Image>().color != Color.clear && cp[2].GetComponent<Image>().color == now_color) cp[2].GetComponent<Image>().color = Color.clear;
        else cp[2].GetComponent<Image>().color = now_color;
    }
    public void onClick_b3(){
        if(cp[3].GetComponent<Image>().color != Color.clear && cp[3].GetComponent<Image>().color == now_color) cp[3].GetComponent<Image>().color = Color.clear;
        else cp[3].GetComponent<Image>().color = now_color;
    }
    public void onclick_next(){
        // 10問終わったら or 見直しモードのとき問題終了
        if(Scene_Load.get_mondai_num() > 9 || Scene_Load.is_answer_mode()) SceneManager.LoadScene("Result");
        else SceneManager.LoadScene("mondai01");
    }
    public void onClick_back(){
        SceneManager.LoadScene("Title");
    }
    public void onClick_howto(){
        howto.SetActive(true);
    }
    public void onClick_endhowto(){
        howto.SetActive(false);
    }

    public void onClick_Check(){
        string pos = script.Active_arrow;
        int [] first_num;
        int[] second_num;

        first_num = new int[4];
        second_num = new int[4];

        // 初期化
        if(pos.Equals("front")){
            first_num = new int[]{0,1,4,5};
            second_num = new int[]{2,3,6,7};
        }
        if(pos.Equals("right")){
            first_num = new int[]{1,3,5,7};
            second_num = new int[]{0,2,4,6};
        }
        if(pos.Equals("up")){
            first_num = new int[]{4,5,6,7};
            second_num = new int[]{0,1,2,3};
        }
        if(pos.Equals("left")){
            first_num = new int[]{2,0,6,4};
            second_num = new int[]{3,1,7,5};
        }
        if(pos.Equals("back")){
            first_num = new int[]{3,2,7,6};
            second_num = new int[]{1,0,5,4};
        }

        for(int i = 0; i < 4; i++){
            // 正誤判定
            if(cube[first_num[i]].GetComponent<Renderer>().material.color != Color.clear){
                if(cube[first_num[i]].GetComponent<Renderer>().material.color == cp[i].GetComponent<Image>().color) check[i] = true;
                else check[i] =false;
            }else if(cube[second_num[i]].GetComponent<Renderer>().material.color == cp[i].GetComponent<Image>().color) check[i] = true;
                else check[i] =false;

            // 正解の色を設定 
            if(cube[first_num[i]].GetComponent<Renderer>().material.color != Color.clear) ans_col[i] = cube[first_num[i]].GetComponent<Renderer>().material.color;
                else ans_col[i] = cube[second_num[i]].GetComponent<Renderer>().material.color;
        }

        // 見直しモードでなければ方向と cube と正解を保存
        if(!Scene_Load.is_answer_mode()){
            Scene_Load.set_mondai1_pos(Scene_Load.get_mondai_num(), pos);
            Scene_Load.set_mondai1_cubes_color(Scene_Load.get_mondai_num(),cube);
            Scene_Load.set_mondai1_ans_color(Scene_Load.get_mondai_num(),ans_col);
        }

        if(check[0] && check[1] && check[2] && check[3]){
            if(done_ans){
                //print("done");
            }else{
                // 正解
                //print("true");
                done_ans = true;
                maru.SetActive(true);
                next_button.SetActive(true);
                if(!Scene_Load.is_answer_mode()){
                    Scene_Load.seikai(Scene_Load.get_mondai_num());
                    Scene_Load.add_mondai_num();
                    Scene_Load.add_point();
                }
            }
        }else{
            if(done_ans){
                //print("done");
            }else{
                // 不正解
                //print("false");
                done_ans = true;
                batu.SetActive(true);
                answers.SetActive(true);
                // 拡張スライダーの表示
                xSlider.SetActive(false);
                ySlider.SetActive(false);
                ex_xSlider.SetActive(true);
                ex_ySlider.SetActive(true);

                for(int i = 0; i < 4; i++) ans[i].GetComponent<Image>().color = ans_col[i];
                next_button.SetActive(true);
                if(!Scene_Load.is_answer_mode()) Scene_Load.add_mondai_num();
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Image>().color = now_color;
    }
}
