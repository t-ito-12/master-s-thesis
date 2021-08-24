using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SetCubeColor : MonoBehaviour
{
    public GameObject maru;
    public GameObject batu;
    public bool done_ans;
    public GameObject next_button;
    public GameObject Howto_image;

    public GameObject front0;
    public GameObject right0;
    public GameObject left0;
    public GameObject back0;
    public GameObject up0;

    public GameObject front1;
    public GameObject right1;
    public GameObject left1;
    public GameObject back1;
    public GameObject up1;

    // Slider
    public GameObject S0;
    public GameObject ex_S0;
    public GameObject S1;
    public GameObject ex_S1;

    public GameObject maru0;
    public GameObject maru1;

    Color c0 = new Color(235f/255f,97f/255f,32f/255f); // 赤
    Color c1 = new Color(255f/255f,241f/255f,0f/255f); // 黄色
    Color c2 = new Color(4f/255f,175f/255f,122f/255f); // 緑
    Color c3 = new Color(107f/255f,200f/255f,243f/255f); // 空色

    GameObject[] cube0 = new GameObject[8];
    Color[] cube0_color = new Color[8];

    GameObject[] cube1 = new GameObject[8];
    Color[] cube1_color = new Color[8];

    GameObject[] image0 = new GameObject[4];
    GameObject[] image1 = new GameObject[4];

    // 二択
    public float choice;

    // Start is called before the first frame update
    void Start()
    {   
        // choice < 0.5f のとき cube0 が正解
        choice = Random.Range(0.0f, 1.0f);
        // 見直しモードのとき上書き
        if(Scene_Load.is_answer_mode()) choice = Scene_Load.get_mondai2_choice(Scene_Load.get_mondai_num());

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

        image0[0] = GameObject.Find("Image0_0");
        image0[1] = GameObject.Find("Image0_1");
        image0[2] = GameObject.Find("Image0_2");
        image0[3] = GameObject.Find("Image0_3");

        image1[0] = GameObject.Find("Image1_0");
        image1[1] = GameObject.Find("Image1_1");
        image1[2] = GameObject.Find("Image1_2");
        image1[3] = GameObject.Find("Image1_3");

        // 回答済みかどうか
        done_ans = false;

        // SetColor
        // 見直しモードのとき
        if(Scene_Load.is_answer_mode()){
            Scene_Load.get_mondai2_cube0_color(Scene_Load.get_mondai_num(),cube0);
            Scene_Load.get_mondai2_cube1_color(Scene_Load.get_mondai_num(),cube1);
        }else{
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
                if(choice < 0.5f) cube0[i].GetComponent<Renderer>().material.color = color;
                else cube1[i].GetComponent<Renderer>().material.color = color;
            }
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
                cube1[i].GetComponent<Renderer>().material.color = color;
            }
        }

        // 組み合わせ5C2=10通り 正面右0 正面左1 正面上2 正面後ろ3 右左4 右上5 右後ろ6 左上7 左後ろ8 上後ろ9
        float comb = Random.Range(0.0f, 10.0f);
        // 見直しモードのとき上書き
        if(Scene_Load.is_answer_mode()) comb = Scene_Load.get_mondai2_comb(Scene_Load.get_mondai_num());

        string pos0 = "front";
        string pos1 = "front";

        int[] c0_first_num;
        int[] c0_second_num;
        int[] c1_first_num;
        int[] c1_second_num;

        c0_first_num = new int[4];
        c0_second_num = new int[4];
        c1_first_num = new int[4];
        c1_second_num = new int[4];

        if(comb < 1.0f){
            pos0 = "front"; pos1 = "right";
        }
        if(comb >= 1.0f && comb < 2.0f){
            pos0 = "front"; pos1 = "left";
        }
        if(comb >= 2.0f && comb < 3.0f){
            pos0 = "front"; pos1 = "up";
        }
        if(comb >= 3.0f && comb < 4.0f){
            pos0 = "front"; pos1 = "back";
        }
        if(comb >= 4.0f && comb < 5.0f){
            pos0 = "right"; pos1 = "left";
        }
        if(comb >= 5.0f && comb < 6.0f){
            pos0 = "right"; pos1 = "up";
        }
        if(comb >= 6.0f && comb < 7.0f){
            pos0 = "right"; pos1 = "back";
        }
        if(comb >= 7.0f && comb < 8.0f){
            pos0 = "left"; pos1 = "up";
        }
        if(comb >= 8.0f && comb < 9.0f){
            pos0 = "left"; pos1 = "back";
        }
        if(comb >= 9.0f && comb <= 10.0f){
            pos0 = "up"; pos1 = "back";
        }

        // 初期化
        if(pos0.Equals("front")){
            c0_first_num = new int[]{0,1,4,5};
            c0_second_num = new int[]{2,3,6,7};
            if(choice < 0.5f ) front0.SetActive(true);
            else front1.SetActive(true);
        }
        if(pos0.Equals("right")){
            c0_first_num = new int[]{1,3,5,7};
            c0_second_num = new int[]{0,2,4,6};
            if(choice < 0.5f ) right0.SetActive(true);
            else right1.SetActive(true);
        }
        if(pos0.Equals("up")){
            c0_first_num = new int[]{4,5,6,7};
            c0_second_num = new int[]{0,1,2,3};
            if(choice < 0.5f ) up0.SetActive(true);
            else up1.SetActive(true);
        }
        if(pos0.Equals("left")){
            c0_first_num = new int[]{2,0,6,4};
            c0_second_num = new int[]{3,1,7,5};
            if(choice < 0.5f ) left0.SetActive(true);
            else left1.SetActive(true);
        }
        if(pos0.Equals("back")){
            c0_first_num = new int[]{3,2,7,6};
            c0_second_num = new int[]{1,0,5,4};
            if(choice < 0.5f ) back0.SetActive(true);
            else back1.SetActive(true);
        }

        if(pos1.Equals("front")){
            c1_first_num = new int[]{0,1,4,5};
            c1_second_num = new int[]{2,3,6,7};
            if(choice < 0.5f ) front0.SetActive(true);
            else front1.SetActive(true);
        }
        if(pos1.Equals("right")){
            c1_first_num = new int[]{1,3,5,7};
            c1_second_num = new int[]{0,2,4,6};
            if(choice < 0.5f ) right0.SetActive(true);
            else right1.SetActive(true);
        }
        if(pos1.Equals("up")){
            c1_first_num = new int[]{4,5,6,7};
            c1_second_num = new int[]{0,1,2,3};
            if(choice < 0.5f ) up0.SetActive(true);
            else up1.SetActive(true);
        }
        if(pos1.Equals("left")){
            c1_first_num = new int[]{2,0,6,4};
            c1_second_num = new int[]{3,1,7,5};
            if(choice < 0.5f ) left0.SetActive(true);
            else left1.SetActive(true);
        }
        if(pos1.Equals("back")){
            c1_first_num = new int[]{3,2,7,6};
            c1_second_num = new int[]{1,0,5,4};
            if(choice < 0.5f ) back0.SetActive(true);
            else back1.SetActive(true);
        }




        // image
        // パネルの順番
        float whitch_p = Random.Range(0.0f, 1.0f);
        // 見直しモードのとき上書き
        if(Scene_Load.is_answer_mode()){
            whitch_p = Scene_Load.get_mondai2_which_p(Scene_Load.get_mondai_num());
        }
        if(choice < 0.5f){
            if(whitch_p < 0.5f){
                for(int i = 0;i < 4;i++){
                    // image0
                    if(cube0[c0_first_num[i]].GetComponent<Renderer>().material.color != Color.clear) image0[i].GetComponent<Image>().color = cube0[c0_first_num[i]].GetComponent<Renderer>().material.color;
                    else image0[i].GetComponent<Image>().color = cube0[c0_second_num[i]].GetComponent<Renderer>().material.color;
                    // image1
                    if(cube0[c1_first_num[i]].GetComponent<Renderer>().material.color != Color.clear) image1[i].GetComponent<Image>().color = cube0[c1_first_num[i]].GetComponent<Renderer>().material.color;
                    else image1[i].GetComponent<Image>().color = cube0[c1_second_num[i]].GetComponent<Renderer>().material.color;
                }
            }else{
                for(int i = 0;i < 4;i++){
                    // image1
                    if(cube0[c0_first_num[i]].GetComponent<Renderer>().material.color != Color.clear) image1[i].GetComponent<Image>().color = cube0[c0_first_num[i]].GetComponent<Renderer>().material.color;
                    else image1[i].GetComponent<Image>().color = cube0[c0_second_num[i]].GetComponent<Renderer>().material.color;
                    // image0
                    if(cube0[c1_first_num[i]].GetComponent<Renderer>().material.color != Color.clear) image0[i].GetComponent<Image>().color = cube0[c1_first_num[i]].GetComponent<Renderer>().material.color;
                    else image0[i].GetComponent<Image>().color = cube0[c1_second_num[i]].GetComponent<Renderer>().material.color;
                }
            }
        }else{
            if(whitch_p < 0.5f){
                for(int i = 0;i < 4;i++){
                    // image0
                    if(cube1[c0_first_num[i]].GetComponent<Renderer>().material.color != Color.clear) image0[i].GetComponent<Image>().color = cube1[c0_first_num[i]].GetComponent<Renderer>().material.color;
                    else image0[i].GetComponent<Image>().color = cube1[c0_second_num[i]].GetComponent<Renderer>().material.color;
                    // image1
                    if(cube1[c1_first_num[i]].GetComponent<Renderer>().material.color != Color.clear) image1[i].GetComponent<Image>().color = cube1[c1_first_num[i]].GetComponent<Renderer>().material.color;
                    else image1[i].GetComponent<Image>().color = cube1[c1_second_num[i]].GetComponent<Renderer>().material.color;
                }
            }else{
                for(int i = 0;i < 4;i++){
                    // image1s
                    if(cube1[c0_first_num[i]].GetComponent<Renderer>().material.color != Color.clear) image1[i].GetComponent<Image>().color = cube1[c0_first_num[i]].GetComponent<Renderer>().material.color;
                    else image1[i].GetComponent<Image>().color = cube1[c0_second_num[i]].GetComponent<Renderer>().material.color;
                    // image0
                    if(cube1[c1_first_num[i]].GetComponent<Renderer>().material.color != Color.clear) image0[i].GetComponent<Image>().color = cube1[c1_first_num[i]].GetComponent<Renderer>().material.color;
                    else image0[i].GetComponent<Image>().color = cube1[c1_second_num[i]].GetComponent<Renderer>().material.color;
                }
            }
        }

        // ダミーキューブに色を配置
        // 片面を配置→もう片面を正解と異なるように配置
        // d_choice < 0.5f のときimage0 からダミーを構成
        float d_choice = Random.Range(0.0f, 1.0f);
        // ダミー方角を決定　もう一つの方角は最初に選ばれなかった方角から一つ選択
        string d_pos0, d_pos1;
        List<string> d_list = new List<string>(){"front","right","left","up","back"};
        d_pos0 = d_list.PopRandomElement();
        d_pos1 = d_list.PopRandomElement();
        //　見直しモードのとき上書き
        if(Scene_Load.is_answer_mode()){
            d_pos0 = Scene_Load.get_d_pos0(Scene_Load.get_mondai_num());
            d_pos1 = Scene_Load.get_d_pos1(Scene_Load.get_mondai_num());
        }
        if(d_pos0.Equals("front")){
            if(choice < 0.5f) front1.SetActive(true);
            else front0.SetActive(true);
        }
        if(d_pos0.Equals("right")){
            if(choice < 0.5f) right1.SetActive(true);
            else right0.SetActive(true);
        }
        if(d_pos0.Equals("left")){
            if(choice < 0.5f) left1.SetActive(true);
            else left0.SetActive(true);
        }
        if(d_pos0.Equals("up")){
            if(choice < 0.5f) up1.SetActive(true);
            else up0.SetActive(true);
        }
        if(d_pos0.Equals("back")){
            if(choice < 0.5f) back1.SetActive(true);
            else back0.SetActive(true);
        }

        if(d_pos1.Equals("front")){
            if(choice < 0.5f) front1.SetActive(true);
            else front0.SetActive(true);
        }
        if(d_pos1.Equals("right")){
            if(choice < 0.5f) right1.SetActive(true);
            else right0.SetActive(true);
        }
        if(d_pos1.Equals("left")){
            if(choice < 0.5f) left1.SetActive(true);
            else left0.SetActive(true);
        }
        if(d_pos1.Equals("up")){
            if(choice < 0.5f) up1.SetActive(true);
            else up0.SetActive(true);
        }
        if(d_pos1.Equals("back")){
            if(choice < 0.5f) back1.SetActive(true);
            else back0.SetActive(true);
        }

        if(!Scene_Load.is_answer_mode()){
            int[] d0_first_num;
            int[] d0_second_num;
            d0_first_num = new int[4];
            d0_second_num = new int[4];
            // cubeを手前に配置するか奥に配置するかはランダム
            set_pos(d_pos0, ref d0_first_num, ref d0_second_num);
            // ダミー生成
            if(choice < 0.5f){
                // cube1に生成
                if(d_choice < 0.5f){
                    // image0から生成
                    for(int i = 0; i < 4; i++){
                        // 手前or奥
                        float d_which = Random.Range(0.0f,1.0f);
                        if(d_which < 0.5f) cube1[d0_first_num[i]].GetComponent<Renderer>().material.color = image0[i].GetComponent<Image>().color;
                        else cube1[d0_second_num[i]].GetComponent<Renderer>().material.color = image0[i].GetComponent<Image>().color;
                    }
                }else{
                    // image1から生成
                    for(int i = 0; i < 4; i++){
                        // 手前or奥
                        float d_which = Random.Range(0.0f,1.0f);
                        if(d_which < 0.5f) cube1[d0_first_num[i]].GetComponent<Renderer>().material.color = image1[i].GetComponent<Image>().color;
                        else cube1[d0_second_num[i]].GetComponent<Renderer>().material.color = image1[i].GetComponent<Image>().color;
                    }
                }
            }else{
                // cube0に生成
                if(d_choice < 0.5f){
                    // image0から生成
                    for(int i = 0; i < 4; i++){
                        // 手前or奥
                        float d_which = Random.Range(0.0f,1.0f);
                        if(d_which < 0.5f) cube0[d0_first_num[i]].GetComponent<Renderer>().material.color = image0[i].GetComponent<Image>().color;
                        else cube0[d0_second_num[i]].GetComponent<Renderer>().material.color = image0[i].GetComponent<Image>().color;
                    }
                }else{
                    // image1から生成
                    for(int i = 0; i < 4; i++){
                        // 手前or奥
                        float d_which = Random.Range(0.0f,1.0f);
                        if(d_which < 0.5f) cube0[d0_first_num[i]].GetComponent<Renderer>().material.color = image1[i].GetComponent<Image>().color;
                        else cube0[d0_second_num[i]].GetComponent<Renderer>().material.color = image1[i].GetComponent<Image>().color;
                    }
                }
            }
        }
        // もう片方からみた断面が正解と同じでないことのチェック
        
        
        // 見直しモードのセット
        if(!Scene_Load.is_answer_mode()){
            Scene_Load.set_mondai2_choice(Scene_Load.get_mondai_num(), choice);
            Scene_Load.set_mondai2_comb(Scene_Load.get_mondai_num(), comb);
            Scene_Load.set_mondai2_cube0_color(Scene_Load.get_mondai_num(), cube0);
            Scene_Load.set_mondai2_cube1_color(Scene_Load.get_mondai_num(), cube1);
            Scene_Load.set_mondai2_which_p(Scene_Load.get_mondai_num(), whitch_p);
            Scene_Load.set_d_pos0(Scene_Load.get_mondai_num(), d_pos0);
            Scene_Load.set_d_pos1(Scene_Load.get_mondai_num(), d_pos1);
        }

    }
    public void onClick_back(){
        SceneManager.LoadScene("Title");
    }
    public void onClick_A(){
        if(choice < 0.5f){
            if(done_ans){

            }else{
                // 正解
                done_ans = true;
                maru.SetActive(true);
                next_button.SetActive(true);
                maru0.SetActive(true);
                S0.SetActive(false);
                S1.SetActive(false);
                ex_S0.SetActive(true);
                ex_S1.SetActive(true);
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
                maru1.SetActive(true);
                S0.SetActive(false);
                S1.SetActive(false);
                ex_S0.SetActive(true);
                ex_S1.SetActive(true);
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
                maru0.SetActive(true);
                S0.SetActive(false);
                S1.SetActive(false);
                ex_S0.SetActive(true);
                ex_S1.SetActive(true);
                if(!Scene_Load.is_answer_mode()) Scene_Load.add_mondai_num();
            }
        }else{
            if(done_ans){

            }else{
                // 正解
                done_ans = true;
                maru.SetActive(true);
                next_button.SetActive(true);
                maru1.SetActive(true);
                S0.SetActive(false);
                S1.SetActive(false);
                ex_S0.SetActive(true);
                ex_S1.SetActive(true);
                if(!Scene_Load.is_answer_mode()){
                    Scene_Load.seikai(Scene_Load.get_mondai_num());
                    Scene_Load.add_mondai_num();
                    Scene_Load.add_point();
                }
            }
        }
    }
    public void onclick_next(){
        // 10問終わったら or 見直しモードのとき問題終了
        if(Scene_Load.get_mondai_num() > 9 || Scene_Load.is_answer_mode()) SceneManager.LoadScene("Result");
        else SceneManager.LoadScene("mondai02");
    }
    public void onClick_Howto(){
        Howto_image.SetActive(true);
    }
    public void onClick_endHowto(){
        Howto_image.SetActive(false);
    }

    public static void set_pos(string pos, ref int[] num0, ref int[] num1){
        if(pos.Equals("front")){
            num0 = new int[]{0,1,4,5};
            num1 = new int[]{2,3,6,7};
        }
        if(pos.Equals("right")){
            num0 = new int[]{1,3,5,7};
            num1 = new int[]{0,2,4,6};   
        }
        if(pos.Equals("up")){
            num0 = new int[]{4,5,6,7};
            num1 = new int[]{0,1,2,3};
        }
        if(pos.Equals("left")){
            num0= new int[]{2,0,6,4};
            num1 = new int[]{3,1,7,5};
        }
        if(pos.Equals("back")){
            num0 = new int[]{3,2,7,6};
            num1 = new int[]{1,0,5,4};
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class ListExt
{
    public static T PopRandomElement<T>( this List<T> self )
    {
        var item = self[ Random.Range( 0, self.Count ) ];
        self.Remove( item );
        return item;
    }
}

