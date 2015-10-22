/*
Viaud Guillaume 20/10/2015

Gère les prix en temps réel pour afficher le prix total et les envoyer au PDF

*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Prix_Script : MonoBehaviour {
	
	public GameObject _PrixTotalTXT;
	
	public GameObject _prixunitaireTXT;
	public GameObject _SurfaceUnitaireTXT;
	
	public GameObject _lightManager;
	public LightManager_Script _lightManager_Script;
	
	public GameObject[] _cloison;
	public GameObject _reserve;
	public GameObject _sol;
	public GameObject[] _enseigne;
	
	XML_Parser xml_parser;
	public GameObject _sceneManager;
	public GameObject[] _decalWall;
	public GameObject[] _decalEnseigne;
	
	
	
	public float[] prixSol;
	public float[] prixMur;
	public string[] matiereMurModel;
	public string[] matiereMur;
	
	public float[] prixLampeStand;
	public float[] prixLampeEnseigne;
	
	public float[] prixReserve;
	public string[] matiereReserveModel;
	public string matiereReserve;

	public float[] prixEnseigne;
	public float prixEnseigneLogo;
	public string matiereEnseigne;


    public float prixFraisDossier;
    public float prixTotal;

	public float pSol;
	public float pMurMain;
	public float pMurGauche;
	public float pMurDroite;
	public float pReserve;
	public float pEnseigne;
    char upArrow = '\u20ac';
    public float pLightTotal;
	public float pLightMurMain;
	public float pLightMurGauche;
	public float pLightMurDroite;
	public float pLightReserve;
	public float pLightEnseigne;

	// Use this for initialization
	void Start () {
		_lightManager_Script = _lightManager.GetComponent<LightManager_Script> ();
		xml_parser = null;
	}

	public void startPrix()
	{
		xml_parser = GetComponent<XML_Parser> ();

		prixSol = xml_parser.prixSol;

		prixMur = xml_parser.prixMur;

		prixLampeStand = xml_parser.prixLampeStand;
		prixLampeEnseigne = xml_parser.prixLampeEnseigne;
		
		prixReserve = xml_parser.prixReserve;
		
		prixEnseigne = xml_parser.prixEnseigne;

		matiereMurModel = new string[4];
		matiereMurModel [0] = "Gainée coton";
		matiereMurModel [1] = "Mélaminée blanc";
		matiereMurModel [2] = "Mélaminée noir";
		matiereMurModel [3] = "Personnalisée";
		
		matiereMur = new string[3];

		matiereReserveModel = new string[3];
		matiereReserveModel [0] = "Gainée coton";
		matiereReserveModel [1] = "Mélaminée blanc";
		matiereReserveModel [2] = "Mélaminée noir";

		matiereEnseigne = "Personnalisée";

        prixFraisDossier = 100;

    }
	
	// Update is called once per frame
	void Update () {

		if (xml_parser != null) 
		{
			int longueur = MySingleton.Instance._length;
			int largeur = MySingleton.Instance._width;
			int longueurReserve = MySingleton.Instance._longueur_Reserve;
			int largeurReserve = MySingleton.Instance._largeur_Reserve;
			int longueurEnseigne = MySingleton.Instance._longueur_Enseigne;
			int largeurEnseigne = MySingleton.Instance._largeur_Enseigne;
	
//////////////SOL
			if (_sol.activeInHierarchy )
				pSol = prixSol[0] * (float)largeur * (float)longueur;
			else pSol = 0;
			
//////////////CLOISON
			if (_cloison [0].activeInHierarchy)
			{
                pMurMain = prixMur [_cloison [0].GetComponent<Texture_Script> ().tex] * (float)longueur;
				matiereMur[0] = matiereMurModel[_cloison [0].GetComponent<Texture_Script> ().tex];
            }
			else pMurMain = 0;

			if (_cloison [1].activeInHierarchy)
			{
				pMurGauche = prixMur[_cloison[1].GetComponent<Texture_Script>().tex] * (float)largeur;
				matiereMur[1] = matiereMurModel[_cloison[1].GetComponent<Texture_Script>().tex];
			}
			else pMurGauche = 0;
			if (_cloison [2].activeInHierarchy)
			{
				pMurDroite = prixMur[_cloison[2].GetComponent<Texture_Script>().tex] * (float)largeur;
				matiereMur[2] = matiereMurModel[_cloison[2].GetComponent<Texture_Script>().tex];
			}
			else pMurDroite = 0;

//////////////RESERVE
			if( _reserve.activeInHierarchy)
			{
				pReserve = prixReserve[_reserve.GetComponent<Texture_Script>().tex] * (float)longueurReserve * (float)largeurReserve;
				matiereReserve = matiereReserveModel[_reserve.GetComponent<Texture_Script>().tex];
			}
			else pReserve = 0;

//////////////ENSEIGNE
			if( _sceneManager.GetComponent<SceneManager_Script>()._Enseigne.activeInHierarchy)
			{
				if (!_sceneManager.GetComponent<SceneManager_Script> ()._isCarre) 
				{
					pEnseigne = prixEnseigne[0] * (float)longueurEnseigne;
				}
				else
				{
					//TOTAL
					pEnseigne = prixEnseigne[0] * (float)largeurEnseigne * 4.0f;
				}
			}
			else pEnseigne = 0;
		}

        //LUMIERE
        try
        {
            if (_cloison[0].activeInHierarchy)
            {

                pLightMurMain = (float)(_lightManager_Script.nbrLightWallMain) * prixLampeStand[0];


            }
            else pLightMurMain = 0;
            if (_cloison[1].activeInHierarchy)
            {
                pLightMurGauche = (float)(_lightManager_Script.nbrLightWallLeft) * prixLampeStand[0];
            }
            else pLightMurGauche = 0;
            if (_cloison[2].activeInHierarchy)
            {
                pLightMurDroite = (float)(_lightManager_Script.nbrLightWallRight) * prixLampeStand[0];
            }
            else pLightMurDroite = 0;
            if (_reserve.activeInHierarchy)
            {
                pLightReserve = (float)(_lightManager_Script.nbrLightWallReserve) * prixLampeStand[0];
            }
            else pLightReserve = 0;
            if (_sceneManager.GetComponent<SceneManager_Script>()._Enseigne.activeInHierarchy)
            {
                   pLightEnseigne = (float)(_lightManager_Script.nbrLightWallEnseigne) * prixLampeEnseigne[0];
            }
            else pLightEnseigne = 0;
        }
        catch
        {
            Debug.Log("");
        }
        pLightTotal = pLightMurMain + pLightMurGauche + pLightMurDroite + pLightReserve + pLightEnseigne;
		prixTotal = pSol + pMurMain + pMurGauche + pMurDroite + pReserve + pEnseigne + pLightTotal;

        prixTotal = Mathf.Round(prixTotal * 100.0f) / 100.0f;
        _PrixTotalTXT.GetComponent<Text>().text = "TOTAL " + (prixTotal + prixFraisDossier) +" "+upArrow + " HT";

        string prixUnitaire = "";
        string surfaceUnitaire = "";

        /*
        SideMenu;
    public GameObject OK;
    public GameObject PrixDetail;
    public GameObject SecondMenu;
    public GameObject Surface;
    */

        //SOL
        if (_sceneManager.GetComponent<Select_Object_Script>().SecondMenu.transform.GetChild(1).gameObject.activeInHierarchy)
        {
           
            pSol = Mathf.Round(pSol * 100.0f)/100.0f;
            prixUnitaire = pSol + " " + upArrow + " HT";
            surfaceUnitaire = "Surface " + _sceneManager.GetComponent<SceneManager_Script>()._longueur * _sceneManager.GetComponent<SceneManager_Script>()._largeur + " m²";
        }
        //CLOISON
        else if (_sceneManager.GetComponent<Select_Object_Script>().SecondMenu.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            if (_sceneManager.GetComponent<Select_Object_Script>()._select_GO == null)
            {
                prixUnitaire = pMurMain + pMurGauche + pMurDroite + " " + upArrow + " HT";
                surfaceUnitaire = "Cloisons";
            }
            else if(_sceneManager.GetComponent<Select_Object_Script>()._select_GO.name == "Wall_Main" || _sceneManager.GetComponent<Select_Object_Script>()._select_GO.name == "DecalMain")
            {
                /*
                if (_sceneManager.GetComponent<SceneManager_Script>().Wall_Tab[0].GetComponent<Texture_Script>().tex == 0)
                    surfaceUnitaire = "Textile " + _sceneManager.GetComponent<SceneManager_Script>()._longueur + " m";
                else if (_sceneManager.GetComponent<SceneManager_Script>().Wall_Tab[0].GetComponent<Texture_Script>().tex == 1)
                    surfaceUnitaire = "Bois " + _sceneManager.GetComponent<SceneManager_Script>()._longueur + " m";
                else if (_sceneManager.GetComponent<SceneManager_Script>().Wall_Tab[0].GetComponent<Texture_Script>().tex == 2)
                    surfaceUnitaire = "Personnalisé " + _sceneManager.GetComponent<SceneManager_Script>()._longueur + " m";
                */
                surfaceUnitaire = "Cloison centrale " + _sceneManager.GetComponent<SceneManager_Script>()._longueur + " m";
                prixUnitaire = pMurMain + " " + upArrow + " HT";
                
            }
            else if (_sceneManager.GetComponent<Select_Object_Script>()._select_GO.name == "Wall_Left" || _sceneManager.GetComponent<Select_Object_Script>()._select_GO.name == "DecalLeft")
            {
                /*
                if (_sceneManager.GetComponent<SceneManager_Script>().Wall_Tab[1].GetComponent<Texture_Script>().tex == 0)
                    surfaceUnitaire = "Textile " + _sceneManager.GetComponent<SceneManager_Script>()._largeur + " m";
                else if (_sceneManager.GetComponent<SceneManager_Script>().Wall_Tab[1].GetComponent<Texture_Script>().tex == 1)
                    surfaceUnitaire = "Bois " + _sceneManager.GetComponent<SceneManager_Script>()._largeur + " m";
                else if (_sceneManager.GetComponent<SceneManager_Script>().Wall_Tab[1].GetComponent<Texture_Script>().tex == 2)
                    surfaceUnitaire = "Personnalisé " + _sceneManager.GetComponent<SceneManager_Script>()._largeur + " m";
                */
                surfaceUnitaire = "Cloison gauche " + _sceneManager.GetComponent<SceneManager_Script>()._largeur + " m";
                prixUnitaire = pMurGauche + " " + upArrow + " HT";
            }
            else if (_sceneManager.GetComponent<Select_Object_Script>()._select_GO.name == "Wall_Right" || _sceneManager.GetComponent<Select_Object_Script>()._select_GO.name == "DecalRight")
            {
                /*
                if (_sceneManager.GetComponent<SceneManager_Script>().Wall_Tab[2].GetComponent<Texture_Script>().tex == 0)
                    surfaceUnitaire = "Textile " + _sceneManager.GetComponent<SceneManager_Script>()._largeur + " m";
                else if (_sceneManager.GetComponent<SceneManager_Script>().Wall_Tab[2].GetComponent<Texture_Script>().tex == 1)
                    surfaceUnitaire = "Bois " + _sceneManager.GetComponent<SceneManager_Script>()._largeur + " m";
                else if (_sceneManager.GetComponent<SceneManager_Script>().Wall_Tab[2].GetComponent<Texture_Script>().tex == 2)
                    surfaceUnitaire = "Personnalisé " + _sceneManager.GetComponent<SceneManager_Script>()._largeur + " m";
                */
                prixUnitaire = pMurDroite + " " + upArrow + " HT";
                surfaceUnitaire = "Cloison droite " + _sceneManager.GetComponent<SceneManager_Script>()._largeur + " m";
            }

        }
        //ENSEIGNE
        else if (_sceneManager.GetComponent<Select_Object_Script>().SecondMenu.transform.GetChild(2).gameObject.activeInHierarchy)
        {
            prixUnitaire = pEnseigne + " " + upArrow + " HT";
            surfaceUnitaire = "Enseigne " + _sceneManager.GetComponent<SceneManager_Script>()._enseigneLongueur + " x " + _sceneManager.GetComponent<SceneManager_Script>()._enseigneLargeur + " m";
        }
        //RESERVE
        else if (_sceneManager.GetComponent<Select_Object_Script>().SecondMenu.transform.GetChild(3).gameObject.activeInHierarchy)
        {
            prixUnitaire = pReserve + " " + upArrow + " HT";
            surfaceUnitaire = "Reserve " + _sceneManager.GetComponent<SceneManager_Script>()._reserveLongueur * _sceneManager.GetComponent<SceneManager_Script>()._reserveLargeur + " m²";
        }
        //ECLAIRAGE
        else if (_sceneManager.GetComponent<Select_Object_Script>().SecondMenu.transform.GetChild(4).gameObject.activeInHierarchy)
        {
            prixUnitaire = pLightTotal + " " + upArrow + " HT";
            surfaceUnitaire = "Eclairage " + (_lightManager_Script.nbrLightWallMain + _lightManager_Script.nbrLightWallLeft + _lightManager_Script.nbrLightWallRight + _lightManager_Script.nbrLightWallReserve + _lightManager_Script.nbrLightWallEnseigne);
        }

        _prixunitaireTXT.GetComponent<Text>().text = prixUnitaire;
        _SurfaceUnitaireTXT.GetComponent<Text>().text = surfaceUnitaire;

    }


    

}
