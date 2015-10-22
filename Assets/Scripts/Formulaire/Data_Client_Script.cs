/*
Viaud Guillaume 20/10/2015

Script attaché au gameObject : CameraGUI->Canvas->Background Formulaire
Gère les données inscrit par le client dans les champs (enfants du GO "Background Formulaire")

*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Data_Client_Script : MonoBehaviour {


	public GameObject _envoyer;

	public string _lastName;
	public string _firstName;
	public string _email;
	public string _address;
    public string _commentaire;
    public string textArea;

    // Use this for initialization
    void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		ChangeInteractableButton ();

	}

    void OnGUI()
    {

        textArea = GUI.TextArea(new Rect(847, 365, 158, 140), textArea, 1000);
        _commentaire = textArea;
    }

    public void ChangeInteractableButton()
	{
		if( _email != "" && _address != "")
		{
			_envoyer.GetComponent<Button>().interactable = true;
            
        }
		else
		{
			_envoyer.GetComponent<Button>().interactable = false;
            _envoyer.GetComponent<Image>().color = new Color(1, 1, 1, 0.1f);
        }
	}

	public void ChangeLastName(string lastName)
	{
		_lastName = lastName;
	}
	public void ChangeFirstName(string firstName)
	{
		_firstName = firstName;
	}
	public void ChangeEmail(string email)
	{
		_email = email;
	}
    public void ChangeAdresse(string address)
    {
        _address = address;
    }
    public void ChangeCommentaire(string commentaire)
    {
        _commentaire = commentaire;
    }
}
