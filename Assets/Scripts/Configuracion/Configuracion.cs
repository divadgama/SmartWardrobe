using UnityEngine;
using System.Collections;
using System.IO;

public class Configuracion : MonoBehaviour {
	public Texture2D BotonAtras;
	public Texture2D EliminaUsuario;
	public Texture2D LogOut;
	public Texture2D ConfigAvatar;

	
	public void OnGUI() {
		if (GUI.Button (new Rect (100, 100, BotonAtras.width, BotonAtras.height), BotonAtras)) {
			
			Application.LoadLevel ("PantallaPrincipal");
		}

		if (GUI.Button (new Rect ((Screen.width/2)-350, (Screen.height/2)-50, ConfigAvatar.width, ConfigAvatar.height),ConfigAvatar)) {
			
			Application.LoadLevel ("ConfiguracionAvatar");
		}
		GUI.Label (new Rect ((Screen.width/2)-310,(Screen.height/2)-80, 50, 50),"Avatar" );
		if (GUI.Button (new Rect ((Screen.width/2)+40, (Screen.height/2)-50, LogOut.width, LogOut.height),LogOut)) {

			Application.LoadLevel ("PantallaInicio");
		}
		GUI.Label (new Rect ((Screen.width/2)+90, (Screen.height/2)-80, 50, 50),"Salir" );
		if (GUI.Button (new Rect ((Screen.width/2)-155, (Screen.height/2)-50, EliminaUsuario.width, EliminaUsuario.height),EliminaUsuario)) {
			//elimiar carpetas del servidor y base de datos del usuario
			BorraUsuario();
		}
		GUI.Label (new Rect ((Screen.width/2)-120,(Screen.height/2)-80, 50, 50),"Eliminar" );
	}



	void BorraUsuario(){
		
		StartCoroutine (Borrar ());
		
	}
	
	IEnumerator Borrar(){
		
				WWWForm postForm = new WWWForm ();
		
				postForm.AddField ("idUsuario", Variables.idUsuario);
	
				WWW upload = new WWW ("myfres.com/SmartWardrobe/EliminaUsuario.php", postForm);
				yield return upload;
				if (upload.error == null)
				{Debug.Log ("upload done :" + upload.text);
				Application.LoadLevel ("PantallaInicio");
				}
		else
			Debug.Log("Error during upload: " + upload.error);
		
	}






}

