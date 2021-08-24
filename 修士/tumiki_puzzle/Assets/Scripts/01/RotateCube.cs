using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class RotateCube : MonoBehaviour
{
    public Slider sliderRotX;
    public Slider sliderRotY;
    public Slider ex_sliderRotX;
    public Slider ex_sliderRotY;


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
        _delta.x = _prevX - sliderRotX.value - ex_sliderRotX.value;
		_delta.y = _prevY - sliderRotY.value - ex_sliderRotY.value;
		_prevX = sliderRotX.value + ex_sliderRotX.value;
		_prevY = sliderRotY.value + ex_sliderRotY.value;
		Vector3 euler = new Vector3(-_delta.y, _delta.x, 0.0f);
		target.Rotate(euler, Space.World);

        //Vector3 euler = new Vector3(sliderRotY.value, -sliderRotX.value, 0);
        //transform.eulerAngles = euler;
        //transform.Rotate(sliderRotY.value, sliderRotX.value, 0);
    }
}
