using UnityEngine;
using System.Collections;

public class RecuperaPass : MonoBehaviour {

	private string stringUsuario="";
		
	private bool mensaje_errorUsuario=false;

	private bool mensaje_usuarioEnvio=false;
	
	public Texture2D BotonEnviar;
	public Texture2D BotonAtras;
	public Texture2D BotonAyuda;
	

	void OnGUI() {
		//Colocación de los objetos en la pantalla
		GUI.Label(new Rect(Screen.width/4,(Screen.height/3)+20,200,20),"Usuario");
		stringUsuario = GUI.TextField(new Rect((Screen.width/4)+80,(Screen.height/3)+20, 200, 20),stringUsuario,20);

		
		//GUI.Label(new Rect (posx,posy,miImagen.width,miImagen.height),miImagen);
		
		if (GUI.Button (new Rect ((Screen.width/4)+300, (Screen.height/3)+8, BotonEnviar.width, BotonEnviar.height),BotonEnviar)) {
			//Application.LoadLevel("Habitacion");
			//comprobar los datos de usuario para saber si esta registrado.
			mensaje_errorUsuario=false;
			mensaje_usuarioEnvio=false;
			enviapeticion();
			stringUsuario="";
			
		}
		GUI.Button (new Rect ((Screen.width/4)+80, (Screen.height/3)+100,BotonAyuda.width,BotonAyuda.height),new GUIContent (BotonAyuda,"Introduzca su usuario y se le enviara la contraseña a su mail"));
		GUI.Label(new Rect((Screen.width/4)+80,(Screen.height/3)+60,300,200),GUI.tooltip);
		
		if (mensaje_errorUsuario) {
			GUI.Label(new Rect((Screen.width/4)+10,(Screen.height/3)-20,250,20),"El usuario no esta registrado");
		}
		if (mensaje_usuarioEnvio) {
			GUI.Label(new Rect((Screen.width/4)+10,(Screen.height/3)-20,400,20),"La contraseña se ha enviado a su mail de registro, vuelva a inicio");
		}
		//volver a la pantalla de inicio
		if (GUI.Button (new Rect (100, 100, BotonAtras.width, BotonAtras.height), BotonAtras)) {
			
			Application.LoadLevel("PantallaInicio");
			
		}
	}
	
	
	void enviapeticion(){
		
		StartCoroutine (consulta ());
		
	}
	
	IEnumerator consulta(){
		
		int compara=1;
		string ConsultaURL="myfres.com/SmartWardrobe/recuperapass.php?";
		
		string post_url = ConsultaURL + "usuario=" + WWW.EscapeURL(stringUsuario);
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done
		
		
		if (hs_post.error != null)
		{
			print("Error Consulta " + hs_post.error);
		}
		
		compara = int.Parse(hs_post.text);

		if (compara==1){
			mensaje_errorUsuario=false;
			mensaje_usuarioEnvio=true;
		}
		else {
			mensaje_errorUsuario=true;
		}
	}
}
