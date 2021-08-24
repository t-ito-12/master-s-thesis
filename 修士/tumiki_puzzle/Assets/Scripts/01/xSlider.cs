using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class xSlider : MonoBehaviour
{

    // X軸回転を制御するオブジェクト（Transform）を格納する変数
    public Transform objRotX;
    // X軸回転を制御する Slider オブジェクトを格納する変数
    public Slider sliderRotX;

     // X軸回転を制御する処理
    public void ValueRotX()
    {
        // スライダーの値をオブジェクトのX軸回転値に格納
        objRotX.eulerAngles = new Vector3(sliderRotX.value, 0, 0);
    }


}
