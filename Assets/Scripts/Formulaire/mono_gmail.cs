/*
Viaud Guillaume 20/10/2015

Script qui ne sert à rien étant donné que le mail est géré en PHP
Tous simplement car se script ne fonctionne pas : les attachments mon posé probleme
*/

using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;

public class mono_gmail : MonoBehaviour 
{

	public void SendMail(Stream _content)
	{
		try{


			MailMessage mail = new MailMessage();

			SmtpClient SmtpServer = new SmtpClient("mail.infomaniak.ch");
			mail.From = new MailAddress("viaud-guillame@hotmail.fr");
			mail.To.Add("gviaud@pointcube.fr");
			
			mail.Subject = "StandExpo";
			mail.Body = "Formulaire";

			string sAttachPDF = Application.dataPath + "/" + GetComponent<CreatePDF_Script>().dosName + "/" + GetComponent<CreatePDF_Script>().attacName;

			sAttachPDF = "http://www.pointcube.com/TestFileServer/Stand3/" + GetComponent<CreatePDF_Script>().dosName + "/" + GetComponent<CreatePDF_Script>().attacName;
			//string sAttachPDF = GetComponent<CreatePDF_Script>().attacName;
			//Attachment myAttachmentPDF = new Attachment(sAttachPDF);
			/*
			StartDl_PDF(sAttachPDF);
			print ("reader.bytesDL : "+reader.bytesDownloaded);
			using (MemoryStream ms = new MemoryStream(reader.bytes))
			{
				print ("pass2");
				mail.Attachments.Add(new Attachment(ms, GetComponent<CreatePDF_Script>().attacName));
			}
			*/
			//StartCoroutine(DelDos( mail, _content ));
			mail.Attachments.Add(new Attachment(_content, GetComponent<CreatePDF_Script>().dosName + "/" + GetComponent<CreatePDF_Script>().attacName));

			SmtpServer.Port = 587;
			SmtpServer.Credentials = new System.Net.NetworkCredential("gviaud@pointcube.fr", "zxn5uoemg24X") as ICredentialsByHost;
			SmtpServer.EnableSsl = true;
			ServicePointManager.ServerCertificateValidationCallback = 
				delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
			{return true; };
			//Debug.Log("Send ...");
			SmtpServer.Send(mail);
			Debug.Log("success");

			//SuppressionDos
			StartCoroutine ( DelDos() );
		}
		catch(Exception e){
			Console.WriteLine("Ouch!"+e.ToString());
		}
	}

	public IEnumerator DelDos()
	{
		WWWForm form = new WWWForm();
		form.AddField("action", "DeleteDir");
		form.AddField("Dos",GetComponent<CreatePDF_Script>().dosName);
		form.AddField("fileName",GetComponent<CreatePDF_Script>().attacName);

		WWW www = new WWW("http://www.pointcube.com/TestFileServer/Stand3/UploadPDF.php", form);
		yield return www;
	}

}
