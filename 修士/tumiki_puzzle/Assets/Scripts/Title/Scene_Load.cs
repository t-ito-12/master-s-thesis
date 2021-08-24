using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Scene_Load : MonoBehaviour
{
    // どの問題を選択したか
    static string mondai_name;
    // 今何問目か
    static int mondai_num;
    // 正解数
    static int point;
    // どの問題が正解or不正解か
    static bool[] mondai = new bool[10];
    // 見直しモードかどうか
    static bool answer_mode;

    // 問題1 cube 8 * 10 問 color 4 * 10 問
    static string[] mondai1_pos = new string[10];
    static Color[] mondai1_cube_color = new Color[80];
    static Color[] mondai1_seikai_color = new Color[40];

    // 問題2
    static float[] mondai2_comb = new float[10];
    static float[] mondai2_choice = new float[10];
    static string[] mondai2_d_pos0 = new string[10];
    static string[] mondai2_d_pos1 = new string[10];
    static float[] mondai2_which_p = new float[10];
    static Color[] mondai2_cube0_color = new Color[80];
    static Color[] mondai2_cube1_color = new Color[80];

    // 問題3
    static float[] mondai3_choice = new float[10];
    static Color[] mondai3_cube0_color = new Color[80];
    static Color[] mondai3_cube1_color = new Color[80];
    static Color[] mondai3_cube2_color = new Color[80];

    // How to Play
    GameObject[] cube = new GameObject[8];
    public GameObject Cubes;
    public GameObject howto;
    public GameObject h01;
    public GameObject h02;
    public GameObject h03;


    Color c0 = new Color(235f/255f,97f/255f,32f/255f); // 赤
    Color c1 = new Color(255f/255f,241f/255f,0f/255f); // 黄色
    Color c2 = new Color(4f/255f,175f/255f,122f/255f); // 緑
    Color c3 = new Color(107f/255f,200f/255f,243f/255f); // 空色


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
        // 初期化
        mondai_num = 0;
        point = 0;
        answer_mode = false;
        for(int i = 0; i < 10; i++) mondai[i] = false;
        cube[0].GetComponent<Renderer>().material.color = c0;
        cube[2].GetComponent<Renderer>().material.color = c3;
        cube[3].GetComponent<Renderer>().material.color = c1;
        cube[4].GetComponent<Renderer>().material.color = c2;
        cube[5].GetComponent<Renderer>().material.color = c0;
        cube[7].GetComponent<Renderer>().material.color = c3;
        h01.SetActive(false);
        h02.SetActive(false);
        h03.SetActive(false);
        howto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_b01(){
        mondai_name = "mondai01";
        SceneManager.LoadScene("mondai01");
    }
    public void OnClick_b02(){
        mondai_name = "mondai02";
        SceneManager.LoadScene("mondai02");
    }
    public void OnClick_b03(){
        mondai_name = "mondai03";
        SceneManager.LoadScene("mondai03");
    }
    public void OnClick_Howto(){
        howto.SetActive(true);
        Cubes.SetActive(true);
    }
    public void OnClick_endHowto(){
        howto.SetActive(false);
        h01.SetActive(false);
        h02.SetActive(false);
        h03.SetActive(false);
    }
    public void OnClick_h00(){
        Cubes.SetActive(true);
        h01.SetActive(false);
        h02.SetActive(false);
        h03.SetActive(false);
    }
    public void OnClick_h01(){
        Cubes.SetActive(false);
        h01.SetActive(true);
        h02.SetActive(false);
        h03.SetActive(false);
    }
    public void OnClick_h02(){
        Cubes.SetActive(false);
        h01.SetActive(false);
        h02.SetActive(true);
        h03.SetActive(false);
    }
    public void OnClick_h03(){
        Cubes.SetActive(false);
        h01.SetActive(false);
        h02.SetActive(false);
        h03.SetActive(true);
    }
    public void OnClick_end(){
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    // どの問題を選択したか
    public static string get_mondai_name(){
        return mondai_name;
    }

    // 第n問目
    public static int get_mondai_num(){
        return mondai_num;
    }
    public static int add_mondai_num(){
        mondai_num += 1;
        return mondai_num;
    }
    // n問目にセット
    public static void set_mondai_num(int n){
        mondai_num = n;
    }

    // その問題が正解のとき
    public static void seikai(int n){
        mondai[n] = true;
    }
    // その問題が正解かどうか
    public static bool isseikai(int n){
        return mondai[n];
    }
    // 得点
    public static int get_point(){
        return point;
    }
    public static int add_point(){
        point += 1;
        return point;
    }

    // 見直しモード on
    public static void answer_mode_on(){
        answer_mode = true;
    }
    // 見直しモード off
    public static void answer_mode_off(){
        answer_mode = false;
    }
    // 見直しモードかどうか
    public static bool is_answer_mode(){
        return answer_mode;
    }

    // 問題1
    // 方向をセット
    public static void set_mondai1_pos(int n, string pos){
        mondai1_pos[n] = pos;
    }
    // 方向をロード
    public static string get_mondai1_pos(int n){
        return mondai1_pos[n];
    }
    // 出題されたcubesをセット
    public static void set_mondai1_cubes_color(int n, GameObject[] o){
        for(int i = 0; i < 8; i++) mondai1_cube_color[8*n + i] = o[i].GetComponent<Renderer>().material.color;
    }
    // 出題されたcubesをロード
    public static void get_mondai1_cubes_color(int n, GameObject[] o){
        for(int i = 0; i < 8; i++)  o[i].GetComponent<Renderer>().material.color  = mondai1_cube_color[8*n + i];
    }
    // 正解の四色をセット
    public static void set_mondai1_ans_color(int n, Color[] c){
        for(int i = 0; i < 4; i++) mondai1_seikai_color[4*n + i] = c[i];
    }
    // 正解の四色をロード
    public static void get_mondai_ans_color(int n, Color[] c){
        for(int i = 0; i < 4; i++)  c[i] = mondai1_seikai_color[4*n + i];
    }
    

    // 問題2
    // 二択をセット
    public static void set_mondai2_choice(int n, float x){
        mondai2_choice[n] = x;
    }
    // 二択をロード
    public static float get_mondai2_choice(int n){
        return mondai2_choice[n];
    }
    // 組み合わせを保存
    public static void set_mondai2_comb(int n, float x){
        mondai2_comb[n] = x;
    }
    // 組み合わせをロード
    public static float get_mondai2_comb(int n){
        return mondai2_comb[n];
    }
    // パネルの順番を保存
    public static void set_mondai2_which_p(int n, float x){
        mondai2_which_p[n] = x;
    }
    // パネルの順番をロード
    public static float get_mondai2_which_p(int n){
        return mondai2_which_p[n];
    }
    // ダミー方角を保存
    public static void set_d_pos0(int n, string pos){
        mondai2_d_pos0[n] = pos;
    }
    public static void set_d_pos1(int n, string pos){
        mondai2_d_pos1[n] = pos;
    }
    // ダミー方角をロード
    public static string get_d_pos0(int n){
        return mondai2_d_pos0[n];
    }
    public static string get_d_pos1(int n){
        return mondai2_d_pos1[n];
    }
    // 出題されたcubesをセット
    public static void set_mondai2_cube0_color(int n, GameObject[] o){
        for(int i = 0; i < 8; i++) mondai2_cube0_color[8*n + i] = o[i].GetComponent<Renderer>().material.color;
    }
    public static void set_mondai2_cube1_color(int n, GameObject[] o){
        for(int i = 0; i < 8; i++) mondai2_cube1_color[8*n + i] = o[i].GetComponent<Renderer>().material.color;
    }
    // 出題されたcubesをロード
    public static void get_mondai2_cube0_color(int n, GameObject[] o){
        for(int i = 0; i < 8; i++)  o[i].GetComponent<Renderer>().material.color = mondai2_cube0_color[8*n + i];
    }
    public static void get_mondai2_cube1_color(int n, GameObject[] o){
        for(int i = 0; i < 8; i++)  o[i].GetComponent<Renderer>().material.color = mondai2_cube1_color[8*n + i];
    }


    // 問題3
    // 二択をセット
    public static void set_mondai3_choice(int n, float x){
        mondai3_choice[n] = x;
    }
    // 二択をロード
    public static float get_mondai3_choice(int n){
        return mondai3_choice[n];
    }
    // 出題されたcubesをセット
    public static void set_mondai3_cube0_color(int n, GameObject[] o){
        for(int i = 0; i < 8; i++) mondai3_cube0_color[8*n + i] = o[i].GetComponent<Renderer>().material.color;
    }
    public static void set_mondai3_cube1_color(int n, GameObject[] o){
        for(int i = 0; i < 8; i++) mondai3_cube1_color[8*n + i] = o[i].GetComponent<Renderer>().material.color;
    }
    public static void set_mondai3_cube2_color(int n, GameObject[] o){
        for(int i = 0; i < 8; i++) mondai3_cube2_color[8*n + i] = o[i].GetComponent<Renderer>().material.color;
    }
    // 出題されたcubesをロード
    public static void get_mondai3_cube0_color(int n, GameObject[] o){
        for(int i = 0; i < 8; i++) o[i].GetComponent<Renderer>().material.color = mondai3_cube0_color[8*n + i];
    }
    public static void get_mondai3_cube1_color(int n, GameObject[] o){
        for(int i = 0; i < 8; i++) o[i].GetComponent<Renderer>().material.color = mondai3_cube1_color[8*n + i];
    }
    public static void get_mondai3_cube2_color(int n, GameObject[] o){
        for(int i = 0; i < 8; i++) o[i].GetComponent<Renderer>().material.color = mondai3_cube2_color[8*n + i];
    }
}
