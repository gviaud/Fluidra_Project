/*
Viaud Guillaume 20/10/2015

Récupération des prix grace au XML (/web/TestFileServer/Stand3/Parametrage_Stand.xml)

*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using OrbCreationExtensions;
using System.Xml;

public class XML_Parser : MonoBehaviour {

	public TextAsset xmlFile;

	private List<GameObject> houses = new List<GameObject>();


	public string adresse;


	public float[] prixSol;
	public float[] prixMur;
	public float[] prixLampeStand;
	public float[] prixLampeEnseigne;
	public float[] prixReserve;
	public float[] prixEnseigne;

	void Start () {
		StartCoroutine (SetupTownFromServer("http://www.pointcube.com/TestFileServer/Stand3/Parametrage_Stand.xml"));
		//SetupTownFromFile();

		// Here are some example that use an external file.
//		SetupTownFromServer("http://myserver.com/town.xml");  // from webserver
//		SetupTownFromServer("file:///path1/path2/town.xml");  // on mac
//		SetupTownFromServer("file://C:/path1/path2/town.xml");  // on windows (i believe)
	}
	/*
	void OnGUI() {
		GUI.Label(new Rect(2,2,400,400), "Very simple example of generating objects that are defined by XML files at runtime.\n\nIt uses 2 prototype of a house and a roof (ok, they are simple cubes in this example, but thats not the point).\n\nAn XML file is downloaded, the XML is parsed and gameobject are created and configured.\nHave a look in the file TownCreator.cs and Town.xml");
	}
	*/
	private void SetupTownFromFile() {
		// read xml file
		Hashtable townDefinition = SimpleXmlImporter.Import( xmlFile.text );
		// build town
		SetupTown(townDefinition);
	}

	private IEnumerator SetupTownFromServer(string url) {
		string xmlString = null;

		yield return StartCoroutine( DownloadFile ( url, retval => xmlString = retval) );

		if(xmlString!=null && xmlString.Length>0) {
			Hashtable townDefinition = SimpleXmlImporter.Import( xmlString );
			SetupTown( townDefinition );
		}
	}

	private void SetupTown(Hashtable townDefinition) {

		ArrayList prixARRAY = townDefinition.GetArrayList( "prix" );
		for(int i=0;i<prixARRAY.Count;i++) {
			Hashtable prixHASH = prixARRAY.GetHashtable(i);
			//Debug.Log(prixHASH["name"]);

			Hashtable add = prixHASH.GetHashtable( "adresse" );
			if( add != null )
			{
				adresse = add.GetString("adresse_destinataire");
			}

			//Debug.Log("hi "+prixHASH[ "m" ]);
			// get elements
			Hashtable elementDefinitions = prixHASH.GetHashtable( "matiere" );
			if( elementDefinitions == null )
				elementDefinitions = prixHASH.GetHashtable( "type" );

			if(elementDefinitions != null)
			{

				for(int j=0;j<elementDefinitions.Count;j++) {
					Hashtable elementDefinition = elementDefinitions.GetHashtable(j);

					if(prixHASH.GetString( "name" ) == "Sol")
					{
						int n = 0;
						float sol_Standard = elementDefinitions.GetFloat("standard");n++;
						prixSol = new float[n];
						//Debug.Log (""+sol_Standard+"|||"+sol_bois+"|||"+sol_bois2);
						prixSol[0] = sol_Standard;
					}
					else if(prixHASH.GetString( "name" ) == "Mur")
					{
						int n = 0;
						float mur_Coton = elementDefinitions.GetFloat("Coton");n++;
                        float mur_MelamineeBlanc = elementDefinitions.GetFloat("MelamineeBlanc"); n++;
                        float mur_MelamineeNoir = elementDefinitions.GetFloat("MelamineeNoir"); n++;
                        float mur_Personnalise = elementDefinitions.GetFloat("Personnalise");n++;

                        //Debug.Log (""+mur_Textile+"|||"+mur_bois+"|||"+mur_bois2);
                        prixMur = new float[n];

                        prixMur[0] = mur_Coton;
                        prixMur[1] = mur_MelamineeBlanc;
                        prixMur[2] = mur_MelamineeNoir;
                        prixMur[3] = mur_Personnalise;
                    }
					else if(prixHASH.GetString( "name" ) == "Lampe_Stand")
					{
						int n = 0;
						float lampe_Standard = elementDefinitions.GetFloat("standard");n++;
						float lampe_bois = elementDefinitions.GetFloat("autre");n++;
						prixLampeStand = new float[n];
						prixLampeStand[0] = lampe_Standard;
						prixLampeStand[1] = lampe_bois;
					}
					else if(prixHASH.GetString( "name" ) == "Lampe_Enseigne")
					{
						int n = 0;
						float lampe_Standard = elementDefinitions.GetFloat("standard");n++;
						float lampe_bois = elementDefinitions.GetFloat("autre");n++;
						prixLampeEnseigne = new float[n];
						prixLampeEnseigne[0] = lampe_Standard;
						prixLampeEnseigne[1] = lampe_bois;
					}
					else if(prixHASH.GetString( "name" ) == "Reserve")
					{
						int n = 0;
						float reserve_Coton = elementDefinitions.GetFloat("Coton");n++;
                        float reserve_MelamineeBlanc = elementDefinitions.GetFloat("MelamineeBlanc"); n++;
                        float reserve_MelamineeNoir = elementDefinitions.GetFloat("MelamineeNoir"); n++;
                        float reserve_Personnalise = elementDefinitions.GetFloat("Personnalise");n++;
                        prixReserve = new float[n];
                        prixReserve[0] = reserve_Coton;
                        prixReserve[1] = reserve_MelamineeBlanc;
                        prixReserve[2] = reserve_MelamineeNoir;
                        prixReserve[3] = reserve_Personnalise;
                    }
					else if(prixHASH.GetString( "name" ) == "Enseigne")
					{
						int n = 0;
						float enseigne_Personnalise = elementDefinitions.GetFloat("Personnalise");n++;
						prixEnseigne = new float[n];
						prixEnseigne[0] = enseigne_Personnalise;
					}

				}
			}


		}
		GetComponent<Prix_Script> ().startPrix ();
		
	}
	
	private IEnumerator DownloadFile(string url, System.Action<string> result) {
		Debug.Log("Downloading "+url);
        WWW www = new WWW(url);
        yield return www;
        if(www.error!=null) {
        	Debug.Log(www.error);
		} else {
        	Debug.Log("Downloaded "+www.bytesDownloaded+" bytes");
        }
       	result(www.text);
	}

}
