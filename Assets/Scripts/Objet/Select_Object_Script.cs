using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Select_Object_Script : MonoBehaviour {

	public SceneManager_Script _SceneManager_Script;
    public GameObject _select_GO;

    Vector3 _lastMousePos;
    bool _NoDeselected;
    public bool _block;
    public GameObject MainMenu;
    public GameObject SideMenu;
    public GameObject OK;
    public GameObject PrixDetail;
    public GameObject SecondMenu;
    public GameObject Surface;
    public GameObject Formulaire;
    public GameObject Valider;
    public GameObject Envoyer;
    public GameObject APropos;
    public GameObject AideCloison;
    public GameObject AideReserve;
    public GameObject AideEnseigne;
    public GameObject AideMultiFace;
    public GameObject AideMultiFace2;
	public GameObject AideGlisserDeposer;
	public GameObject AideDeplacerVisuelCloison;
	public GameObject AideDeplacerVisuelEnseigne;
	public GameObject AideDeplacerVisuelEnseigneBack;
    public GameObject SliderMain;


    bool activAideCloison;
    bool activAideReserve;
    bool activAideEnseigne;
    bool activAideMutiFace;
    bool activAideMutiFace2;
	bool activAideGlisserDeposer;
	bool activAideDeplacerVisuel;

    public GameObject _decalCollider_1;
    public GameObject _decalCollider_2;

    public Material _Mat_Opaque;
    public Material _Mat_Transparent;

    public Material _Mat_Opaque_Wall;
    public Material _Mat_Transparent_Wall;

    public Material _Mat_Opaque_Reserve;
    public Material _Mat_Transparent_Reserve;

    public Material _Mat_Opaque_Enseigne;
    public Material _Mat_Transparent_Enseigne;

    public GameObject _lastCloisonSelect;
    public GameObject _lastDecalSelect;
    public GameObject _lastEnseigneSelect;

    float valueAnim;
    bool camAnim;

	public Toggle tEnseigne;

    // Use this for initialization
    void Start()
    {
        _block = false;
        _select_GO = null;
        _NoDeselected = false;
        _lastMousePos = Input.mousePosition;

        _SceneManager_Script = GameObject.Find("SceneManager").GetComponent<SceneManager_Script>();
        activAideCloison = true;
        activAideReserve = true;
        activAideEnseigne = true;
        activAideMutiFace = true;
		activAideMutiFace2 = true;
		activAideGlisserDeposer = true;
		activAideDeplacerVisuel = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (SecondMenu.activeInHierarchy==false)
        {
            _SceneManager_Script.WhiteTextMenu(MainMenu.transform.GetChild(5).transform.GetChild(0).GetComponent<Text>());
            _SceneManager_Script.WhiteTextMenu(MainMenu.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>());
            _SceneManager_Script.WhiteTextMenu(MainMenu.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>());
            _SceneManager_Script.WhiteTextMenu(MainMenu.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>());
            _SceneManager_Script.WhiteTextMenu(MainMenu.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>());
			_SceneManager_Script.WhiteTextMenu(MainMenu.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>());
        }
        if (!_block)
            SelectObject();
        if (_select_GO != null)
        {

            if (_select_GO.GetComponent<InteracibleObject_Script>())
            {

                _select_GO.GetComponent<InteracibleObject_Script>().UpdateAll();

            }

            _lastMousePos = Input.mousePosition;
            //print(_select_GO.name);

            lastCloison();
            lastEnseigne();

            if(_select_GO.transform.parent.name.StartsWith("Parent"))
            {

                ReinitMenuDecal();
            }
        }

        CamAnim();

    }

    public void ActivAideCloison(bool gauche)
    {

        if(activAideCloison)
        {
            AideCloison.SetActive(true);
            activAideCloison = false;

            _SceneManager_Script.CameraHomme.gameObject.SetActive(false);
            _SceneManager_Script.CameraMain.gameObject.SetActive(true);
            SliderMain.SetActive(true);

            if (gauche)
            {
                valueAnim = 240;
               // _SceneManager_Script.CameraMain.GetComponent<CameraControl_Script>().slideMoveCam.value = 230;
            }   
            else
            {
                valueAnim = 300;
               // _SceneManager_Script.CameraMain.GetComponent<CameraControl_Script>().slideMoveCam.value = 290;
            }
               

            _SceneManager_Script.CameraMain.GetComponent<CameraControl_Script>().Slide();
            camAnim = true;
        }
        time = Time.time;
    }

	public void ActivAideReserve()
	{
		
		if (activAideReserve)
		{
			AideReserve.SetActive(true);
			activAideReserve = false;
			
			_SceneManager_Script.CameraHomme.gameObject.SetActive(false);
			_SceneManager_Script.CameraMain.gameObject.SetActive(true);
			SliderMain.SetActive(true);
			
			valueAnim = 270;
			
			
			_SceneManager_Script.CameraMain.GetComponent<CameraControl_Script>().Slide();
			camAnim = true;
		}
		time = Time.time;
	}

	public void ActivAideDeplacerVisuel()
	{
		
		if (activAideDeplacerVisuel)
		{

			if(_select_GO.name.StartsWith("Decal"))
				AideDeplacerVisuelCloison.SetActive(true);
			else if(_select_GO.name == "EnseigneBack")
				AideDeplacerVisuelEnseigneBack.SetActive(true);
			else
				AideDeplacerVisuelEnseigne.SetActive(true);

			activAideDeplacerVisuel = false;
			
			_SceneManager_Script.CameraHomme.gameObject.SetActive(false);
			_SceneManager_Script.CameraMain.gameObject.SetActive(true);
			SliderMain.SetActive(true);

			//camAnim = true;
		}
		time = Time.time;
	}
	
    public void ActivAideEnseigne()
    {
		if( !tEnseigne.IsInteractable () )
			activAideEnseigne = true;
		else
			activAideEnseigne = false;
		if (activAideEnseigne ) {
			AideEnseigne.SetActive (true);
			activAideEnseigne = false;

			_SceneManager_Script.CameraHomme.gameObject.SetActive (false);
			_SceneManager_Script.CameraMain.gameObject.SetActive (true);
			SliderMain.SetActive (true);

			valueAnim = 240;


			_SceneManager_Script.CameraMain.GetComponent<CameraControl_Script> ().Slide ();
			camAnim = true;
		}
		print ("activAideEnseigne : "+activAideEnseigne);

        time = Time.time;
    }

    public void ActivAideMultiFace()
    {

        if (activAideMutiFace)
        {
            AideMultiFace.SetActive(true);
            activAideMutiFace = false;

            _SceneManager_Script.CameraHomme.gameObject.SetActive(false);
            _SceneManager_Script.CameraMain.gameObject.SetActive(true);
            SliderMain.SetActive(true);

            valueAnim = 300;


            _SceneManager_Script.CameraMain.GetComponent<CameraControl_Script>().Slide();
            camAnim = true;
        }
        time = Time.time;
    }

    public void ActivAideMultiFace2()
    {

        if (activAideMutiFace2)
        {
            AideMultiFace2.SetActive(true);
            activAideMutiFace2 = false;

            _SceneManager_Script.CameraHomme.gameObject.SetActive(false);
            _SceneManager_Script.CameraMain.gameObject.SetActive(true);
            SliderMain.SetActive(true);

            valueAnim = 240;


            _SceneManager_Script.CameraMain.GetComponent<CameraControl_Script>().Slide();
            camAnim = true;
        }
        time = Time.time;
    }

    public void ActivAideGlisserDeposer()
    {

        if (activAideGlisserDeposer)
        {


            AideGlisserDeposer.SetActive(true);
            activAideGlisserDeposer = false;

            _SceneManager_Script.CameraHomme.gameObject.SetActive(false);
            _SceneManager_Script.CameraMain.gameObject.SetActive(true);
            SliderMain.SetActive(true);

			if(_select_GO.name == "DecalLeft")
				valueAnim = 300;
			else if(_select_GO.name == "DecalRight")
            	valueAnim = 240;
			else
				valueAnim = 270;

            _SceneManager_Script.CameraMain.GetComponent<CameraControl_Script>().Slide();
            camAnim = true;
        }
        time = Time.time;
    }

    float time;
    public void CamAnim()
    {
        if(camAnim)
        {
            
            _SceneManager_Script.CameraMain.GetComponent<CameraControl_Script>().slideMoveCam.value = Mathf.Lerp(_SceneManager_Script.CameraMain.GetComponent<CameraControl_Script>().slideMoveCam.value, valueAnim, Time.time - time) ;
            if(_SceneManager_Script.CameraMain.GetComponent<CameraControl_Script>().slideMoveCam.value >= valueAnim + 0.1f && _SceneManager_Script.CameraMain.GetComponent<CameraControl_Script>().slideMoveCam.value <= valueAnim - 0.1f)
                camAnim = false;
            if (Input.GetMouseButtonDown(0))
                camAnim = false;
        }
    }


    public void ReinitMenuDecal()
    {
        SideMenu.transform.GetChild(2).transform.GetChild(3).transform.FindChild("Slider Longueur").GetComponent<Slider>().value = _select_GO.GetComponent<Decal_Script>()._scale;
        SideMenu.transform.GetChild(5).transform.GetChild(1).transform.FindChild("Slider Longueur").GetComponent<Slider>().value = _select_GO.GetComponent<Decal_Script>()._scale;

        SideMenu.transform.GetChild(2).transform.GetChild(3).transform.FindChild("Slider rotation").GetComponent<Slider>().value = _select_GO.GetComponent<Decal_Script>()._rotation;
        SideMenu.transform.GetChild(5).transform.GetChild(1).transform.FindChild("Slider rotation").GetComponent<Slider>().value = _select_GO.GetComponent<Decal_Script>()._rotation;
    }

    void lastEnseigne()
    {
        if (_select_GO.name.StartsWith("Enseigne"))
        {
            if (_select_GO.name == "EnseigneBack")
            {
                _lastDecalSelect = GetComponent<SceneManager_Script>().decals_Tab[3].transform.GetChild(0).gameObject;
                _lastEnseigneSelect = GetComponent<SceneManager_Script>()._Enseigne.transform.GetChild(0).gameObject;
            }
            else if (_select_GO.name == "EnseigneDroite" || _select_GO.name == "EnseigneLeft")
            {
                _lastDecalSelect = GetComponent<SceneManager_Script>().decals_Tab[5].transform.GetChild(0).gameObject;
                _lastEnseigneSelect = GetComponent<SceneManager_Script>()._Enseigne.transform.GetChild(2).gameObject;
            }
            else if (_select_GO.name == "EnseigneGauche" || _select_GO.name == "EnseigneRight")
            {
                _lastDecalSelect = GetComponent<SceneManager_Script>().decals_Tab[6].transform.GetChild(0).gameObject;
                _lastEnseigneSelect = GetComponent<SceneManager_Script>()._Enseigne.transform.GetChild(3).gameObject;
            }
            else if (_select_GO.name == "EnseigneFront")
            {
                _lastDecalSelect = GetComponent<SceneManager_Script>().decals_Tab[4].transform.GetChild(0).gameObject;
                _lastEnseigneSelect = GetComponent<SceneManager_Script>()._Enseigne.transform.GetChild(1).gameObject;
            }

        }
        
    }

    public void ChangeNumTex(int i)
    {
        if (_select_GO.transform.parent.name.StartsWith("Parent"))
        {
            if (_select_GO.name == "EnseigneBack")
            {
                _SceneManager_Script._Enseigne.transform.GetChild(0).GetComponent<Texture_Script>().ChangeNumTex(0);
            }
            else if (_select_GO.name == "EnseigneFront")
            {
                _SceneManager_Script._Enseigne.transform.GetChild(1).GetComponent<Texture_Script>().ChangeNumTex(0);
            }
            else if (_select_GO.name == "EnseigneRight")
            {
                _SceneManager_Script._Enseigne.transform.GetChild(3).GetComponent<Texture_Script>().ChangeNumTex(0);
            }
            else if (_select_GO.name == "EnseigneLeft")
            {
                _SceneManager_Script._Enseigne.transform.GetChild(2).GetComponent<Texture_Script>().ChangeNumTex(0);
            }
            else if (_select_GO.name == "DecalLeft")
            {
                _SceneManager_Script.Wall_Tab[1].GetComponent<Texture_Script>().ChangeNumTex(3);
            }
            else if (_select_GO.name == "DecalRight")
            {
                _SceneManager_Script.Wall_Tab[2].GetComponent<Texture_Script>().ChangeNumTex(3);
            }
            else if (_select_GO.name == "DecalMain")
            {
                _SceneManager_Script.Wall_Tab[0].GetComponent<Texture_Script>().ChangeNumTex(3);
            }
        }
        else
            _select_GO.GetComponent<Texture_Script>().ChangeNumTex(i);
    }

    void lastCloison()
    {
        if (_select_GO.name.StartsWith("Wall"))
        {
            if (_select_GO.name == "Wall_Main")
            {
                _lastDecalSelect = GetComponent<SceneManager_Script>().decals_Tab[0].transform.GetChild(0).gameObject;
                _lastCloisonSelect = GetComponent<SceneManager_Script>().Wall_Tab[0];
            }
            else if (_select_GO.name == "Wall_Left")
            {
                _lastDecalSelect = GetComponent<SceneManager_Script>().decals_Tab[1].transform.GetChild(0).gameObject;
                _lastCloisonSelect = GetComponent<SceneManager_Script>().Wall_Tab[1];
            }
            else if (_select_GO.name == "Wall_Right")
            {
                _lastDecalSelect = GetComponent<SceneManager_Script>().decals_Tab[2].transform.GetChild(0).gameObject;
                _lastCloisonSelect = GetComponent<SceneManager_Script>().Wall_Tab[2];
            }
        }
        else if (_select_GO.name.StartsWith("Decal"))
        {
            if (_select_GO.name == "DecalMain")
            {
                _lastDecalSelect = GetComponent<SceneManager_Script>().decals_Tab[0].transform.GetChild(0).gameObject;
                _lastCloisonSelect = GetComponent<SceneManager_Script>().Wall_Tab[0];
            }
            else if (_select_GO.name == "DecalLeft")
            {
                _lastDecalSelect = GetComponent<SceneManager_Script>().decals_Tab[1].transform.GetChild(0).gameObject;
                _lastCloisonSelect = GetComponent<SceneManager_Script>().Wall_Tab[1];
            }
            else if (_select_GO.name == "DecalRight")
            {
                _lastDecalSelect = GetComponent<SceneManager_Script>().decals_Tab[2].transform.GetChild(0).gameObject;
                _lastCloisonSelect = GetComponent<SceneManager_Script>().Wall_Tab[2];
            }
        }
    }

    public void getLastdecalSelect()
    {

        SelectObjectViaMenu(_lastDecalSelect);
    }
    public void getLastCloisonSelect()
    {
 
        SelectObjectViaMenu(_lastCloisonSelect);
    }
    public void getLastEnseigneSelect()
    {

        SelectObjectViaMenu(_lastEnseigneSelect);
    }

    public void ChangeSideMenuNum(int num)
    {
        if (_select_GO != null)
            _select_GO.GetComponent<InteracibleObject_Script>().menuSideNum = num;
    }

    public void desactiveDecal() {
        _select_GO.transform.parent.gameObject.SetActive(false);
    }

    public void desactiveDecalEnseigne()
    {
        _lastDecalSelect.transform.parent.gameObject.SetActive(false);
        getLastEnseigneSelect();
    }


    public void ActivVisuel(bool _bool)
    {
        if (!_bool)
        {
            _SceneManager_Script.decals_Tab[3].SetActive(false);
            _SceneManager_Script.decals_Tab[4].SetActive(false);
            _SceneManager_Script.decals_Tab[5].SetActive(false);
            _SceneManager_Script.decals_Tab[6].SetActive(false);
        }
        else
        {

            if (!_SceneManager_Script._isCarre)
            {

                _SceneManager_Script.decals_Tab[3].SetActive(true);
                _SceneManager_Script.decals_Tab[4].SetActive(true);

                _SceneManager_Script.decals_Tab[3].transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1,1,1,1);
                _SceneManager_Script.decals_Tab[4].transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1,1,1,1);
                _SceneManager_Script.decals_Tab[3].transform.GetChild(0).GetComponent<Decal_Script>()._saveColor = new Color(1, 1, 1, 1);
                _SceneManager_Script.decals_Tab[4].transform.GetChild(0).GetComponent<Decal_Script>()._saveColor = new Color(1, 1, 1, 1);
            }
            else if (_SceneManager_Script._isCarre)
            {

                _SceneManager_Script.decals_Tab[3].SetActive(true);
                _SceneManager_Script.decals_Tab[4].SetActive(true);
                _SceneManager_Script.decals_Tab[5].SetActive(true);
                _SceneManager_Script.decals_Tab[6].SetActive(true);

                _SceneManager_Script.decals_Tab[3].transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                _SceneManager_Script.decals_Tab[4].transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                _SceneManager_Script.decals_Tab[5].transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
                _SceneManager_Script.decals_Tab[6].transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);

                _SceneManager_Script.decals_Tab[3].transform.GetChild(0).GetComponent<Decal_Script>()._saveColor = new Color(1, 1, 1, 1);
                _SceneManager_Script.decals_Tab[4].transform.GetChild(0).GetComponent<Decal_Script>()._saveColor = new Color(1, 1, 1, 1);
                _SceneManager_Script.decals_Tab[5].transform.GetChild(0).GetComponent<Decal_Script>()._saveColor = new Color(1, 1, 1, 1);
                _SceneManager_Script.decals_Tab[6].transform.GetChild(0).GetComponent<Decal_Script>()._saveColor = new Color(1, 1, 1, 1);

            }

        }
    }


    public void activeDecal() {
        
    GameObject decal;
        int imax;//si coté ou pas 
        if (_SceneManager_Script._isCarre) {
            imax = 7;
        } else {
            imax = 5;
        }
        switch (_select_GO.name) {
            case "Wall_Main":
                decal = _SceneManager_Script.decals_Tab[0];
                if (decal.activeInHierarchy) {
                    decal.SetActive(false);
                } else {
                    decal.SetActive(true);
                }
                break;
            case "Wall_Left":
                decal = _SceneManager_Script.decals_Tab[1];
                if (decal.activeInHierarchy) {
                    decal.SetActive(false);
                } else {
                    decal.SetActive(true);
                }
                break;
            case "Wall_Right":
                decal = _SceneManager_Script.decals_Tab[2];
                if (decal.activeInHierarchy) {
                    decal.SetActive(false);
                } else {
                    decal.SetActive(true);
                }
                break;
            case "EnseigneBack":
                decal = _SceneManager_Script.decals_Tab[3];
                if (decal.activeInHierarchy)
                {
                    decal.SetActive(false);
                }
                else
                {
                    decal.SetActive(true);
                }
                break;
            case "EnseigneFront":
                decal = _SceneManager_Script.decals_Tab[4];
                if (decal.activeInHierarchy)
                {
                    decal.SetActive(false);
                }
                else
                {
                    decal.SetActive(true);
                }
                break;
            case "EnseigneDroite":
                decal = _SceneManager_Script.decals_Tab[5];
                if (decal.activeInHierarchy)
                {
                    decal.SetActive(false);
                }
                else
                {
                    decal.SetActive(true);
                }
                break;
            case "EnseigneGauche":
                decal = _SceneManager_Script.decals_Tab[6];
                if (decal.activeInHierarchy)
                {
                    decal.SetActive(false);
                }
                else
                {
                    decal.SetActive(true);
                }
                break;
        }
    }

    public void ChangeTexture(int num)
    {

        if (_select_GO.transform.parent.name == "Enseigne") {
            foreach (Transform child in _select_GO.transform.parent) {
                if (child.name != "Spotlight_Model(Clone)" && child.name != "Alutri(Clone)")
                    child.gameObject.GetComponent<Texture_Script>().Changetexture(num);
            }
        }
        else
        {
            if (_select_GO != null && _select_GO.GetComponent<InteracibleObject_Script>())
            {
                _select_GO.GetComponent<InteracibleObject_Script>().Changetexture(num);

            }
        }

    }

    public void ChangeColorVinyle(int num)
    {


        if (_select_GO != null && _select_GO.GetComponent<InteracibleObject_Script>())
        {

            GameObject go = _select_GO;
            if(_select_GO.transform.parent.name.StartsWith("Parent"))
            {
                if ( _select_GO.name.StartsWith("Decal") )
                {
                    go = _lastCloisonSelect;
                }
                else
                    go = _lastEnseigneSelect;
            }

            if (num == 0)
            {
                
                go.GetComponent<Renderer>().material.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, go.GetComponent<Renderer>().material.color.a);
                go.GetComponent<InteracibleObject_Script>()._saveColor = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, go.GetComponent<Renderer>().material.color.a);

            }
            else if (num == 1)
            {

                go.GetComponent<Renderer>().material.color = new Color(30.0f / 255.0f, 30.0f / 255.0f, 30.0f / 255.0f, go.GetComponent<Renderer>().material.color.a);
                go.GetComponent<InteracibleObject_Script>()._saveColor = new Color(30.0f / 255.0f, 30.0f / 255.0f, 30.0f / 255.0f, go.GetComponent<Renderer>().material.color.a);

            }
        }
        ChangeAlpha(true);
        ChangeAlpha();
    }

    public void ChangeColor(int num)
    {

        if (_select_GO != null && _select_GO.GetComponent<InteracibleObject_Script>())
        {

           
            switch (num)
            {
                case 0:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(225.0f / 255.0f, 226.0f / 255.0f, 220.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(225.0f / 255.0f, 226.0f / 255.0f, 220.0f / 255.0f, 1.0f);
                    break;
                case 1:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(141.0f / 255.0f, 122.0f / 255.0f, 108.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(141.0f / 255.0f, 122.0f / 255.0f, 108.0f / 255.0f, 1.0f);
                    break;
                case 2:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(163.0f / 255.0f, 136.0f / 255.0f, 105.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(163.0f / 255.0f, 136.0f / 255.0f, 105.0f / 255.0f, 1.0f);
                    break;
                case 3:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(247.0f / 255.0f, 216.0f / 255.0f, 89.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(247.0f / 255.0f, 216.0f / 255.0f, 89.0f / 255.0f, 1.0f);
                    break;
                case 4:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(160.0f / 255.0f, 41.0f / 255.0f, 58.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(160.0f / 255.0f, 41.0f / 255.0f, 58.0f / 255.0f, 1.0f);
                    break;
                case 5:
					_select_GO.GetComponent<Renderer>().material.color = new Color(160.0f / 255.0f, 41.0f / 255.0f, 58.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(160.0f / 255.0f, 41.0f / 255.0f, 58.0f / 255.0f, 1.0f);
                    break;
                case 6:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(96.0f / 255.0f, 41.0f / 255.0f, 41.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(96.0f / 255.0f, 41.0f / 255.0f, 41.0f / 255.0f, 1.0f);
                    break;
                case 7:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(130.0f / 255.0f, 34.0f / 255.0f, 47.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(130.0f / 255.0f, 34.0f / 255.0f, 47.0f / 255.0f, 1.0f);
                    break;
                case 8:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(214.0f / 255.0f, 75.0f / 255.0f, 58.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(214.0f / 255.0f, 75.0f / 255.0f, 58.0f / 255.0f, 1.0f);
                    break;
                case 9:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(216.0f / 255.0f, 113.0f / 255.0f, 59.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(216.0f / 255.0f, 113.0f / 255.0f, 59.0f / 255.0f, 1.0f);
                    break;
                case 10:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(70.0f / 255.0f, 45.0f / 255.0f, 103.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(70.0f / 255.0f, 45.0f / 255.0f, 103.0f / 255.0f, 1.0f);
                    break;
                case 11:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(50.0f / 255.0f, 101.0f / 255.0f, 167.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(50.0f / 255.0f, 101.0f / 255.0f, 167.0f / 255.0f, 1.0f);
                    break;
                case 12:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(55.0f / 255.0f, 61.0f / 255.0f, 88.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(55.0f / 255.0f, 61.0f / 255.0f, 88.0f / 255.0f, 1.0f);
                    break;
                case 13:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(54.0f / 255.0f, 79.0f / 255.0f, 128.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(54.0f / 255.0f, 79.0f / 255.0f, 128.0f / 255.0f, 1.0f);
                    break;
                case 14:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(30.0f / 255.0f, 30.0f / 255.0f, 30.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(30.0f / 255.0f, 30.0f / 255.0f, 30.0f / 255.0f, 1.0f);
                    break;
                case 15:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(59.0f / 255.0f, 70.0f / 255.0f, 141.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(59.0f / 255.0f, 70.0f / 255.0f, 141.0f / 255.0f, 1.0f);
                    break;
                case 16:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(31.0f / 255.0f, 102.0f / 255.0f, 163.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(31.0f / 255.0f, 102.0f / 255.0f, 163.0f / 255.0f, 1.0f);
                    break;
                case 17:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(68.0f / 255.0f, 111.0f / 255.0f, 83.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(68.0f / 255.0f, 111.0f / 255.0f, 83.0f / 255.0f, 1.0f);
                    break;
                case 18:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(39.0f / 255.0f, 164.0f / 255.0f, 80.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(39.0f / 255.0f, 164.0f / 255.0f, 80.0f / 255.0f, 1.0f);
                    break;
                case 19:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(58.0f / 255.0f, 130.0f / 255.0f, 74.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(58.0f / 255.0f, 130.0f / 255.0f, 74.0f / 255.0f, 1.0f);
                    break;
                case 20:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(12.0f / 255.0f, 84.0f / 255.0f, 64.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(12.0f / 255.0f, 84.0f / 255.0f, 64.0f / 255.0f, 1.0f);
                    break;
                case 21:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(133.0f / 255.0f, 137.0f / 255.0f, 138.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(133.0f / 255.0f, 137.0f / 255.0f, 138.0f / 255.0f, 1.0f);
                    break;
                case 22:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(145.0f / 255.0f, 143.0f / 255.0f, 145.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(145.0f / 255.0f, 143.0f / 255.0f, 145.0f / 255.0f, 1.0f);
                    break;
                case 23:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(106.0f / 255.0f, 105.0f / 255.0f, 107.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(106.0f / 255.0f, 105.0f / 255.0f, 107.0f / 255.0f, 1.0f);
                    break;
                case 24:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(197.0f / 255.0f, 198.0f / 255.0f, 197.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(197.0f / 255.0f, 198.0f / 255.0f, 197.0f / 255.0f, 1.0f);
                    break;
                case 25:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(154.0f / 255.0f, 157.0f / 255.0f, 157.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(154.0f / 255.0f, 157.0f / 255.0f, 157.0f / 255.0f, 1.0f);
                    break;
                case 26:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(81.0f / 255.0f, 78.0f / 255.0f, 81.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(81.0f / 255.0f, 78.0f / 255.0f, 81.0f / 255.0f, 1.0f);
                    break;
                case 27:
                    _select_GO.GetComponent<Renderer>().material.color = new Color(81.0f / 255.0f, 82.0f / 255.0f, 85.0f / 255.0f, 1.0f);
                    _select_GO.GetComponent<InteracibleObject_Script>()._saveColor = new Color(81.0f / 255.0f, 82.0f / 255.0f, 85.0f / 255.0f, 1.0f);
                    break;
            }

            //if (_select_GO.name == "Reserve")
               // _select_GO.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(197.0f / 255.0f, 198.0f / 255.0f, 197.0f/255.0f, 1);

        }

    }

    void ResetMenu()
    {


    }

    public void DeselectObjectAndMenu()
    {
        if (_select_GO != null)
        {

            _select_GO = null;

            _decalCollider_1.GetComponent<BoxCollider>().enabled = false;
            _decalCollider_2.GetComponent<BoxCollider>().enabled = false;

            ChangeAlpha(true);

        }
        DeselectMenu();

    }

    public void DeselectObject()
    {
        if (_select_GO != null)
        {
 
            _select_GO = null;

            _decalCollider_1.GetComponent<BoxCollider>().enabled = false;
            _decalCollider_2.GetComponent<BoxCollider>().enabled = false;

            ChangeAlpha(true);

        }

    }

    public void DeselectMenu()
    {
        for (int i = 0; i < SideMenu.transform.childCount; i++)
        {
            SideMenu.transform.GetChild(i).gameObject.SetActive(false);
        }
        SideMenu.SetActive(false);
		AideEnseigne.SetActive(false);

        OK.SetActive(false);
        PrixDetail.SetActive(false);

        for (int i = 0; i < SecondMenu.transform.childCount; i++)
        {
            SecondMenu.transform.GetChild(i).gameObject.SetActive(false);
        }
        SecondMenu.SetActive(false);

        Surface.SetActive(true);
        Formulaire.SetActive(false);
        Valider.SetActive(true);
        Envoyer.SetActive(false);
    }

    public void SelectMenu(GameObject _menu)
    {

        _menu.transform.parent.gameObject.SetActive(true);
        _menu.SetActive(true);

        OK.SetActive(true);
        PrixDetail.SetActive(true);
        Surface.SetActive(false);
    }

    public void blockInput(bool block)
    {
        _block = block;
    }

    public void ChangeAlpha(bool _restart = false)
    {



        if (_restart)
        {
            for (int i = 0; i < _SceneManager_Script.decals_Tab.Length; i++)
            {
                for (int j = 0; j < _SceneManager_Script.decals_Tab[i].transform.childCount; j++)
                {
                    if (_SceneManager_Script.decals_Tab[i].transform.GetChild(j).gameObject.activeInHierarchy)
                    {
						_SceneManager_Script.decals_Tab[i].transform.GetChild(j).GetComponent<Renderer>().material.color = _SceneManager_Script.decals_Tab[i].transform.GetChild(j).GetComponent<InteracibleObject_Script>()._saveColor;
                    }
                }

            }

            for (int i = 0; i < transform.childCount; i++)
            {

                if (transform.GetChild(i).name == "Enseigne" && transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    for (int j = 0; j < transform.GetChild(i).childCount; j++)
                    {

                        if (!transform.GetChild(i).GetChild(j).name.StartsWith("Spotlight") && transform.GetChild(i).GetChild(j).name != "Alutri(Clone)")
                        {
                            //Texture _tex = transform.GetChild(i).GetChild(j).GetComponent<Renderer>().material.mainTexture;
                            transform.GetChild(i).GetChild(j).GetComponent<Renderer>().material = _Mat_Opaque_Enseigne;
                            //transform.GetChild(i).GetChild(j).GetComponent<Renderer>().material.mainTexture = _tex;

                            transform.GetChild(i).GetChild(j).GetComponent<Renderer>().material.color = transform.GetChild(i).GetChild(j).GetComponent<InteracibleObject_Script>()._saveColor;
                        }
                    }
                }
                else
                {

                    if (transform.GetChild(i).name != "Alutri" && transform.GetChild(i).gameObject.activeInHierarchy)
                    {

                        Texture _tex = transform.GetChild(i).GetComponent<Renderer>().material.mainTexture;


                        if (transform.GetChild(i).name == "Ground")
                        {
                            transform.GetChild(i).GetComponent<Renderer>().material = _Mat_Opaque;
                        }
                        else if (transform.GetChild(i).name == "Reserve")
                        {
                            transform.GetChild(i).GetComponent<Renderer>().material = _Mat_Opaque_Reserve;
                        }
                        else
                        { 
                            transform.GetChild(i).GetComponent<Renderer>().material = _Mat_Opaque_Wall;
                       }

                        transform.GetChild(i).GetComponent<Renderer>().material.mainTexture = _tex;

                        transform.GetChild(i).GetComponent<Renderer>().material.color = transform.GetChild(i).GetComponent<InteracibleObject_Script>()._saveColor;

                        if (transform.GetChild(i).name == "Reserve")
                        {
                            transform.GetChild(i).FindChild("Door").GetComponent<Renderer>().material.color = transform.GetChild(i).FindChild("Door").GetComponent<Door_Script>()._saveColor;
							transform.GetChild(i).FindChild("Door").GetChild(1).GetComponent<Renderer>().material.color = new Color(150.0f/255.0f, 150.0f / 255.0f, 150.0f / 255.0f, 1);
							transform.GetChild(i).FindChild("Door").GetChild(2).GetComponent<Renderer>().material.color = new Color(150.0f / 255.0f, 150.0f / 255.0f, 150.0f / 255.0f, 1);
							transform.GetChild(i).FindChild("Door").GetChild(3).GetComponent<Renderer>().material.color = new Color(150.0f / 255.0f, 150.0f / 255.0f, 150.0f / 255.0f, 1);
							transform.GetChild(i).FindChild("Door").GetChild(4).GetComponent<Renderer>().material.color = new Color(150.0f / 255.0f, 150.0f / 255.0f, 150.0f / 255.0f, 1);
                        }
                    }
                }
            }
        }
        else
        {

            Color newColor = new Color(1, 1, 1, 1);
            for (int i = 0; i < _SceneManager_Script.decals_Tab.Length; i++)
            {
                for (int j = 0; j < _SceneManager_Script.decals_Tab[i].transform.childCount; j++)
                {
                    if (_SceneManager_Script.decals_Tab[i].transform.GetChild(j).gameObject.activeInHierarchy)
                    {
                        _SceneManager_Script.decals_Tab[i].transform.GetChild(j).GetComponent<InteracibleObject_Script>()._saveColor = _SceneManager_Script.decals_Tab[i].transform.GetChild(j).GetComponent<Renderer>().material.color;

                        newColor = _SceneManager_Script.decals_Tab[i].transform.GetChild(j).GetComponent<Renderer>().material.color;
                        newColor.r = 0.5f;
                        newColor.g = 0.5f;
                        newColor.b = 0.5f;
                        newColor.a = 0.7f;
                        _SceneManager_Script.decals_Tab[i].transform.GetChild(j).GetComponent<Renderer>().material.color = newColor;
                    }
                }

            }


            for (int i = 0; i < transform.childCount; i++)
            {

                if (transform.GetChild(i).name == "Enseigne" && transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    for (int j = 0; j < transform.GetChild(i).childCount; j++)
                    {

                        if (!transform.GetChild(i).GetChild(j).name.StartsWith("Spotlight") && transform.GetChild(i).GetChild(j).name != "Alutri(Clone)")
                        {
                            transform.GetChild(i).GetChild(j).GetComponent<InteracibleObject_Script>()._saveColor = transform.GetChild(i).GetChild(j).GetComponent<Renderer>().material.color;

                            
                            //Texture _tex = transform.GetChild(i).GetChild(j).GetComponent<Renderer>().material.mainTexture;
                            transform.GetChild(i).GetChild(j).GetComponent<Renderer>().material = _Mat_Transparent_Enseigne;
                            //transform.GetChild(i).GetChild(j).GetComponent<Renderer>().material.mainTexture = _tex;

                            newColor = transform.GetChild(i).GetChild(j).GetComponent<InteracibleObject_Script>()._saveColor;
                            newColor.r = 0.5f;
                            newColor.g = 0.5f;
                            newColor.b = 0.5f; ;
                            newColor.a = 0.1f;
                            transform.GetChild(i).GetChild(j).GetComponent<Renderer>().material.color = newColor;
                        }
                    }
                }
                else
                {
                    if (transform.GetChild(i).name != "Alutri" && transform.GetChild(i).gameObject.activeInHierarchy)
                    {
                        transform.GetChild(i).GetComponent<InteracibleObject_Script>()._saveColor = transform.GetChild(i).GetComponent<Renderer>().material.color;

                        Texture _tex = transform.GetChild(i).GetComponent<Renderer>().material.mainTexture;

                        if (transform.GetChild(i).name == "Ground")
                        {
                            transform.GetChild(i).GetComponent<Renderer>().material = _Mat_Transparent;
                        }
                        else if (transform.GetChild(i).name == "Reserve")
                        {
                            transform.GetChild(i).GetComponent<Renderer>().material = _Mat_Transparent_Reserve;
                        }
                        else
                        {
                            transform.GetChild(i).GetComponent<Renderer>().material = _Mat_Transparent_Wall;
                        }

                        transform.GetChild(i).GetComponent<Renderer>().material.mainTexture = _tex;


                        newColor = transform.GetChild(i).GetComponent<InteracibleObject_Script>()._saveColor;
                        newColor.r = 0.5f;
                        newColor.g = 0.5f;
                        newColor.b = 0.5f;
                        newColor.a = 0.1f;
                        if (transform.GetChild(i).name == "Ground")
                            newColor.a = 0.0f;
                        transform.GetChild(i).GetComponent<Renderer>().material.color = newColor;

                        if (transform.GetChild(i).name == "Reserve")
                        {
                            transform.GetChild(i).FindChild("Door").GetComponent<Renderer>().material.color = newColor;
                            transform.GetChild(i).FindChild("Door").GetChild(1).GetComponent<Renderer>().material.color = new Color(150.0f / 255.0f, 150.0f / 255.0f, 150.0f / 255.0f, 0.1f);
							transform.GetChild(i).FindChild("Door").GetChild(2).GetComponent<Renderer>().material.color = new Color(150.0f / 255.0f, 150.0f / 255.0f, 150.0f / 255.0f, 0.1f);
							transform.GetChild(i).FindChild("Door").GetChild(3).GetComponent<Renderer>().material.color = new Color(150.0f / 255.0f, 150.0f / 255.0f, 150.0f / 255.0f, 0.1f);
							transform.GetChild(i).FindChild("Door").GetChild(4).GetComponent<Renderer>().material.color = new Color(150.0f / 255.0f, 150.0f / 255.0f, 150.0f / 255.0f, 0.1f);
						}
                    }
                }
            }


            if (_select_GO != null)
            {
                if (_select_GO.name != "DecalMain" && _select_GO.name != "DecalLeft" && _select_GO.name != "DecalRight" && _select_GO.name != "EnseigneBack" && _select_GO.name != "EnseigneFront" && _select_GO.name != "EnseigneLeft" && _select_GO.name != "EnseigneRight")
                {
                    Texture _tex = _select_GO.GetComponent<Renderer>().material.mainTexture;

                    if (_select_GO.name.StartsWith("Wall"))
                    {
                        _select_GO.GetComponent<Renderer>().material = _Mat_Opaque_Wall;
                    }
                    else if (_select_GO.name == "Reserve")
                    {
                        _select_GO.GetComponent<Renderer>().material = _Mat_Opaque_Reserve;
                    }
                    else
                    {
                        _select_GO.GetComponent<Renderer>().material = _Mat_Opaque;
                    }

                       
                    _select_GO.GetComponent<Renderer>().material.mainTexture = _tex;

                }
                if (_select_GO.name.StartsWith("Enseigne") && !_select_GO.transform.parent.name.StartsWith("Parent"))
                {
                    _select_GO.GetComponent<Renderer>().material = _Mat_Opaque_Enseigne;
                }
                _select_GO.GetComponent<Renderer>().material.color = _select_GO.GetComponent<InteracibleObject_Script>()._saveColor;
                if (_select_GO.name == "Reserve")
                {
                    _select_GO.transform.FindChild("Door").GetComponent<Renderer>().material.color = _select_GO.transform.FindChild("Door").GetComponent<Door_Script>()._saveColor;//_select_GO.GetComponent<InteracibleObject_Script>()._saveColor;
                    _select_GO.transform.FindChild("Door").GetChild(1).GetComponent<Renderer>().material.color = new Color(150.0f / 255.0f, 150.0f / 255.0f, 150.0f / 255.0f, 1);
					_select_GO.transform.FindChild("Door").GetChild(2).GetComponent<Renderer>().material.color = new Color(150.0f / 255.0f, 150.0f / 255.0f, 150.0f / 255.0f, 1);
					_select_GO.transform.FindChild("Door").GetChild(3).GetComponent<Renderer>().material.color = new Color(150.0f / 255.0f, 150.0f / 255.0f, 150.0f / 255.0f, 1);
					_select_GO.transform.FindChild("Door").GetChild(4).GetComponent<Renderer>().material.color = new Color(150.0f / 255.0f, 150.0f / 255.0f, 150.0f / 255.0f, 1);
                }
            }

        }

    }

    public void SelectObjectViaMenuV2(GameObject _go)
    {
        if (_go.activeInHierarchy)
        {
            _select_GO = _go;

            ChangeAlpha(true);
            ChangeAlpha();

            if (_select_GO.name == "Wall_Main" || _select_GO.name == "Wall_Left" || _select_GO.name == "Wall_Right")
            {

                SideMenu.SetActive(true);
                SideMenu.transform.GetChild(_select_GO.GetComponent<InteracibleObject_Script>().menuSideNum).gameObject.SetActive(true);


                if (_select_GO.GetComponent<InteracibleObject_Script>().menuSideNum == 2)
                {
                    if (_select_GO.name == "Wall_Main")
                    {
                        GetComponent<SceneManager_Script>().decals_Tab[0].transform.GetChild(0).gameObject.SetActive(true);
                        SelectObjectViaMenu(GetComponent<SceneManager_Script>().decals_Tab[0].transform.GetChild(0).gameObject);
                    }
                    else if (_select_GO.name == "Wall_Left")
                    {
                        GetComponent<SceneManager_Script>().decals_Tab[1].transform.GetChild(0).gameObject.SetActive(true);
                        SelectObjectViaMenu(GetComponent<SceneManager_Script>().decals_Tab[1].transform.GetChild(0).gameObject);
                    }
                    else if (_select_GO.name == "Wall_Right")
                    {
                        GetComponent<SceneManager_Script>().decals_Tab[2].transform.GetChild(0).gameObject.SetActive(true);
                        SelectObjectViaMenu(GetComponent<SceneManager_Script>().decals_Tab[2].transform.GetChild(0).gameObject);
                    }
                }


                SecondMenu.SetActive(true);
                SecondMenu.transform.GetChild(0).gameObject.SetActive(true);

                PrixDetail.SetActive(true);
                OK.SetActive(true);
                Surface.SetActive(false);
            }

        }
        else
        {
 
            if (_go.name == "Wall_Main")
                _SceneManager_Script.decals_Tab[0].SetActive(false);
            else if (_go.name == "Wall_Left")
                _SceneManager_Script.decals_Tab[1].SetActive(false);
            else if (_go.name == "Wall_Right")
                _SceneManager_Script.decals_Tab[2].SetActive(false);

            SideMenu.SetActive(false);
            SideMenu.transform.GetChild(_go.GetComponent<InteracibleObject_Script>().menuSideNum).gameObject.SetActive(false);

            _go.GetComponent<InteracibleObject_Script>().menuSideNum = 0;

            PrixDetail.SetActive(true);
            OK.SetActive(true);
            Surface.SetActive(false);

            DeselectObject();
        }
    }

    bool first = true;
    public void SelectObjectViaMenuV3(GameObject _go)
    {
        if (_go.activeInHierarchy)
        {

            _select_GO = _go;

            ChangeAlpha(true);
            ChangeAlpha();

            SecondMenu.SetActive(true);
            SecondMenu.transform.GetChild(2).gameObject.SetActive(true);
            SideMenu.SetActive(true);
            SideMenu.transform.GetChild(_select_GO.GetComponent<InteracibleObject_Script>().menuSideNum).gameObject.SetActive(true);
            PrixDetail.SetActive(true);
            OK.SetActive(true);

            if (first)
            {
                first = false;
                _SceneManager_Script.EnseigneWalls[0].GetComponent<Renderer>().material.color = Color.white;
                _SceneManager_Script.EnseigneWalls[2].GetComponent<Renderer>().material.color = Color.white;
                _SceneManager_Script.EnseigneWalls[3].GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }

    public void SelectObjectViaMenu(GameObject _go)
    {
        if(_go.activeInHierarchy)
        { 
            _select_GO = _go;

            ChangeAlpha(true);
            ChangeAlpha();
        }
    }

    public void ActiveSideMenuIfReserveIsActiv()
    {
        if (GetComponent<SceneManager_Script>()._Reserve.activeInHierarchy)
        {
            SideMenu.SetActive(true);
            SideMenu.transform.GetChild(3).gameObject.SetActive(true);
        }

    }

    
    public void SelectSideMenuEnseigne()
    {
        if (GetComponent<SceneManager_Script>()._Enseigne.activeInHierarchy)
        {

            SecondMenu.transform.GetChild(2).transform.GetChild(1).GetComponent<Slider>().interactable = true;

            SecondMenu.transform.GetChild(2).transform.GetChild(2).transform.GetChild(0).GetComponent<Toggle>().interactable = true;
            SecondMenu.transform.GetChild(2).transform.GetChild(2).transform.GetChild(1).GetComponent<Toggle>().interactable = true;


            PrixDetail.SetActive(true);
            OK.SetActive(true);
            Surface.SetActive(false);

        }
        else
        {

            SecondMenu.transform.GetChild(2).transform.GetChild(1).GetComponent<Slider>().interactable = false;

            SecondMenu.transform.GetChild(2).transform.GetChild(2).transform.GetChild(0).GetComponent<Toggle>().interactable = false;
            SecondMenu.transform.GetChild(2).transform.GetChild(2).transform.GetChild(1).GetComponent<Toggle>().interactable = false;

            PrixDetail.SetActive(true);
            OK.SetActive(true);
            Surface.SetActive(false);

            if(_select_GO != null)
                DeselectObject();
        }
    }
    

    public void   SelectSideMenuReserve()
    {
        if ( GetComponent<SceneManager_Script>()._Reserve.activeInHierarchy )
        {
            for (int i = 1; i < SecondMenu.transform.GetChild(3).transform.childCount; i++)
            {
                if(SecondMenu.transform.GetChild(3).transform.GetChild(i).GetComponent<Button>())
                    SecondMenu.transform.GetChild(3).transform.GetChild(i).GetComponent<Button>().interactable = true;
                else if (SecondMenu.transform.GetChild(3).transform.GetChild(i).GetComponent<Slider>())
                    SecondMenu.transform.GetChild(3).transform.GetChild(i).GetComponent<Slider>().interactable = true;
            }
           

            SideMenu.SetActive(true);
            SideMenu.transform.GetChild(3).gameObject.SetActive(true);

            PrixDetail.SetActive(true);
            OK.SetActive(true);
            Surface.SetActive(false);
      
            SelectObjectViaMenu(GetComponent<SceneManager_Script>()._Reserve);

        }
        else
        {

            for (int i = 1; i < SecondMenu.transform.GetChild(3).transform.childCount; i++)
            {
                if (SecondMenu.transform.GetChild(3).transform.GetChild(i).GetComponent<Button>())
                    SecondMenu.transform.GetChild(3).transform.GetChild(i).GetComponent<Button>().interactable = false;
                else if (SecondMenu.transform.GetChild(3).transform.GetChild(i).GetComponent<Slider>())
                    SecondMenu.transform.GetChild(3).transform.GetChild(i).GetComponent<Slider>().interactable = false;
            }

            SideMenu.SetActive(false);
            SideMenu.transform.GetChild(4).gameObject.SetActive(false);

            PrixDetail.SetActive(true);
            OK.SetActive(true);
            Surface.SetActive(false);
        }
    }
    void SelectObject()
	{

		bool pass = CanMoveObject ();

        if (Input.GetMouseButtonDown(0) && pass)
        {

            Ray ray = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            // Casts the ray and get the first game object hit
            if (Physics.Raycast(ray, out hit))
            {

                Vector3 mousPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

                if (hit.transform.gameObject.layer == 9 && !((mousPos.x >= 0 && mousPos.x <= 0.7f) && (mousPos.y >= 0.01f && mousPos.y <= 0.07f)))
                {
                    if (_select_GO != null)
                    {
                        DeselectObjectAndMenu();
                        ChangeAlpha(true);
                    }
                    else if (_select_GO == null)
                    {
                        DeselectMenu();
                        ChangeAlpha(true);
                    }
                    Formulaire.SetActive(false);
                }
                ChangeAlpha(true);
                DeselectObject();

                if (hit.transform.gameObject.layer == 8 || hit.transform.gameObject.layer == 10 || hit.transform.gameObject.layer == 11 || hit.transform.gameObject.layer == 13)
                {
                    DeselectMenu();
                    _select_GO = hit.transform.gameObject;

                    ChangeAlpha(true);
                    ChangeAlpha();

                    _SceneManager_Script.DesactiveMenuDeroulant();
                    _select_GO.GetComponent<InteracibleObject_Script>()._timer = 0.05f;

                    if (_select_GO.GetComponent<Decal_Script>() != null)
                    {
                        if (Camera.main.name == "Main Camera")
                            _decalCollider_1.GetComponent<BoxCollider>().enabled = true;
                        else if (Camera.main.name == "FocusCamera")
                            _decalCollider_2.GetComponent<BoxCollider>().enabled = true;
                    }

                    if (_select_GO.name == "Wall_Main" || _select_GO.name == "Wall_Left" || _select_GO.name == "Wall_Right")
                    {
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(5).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>());
						_SceneManager_Script.WhiteTextMenu(MainMenu.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>());
						_SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>());
                        SideMenu.SetActive(true);
                        SideMenu.transform.GetChild(_select_GO.GetComponent<InteracibleObject_Script>().menuSideNum).gameObject.SetActive(true);

                       
                        if (_select_GO.GetComponent<InteracibleObject_Script>().menuSideNum==2)
                        {
                            if (_select_GO.name == "Wall_Main")
                            {
                                GetComponent<SceneManager_Script>().decals_Tab[0].transform.GetChild(0).gameObject.SetActive(true);
                                SelectObjectViaMenu(GetComponent<SceneManager_Script>().decals_Tab[0].transform.GetChild(0).gameObject);
                            }
                            else if (_select_GO.name == "Wall_Left")
                            {
                                GetComponent<SceneManager_Script>().decals_Tab[1].transform.GetChild(0).gameObject.SetActive(true);
                                SelectObjectViaMenu(GetComponent<SceneManager_Script>().decals_Tab[1].transform.GetChild(0).gameObject);
                            }
                            else if (_select_GO.name == "Wall_Right")
                            {
                                GetComponent<SceneManager_Script>().decals_Tab[2].transform.GetChild(0).gameObject.SetActive(true);
                                SelectObjectViaMenu(GetComponent<SceneManager_Script>().decals_Tab[2].transform.GetChild(0).gameObject);
                            }
                        }
                       

                        SecondMenu.SetActive(true);
                        SecondMenu.transform.GetChild(0).gameObject.SetActive(true);

                        PrixDetail.SetActive(true);
                        OK.SetActive(true);
                        Surface.SetActive(false);
                    }
                    else if (_select_GO.name == "Reserve")
                    {
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(5).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.WhiteTextMenu(MainMenu.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>());
						_SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>());
                        SideMenu.SetActive(true);
                        SideMenu.transform.GetChild(_select_GO.GetComponent<InteracibleObject_Script>().menuSideNum).gameObject.SetActive(true);

                        SecondMenu.SetActive(true);
                        SecondMenu.transform.GetChild(3).gameObject.SetActive(true);

                        PrixDetail.SetActive(true);
                        OK.SetActive(true);
                        Surface.SetActive(false);
                    }
                    else if (_select_GO.name.StartsWith("Decal") )
                    {

                        SideMenu.SetActive(true);
                        SideMenu.transform.GetChild(2).gameObject.SetActive(true);

                        SecondMenu.SetActive(true);
                        SecondMenu.transform.GetChild(0).gameObject.SetActive(true);

                        PrixDetail.SetActive(true);
                        OK.SetActive(true);
                        Surface.SetActive(false);
                    }
                    else if (_select_GO.transform.parent.name.StartsWith("Parent") && _select_GO.name.StartsWith("Enseigne") )
                    {
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(5).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.WhiteTextMenu(MainMenu.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>());
						_SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>());
                        SideMenu.SetActive(true);
                        SideMenu.transform.GetChild(5).gameObject.SetActive(true);

                        SecondMenu.SetActive(true);
                        SecondMenu.transform.GetChild(2).gameObject.SetActive(true);

                        PrixDetail.SetActive(true);
                        OK.SetActive(true);
                        Surface.SetActive(false);
                    }
                    else if (_select_GO.name == "Ground")
                    {
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.WhiteTextMenu(MainMenu.transform.GetChild(5).transform.GetChild(0).GetComponent<Text>());
						_SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>());
                        SecondMenu.SetActive(true);
                        SecondMenu.transform.GetChild(1).gameObject.SetActive(true);

                        PrixDetail.SetActive(true);
                        OK.SetActive(true);
                        Surface.SetActive(false);
                        //print("OK");
                    }
                    else if (!_select_GO.transform.parent.name.StartsWith("Parent") && (_select_GO.name == "EnseigneBack" || _select_GO.name == "EnseigneGauche"|| _select_GO.name == "EnseigneDroite"|| _select_GO.name == "EnseigneFront"))
                    {
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(5).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>());
                        _SceneManager_Script.WhiteTextMenu(MainMenu.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>());
						_SceneManager_Script.GriserTextMenu(MainMenu.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>());
                        SecondMenu.SetActive(true);
                        SecondMenu.transform.GetChild(2).gameObject.SetActive(true);
                        SideMenu.SetActive(true);
                        SideMenu.transform.GetChild(_select_GO.GetComponent<InteracibleObject_Script>().menuSideNum).gameObject.SetActive(true);

                        if (_select_GO.GetComponent<InteracibleObject_Script>().menuSideNum == 5)
                        {
                           
                            if (_select_GO.name == "EnseigneBack")
                            {
                                GetComponent<SceneManager_Script>().decals_Tab[3].transform.GetChild(0).gameObject.SetActive(true);
                                SelectObjectViaMenu(GetComponent<SceneManager_Script>().decals_Tab[3].transform.GetChild(0).gameObject);
                            }
                            else if (_select_GO.name == "EnseigneFront")
                            {
                                GetComponent<SceneManager_Script>().decals_Tab[4].transform.GetChild(0).gameObject.SetActive(true);
                                SelectObjectViaMenu(GetComponent<SceneManager_Script>().decals_Tab[4].transform.GetChild(0).gameObject);
                            }
                            else if (_select_GO.name == "EnseigneDroite")
                            {
                                GetComponent<SceneManager_Script>().decals_Tab[5].transform.GetChild(0).gameObject.SetActive(true);
                                SelectObjectViaMenu(GetComponent<SceneManager_Script>().decals_Tab[5].transform.GetChild(0).gameObject);
                            }
                            else if (_select_GO.name == "EnseigneGauche")
                            {
                                GetComponent<SceneManager_Script>().decals_Tab[6].transform.GetChild(0).gameObject.SetActive(true);
                                SelectObjectViaMenu(GetComponent<SceneManager_Script>().decals_Tab[6].transform.GetChild(0).gameObject);
                            }
                        }

                        
                        PrixDetail.SetActive(true);
                        OK.SetActive(true);
                        Surface.SetActive(false);
                    }

                }

            }
            else if (_select_GO != null)
            {

                DeselectObjectAndMenu();
                ChangeAlpha(true);

            }
            else if (_select_GO == null)
            {
                ChangeAlpha(true);
                DeselectMenu();
            }




        }

    }

	public bool CanMoveObject()
    {

        Vector3 mousPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        
        if ((mousPos.x >= 0 && mousPos.x <= 1.0f) && (mousPos.y >= 0.94f && mousPos.y <= 1.0f))
        {
            return false;
        }
        if ((mousPos.x >= 0 && mousPos.x <= 1.0f) && (mousPos.y >= 0.0f && mousPos.y <= 0.07f))
        {
            return false;
        }
        if (SecondMenu.activeInHierarchy && (mousPos.x >= 0.815f && mousPos.x <= 1.0f) && (mousPos.y >= 0.70f && mousPos.y <= 1.0f))
        {
            return false;
        }
        else if (SideMenu.activeInHierarchy && (mousPos.x >= 0.815f && mousPos.x <= 1.0f) && (mousPos.y >= 0.0f && mousPos.y <= 1.0f))
        {
            return false;
        }
        else if (Formulaire.activeInHierarchy && (mousPos.x >= 0.815f && mousPos.x <= 1.0f) && (mousPos.y >= 0.0f && mousPos.y <= 1.0f))
        {
            return false;
        }
        
        return true;
    }

    public void desactivDecalEnseigneV2()
    {

        for(int i = 3; i < 7; i++)
        {
            _SceneManager_Script.decals_Tab[i].SetActive(false);
        }
        for (int i = 0; i < 4; i++)
        {
            _SceneManager_Script._Enseigne.transform.GetChild(i).GetComponent<EnseigneObject_Script>().menuSideNum = 5;
        }
    }


    public void vinylyMyItem()
    {
        if (_select_GO.transform.parent.name.StartsWith("Parent"))
        {
            if (_select_GO.name == "EnseigneBack")
            {
                _SceneManager_Script._Enseigne.transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = null;
            }
            else if (_select_GO.name == "EnseigneFront")
            {
                _SceneManager_Script._Enseigne.transform.GetChild(1).GetComponent<Renderer>().material.mainTexture = null;
            }
            else if (_select_GO.name == "EnseigneRight")
            {
                _SceneManager_Script._Enseigne.transform.GetChild(3).GetComponent<Renderer>().material.mainTexture = null;
            }
            else if (_select_GO.name == "EnseigneLeft")
            {
                _SceneManager_Script._Enseigne.transform.GetChild(2).GetComponent<Renderer>().material.mainTexture = null;
            }
            else if (_select_GO.name == "DecalLeft")
            {
                _SceneManager_Script.Wall_Tab[1].GetComponent<Renderer>().material.mainTexture = null;
            }
            else if (_select_GO.name == "DecalRight")
            {
                _SceneManager_Script.Wall_Tab[2].GetComponent<Renderer>().material.mainTexture = null;
            }
            else if (_select_GO.name == "DecalMain")
            {
                _SceneManager_Script.Wall_Tab[0].GetComponent<Renderer>().material.mainTexture = null;
            }
            
        }
        else
            _select_GO.GetComponent<Renderer>().material.mainTexture = null;
    }

    public void textilyseMyItem(Texture _tex)
    {
        if(_select_GO != null)
            _select_GO.GetComponent<Renderer>().material.mainTexture = _tex;
    }

}
