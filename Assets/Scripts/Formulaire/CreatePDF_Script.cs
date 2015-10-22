/*
Viaud Guillaume 20/10/2015

Création du PDF et envoit des données à une page php (/web/TestFileServer/Stand3/UploadPDF.php) se trouvant sur le serveur. 
Cette page envoit le pdf par mail à l'adresse indiquer dans le XML (/web/TestFileServer/Stand3/Parametrage_Stand.xml)

*/
using UnityEngine;
using 	System.Collections;
using 	System.Collections.Generic;
using 	System.IO;
using	sharpPDF;
using	sharpPDF.Enumerators;
using System.Xml;
using System.Text;
using 	UnityEngine.UI;

public class CreatePDF_Script : MonoBehaviour {

	public Texture2D bandeau;
	internal string attacName;
	internal string dosName;
	public byte[] buffer;

	public GameObject _menuFormulaire;
	public GameObject _sceneManager;

	public GameObject _cam1;
	public GameObject _cam2;
	public GameObject _slider;

	public GameObject _messVALIDATION;
	float timerMessValidation;

    XML_Parser xml_Parser;

    // Use this for initialization
    IEnumerator StartPDF () {
		yield return StartCoroutine ( CreatePDF() );
	}

	void Start()
	{
		timerMessValidation = -11;
	}

	void Update()
	{	
		if (timerMessValidation > -10 ) 
		{
			timerMessValidation -= Time.deltaTime;
			if (timerMessValidation <= 0 ) {
				_messVALIDATION.SetActive(false);
                _sceneManager.GetComponent<SceneManager_Script>().Reinit();
			}
			else if(Input.GetMouseButtonDown(0))
			{
				_messVALIDATION.SetActive(false);
                _sceneManager.GetComponent<SceneManager_Script>().Reinit();
            }
		}

	}

	public void Create_PDF()
	{
		StartCoroutine ( StartPDF() );

	}

	// Update is called once per frame
	public IEnumerator CreatePDF () 
	{

        xml_Parser = GetComponent<XML_Parser>();

        Prix_Script _prix_Script = GetComponent<Prix_Script> ();
        float prix_FraisDossier = _prix_Script.prixFraisDossier;


        attacName = Path.GetRandomFileName();
		attacName = attacName.Substring(0,6);
		attacName = attacName.ToUpper();
		dosName = attacName;
		attacName = attacName + ".pdf";

		Data_Client_Script _data_Client_Script = _menuFormulaire.GetComponent<Data_Client_Script>();

		string nom = _data_Client_Script._lastName;
		string prenom = _data_Client_Script._firstName;
		string adresse = _data_Client_Script._address;
        string mail = _data_Client_Script._email;
        string commentaire = _data_Client_Script._commentaire;

        attacName = nom + ".pdf";

        pdfDocument myDoc = new pdfDocument("Sample Application","Me", false);
		pdfPage myFirstPage = myDoc.addPage();
        pdfPage mySecondPage = myDoc.addPage();
        //pdfPage myThirdPage = myDoc.addPage();
        //pdfPage myFourthPage = myDoc.addPage();

        int longueur = MySingleton.Instance._length;
		int largeur = MySingleton.Instance._width;

		bool _Wall_Main = MySingleton.Instance._Wall_Main;
		bool _Wall_Left = MySingleton.Instance._Wall_Left;
		bool _Wall_Right = MySingleton.Instance._Wall_Right;
		bool _Wall_Behind = MySingleton.Instance._Wall_Behind;

		bool _Enseigne = MySingleton.Instance._Enseigne;
		int longueur_Enseigne = MySingleton.Instance._longueur_Enseigne;
		int largeur_Enseigne = MySingleton.Instance._largeur_Enseigne;

		bool _Reserve = MySingleton.Instance._Reserve;
		int longueur_Reserve = MySingleton.Instance._longueur_Reserve;
		int largeur_Reserve = MySingleton.Instance._largeur_Reserve;

		//width = 612
		//height = ?
		myFirstPage.newAddImageV4 (bandeau, 180,myFirstPage.height - 130);

		//myFirstPage.addText("Devis",10,650,predefinedFont.csHelveticaOblique,30,new pdfColor(predefinedColor.csBlueStandExpo));

		myFirstPage.addText("Nom : " +nom,55,650,predefinedFont.csHelveticaOblique,11,new pdfColor(predefinedColor.csBlack));
		myFirstPage.addText("Prénom : " +prenom,55,630,predefinedFont.csHelveticaOblique,11,new pdfColor(predefinedColor.csBlack));
		myFirstPage.addText("Nom de la société: " +adresse,55,610,predefinedFont.csHelveticaOblique,11,new pdfColor(predefinedColor.csBlack));
		myFirstPage.addText("Email : " + mail, 55, 590, predefinedFont.csHelveticaOblique, 11, new pdfColor(predefinedColor.csBlack));

		if (commentaire != "") {
			string newParagraph = "Commentaire : \n" + commentaire;
			myFirstPage.addParagraph (newParagraph, 306, 660, predefinedFont.csHelveticaOblique, 11, myFirstPage.width / 2 - 20, 12, new pdfColor (predefinedColor.csBlack));
		}
        /*
        pdfTable remarqueTable = new pdfTable();
        remarqueTable.borderSize = 1;
        remarqueTable.tableHeader.addColumn(new pdfTableColumn("", predefinedAlignment.csLeft, myThirdPage.width - 50));
        remarqueTable.cellpadding = 60;
        myThirdPage.addTable(remarqueTable, 20, 150);

        remarqueTable = null;
        */


        yield return new WaitForEndOfFrame();

		/*Table's creation*/

		pdfTable myTable = new pdfTable();
		//Set table's border
		myTable.borderSize = 1;
		myTable.borderColor = new pdfColor(predefinedColor.csBlack);
		/*Create table's header*/
		int nbrRow = 0;
		myTable.tableHeader.addColumn(new pdfTableColumn("Stand",predefinedAlignment.csCenter,160));
		myTable.tableHeader.addColumn(new pdfTableColumn("Mesure",predefinedAlignment.csCenter,120));
		myTable.tableHeader.addColumn(new pdfTableColumn("Prix unit",predefinedAlignment.csCenter,120));
		myTable.tableHeader.addColumn(new pdfTableColumn("Prix",predefinedAlignment.csCenter,100));

		//Create table's rows
		pdfTableRow myRow;
		/*
		 * Si erreur : taille de la cellule trop petite par rapport au texte
		 */

		float _prixObjet = 0;

		myRow = myTable.createRow();//myRow[0].columnSize
		myRow[0].columnValue = "Sol";
		myRow[1].columnValue = (longueur*largeur) + "m²";
		myRow[2].columnValue = _prix_Script.prixSol[0] + " Euros/m² HT";
		myRow[3].columnValue = _prix_Script.pSol + " Euros HT";
		myTable.addRow(myRow);
		_prixObjet += _prix_Script.pSol;
		nbrRow = 2;


		if (_Wall_Main || _Wall_Left || _Wall_Right) 
		{

			int longueurGaineCoton = 0;
			int longueurMelamineeBlanc = 0;
			int longueurMelamineeNoir = 0;
			int longueurPersonnalise = 0;

			float prixGaineCoton = 0;
			float prixMelamineeBlanc = 0;
			float prixMelamineeNoir = 0;
			float prixPersonnalise = 0;

			if( _Wall_Main )
			{
				if( _prix_Script.matiereMur[0] == "Gainée coton" )
				{
					longueurGaineCoton += longueur;
					prixGaineCoton += _prix_Script.pMurMain;
				}
				else if( _prix_Script.matiereMur[0] == "Mélaminée blanc" )
				{
					longueurMelamineeBlanc += longueur;
					prixMelamineeBlanc += _prix_Script.pMurMain;
				}
				else if( _prix_Script.matiereMur[0] == "Mélaminée noir" )
				{
					longueurMelamineeNoir += longueur;
					prixMelamineeNoir += _prix_Script.pMurMain;
				}
				else if( _prix_Script.matiereMur[0] == "Personnalisée" )
				{
					longueurPersonnalise += longueur;
					prixPersonnalise += _prix_Script.pMurMain;
				}
			}
			if( _Wall_Left )
			{
				if( _prix_Script.matiereMur[1] == "Gainée coton" )
				{
					longueurGaineCoton += largeur;
					prixGaineCoton += _prix_Script.pMurGauche;
				}
				else if( _prix_Script.matiereMur[1] == "Mélaminée blanc" )
				{
					longueurMelamineeBlanc += largeur;
					prixMelamineeBlanc += _prix_Script.pMurGauche;
				}
				else if( _prix_Script.matiereMur[1] == "Mélaminée noir" )
				{
					longueurMelamineeNoir += largeur;
					prixMelamineeNoir += _prix_Script.pMurGauche;
				}
				else if( _prix_Script.matiereMur[1] == "Personnalisée" )
				{
					longueurPersonnalise += largeur;
					prixPersonnalise += _prix_Script.pMurGauche;
				}
			}
			if( _Wall_Right )
			{
				if( _prix_Script.matiereMur[2] == "Gainée coton" )
				{
					longueurGaineCoton += largeur;
					prixGaineCoton += _prix_Script.pMurDroite;
				}
				else if( _prix_Script.matiereMur[2] == "Mélaminée blanc" )
				{
					longueurMelamineeBlanc += largeur;
					prixMelamineeBlanc += _prix_Script.pMurDroite;
				}
				else if( _prix_Script.matiereMur[2] == "Mélaminée noir" )
				{
					longueurMelamineeNoir += largeur;
					prixMelamineeNoir += _prix_Script.pMurDroite;
				}
				else if( _prix_Script.matiereMur[2] == "Personnalisée" )
				{
					longueurPersonnalise += largeur;
					prixPersonnalise += _prix_Script.pMurDroite;
				}
			}

			if( prixGaineCoton > 0)
			{

				myRow = myTable.createRow();
				myRow[0].columnValue = "Cloison Gainée coton";
				myRow[1].columnValue = longueurGaineCoton+" m";
				myRow[2].columnValue = _prix_Script.prixMur[0] + " Euros/m HT";
				myRow[3].columnValue = prixGaineCoton + " Euros HT";
				myTable.addRow(myRow);
				_prixObjet += prixGaineCoton;
				nbrRow++;

			}
			if( prixMelamineeBlanc > 0)
			{
				
				myRow = myTable.createRow();
				myRow[0].columnValue = "Cloison Mélaminée blanc";
				myRow[1].columnValue = longueurMelamineeBlanc+" m";
				myRow[2].columnValue = _prix_Script.prixMur[1] + " Euros/m HT";
				myRow[3].columnValue = prixMelamineeBlanc + " Euros HT";
				myTable.addRow(myRow);
				_prixObjet += prixMelamineeBlanc;
				nbrRow++;
				
			}
			if( prixMelamineeNoir > 0)
			{
				
				myRow = myTable.createRow();
				myRow[0].columnValue = "Cloison Mélaminée noir";
				myRow[1].columnValue = longueurMelamineeNoir+" m";
				myRow[2].columnValue = _prix_Script.prixMur[2] + " Euros/m HT";
				myRow[3].columnValue = prixMelamineeNoir + " Euros HT";
				myTable.addRow(myRow);
				_prixObjet += prixMelamineeNoir;
				nbrRow++;
				
			}
			if( prixPersonnalise > 0)
			{
				
				myRow = myTable.createRow();
				myRow[0].columnValue = "Cloison Personnalisée";
				myRow[1].columnValue = longueurPersonnalise+" m";
				myRow[2].columnValue = _prix_Script.prixMur[3] + " Euros/m HT";
				myRow[3].columnValue = prixPersonnalise + " Euros HT";
				myTable.addRow(myRow);
				_prixObjet += prixPersonnalise;
				nbrRow++;
				
			}

		}



		if( _Reserve )
		{
			myRow = myTable.createRow();
			myRow[0].columnValue = "Reserve " + _prix_Script.matiereReserve;
			myRow[1].columnValue = longueur_Reserve * largeur_Reserve + "m²";
			myRow[2].columnValue = _prix_Script.prixReserve[_prix_Script._reserve.GetComponent<Texture_Script>().tex] + " Euros/m² HT";
			//myRow[3].columnValue = _prix_Script.matiereReserve;
			myRow[3].columnValue = _prix_Script.pReserve + " Euros HT";
			myTable.addRow(myRow);
			_prixObjet += _prix_Script.pReserve;
			nbrRow++;
		}
		if( _Enseigne )
		{
			myRow = myTable.createRow();
			myRow[0].columnValue = "Enseigne";
			if( !_sceneManager.GetComponent<SceneManager_Script>()._isCarre )
				myRow[1].columnValue = longueur_Enseigne + "m ";
			else
				myRow[1].columnValue = longueur_Enseigne + "m * 4";
			myRow[2].columnValue = _prix_Script.prixEnseigne[_prix_Script._enseigne[0].GetComponent<Texture_Script>().tex] + " Euros/m HT";
			//myRow[3].columnValue = _prix_Script.matiereEnseigne;
			myRow[3].columnValue = _prix_Script.pEnseigne + " Euros HT";
			myTable.addRow(myRow);
			_prixObjet += _prix_Script.pEnseigne;
			nbrRow++;
		}




		int nbrBecSigne = 0;
		int nbrPelleTarte = 0;

		if( _Wall_Main )
		{
			nbrBecSigne += _prix_Script._lightManager_Script.nbrLightWallMain;
		}
		if( _Wall_Left )
		{
			nbrBecSigne += _prix_Script._lightManager_Script.nbrLightWallLeft;
		}
		if( _Wall_Right )
		{
			nbrBecSigne += _prix_Script._lightManager_Script.nbrLightWallRight;
		}
		if( _Reserve )
		{
			nbrBecSigne += _prix_Script._lightManager_Script.nbrLightWallReserve;
		}

		if( _Enseigne )
		{
			nbrPelleTarte += _prix_Script._lightManager_Script.nbrLightWallEnseigne;
		}




		if (nbrBecSigne > 0) {
			myRow = myTable.createRow ();
			myRow [0].columnValue = "Col de cygne";
			myRow [1].columnValue = nbrBecSigne + " Lampe(s)";
			myRow [2].columnValue = _prix_Script.prixLampeStand [0] + " Euros HT";
			myRow [3].columnValue = ( _prix_Script.pLightMurDroite + _prix_Script.pLightMurMain + _prix_Script.pLightMurGauche  + _prix_Script.pLightReserve ) + " Euros HT";
			myTable.addRow (myRow);
			nbrRow++;
		}
		if (nbrPelleTarte > 0) {
			myRow = myTable.createRow ();
			myRow [0].columnValue = "Pelle à Tarte";
			myRow [1].columnValue = nbrPelleTarte + " Lampe(s)";
			myRow [2].columnValue = _prix_Script.prixLampeEnseigne [0] + " Euros HT";
			myRow [3].columnValue = _prix_Script.pLightEnseigne + " Euros HT";
			myTable.addRow (myRow);
			nbrRow++;
		}



		myRow = myTable.createRow();
		myRow[0].columnValue = "Total + "+ prix_FraisDossier + " Euros HT";
		myRow[1].columnValue = "";
		myRow[2].columnValue = "";
		myRow[3].columnValue = (_prixObjet + _prix_Script.pLightTotal + prix_FraisDossier) + " Euros HT";
		myTable.addRow(myRow);
		nbrRow++;

		/*Set Header's Style*/
		int sizeRowTitle = 10;
		myTable.tableHeaderStyle = new pdfTableRowStyle(predefinedFont.csCourierBoldOblique,sizeRowTitle,new pdfColor(predefinedColor.csBlack),new pdfColor(predefinedColor.csBlueStandExpo));
		/*Set Row's Style*/
		int sizeRow = 9;
		myTable.rowStyle = new pdfTableRowStyle(predefinedFont.csCourier,sizeRow,new pdfColor(predefinedColor.csBlack),new pdfColor(predefinedColor.csWhite));
		/*Set Alternate Row's Style*/
		myTable.alternateRowStyle = new pdfTableRowStyle(predefinedFont.csCourier,sizeRow,new pdfColor(predefinedColor.csBlack),new pdfColor(predefinedColor.csLightYellow));
		/*Set Cellpadding*/
		myTable.cellpadding = 13;
		//Put the table on the page object
		myFirstPage.addTable(myTable, 55, (myFirstPage.height/2));
		myTable = null;

		int ligne = (mySecondPage.height - 20) - ((13*3) * nbrRow);
	
		//yield return new WaitForEndOfFrame();






		/*
		
		pdfTable myTableLight = new pdfTable();
		//Set table's border
		myTableLight.borderSize = 1;
		myTableLight.borderColor = new pdfColor(predefinedColor.csBlack);
		/
		nbrRow = 0;
		myTableLight.tableHeader.addColumn(new pdfTableColumn("Lampe",predefinedAlignment.csCenter,130));
		myTableLight.tableHeader.addColumn(new pdfTableColumn("Nombre",predefinedAlignment.csCenter,130));
		myTableLight.tableHeader.addColumn(new pdfTableColumn("Prix unitaire",predefinedAlignment.csCenter,150));
		myTableLight.tableHeader.addColumn(new pdfTableColumn("Prix",predefinedAlignment.csCenter,130));
		nbrRow ++;
		//Create table's rows
		pdfTableRow myRowLight;
		float _prixLight = 0;
		
		if( _Wall_Main )
		{
			myRowLight = myTableLight.createRow();
			myRowLight[0].columnValue = "Cloison 1";
			myRowLight[1].columnValue = _prix_Script._lightManager_Script.nbrLightWallMain + " lampe(s)";
			myRowLight[2].columnValue = _prix_Script.prixLampeStand[0] + " Euro";
			myRowLight[3].columnValue = _prix_Script.pLightMurMain + " Euros";
			myTableLight.addRow(myRowLight);
			_prixLight += _prix_Script.pLightMurMain;
			nbrRow++;
		}
		if( _Wall_Left )
		{
			myRowLight = myTableLight.createRow();
			myRowLight[0].columnValue = "Cloison 2";
			myRowLight[1].columnValue = _prix_Script._lightManager_Script.nbrLightWallLeft + " lampe(s)";
			myRowLight[2].columnValue = _prix_Script.prixLampeStand[0] + " Euros";
			myRowLight[3].columnValue = _prix_Script.pLightMurGauche + " Euros";
			myTableLight.addRow(myRowLight);
			_prixLight += _prix_Script.pLightMurGauche;
			nbrRow++;
		}
		if( _Wall_Right )
		{
			myRowLight = myTableLight.createRow();
			myRowLight[0].columnValue = "Cloison 3";
			myRowLight[1].columnValue = _prix_Script._lightManager_Script.nbrLightWallRight + " lampe(s)";
			myRowLight[2].columnValue = _prix_Script.prixLampeStand[0] + " Euros";
			myRowLight[3].columnValue = _prix_Script.pLightMurDroite + " Euros";
			myTableLight.addRow(myRowLight);
			_prixLight += _prix_Script.pLightMurDroite;
			nbrRow++;
		}
		if( _Reserve )
		{
			myRowLight = myTableLight.createRow();
			myRowLight[0].columnValue = "Reserve";
			myRowLight[1].columnValue = _prix_Script._lightManager_Script.nbrLightWallReserve + " lampe(s)";
			myRowLight[2].columnValue = _prix_Script.prixLampeStand[0] + " Euros";
			myRowLight[3].columnValue = _prix_Script.pLightReserve + " Euros";
			myTableLight.addRow(myRowLight);
			_prixLight += _prix_Script.pLightReserve;
			nbrRow++;
		}
		if( _Enseigne )
		{
			myRowLight = myTableLight.createRow();
			myRowLight[0].columnValue = "Enseigne";
			myRowLight[1].columnValue = _prix_Script._lightManager_Script.nbrLightWallEnseigne + " lampe(s)";
			myRowLight[2].columnValue = _prix_Script.prixLampeEnseigne[0] + " Euros";
			myRowLight[3].columnValue = _prix_Script.pLightEnseigne + " Euros";
			myTableLight.addRow(myRowLight);
			_prixLight += _prix_Script.pLightEnseigne;
			nbrRow++;
		}

		myRow = myTableLight.createRow();
		myRow[0].columnValue = "Total";
		myRow[1].columnValue = "";
		myRow[2].columnValue = "";
		myRow[3].columnValue = _prixLight + " Euros";
		myTableLight.addRow(myRow);
		nbrRow++;


		sizeRowTitle = 15;
		myTableLight.tableHeaderStyle = new pdfTableRowStyle(predefinedFont.csCourierBoldOblique,sizeRowTitle,new pdfColor(predefinedColor.csBlack),new pdfColor(predefinedColor.csBlueStandExpo));

		sizeRow = 12;
		myTableLight.rowStyle = new pdfTableRowStyle(predefinedFont.csCourier,sizeRow,new pdfColor(predefinedColor.csBlack),new pdfColor(predefinedColor.csWhite));

		myTableLight.alternateRowStyle = new pdfTableRowStyle(predefinedFont.csCourier,sizeRow,new pdfColor(predefinedColor.csBlack),new pdfColor(predefinedColor.csLightYellow));

		myTableLight.cellpadding = 13;
		//Put the table on the page object
		mySecondPage.addTable(myTableLight, 10, ligne);
		myTableLight = null;

		ligne -= (10 + ((13*3) * nbrRow ));


		yield return new WaitForEndOfFrame();



		pdfTable myTableTotal = new pdfTable();
		//Set table's border
		myTableTotal.borderSize = 1;
		myTableTotal.borderColor = new pdfColor(predefinedColor.csBlack);

		nbrRow = 0;
		myTableTotal.tableHeader.addColumn(new pdfTableColumn("Total",predefinedAlignment.csCenter,130));
		myTableTotal.tableHeader.addColumn(new pdfTableColumn(_prixLight + _prixObjet + " Euros",predefinedAlignment.csCenter,130));


		sizeRowTitle = 15;
		myTableTotal.tableHeaderStyle = new pdfTableRowStyle(predefinedFont.csCourierBoldOblique,sizeRowTitle,new pdfColor(predefinedColor.csBlack),new pdfColor(predefinedColor.csVertStandExpo));
	
		sizeRow = 12;
		myTableTotal.rowStyle = new pdfTableRowStyle(predefinedFont.csCourier,sizeRow,new pdfColor(predefinedColor.csBlack),new pdfColor(predefinedColor.csWhite));
	
		myTableTotal.alternateRowStyle = new pdfTableRowStyle(predefinedFont.csCourier,sizeRow,new pdfColor(predefinedColor.csBlack),new pdfColor(predefinedColor.csLightYellow));

		myTableTotal.cellpadding = 13;
		//Put the table on the page object
		mySecondPage.addTable(myTableTotal, 10, ligne);
		myTableTotal = null;


		*/









		yield return new WaitForSeconds(3.0f);
		mySecondPage.newAddImageV2 (GetComponent<Capture_Script>()._texture, mySecondPage.width/ 2 - ((GetComponent<Capture_Script> ()._texture.width/2)/2), mySecondPage.height - 10 - (GetComponent<Capture_Script> ()._texture.height)/2);
		mySecondPage.newAddImageV2(GetComponent<Capture_Script>()._texture2, mySecondPage.width / 2 - ((GetComponent<Capture_Script>()._texture2.width / 2) / 2)/*25*/, mySecondPage.height - 20 - (GetComponent<Capture_Script>()._texture.height));

		/*
        pdfTable remarqueTable = new pdfTable();
        remarqueTable.borderSize = 1;
		remarqueTable.tableHeader.addColumn(new pdfTableColumn("", predefinedAlignment.csCenter, mySecondPage.width-50));
        remarqueTable.cellpadding = 60;
        myFirstPage.addTable(remarqueTable, 20, 150);
       
        remarqueTable = null;

        myFirstPage.addText("Remarque : ", 23, 130, predefinedFont.csHelveticaOblique, 15, new pdfColor(predefinedColor.csBlack));
		*/

        //print (myFirstPage.width);->612
        myDoc.createPDF(attacName);





		buffer = System.IO.File.ReadAllBytes(attacName);

		WWWForm form = new WWWForm();
		form.AddField("action", "createPDF");
        form.AddField("add", xml_Parser.adresse);
        form.AddField("add2", _data_Client_Script._email);
        form.AddField("file","file");
		form.AddField("Dos",dosName);

		form.AddBinaryData( "file", buffer, attacName,"pdf");

		WWW www = new WWW("http://www.pointcube.com/TestFileServer/Stand3/UploadPDF.php", form);
		yield return www;
		print("SenMail");

		//_menuFormulaire.SetActive (true);
		_sceneManager.GetComponent<Select_Object_Script> ()._block = false;
		//_sceneManager.GetComponent<Select_Object_Script> ()._cacheBool = false;

		_cam1.SetActive (true);
		//_cam2.SetActive (true);
		//_slider.SetActive (true);

		_messVALIDATION.transform.GetChild(0).GetComponent<Text>().text = "Merci pour votre montage";
		timerMessValidation = 3.0f;
        _messVALIDATION.SetActive(true);

        /*
		if (www.error != null) 
		{
			print (www.error);    
		} 
		else 
		{
			//print (www.uploadProgress);
			if(www.uploadProgress == 1  && www.isDone)
			{

				yield return new WaitForSeconds(1);
				//change the url to the url of the folder you want it the levels to be stored, the one you specified in the php file
				WWW w2 = new WWW("http://www.pointcube.com/TestFileServer/Stand3/" + dosName + "/" + attacName);
				while(!w2.isDone){yield return w2;}

				if(w2.error != null)
				{
					print("error 2");
					print ( w2.error );  
				}
				else
				{
					//WWW.LoadFromCacheOrDownload
					print("SenMail");
					//GetComponent<mono_gmail>().SendMail(myDoc._myFileStream);

				}

			}      
		}
		*/
    }

}
