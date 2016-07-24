using UnityEngine;
using System.Collections;
using System.IO;

public class EntadaDeDatos : MonoBehaviour {
	
	protected string stringUsuario="";
	protected string stringPass="";
	
	private bool mensaje_errorUsuario=false;
	
	public Texture2D BotonEnviar;
	public Texture2D BotonAyuda;

	public Texture2D Botonregistro;


	void OnGUI() {
		//Colocación de los objetos en la pantalla
		GUI.Label(new Rect(Screen.width/4,(Screen.height/3),200,20),"Usuario");
		GUI.Label (new Rect (Screen.width/4, (Screen.height/3)+40, 200, 20), "Contraseña");
		stringUsuario = GUI.TextField(new Rect((Screen.width/4)+80,(Screen.height/3), 200, 20),stringUsuario,20);
		stringPass = GUI.PasswordField(new Rect((Screen.width/4)+80, (Screen.height/3)+40, 200, 20),stringPass,"*"[0],20);

		//GUI.Label(new Rect (posx,posy,miImagen.width,miImagen.height),miImagen);

		if (GUI.Button (new Rect ((Screen.width/4)+300, (Screen.height/3)+8, BotonEnviar.width, BotonEnviar.height),BotonEnviar)) {
						//Application.LoadLevel("Habitacion");
						//comprobar los datos de usuario para saber si esta registrado.
			CompruebaDatos();

		}
		if (GUI.Button (new Rect ((Screen.width/4)+300, (Screen.height/3)+100,42,30),Botonregistro)) {
		
			//se carga la pantalla para registro de usuario
			Application.LoadLevel("PantallaRegistro");
		}

		//boton de ayuda para que el ususario sepa que hacer en todo momento
		GUI.Button (new Rect ((Screen.width/4)+80, (Screen.height/3)+100,BotonAyuda.width,BotonAyuda.height),new GUIContent (BotonAyuda,"Si estas registraado en el sistema introduce tu usuario y contraseña" +
			" sino pulsa el boton '+' para registrarte"));
			GUI.Label(new Rect((Screen.width/4)+80,(Screen.height/3)+60,400,200),GUI.tooltip);

		//boton para recuperar contraseña
		if (GUI.Button (new Rect ((Screen.width/4)+130, (Screen.height/3)+110,150,20),
		                new GUIContent ("Recuperar contraseña",""))) {
			
			//se carga la pantalla para registro de usuario
			Application.LoadLevel("RecuperaPass");
		}
	

		if (mensaje_errorUsuario) {
			GUI.Label(new Rect((Screen.width/4),(Screen.height/3)-25,400,25),"El usuario y la contraseña no coinciden con usuario registrado");
		}
	}


	void CompruebaDatos(){

	 StartCoroutine (consulta ());

	}
	
	IEnumerator consulta(){

		int compara=1;
		string ConsultaURL="myfres.com/SmartWardrobe/login.php?";

		string post_url = ConsultaURL + "usuario=" + WWW.EscapeURL(stringUsuario) + "&pass=" + WWW.EscapeURL(stringPass);
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done

		print (post_url);
		if (hs_post.error != null)
		{
			print("Error Consulta " + hs_post.error);
		}

		compara = int.Parse(hs_post.text);
		print (compara);
		
		if (compara==0){
			mensaje_errorUsuario=true;

		}
		else {

			//Creacion de las carpetas necesarias para almacenar de forma local las fotos dependiendo de el tipo de prenda.
			mensaje_errorUsuario=false;
			Variables.idUsuario=compara;
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara);
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Pantalon");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Pantalon/Texturas");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Pantalon/Prendas");
			
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Camiseta");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Camiseta/Texturas");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Camiseta/Prendas");
			
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Sudadera");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Sudadera/Texturas");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Sudadera/Prendas");
			
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Camisa");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Camisa/Texturas");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Camisa/Prendas");
			
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Vestido");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Vestido/Texturas");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Vestido/Prendas");
			
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Jersey");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Jersey/Texturas");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Jersey/Prendas");
				
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Chaqueta");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Chaqueta/Texturas");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/Chaqueta/Prendas");
			
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/PantalonCorto");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/PantalonCorto/Texturas");
			Directory.CreateDirectory(Application.dataPath + "/RopaArmario/"+compara+"/PantalonCorto/Prendas");

			Application.LoadLevel("PantallaPrincipal");
			//Cargar el usuario para que empiece en la aplicacion

		}
		
	}
	
}
