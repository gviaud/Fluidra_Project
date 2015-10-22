using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MySingleton : SingletonPattern<MySingleton> 
{

	public int _length;
	public int _width;

	public int _colorTextureFloor;

	// --------------- DEBUT FORMULAIRE ---------------

	public string _firstName;
	public string _lastName;
	public string _company;
	public string _adresse;
	public string _mail;
	public string _tel;
	public string _com;

	public bool _Wall_Main;
	public bool _Wall_Left;
	public bool _Wall_Right;
	public bool _Wall_Behind;


	public bool _Enseigne;
	public int _longueur_Enseigne;
	public int _largeur_Enseigne;

	public bool _Reserve;
	public int _longueur_Reserve;
	public int _largeur_Reserve;

	// --------------- FIN FORMULAIRE ---------------

	// Use this for initialization
	public void Start () 
	{
		_length = 4;
		_width = 3;

		_colorTextureFloor = 0;

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

}
