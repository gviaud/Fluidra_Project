using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuDecal_Script : Menu_Script {

	public GameObject _SliderScaleDecal;
	public GameObject _SliderRotateDecal;

	// Use this for initialization
	void Start () 
	{
		start ();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void ChangeScale()
	{
        if (_select_Object_Script != null)
            if (_select_Object_Script._select_GO != null)
                if (_select_Object_Script._select_GO.GetComponent<Decal_Script>())
                    _select_Object_Script._select_GO.GetComponent<Decal_Script>().Scale(_SliderScaleDecal.GetComponent<Slider>().value);
	}

	public void ChangeRotation()
	{
        if (_select_Object_Script != null)
            if (_select_Object_Script._select_GO != null)
                if (_select_Object_Script._select_GO.GetComponent<Decal_Script>())
                    _select_Object_Script._select_GO.GetComponent<Decal_Script>().Rotate(_SliderRotateDecal.GetComponent<Slider>().value);
	}


	override public void Reinit () 
	{

		if ( _select_Object_Script && _select_Object_Script._select_GO != null && _select_Object_Script._select_GO.GetComponent<Decal_Script>()) 
		{
			_SliderScaleDecal.GetComponent<Slider>().value = _select_Object_Script._select_GO.GetComponent<Decal_Script>()._scale;
			_SliderRotateDecal.GetComponent<Slider>().value = _select_Object_Script._select_GO.GetComponent<Decal_Script>()._rotation;
		}

	}

}
