/* Viaud Guillaume
 *	Creation : 26/08/2015
 * 
 * Script qui gère les éléments les plus importants comme le sol, les cloisons, la réserve et l'enseigne (création, agrandissement, rapetissement...)
 * 
 * Script attached to SceneManager(GameObject/Prefab) and present in scene
 * 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class SceneManager_Script : MonoBehaviour {

    public GameObject _alutri_model;
    GameObject[] _alutri_Tab;
    float cooldown = 0.0f;
    public GameObject[] Wall_Tab;
	Cloison_Script[] Wall_Tab_Script;
	public GameObject Ground;

	public int _longueur;
	public int _largeur;
	public int _maxLongueur;
	public int _minLongueur;
	public Text _longueurTxt;
	public Text _largeurTxt;


	public GameObject[] EnseigneWalls;
	public int _enseigneLongueur;
	public int _enseigneLargeur;
	public Text _enseigneLongueurTxt;
	public bool _isCarre; //false si lineaire || true si carre

    public GameObject CameraMain;
    public GameObject CameraHomme;

	public Text _reserveLongueurTxt;
	public int _reserveLongueur;
	public int _reserveLargeur;

	GameObject _Wall_Main;
	GameObject _Wall_Left;
	GameObject _Wall_Right;
	GameObject _Wall_Behind;
	public GameObject _Door;
	public GameObject _Enseigne;
	public GameObject _Reserve;
	public GameObject[] decals_Tab;
    public Slider _ReserveSlider;
	Select_Object_Script select_Script;

	LightManager_Script _lightManager_Script;

	bool _pass;

	public GameObject _largueurPossible;
	public GameObject _longueurPossible;
	public GameObject _longueurReserveMenu;
	public GameObject _largueurReserveMenu;

	public GameObject _sliderLongueur;
	public GameObject _sliderLargeur;
	int _lastValueLongueur;
	int _lastValueLargeur;

	public GameObject _sliderLongueurReserve;
	public GameObject _sliderLargeurReserve;
	int _lastValueLongueurReserve;
	int _lastValueLargeurReserve;
	public GameObject _longueurReserveTxT;
	public GameObject _largueurReserveTxT;

	public GameObject _sliderTailleEnseigne;
	int _lastValueEnseigne;

    public GameObject _SurfaceTXT;

    public Toggle toggleAjoutEnseigne;
    public Toggle toggleLineaire;
    public Toggle toggleCarre;

    // Use this for initialization
    public void Start () 
	{
        
        _pass = true;
		_Wall_Main = Wall_Tab[0];
		_Wall_Left = Wall_Tab[1];
		_Wall_Right = Wall_Tab[2];
		_Wall_Behind  = Wall_Tab[3];
		_Enseigne = transform.FindChild ("Enseigne").gameObject;
		_Reserve = transform.FindChild ("Reserve").gameObject;
		//_Door = transform.FindChild ("Door").gameObject;

		_longueur = MySingleton.Instance._length;
		_largeur = MySingleton.Instance._width;

		_reserveLargeur = 1;
		_reserveLongueur = 1;

		if (_largeur == 0) {
			_largeur = 3;
			MySingleton.Instance._length = 3;
		}
		if (_longueur == 0){
			_longueur = 4;
			MySingleton.Instance._width = 4;
		}

		_lastValueLongueur = _longueur;
		_lastValueLargeur = _largeur;
		_lastValueEnseigne = 3;
		_lastValueLongueurReserve = 1;
		_lastValueLargeurReserve = 1;

        CreateAlutri(3);
        
        Wall_Tab_Script = new Cloison_Script[4];
		
		for(int i = 0;i < 4; i++)
			Wall_Tab_Script [i] = Wall_Tab [i].GetComponent<Cloison_Script> ();

		_largeurTxt.text = "Largeur                  " + _largeur+"m";
		_longueurTxt.text = "Longueur               " + _longueur+"m";

		select_Script = GetComponent<Select_Object_Script>();
		_lightManager_Script = GameObject.Find ("LightManager").GetComponent<LightManager_Script>();
        _Enseigne.SetActive(true);
        setIsCarre(false);
        _Enseigne.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () 
	{

		//CameraHomme.transform.position = new Vector3(0,3.4f,_largeur * -2f);

		UpdateMinMaxLongueur ();
		CheckWall ();
        


        _SurfaceTXT.GetComponent<Text>().text = "Surface " + _longueur*_largeur + " m²";
        cooldown -= Time.deltaTime;

        TestEnseigneLimite();

    }
	public void Reinit(){
		Application.LoadLevel("StandExpo");
	}

    float lastValuerSliderPorte = 0;



    public void ApplyAll()
    {

        if( select_Script._select_GO != null )
        {

            Texture tex = select_Script._select_GO.GetComponent<Renderer>().material.mainTexture;
            float axis = select_Script._select_GO.GetComponent<Decal_Script>()._rotation;
            float scale = select_Script._select_GO.GetComponent<Decal_Script>()._scale;
            Vector3 pos = select_Script._select_GO.transform.position;
            float ratioX = select_Script._select_GO.GetComponent<Decal_Script>()._ratioX;
            float ratioY = select_Script._select_GO.GetComponent<Decal_Script>()._ratioY;


			Vector3 localScale = select_Script._select_GO.transform.localScale;


            decals_Tab[3].transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = tex;
            decals_Tab[4].transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = tex;
            decals_Tab[5].transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = tex;
            decals_Tab[6].transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = tex;

            decals_Tab[3].transform.GetChild(0).GetComponent<Decal_Script>().Rotate(axis);
            decals_Tab[4].transform.GetChild(0).GetComponent<Decal_Script>().Rotate(axis);
            decals_Tab[5].transform.GetChild(0).GetComponent<Decal_Script>().Rotate(axis);
            decals_Tab[6].transform.GetChild(0).GetComponent<Decal_Script>().Rotate(axis);

            decals_Tab[3].transform.GetChild(0).GetComponent<Decal_Script>()._ratioX = ratioX;
            decals_Tab[4].transform.GetChild(0).GetComponent<Decal_Script>()._ratioX = ratioX;
            decals_Tab[5].transform.GetChild(0).GetComponent<Decal_Script>()._ratioX = ratioX;
            decals_Tab[6].transform.GetChild(0).GetComponent<Decal_Script>()._ratioX = ratioX;

            decals_Tab[3].transform.GetChild(0).GetComponent<Decal_Script>()._ratioY = ratioY;
            decals_Tab[4].transform.GetChild(0).GetComponent<Decal_Script>()._ratioY = ratioY;
            decals_Tab[5].transform.GetChild(0).GetComponent<Decal_Script>()._ratioY = ratioY;
            decals_Tab[6].transform.GetChild(0).GetComponent<Decal_Script>()._ratioY = ratioY;

			decals_Tab[3].transform.GetChild(0).GetComponent<Decal_Script>().Scale(scale);
			decals_Tab[4].transform.GetChild(0).GetComponent<Decal_Script>().Scale(scale);
			decals_Tab[5].transform.GetChild(0).GetComponent<Decal_Script>().Scale(scale);
			decals_Tab[6].transform.GetChild(0).GetComponent<Decal_Script>().Scale(scale);

			decals_Tab[3].transform.GetChild(0).transform.localScale = localScale;
			decals_Tab[4].transform.GetChild(0).transform.localScale = localScale;
			decals_Tab[5].transform.GetChild(0).transform.localScale = localScale;
			decals_Tab[6].transform.GetChild(0).transform.localScale = localScale;

			decals_Tab[3].transform.GetChild(0).GetChild(0).transform.localPosition = new Vector3(0,0,0.5f);
			decals_Tab[4].transform.GetChild(0).GetChild(0).transform.localPosition = new Vector3(0,0,0.5f);
			decals_Tab[5].transform.GetChild(0).GetChild(0).transform.localPosition = new Vector3(0,0,0.5f);
			decals_Tab[6].transform.GetChild(0).GetChild(0).transform.localPosition = new Vector3(0,0,-0.5f);

            if (select_Script._select_GO.name == "EnseigneFront")
            {

                decals_Tab[3].transform.GetChild(0).transform.position = new Vector3(-pos.x, pos.y, decals_Tab[3].transform.GetChild(0).transform.position.z);

                decals_Tab[5].transform.GetChild(0).transform.position = new Vector3(decals_Tab[5].transform.GetChild(0).transform.position.x, pos.y, pos.x);
                decals_Tab[6].transform.GetChild(0).transform.position = new Vector3(decals_Tab[6].transform.GetChild(0).transform.position.x, pos.y, -pos.x);

            }
            else if (select_Script._select_GO.name == "EnseigneBack")
            {

                decals_Tab[4].transform.GetChild(0).transform.position = new Vector3(-pos.x, pos.y, decals_Tab[4].transform.GetChild(0).transform.position.z);
                decals_Tab[5].transform.GetChild(0).transform.position = new Vector3(decals_Tab[5].transform.GetChild(0).transform.position.x, pos.y, -pos.x);
                decals_Tab[6].transform.GetChild(0).transform.position = new Vector3(decals_Tab[6].transform.GetChild(0).transform.position.x, pos.y, pos.x);

            }
            else if (select_Script._select_GO.name == "EnseigneLeft")
            {

                decals_Tab[3].transform.GetChild(0).transform.position = new Vector3(-pos.z, pos.y, decals_Tab[3].transform.GetChild(0).transform.position.z);
                decals_Tab[4].transform.GetChild(0).transform.position = new Vector3(pos.z, pos.y, decals_Tab[4].transform.GetChild(0).transform.position.z);

                decals_Tab[6].transform.GetChild(0).transform.position = new Vector3(decals_Tab[6].transform.GetChild(0).transform.position.x, pos.y, -pos.z);

            }
            else if (select_Script._select_GO.name == "EnseigneRight")
            {

                decals_Tab[3].transform.GetChild(0).transform.position = new Vector3(pos.z, pos.y, decals_Tab[3].transform.GetChild(0).transform.position.z);
                decals_Tab[4].transform.GetChild(0).transform.position = new Vector3(-pos.z, pos.y, decals_Tab[4].transform.GetChild(0).transform.position.z);

                decals_Tab[5].transform.GetChild(0).transform.position = new Vector3(decals_Tab[5].transform.GetChild(0).transform.position.x, pos.y, -pos.z);

            }

        }

    }

    public void SliderPorte()
    {

        if (_ReserveSlider.value - lastValuerSliderPorte <= -2)
        {
            _ReserveSlider.value = lastValuerSliderPorte - 1;
        }
        else if (_ReserveSlider.value - lastValuerSliderPorte >= 2)
        {
            _ReserveSlider.value = lastValuerSliderPorte + 1;
        }

        if (_ReserveSlider.value - lastValuerSliderPorte == -1)
        {
            _Reserve.transform.GetChild(0).GetComponent<Door_Script>().ReplaceDoor_Left();
        }
        else if (_ReserveSlider.value - lastValuerSliderPorte == 1)
        {
            _Reserve.transform.GetChild(0).GetComponent<Door_Script>().ReplaceDoor_Right();
        }

        lastValuerSliderPorte = _ReserveSlider.value;
    }

    public void ReinitValueSliderPorte()
    {
        lastValuerSliderPorte = 0;
        _ReserveSlider.value = 0;
    }

    void LongueurPossible()
	{

		if (_reserveLargeur == 1)  
		{
			_sliderLongueurReserve.GetComponent<Slider>().maxValue = 4;
		}
		else if (_reserveLargeur == 2) 
		{
			_sliderLongueurReserve.GetComponent<Slider>().maxValue = 2;
		}
		else if (_reserveLargeur == 3) 
		{
			_sliderLongueurReserve.GetComponent<Slider>().maxValue = 1;
		}
		else if (_reserveLargeur == 4) 
		{
			_sliderLongueurReserve.GetComponent<Slider>().maxValue = 1;
		}
	}

	void LargueurPossible()
	{

		if (_reserveLongueur == 1) 
		{
			_sliderLargeurReserve.GetComponent<Slider>().maxValue = 4;
			
		}
		else if (_reserveLongueur == 2) 
		{
			_sliderLargeurReserve.GetComponent<Slider>().maxValue = 2;
		}
		else if (_reserveLongueur == 3) 
		{
			_sliderLargeurReserve.GetComponent<Slider>().maxValue = 1;
		}
		else if (_reserveLongueur == 4) 
		{
			_sliderLargeurReserve.GetComponent<Slider>().maxValue = 1;
		}
	}

	public void DesactiveMenuDeroulant()
	{
        /*
		_longueurReserveMenu.GetComponent<Toggle> ().isOn = false;
		_largueurReserveMenu.GetComponent<Toggle> ().isOn = false;

		_largueurPossible.SetActive (false);
		_longueurPossible.SetActive (false);
        */
	}

	public void UpdateALL()
	{

		ResizeScene(_longueur, _largeur);
        

    }
    public void GriserTextMenu(Text t)
    {

        t.color = new Color(0.4f, 0.4f, 0.4f);
    }
    public void WhiteTextMenu(Text t)
    {
        t.color = Color.white;
    }
	void setPosDecals(){
		//main
		decals_Tab[0].transform.position = _Wall_Main.transform.position;
		//DecalBuilder.BuildDecalForObject( decals_Tab[0].GetComponent<Decal>(), _Wall_Main );
	
		//left
		decals_Tab[1].transform.position = _Wall_Left.transform.position;

        //right
        decals_Tab[2].transform.position = _Wall_Right.transform.position;
        decals_Tab[2].transform.position = new Vector3(decals_Tab[2].transform.position.x-0.09f, decals_Tab[2].transform.position.y, decals_Tab[2].transform.position.z);

        //enseigne back
        decals_Tab[3].transform.position = EnseigneWalls[0].transform.position;

		//enseigne front
		decals_Tab[4].transform.position = EnseigneWalls[1].transform.position;

		//enseigne right
		decals_Tab[5].transform.position = EnseigneWalls[2].transform.position;

		//enseigne left
		decals_Tab[6].transform.position = EnseigneWalls[3].transform.position;
        decals_Tab[6].transform.position = new Vector3(decals_Tab[6].transform.position.x - 0.042f, decals_Tab[6].transform.position.y, decals_Tab[6].transform.position.z);
        //decals_Tab[6].GetComponent<Decal>();

    }
	void CheckWall()
	{

		if (_Wall_Main.activeInHierarchy)
			MySingleton.Instance._Wall_Main = true;
		else
			MySingleton.Instance._Wall_Main = false;

		if (_Wall_Left.activeInHierarchy)
			MySingleton.Instance._Wall_Left = true;
		else
			MySingleton.Instance._Wall_Left = false;

		if (_Wall_Right.activeInHierarchy)
			MySingleton.Instance._Wall_Right = true;
		else
			MySingleton.Instance._Wall_Right = false;

		if (_Wall_Behind.activeInHierarchy)
			MySingleton.Instance._Wall_Behind = true;
		else
			MySingleton.Instance._Wall_Behind = false;

		if (_Enseigne.activeInHierarchy) {
			MySingleton.Instance._Enseigne = true;
			MySingleton.Instance._longueur_Enseigne = _enseigneLongueur;
			MySingleton.Instance._largeur_Enseigne = _enseigneLargeur;
		}
		else
			MySingleton.Instance._Enseigne = false;
		
		if (_Reserve.activeInHierarchy) {
			MySingleton.Instance._Reserve = true;
			MySingleton.Instance._longueur_Reserve = _reserveLongueur;
			MySingleton.Instance._largeur_Reserve = _reserveLargeur;
		}
		else
			MySingleton.Instance._Reserve = false;

	}

	void UpdateMinMaxLongueur()
	{
		if(_largeur == 3)
		{
			_maxLongueur = 7;
			_minLongueur = 4;

			_sliderLongueur.GetComponent<Slider>().maxValue = _maxLongueur;
			_sliderLongueur.GetComponent<Slider>().minValue = _minLongueur;

			if( _longueur < _minLongueur)
			{
				ResizeLongueur(1);
			}

		}
		else if(_largeur == 4)
		{
			_maxLongueur = 7;
			_minLongueur = 3;

			_sliderLongueur.GetComponent<Slider>().maxValue = _maxLongueur;
			_sliderLongueur.GetComponent<Slider>().minValue = _minLongueur;

			if( _longueur > _maxLongueur)
			{
				ResizeLongueur(_maxLongueur-_longueur);
			}
		}
		else  if(_largeur == 5)
		{
			_maxLongueur = 7;
			_minLongueur = 3;

			_sliderLongueur.GetComponent<Slider>().maxValue = _maxLongueur;
			_sliderLongueur.GetComponent<Slider>().minValue = _minLongueur;

			if( _longueur > _maxLongueur)
			{
				ResizeLongueur(_maxLongueur-_longueur);
			}
		}
	}
	
    void TestEnseigneLimite()
    {
        
        if (!_isCarre)
        {
   
            if (_longueur - 2 < _enseigneLongueur)
                toggleAjoutEnseigne.interactable = false;
            else
            {

                toggleAjoutEnseigne.interactable = true;

                if (_longueur - 2 < 4)
                {
                        _sliderTailleEnseigne.GetComponent<Slider>().interactable = false;
                }
                else if (_longueur - 2 < 5)
                {
                    if (_Enseigne.activeInHierarchy)
                        _sliderTailleEnseigne.GetComponent<Slider>().interactable = true;
                    _sliderTailleEnseigne.GetComponent<Slider>().maxValue = 4;
                }
                else
                {
                    if (_Enseigne.activeInHierarchy)
                        _sliderTailleEnseigne.GetComponent<Slider>().interactable = true;
                    _sliderTailleEnseigne.GetComponent<Slider>().maxValue = 5;
                }

                if (_longueur - 2 < 2 || _largeur - 2 < 2)
                    toggleCarre.interactable = false;
                else if (_Enseigne.activeInHierarchy)
                {
                    toggleCarre.interactable = true;
                }
            }
        }
        else if (_isCarre)
        {
            if (_longueur - 2 < _enseigneLongueur || _largeur - 2 < _enseigneLongueur)
                toggleAjoutEnseigne.interactable = false;
            else
            {

                toggleAjoutEnseigne.interactable = true;

                if (_longueur - 2 < 3 || _largeur - 2 < 3 )
                    _sliderTailleEnseigne.GetComponent<Slider>().interactable = false;
                else
                {
                    if (_Enseigne.activeInHierarchy)
                        _sliderTailleEnseigne.GetComponent<Slider>().interactable = true;
                }

                if (_longueur - 2 < 3 )
                    toggleLineaire.interactable = false;
                else if (_Enseigne.activeInHierarchy)
                {
                    toggleLineaire.interactable = true;
                }

            }

        }
    }

    public void EnseigneLimite()
    {
        
        if (!_isCarre)
        {
            if (_longueur - 2 < _enseigneLongueur)
            {
                if (_longueur - 2 >= 3)
                    ResizeElementEnseigneV2WhitLimite(_longueur - 2);
                else
                {
                    _Enseigne.SetActive(false);
                    select_Script.ActivVisuel(false);
                    toggleAjoutEnseigne.isOn = false;
                    _enseigneLongueur = 3;
                    _sliderTailleEnseigne.GetComponent<Slider>().value = 3;
                    
                }
            }
        }
        else if (_isCarre)
        {
            if (_longueur - 2 < _enseigneLongueur || _largeur - 2 < _enseigneLongueur)
            {
                if (_longueur - 2 >= 3 && _largeur - 2 >= 3)
                    ResizeElementEnseigneV2WhitLimite(_longueur - 2);
                else
                {
                    _Enseigne.SetActive(false);
                    select_Script.ActivVisuel(false);
                    toggleAjoutEnseigne.isOn = false;
                    _enseigneLongueur = 2;
                    _sliderTailleEnseigne.GetComponent<Slider>().value = 2;
                    
                }
            }
      
        }

    }

	//called by GUI element, increment value can be -1 or 1
	public void ResizeLongueurV2()
	{
		int value = (int)_sliderLongueur.GetComponent<Slider>().value;
		if( value >= _minLongueur && value <= _maxLongueur)
		{
			_longueur = value;
			_longueurTxt.text = "Longueur               " + _longueur+"m";
			
			MySingleton.Instance._length = _longueur;
			ResizeScene(_longueur, _largeur);
			
			if( _Reserve.activeInHierarchy )
			{
				
				Vector3 reservePos =_Reserve.transform.position;
				if( reservePos.x - (_Reserve.transform.localScale.x/2.0f) < -(Ground.transform.localScale.x/2.0f)+0.06f)
				{
					_Reserve.transform.position = new Vector3(reservePos.x + 1.0f,reservePos.y,reservePos.z);
					reservePos =_Reserve.transform.position;
				}
				if( reservePos.x + (_Reserve.transform.localScale.x/2.0f) > (Ground.transform.localScale.x/2.0f)-0.06f)
				{
					_Reserve.transform.position = new Vector3(reservePos.x - 1.0f,reservePos.y,reservePos.z);
					reservePos =_Reserve.transform.position;
				}
				
			}
			
			if( value - _lastValueLongueur < 0)
				decals_Tab[0].transform.GetChild(0).GetComponent<Decal_Script>().Reinit(0, -1);

            EnseigneLimite();

        }
		_lastValueLongueur = value;
	}
	public void ResizeLargeurV2()
	{
		int value = (int)_sliderLargeur.GetComponent<Slider>().value;

		if (value >= 3 && value <= 5) 
		{
			_largeur = value;
			_largeurTxt.text = "Largeur                  " + _largeur+"m";
			
			MySingleton.Instance._width = _largeur;
			ResizeScene (_longueur, _largeur);
			
			if( _Reserve.activeInHierarchy )
			{
				
				Vector3 reservePos =_Reserve.transform.position;
				
				if( reservePos.z - (_Reserve.transform.localScale.z/2.0f) < -(Ground.transform.localScale.z/2.0f)+0.06f)
				{
					_Reserve.transform.position = new Vector3(reservePos.x,reservePos.y,reservePos.z + 1.0f);
					reservePos =_Reserve.transform.position;
				}
				if( reservePos.z + (_Reserve.transform.localScale.z/2.0f) > (Ground.transform.localScale.z/2.0f)-0.06f)
				{
					_Reserve.transform.position = new Vector3(reservePos.x,reservePos.y,reservePos.z - 1.0f);
					reservePos =_Reserve.transform.position;
				}
			}
			
			if( value - _lastValueLargeur < 0)
			{
				decals_Tab[1].transform.GetChild(0).GetComponent<Decal_Script>().Reinit(1);
				decals_Tab[2].transform.GetChild(0).GetComponent<Decal_Script>().Reinit(-1);
			}

            EnseigneLimite();
            _lastValueLargeur = value;
		}
		
	}

	//called by GUI element, increment value can be -1 or 1
	public void ResizeLongueur(int increment)
	{

		if( _longueur+increment >= _minLongueur && _longueur+increment <= _maxLongueur)
		{
			_longueur += increment;
			_longueurTxt.text = ""+_longueur+"m";

			MySingleton.Instance._length = _longueur;
			ResizeScene(_longueur, _largeur);

			if( _Reserve.activeInHierarchy )
			{
				
				Vector3 reservePos =_Reserve.transform.position;
				if( reservePos.x - (_Reserve.transform.localScale.x/2.0f) < -(Ground.transform.localScale.x/2.0f)+0.06f)
				{
					_Reserve.transform.position = new Vector3(reservePos.x + 1.0f,reservePos.y,reservePos.z);
					reservePos =_Reserve.transform.position;
				}
				if( reservePos.x + (_Reserve.transform.localScale.x/2.0f) > (Ground.transform.localScale.x/2.0f)-0.06f)
				{
					_Reserve.transform.position = new Vector3(reservePos.x - 1.0f,reservePos.y,reservePos.z);
					reservePos =_Reserve.transform.position;
				}

			}

			if( increment < 0)
				decals_Tab[0].transform.GetChild(0).GetComponent<Decal_Script>().Reinit(0, -1);

		}



	}
	//called by GUI element, increment value can be -1 or 1
	public void ResizeLargeur(int increment)
	{
		if (_largeur+increment >= 3 && _largeur+increment <= 5) 
		{
			_largeur += increment;
			_largeurTxt.text = "" + _largeur+"m";

			MySingleton.Instance._width = _largeur;
			ResizeScene (_longueur, _largeur);

			if( _Reserve.activeInHierarchy )
			{
				
				Vector3 reservePos =_Reserve.transform.position;

				if( reservePos.z - (_Reserve.transform.localScale.z/2.0f) < -(Ground.transform.localScale.z/2.0f)+0.06f)
				{
					_Reserve.transform.position = new Vector3(reservePos.x,reservePos.y,reservePos.z + 1.0f);
					reservePos =_Reserve.transform.position;
				}
				if( reservePos.z + (_Reserve.transform.localScale.z/2.0f) > (Ground.transform.localScale.z/2.0f)-0.06f)
				{
					_Reserve.transform.position = new Vector3(reservePos.x,reservePos.y,reservePos.z - 1.0f);
					reservePos =_Reserve.transform.position;
				}
			}

			if( increment < 0)
			{
				decals_Tab[1].transform.GetChild(0).GetComponent<Decal_Script>().Reinit(1);
				decals_Tab[2].transform.GetChild(0).GetComponent<Decal_Script>().Reinit(-1);
			}

		}

	}

	public void ResizeScene(int Longueur, int Largeur)
	{

		Ground.transform.localScale = new Vector3 (Longueur, 0.1f, Largeur)*2.0f;

		if( Wall_Tab[0].activeInHierarchy){
			Wall_Tab[0].transform.localScale = new Vector3 (Longueur, 2.5f, 0.06f)*2.0f;
			Wall_Tab[0].transform.position = new Vector3 (0, 1.25f, Largeur/2.0f)*2.0f;
		}
	
		if (Wall_Tab [1].activeInHierarchy){
			Wall_Tab [1].transform.localScale = new Vector3 (Largeur, 2.5f, 0.06f)*2.0f;
			Wall_Tab [1].transform.position = new Vector3 (-Longueur / 2.0f, 1.25f, 0)*2.0f;
		}

		if (Wall_Tab [2].activeInHierarchy){
			Wall_Tab [2].transform.localScale = new Vector3 (Largeur, 2.5f, 0.06f)*2.0f;
			Wall_Tab [2].transform.position = new Vector3 (Longueur / 2.0f, 1.25f, 0)*2.0f;
		}

		if (Wall_Tab [3].activeInHierarchy){
			Wall_Tab [3].transform.localScale = new Vector3 (Longueur, 2.5f, 0.06f)*2.0f;
			Wall_Tab [3].transform.position = new Vector3 (0, 1.25f, -Largeur / 2.0f)*2.0f;
		}

		setPosDecals();
		_lightManager_Script.UpdateLight ();

	}



	public void setIsCarre(bool b){
		_isCarre = b;
		if(b)
		{

			_enseigneLargeur = _enseigneLongueur;
			if(decals_Tab[3].activeInHierarchy){
				for (int i =3; i<7;i++){
					decals_Tab[i].SetActive(true);
				}
			}

            _sliderTailleEnseigne.GetComponent<Slider>().minValue = 2;
            _sliderTailleEnseigne.GetComponent<Slider>().maxValue = 3;
            CreateAlutriCarre(_enseigneLongueur);
        }
		else{
			if(_enseigneLongueur == 2){
				_enseigneLongueur = 3;
			}
			_enseigneLargeur = 0;
			if(decals_Tab[5].activeInHierarchy){
				for (int i =5; i<7;i++){
					decals_Tab[i].SetActive(false);
				}
			}

			_sliderTailleEnseigne.GetComponent<Slider> ().minValue = 3;
            _sliderTailleEnseigne.GetComponent<Slider>().maxValue = 5;
            CreateAlutri(_enseigneLongueur);
        }

			
		_enseigneLongueurTxt.text = ""+_enseigneLongueur+"m";
		ResizeEnseigne(_enseigneLongueur, (float)_enseigneLargeur );


	}



	public void ResizeElementLongueurReserveV2()
	{ 

		int value = (int)_sliderLongueurReserve.GetComponent<Slider>().value;


		Vector3 reservePos = _Reserve.transform.position;
		Vector3 reserveScale = _Reserve.transform.localScale;
		
		//Pas le droit d'agrandir si depasse du terrain
		if( reservePos.x + value - 0.06f > Ground.transform.localScale.x/2.0f)
			_pass = false;
		if( reservePos.x - value + 0.06f < -Ground.transform.localScale.x/2.0f)
			_pass = false;
		
		if (!_pass) 
		{
			
			_pass = true;
			
			_Reserve.transform.position = new Vector3(0,2.5f,0);
			reservePos = _Reserve.transform.position;
			if( reservePos.x + value - 0.06f > Ground.transform.localScale.x/2.0f)
				_pass = false;
			if( reservePos.x - value + 0.06f < -Ground.transform.localScale.x/2.0f)
				_pass = false;
		}
		
		if( _pass == true)
		{
			_reserveLongueur = value;
			MySingleton.Instance._longueur_Reserve = _reserveLongueur;
			ResizeReserve (_reserveLongueur, _reserveLargeur);
			
			_lightManager_Script.UpdateLight ();
			LargueurPossible ();
			_longueurReserveTxT.GetComponent<Text>().text = ""+value+"m";
		}

	}
	public void ResizeElementLargeurReserveV2()
	{ 

		int value = (int)_sliderLargeurReserve.GetComponent<Slider>().value;

		if (_pass ) 
		{
			Vector3 reservePos = _Reserve.transform.position;
			Vector3 reserveScale = _Reserve.transform.localScale;
			
			//Pas le droit d'agrandir si depasse du terrain
			if (reservePos.z + value - 0.06f > Ground.transform.localScale.z / 2.0f)
				_pass = false;
			if (reservePos.z - value + 0.06f < -Ground.transform.localScale.z / 2.0f)
				_pass = false;
			
			if (!_pass) 
			{
				
				_pass = true;
				
				_Reserve.transform.position = new Vector3(0,2.5f,0);
				if (reservePos.z + value - 0.06f > Ground.transform.localScale.z / 2.0f)
					_pass = false;
				if (reservePos.z - value + 0.06f < -Ground.transform.localScale.z / 2.0f)
					_pass = false;
			}
			
			if( _pass == true)
			{
				_reserveLargeur = value;
				MySingleton.Instance._largeur_Reserve = _reserveLargeur;
				ResizeReserve (_reserveLongueur, _reserveLargeur);
				
				_lightManager_Script.UpdateLight ();
				LongueurPossible();
				_largueurReserveTxT.GetComponent<Text>().text = ""+value+"m";
			}
			
		}
		_pass = true;
		
	}





	public void ResizeElementLargeurReserve(int largeur)
	{ 
		if (_pass ) 
		{
			Vector3 reservePos = _Reserve.transform.position;
			Vector3 reserveScale = _Reserve.transform.localScale;

			//Pas le droit d'agrandir si depasse du terrain
			if (reservePos.z + largeur - 0.06f > Ground.transform.localScale.z / 2.0f)
				_pass = false;
			if (reservePos.z - largeur + 0.06f < -Ground.transform.localScale.z / 2.0f)
				_pass = false;
		
			if (!_pass) 
			{

				_pass = true;

				_Reserve.transform.position = new Vector3(0,2.5f,0);
				if (reservePos.z + largeur - 0.06f > Ground.transform.localScale.z / 2.0f)
					_pass = false;
				if (reservePos.z - largeur + 0.06f < -Ground.transform.localScale.z / 2.0f)
					_pass = false;
			}

			if( _pass == true)
			{
				_reserveLargeur = largeur;
				MySingleton.Instance._largeur_Reserve = _reserveLargeur;
				ResizeReserve (_reserveLongueur, _reserveLargeur);
			
				_lightManager_Script.UpdateLight ();
				LongueurPossible();
			}

		}
		_pass = true;

	}
	public void ResizeElementLongueurReserve(int longueur)
	{ 

		Vector3 reservePos = _Reserve.transform.position;
		Vector3 reserveScale = _Reserve.transform.localScale;

		//Pas le droit d'agrandir si depasse du terrain
		if( reservePos.x + longueur - 0.06f > Ground.transform.localScale.x/2.0f)
			_pass = false;
		if( reservePos.x - longueur + 0.06f < -Ground.transform.localScale.x/2.0f)
			_pass = false;

		if (!_pass) 
		{

			_pass = true;

			_Reserve.transform.position = new Vector3(0,2.5f,0);
			reservePos = _Reserve.transform.position;
			if( reservePos.x + longueur - 0.06f > Ground.transform.localScale.x/2.0f)
				_pass = false;
			if( reservePos.x - longueur + 0.06f < -Ground.transform.localScale.x/2.0f)
				_pass = false;
		}

		if( _pass == true)
		{
			_reserveLongueur = longueur;
			MySingleton.Instance._longueur_Reserve = _reserveLongueur;
			ResizeReserve (_reserveLongueur, _reserveLargeur);

			_lightManager_Script.UpdateLight ();
			LargueurPossible ();
		}

	}
	
	//called by GUI element, increment value can be -1 or 1
	public void ResizeReserve(int Longueur, float Largeur )
	{

		if( _Reserve.activeInHierarchy )
		{

			_Door.transform.parent = transform;

			_Reserve.transform.localScale = new Vector3 (Longueur, 2.5f, Largeur)*2.0f;
			_Door.GetComponent<Door_Script> ().ReinitDoor ();

			_Door.transform.parent = _Reserve.transform;
            
        }

	}

    void CreateAlutri(int longueur)
    {

        if (_alutri_Tab != null)
        {
            for (int i = 0; i < _alutri_Tab.Length; i++)
            {
                DestroyImmediate(_alutri_Tab[i]);
            }
        }

        _alutri_Tab = new GameObject[longueur];



        GameObject newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
        newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
        newAlutri.transform.position = new Vector3(2, 10.29f, 0);
        newAlutri.SetActive(true);
        newAlutri.layer = 12;

         _alutri_Tab[0] = newAlutri;



        newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
        newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
        newAlutri.transform.position = new Vector3(0, 10.29f, 0);
        newAlutri.SetActive(true);
        newAlutri.layer = 12;

        _alutri_Tab[1] = newAlutri;



        newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
        newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
        newAlutri.transform.position = new Vector3(-2, 10.29f, 0);
        newAlutri.SetActive(true);
        newAlutri.layer = 12;

        _alutri_Tab[2] = newAlutri;


        if (longueur >= 4)
        {

            _alutri_Tab[0].transform.position = new Vector3(3, 10.29f, 0);
            _alutri_Tab[1].transform.position = new Vector3(1, 10.29f, 0);
            _alutri_Tab[2].transform.position = new Vector3(-1, 10.29f, 0);

            newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
            newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
            newAlutri.transform.position = new Vector3(-3, 10.29f, 0);
            newAlutri.SetActive(true);
            newAlutri.layer = 12;

            _alutri_Tab[3] = newAlutri;

        }
        if (longueur >= 5)
        {


            _alutri_Tab[0].transform.position = new Vector3(4, 10.29f, 0);
            _alutri_Tab[1].transform.position = new Vector3(2, 10.29f, 0);
            _alutri_Tab[2].transform.position = new Vector3(0, 10.29f, 0);
            _alutri_Tab[3].transform.position = new Vector3(-2, 10.29f, 0);



            newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
            newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
            newAlutri.transform.position = new Vector3(-4, 10.29f, 0);
            newAlutri.SetActive(true);
            newAlutri.layer = 12;

            _alutri_Tab[4] = newAlutri;



            //newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
            //newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
            //newAlutri.transform.position = new Vector3(-5, 10.29f, 0);
            //newAlutri.SetActive(true);
            //newAlutri.layer = 12;

            //_alutri_Tab[5] = newAlutri;


        }

        if (_alutri_Tab != null)
        {
            for (int i = 0; i < _alutri_Tab.Length; i++)
            {
                _alutri_Tab[i].transform.parent = _Enseigne.transform;
            }
        }

    }

    void CreateAlutriCarre(int longueur)
    {
        
        if (_alutri_Tab != null)
        {
            for (int i = 0; i < _alutri_Tab.Length; i++)
            {
                DestroyImmediate(_alutri_Tab[i]);
            }
        }

        _alutri_Tab = new GameObject[longueur*4];


        ////////////////////////////////////////MAIN
        GameObject newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
        newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
        newAlutri.transform.position = new Vector3(1, 10.29f, -longueur );
        newAlutri.SetActive(true);
        newAlutri.layer = 12;

        _alutri_Tab[0] = newAlutri;



        newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
        newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
        newAlutri.transform.position = new Vector3(-1, 10.29f, -longueur );
        newAlutri.SetActive(true);
        newAlutri.layer = 12;

        _alutri_Tab[1] = newAlutri;



        ////////////////////////////////////////FOND
        newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
        newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
        newAlutri.transform.position = new Vector3(1, 10.29f, longueur);
        newAlutri.SetActive(true);
        newAlutri.layer = 12;

        _alutri_Tab[2] = newAlutri;



        newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
        newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
        newAlutri.transform.position = new Vector3(-1, 10.29f, longueur);
        newAlutri.SetActive(true);
        newAlutri.layer = 12;

        _alutri_Tab[3] = newAlutri;


        ////////////////////////////////////////GAUCHE
        newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
        newAlutri.transform.eulerAngles = new Vector3(-90, 0, 0);
        newAlutri.transform.position = new Vector3(-longueur, 10.29f, 1);
        newAlutri.SetActive(true);
        newAlutri.layer = 12;

        _alutri_Tab[4] = newAlutri;



        newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
        newAlutri.transform.eulerAngles = new Vector3(-90, 0, 0);
        newAlutri.transform.position = new Vector3(-longueur, 10.29f, -1);
        newAlutri.SetActive(true);
        newAlutri.layer = 12;

        _alutri_Tab[5] = newAlutri;


        ////////////////////////////////////////DROITE
        newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
        newAlutri.transform.eulerAngles = new Vector3(-90, 0, 0);
        newAlutri.transform.position = new Vector3(longueur, 10.29f, 1);
        newAlutri.SetActive(true);
        newAlutri.layer = 12;

        _alutri_Tab[6] = newAlutri;



        newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
        newAlutri.transform.eulerAngles = new Vector3(-90, 0, 0);
        newAlutri.transform.position = new Vector3(longueur, 10.29f, -1);
        newAlutri.SetActive(true);
        newAlutri.layer = 12;

        _alutri_Tab[7] = newAlutri;


        if (longueur >= 3)
        {
            ////////////////////////////////////////MAIN
            newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
            newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
            newAlutri.SetActive(true);
            newAlutri.layer = 12;

            _alutri_Tab[8] = newAlutri;

            _alutri_Tab[0].transform.position = new Vector3(2, 10.29f, -longueur);
            _alutri_Tab[1].transform.position = new Vector3(0, 10.29f, -longueur);
            _alutri_Tab[8].transform.position = new Vector3(-2, 10.29f, -longueur);

            ////////////////////////////////////////FOND
            newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
            newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
            newAlutri.SetActive(true);
            newAlutri.layer = 12;

            _alutri_Tab[9] = newAlutri;

            _alutri_Tab[2].transform.position = new Vector3(2, 10.29f, longueur);
            _alutri_Tab[3].transform.position = new Vector3(0, 10.29f, longueur);
            _alutri_Tab[9].transform.position = new Vector3(-2, 10.29f, longueur);

            ////////////////////////////////////////GAUCHE
            newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
            newAlutri.transform.eulerAngles = new Vector3(-90, 0, 0);
            newAlutri.SetActive(true);
            newAlutri.layer = 12;

            _alutri_Tab[10] = newAlutri;

            _alutri_Tab[4].transform.position = new Vector3(-longueur, 10.29f, 2);
            _alutri_Tab[5].transform.position = new Vector3(-longueur, 10.29f, 0);
            _alutri_Tab[10].transform.position = new Vector3(-longueur, 10.29f, -2);

            ////////////////////////////////////////DROITE
            newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
            newAlutri.transform.eulerAngles = new Vector3(-90, 0, 0);
            newAlutri.SetActive(true);
            newAlutri.layer = 12;

            _alutri_Tab[11] = newAlutri;

            _alutri_Tab[6].transform.position = new Vector3(longueur, 10.29f, 2);
            _alutri_Tab[7].transform.position = new Vector3(longueur, 10.29f, 0);
            _alutri_Tab[11].transform.position = new Vector3(longueur, 10.29f, -2);

        }
        if (longueur >= 4)
        {
            ////////////////////////////////////////MAIN
            newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
            newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
            newAlutri.SetActive(true);
            newAlutri.layer = 12;

            _alutri_Tab[12] = newAlutri;


            _alutri_Tab[0].transform.position = new Vector3(3, 10.29f, -longueur);
            _alutri_Tab[1].transform.position = new Vector3(1, 10.29f, -longueur);
            _alutri_Tab[8].transform.position = new Vector3(-1, 10.29f, -longueur);
            _alutri_Tab[12].transform.position = new Vector3(-3, 10.29f, -longueur);


            ////////////////////////////////////////FOND
            newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
            newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
            newAlutri.SetActive(true);
            newAlutri.layer = 12;

            _alutri_Tab[13] = newAlutri;

            _alutri_Tab[2].transform.position = new Vector3(3, 10.29f, longueur);
            _alutri_Tab[3].transform.position = new Vector3(1, 10.29f, longueur);
            _alutri_Tab[9].transform.position = new Vector3(-1, 10.29f, longueur);
            _alutri_Tab[13].transform.position = new Vector3(-3, 10.29f, longueur);

            ////////////////////////////////////////GAUCHE
            newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
            newAlutri.transform.eulerAngles = new Vector3(-90, 0, 0);
            newAlutri.SetActive(true);
            newAlutri.layer = 12;

            _alutri_Tab[14] = newAlutri;

            _alutri_Tab[4].transform.position = new Vector3(-longueur, 10.29f, 3);
            _alutri_Tab[5].transform.position = new Vector3(-longueur, 10.29f, 1);
            _alutri_Tab[10].transform.position = new Vector3(-longueur, 10.29f, -1);
            _alutri_Tab[14].transform.position = new Vector3(-longueur, 10.29f, -3);

            ////////////////////////////////////////DROITE
            newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
            newAlutri.transform.eulerAngles = new Vector3(-90, 0, 0);
            newAlutri.SetActive(true);
            newAlutri.layer = 12;

            _alutri_Tab[15] = newAlutri;

            _alutri_Tab[6].transform.position = new Vector3(longueur, 10.29f, 3);
            _alutri_Tab[7].transform.position = new Vector3(longueur, 10.29f, 1);
            _alutri_Tab[11].transform.position = new Vector3(longueur, 10.29f, -1);
            _alutri_Tab[15].transform.position = new Vector3(longueur, 10.29f, -3);
        }
        if (longueur >= 5)
        {
            ////////////////////////////////////////MAIN
            newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
            newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
            newAlutri.SetActive(true);
            newAlutri.layer = 12;

            _alutri_Tab[16] = newAlutri;


            _alutri_Tab[0].transform.position = new Vector3(4, 10.29f, -longueur);
            _alutri_Tab[1].transform.position = new Vector3(2, 10.29f, -longueur);
            _alutri_Tab[8].transform.position = new Vector3(0, 10.29f, -longueur);
            _alutri_Tab[12].transform.position = new Vector3(-2, 10.29f, -longueur);
            _alutri_Tab[16].transform.position = new Vector3(-4, 10.29f, -longueur);

            ////////////////////////////////////////FOND
            newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
            newAlutri.transform.eulerAngles = new Vector3(-90, 90, 0);
            newAlutri.SetActive(true);
            newAlutri.layer = 12;

            _alutri_Tab[17] = newAlutri;

            _alutri_Tab[2].transform.position = new Vector3(4, 10.29f, longueur);
            _alutri_Tab[3].transform.position = new Vector3(2, 10.29f, longueur);
            _alutri_Tab[9].transform.position = new Vector3(0, 10.29f, longueur);
            _alutri_Tab[13].transform.position = new Vector3(-2, 10.29f, longueur);
            _alutri_Tab[17].transform.position = new Vector3(-4, 10.29f, longueur);

            ////////////////////////////////////////GAUCHE
            newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
            newAlutri.transform.eulerAngles = new Vector3(-90, 0, 0);
            newAlutri.SetActive(true);
            newAlutri.layer = 12;

            _alutri_Tab[18] = newAlutri;

            _alutri_Tab[4].transform.position = new Vector3(-longueur, 10.29f, 4);
            _alutri_Tab[5].transform.position = new Vector3(-longueur, 10.29f, 2);
            _alutri_Tab[10].transform.position = new Vector3(-longueur, 10.29f, 0);
            _alutri_Tab[14].transform.position = new Vector3(-longueur, 10.29f, -2);
            _alutri_Tab[18].transform.position = new Vector3(-longueur, 10.29f, -4);

            ////////////////////////////////////////DROITE
            newAlutri = Instantiate(_alutri_model, transform.position, transform.rotation) as GameObject;
            newAlutri.transform.eulerAngles = new Vector3(-90, 0, 0);
            newAlutri.SetActive(true);
            newAlutri.layer = 12;

            _alutri_Tab[19] = newAlutri;

            _alutri_Tab[6].transform.position = new Vector3(longueur, 10.29f, 4);
            _alutri_Tab[7].transform.position = new Vector3(longueur, 10.29f, 2);
            _alutri_Tab[11].transform.position = new Vector3(longueur, 10.29f, 0);
            _alutri_Tab[15].transform.position = new Vector3(longueur, 10.29f, -2);
            _alutri_Tab[19].transform.position = new Vector3(longueur, 10.29f, -4);
        }

        if (_alutri_Tab != null)
        {
            for (int i = 0; i < _alutri_Tab.Length; i++)
            {
                _alutri_Tab[i].transform.parent = _Enseigne.transform;
            }
        }

    }

    public void ResizeElementEnseigneV2WhitLimite(int limite)
    {
        if( _Enseigne.activeInHierarchy )
        {
            int value = limite;

            if (_isCarre)
            {

                _enseigneLongueur = value;
                _enseigneLargeur = _enseigneLongueur;
                CreateAlutriCarre(_enseigneLongueur);
            }
            else
            {

                _enseigneLongueur = value;
                _enseigneLargeur = 0;
                //print(value);
                CreateAlutri(_enseigneLongueur);
            }
            _enseigneLongueurTxt.text = "" + _enseigneLongueur + "m";
            ResizeEnseigne(_enseigneLongueur, (float)_enseigneLargeur);

            if (value - _lastValueEnseigne < 0)
            {
                decals_Tab[3].transform.GetChild(0).GetComponent<Decal_Script>().Reinit(0, 1);
                decals_Tab[4].transform.GetChild(0).GetComponent<Decal_Script>().Reinit(0, -1);
                decals_Tab[5].transform.GetChild(0).GetComponent<Decal_Script>().Reinit(1);
                decals_Tab[6].transform.GetChild(0).GetComponent<Decal_Script>().Reinit(-1);
            }

            _lastValueEnseigne = value;
        }
    }

    public void ResizeElementEnseigneV2()
	{ 
		int value = (int)_sliderTailleEnseigne.GetComponent<Slider>().value;
        
        if (_isCarre)
		{
           
            _enseigneLongueur = value;
			_enseigneLargeur = _enseigneLongueur;
            CreateAlutriCarre(_enseigneLongueur);
        }
		else
		{

			_enseigneLongueur = value;
			_enseigneLargeur = 0;
            print(value);
            CreateAlutri(_enseigneLongueur);
        }
		_enseigneLongueurTxt.text = ""+_enseigneLongueur+"m";
		ResizeEnseigne(_enseigneLongueur, (float)_enseigneLargeur );
		
		if( value - _lastValueEnseigne < 0)
		{
			decals_Tab [3].transform.GetChild (0).GetComponent<Decal_Script> ().Reinit (0, 1);
			decals_Tab [4].transform.GetChild (0).GetComponent<Decal_Script> ().Reinit (0, -1);
			decals_Tab [5].transform.GetChild (0).GetComponent<Decal_Script> ().Reinit (1);
			decals_Tab [6].transform.GetChild (0).GetComponent<Decal_Script> ().Reinit (-1);
		}

		_lastValueEnseigne = value;
	}

	//called by GUI element, increment value can be -1 or 1
	public void ResizeElementEnseigne(int increment)
	{
        _sliderTailleEnseigne.GetComponent<Slider>().value = increment;
        int value = increment;

        if (_isCarre)
        {

            _enseigneLongueur = value;
            _enseigneLargeur = _enseigneLongueur;
            CreateAlutriCarre(_enseigneLongueur);
        }
        else
        {

            _enseigneLongueur = value;
            _enseigneLargeur = 0;
            print(value);
            CreateAlutri(_enseigneLongueur);
        }
        _enseigneLongueurTxt.text = "" + _enseigneLongueur + "m";
        ResizeEnseigne(_enseigneLongueur, (float)_enseigneLargeur);

        if (value - _lastValueEnseigne < 0)
        {
            decals_Tab[3].transform.GetChild(0).GetComponent<Decal_Script>().Reinit(0, 1);
            decals_Tab[4].transform.GetChild(0).GetComponent<Decal_Script>().Reinit(0, -1);
            decals_Tab[5].transform.GetChild(0).GetComponent<Decal_Script>().Reinit(1);
            decals_Tab[6].transform.GetChild(0).GetComponent<Decal_Script>().Reinit(-1);
        }

        _lastValueEnseigne = value;

    }

	//called by GUI element, increment value can be -1 or 1
	public void ResizeEnseigne(int Longueur, float Largeur )
	{
		if(Largeur == 0){
			Largeur = 0.001f;
		}

		if( EnseigneWalls[0].activeInHierarchy){
			EnseigneWalls[0].transform.localScale = new Vector3 (Longueur, 1f, 0.03f)*2.0f;
			EnseigneWalls[0].transform.position = new Vector3 (0, 4.5f, Largeur/2.0f)*2.0f;
		}
		
		if (EnseigneWalls [1].activeInHierarchy){
			EnseigneWalls [1].transform.localScale = new Vector3 (Longueur, 1f, 0.03f)*2.0f;
			EnseigneWalls [1].transform.position = new Vector3 (0, 4.5f, -Largeur / 2.0f)*2.0f;
		}
		
		if (EnseigneWalls [2].activeInHierarchy){
			EnseigneWalls [2].transform.localScale = new Vector3 (Largeur, 1f, 0.03f)*2.0f;
            EnseigneWalls [2].transform.position = new Vector3 (Longueur / 2f, 4.5f, 0)*2.0f;
		}
		
		if (EnseigneWalls [3].activeInHierarchy){
			EnseigneWalls [3].transform.localScale = new Vector3 (Largeur, 1f, 0.03f)*2.0f;
			EnseigneWalls [3].transform.position = new Vector3 (-Longueur / 2f, 4.5f, 0)*2.0f;
		}
		setPosDecals();
		_lightManager_Script.UpdateLight ();
	}


	public void activateEnseigne(){
		ResizeEnseigne(_enseigneLongueur,_enseigneLargeur);
	}

	public void MoveMenu(bool _Move)
	{

		GameObject EnseigneMenu = GameObject.FindWithTag ("EnseigneMenu");

		if( _Move )
		{

			EnseigneMenu.GetComponent<RectTransform>().offsetMin = new Vector2(0, -70);//left | bottom
			EnseigneMenu.GetComponent<RectTransform>().offsetMax = new Vector2(0, -70);//right | top

		}
		else
		{

			EnseigneMenu.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
			EnseigneMenu.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

        }
    }


}
