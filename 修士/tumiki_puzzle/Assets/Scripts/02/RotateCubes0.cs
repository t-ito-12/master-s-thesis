using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class RotateCubes0 : MonoBehaviour
{
    public Slider slider_0_RotX;
    public Slider slider_0_RotY;

    public Slider ex_sliderRotX0;
    public Slider ex_sliderRotY0;

    public Transform target;

    private float _prevX;
	private float _prevY;
	private Vector2 _delta = new Vector2(0.0f, 0.0f);
    
    void Awake()
	{
		if (target == null)
		{
			target = transform;
		}
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _delta.x = _prevX - slider_0_RotX.value - ex_sliderRotX0.value;
		_delta.y = _prevY - slider_0_RotY.value - ex_sliderRotY0.value;
		_prevX = slider_0_RotX.value + ex_sliderRotX0.value;
		_prevY = slider_0_RotY.value + ex_sliderRotY0.value;
		Vector3 euler = new Vector3(-_delta.y, _delta.x, 0.0f);
		target.Rotate(euler, Space.World);

        //Vector3 euler = new Vector3(sliderRotY.value, -sliderRotX.value, 0);
        //transform.eulerAngles = euler;
        //transform.Rotate(sliderRotY.value, sliderRotX.value, 0);
    }
}