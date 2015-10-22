using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Clamp_Slider_Script : MonoBehaviour {

	public float _valueClamp;
	public float _dif;
	public bool _clamp;
	Slider _slider;

	// Use this for initialization
	void Start () 
	{
		_slider = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if( _clamp )
		{
			if( _slider.value >= _valueClamp-_dif && _slider.value <= _valueClamp+_dif )
			{
				_slider.value = _valueClamp;
			}
		}

	}
}
