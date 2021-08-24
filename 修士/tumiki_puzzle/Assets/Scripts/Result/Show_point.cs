using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Show_point : MonoBehaviour
{
    public GameObject Great;
    public GameObject Good;
    public GameObject Soso;
    public GameObject Notgood;
    public GameObject Bad;

    // Start is called before the first frame update
    void Start()
    {
        Text result_text = this.GetComponent<Text>();
        result_text.text = "てんすう：　" + Scene_Load.get_point()*10 +  "てん";
        if(Scene_Load.get_point() < 3) Bad.SetActive(true);
        else if(Scene_Load.get_point() < 5) Notgood.SetActive(true);
        else if(Scene_Load.get_point() < 7) Soso.SetActive(true);
        else if(Scene_Load.get_point() < 9) Good.SetActive(true);
        else Great.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
