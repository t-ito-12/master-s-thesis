using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToTitle : MonoBehaviour
{
    public GameObject title_button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void on_click_titlebutton(){
        SceneManager.LoadScene("Title");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
