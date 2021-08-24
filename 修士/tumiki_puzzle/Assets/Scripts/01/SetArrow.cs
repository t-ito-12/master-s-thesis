using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetArrow : MonoBehaviour
{   
    GameObject front_arrow;
    GameObject right_arrow;
    GameObject up_arrow;
    GameObject left_arrow;
    GameObject back_arrow;
    public string Active_arrow;

    // Start is called before the first frame update
    void Start()
    {   
        front_arrow = GameObject.Find("Arrow_symbol_01");
        right_arrow = GameObject.Find("Arrow_symbol_02");
        up_arrow = GameObject.Find("Arrow_symbol_03");
        left_arrow = GameObject.Find("Arrow_symbol_04");
        back_arrow = GameObject.Find("Arrow_symbol_05");

        // 見直しモードのとき
        if(Scene_Load.is_answer_mode()){
            Active_arrow = Scene_Load.get_mondai1_pos(Scene_Load.get_mondai_num());
        }else{
            float pick = Random.Range (0.0f, 5.0f);

        
            if(pick < 1.0f) Active_arrow = "front";
            else if(pick >= 1.0f && pick < 2.0f) Active_arrow = "right";
            else if(pick >= 2.0f && pick < 3.0f) Active_arrow = "up";
            else if(pick >= 3.0f && pick < 4.0f) Active_arrow = "left";
            else Active_arrow = "back";
        }

        if(Active_arrow.Equals("front")){
            right_arrow.SetActive(false);
            up_arrow.SetActive(false);
            left_arrow.SetActive(false);
            back_arrow.SetActive(false);
        }
        if(Active_arrow.Equals("right")){
            front_arrow.SetActive(false);
            up_arrow.SetActive(false);
            left_arrow.SetActive(false);
            back_arrow.SetActive(false);
        }
        if(Active_arrow.Equals("up")){
            front_arrow.SetActive(false);
            right_arrow.SetActive(false);
            left_arrow.SetActive(false);
            back_arrow.SetActive(false);
        }
        if(Active_arrow.Equals("left")){
            front_arrow.SetActive(false);
            right_arrow.SetActive(false);
            up_arrow.SetActive(false);
            back_arrow.SetActive(false);
        }
        if(Active_arrow.Equals("back")){
            front_arrow.SetActive(false);
            right_arrow.SetActive(false);
            up_arrow.SetActive(false);
            left_arrow.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
