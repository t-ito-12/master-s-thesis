using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int now_mondai;
    // Start is called before the first frame update
    void Start()
    {
        now_mondai = Scene_Load.get_mondai_num()+1;
    }

    // Update is called once per frame
    void Update()
    {
        Text score_text = this.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "だい"+now_mondai+"もん";
    }
}
