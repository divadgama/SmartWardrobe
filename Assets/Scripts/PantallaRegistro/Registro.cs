using UnityEngine;
using System.Collections;
using System.IO;

public class Registro : MonoBehaviour {

	private string stringNombre="";
	private string stringApellido="";
	private string stringUsuario="";
	private string stringPass="";
	private string stringEmail="";

	private bool mensaje_errorRegistro=false;
	private bool mensaje_errorSexo = false;

	public Texture2D BotonRegistro;
	public Texture2D BotonChico;
	public Texture2D BotonChicoPulsado;
	public Texture2D BotonChica;
	public Texture2D BotonChicaPulsado;
	public Texture2D BotonAtras;
	public Texture2D BotonAyuda;

	private bool chicoPulsado=false;
	private bool chicaPulsado=false;

	// Use this for initialization
	void Start () {
	
	}

	public void OnGUI() {
				//Colocación de los objetos en la pantalla
				GUI.Label (new Rect ((Screen.width / 4)-35, (Screen.height / 3)-50, 200, 20), "Nombre");
				GUI.Label (new Rect ((Screen.width / 3) + 125, (Screen.height / 3)-50, 200, 20), "Apellidos");
				stringNombre = GUI.TextField (new Rect ((Screen.width / 4) + 20, (Screen.height / 3)-50, 200, 20), stringNombre, 20);
				stringApellido = GUI.TextField (new Rect ((Screen.width / 3) + 200, (Screen.height / 3)-50, 200, 20), stringApellido,20);
				GUI.Label (new Rect ((Screen.width / 4)-35, (Screen.height / 3), 200, 20), "Usuario");
				GUI.Label (new Rect ((Screen.width / 3) + 125, (Screen.height / 3), 200, 20), "Contraseña");
				stringUsuario = GUI.TextField (new Rect ((Screen.width / 4) + 20, (Screen.height / 3), 200, 20), stringUsuario, 20);
				stringPass = GUI.PasswordField (new Rect ((Screen.width / 3) + 200, (Screen.height / 3), 200, 20), stringPass, "*" [0], 20);
				GUI.Label (new Rect ((Screen.width / 3) + 125, (Screen.height / 3) +50, 200, 20), "Email");
				stringEmail = GUI.TextField (new Rect ((Screen.width / 3) +200, (Screen.height / 3)+50, 200, 20), stringEmail, 25);
				
		//Botón de nuevo registro llama a la función para que se realice el registro del nuevo usuario
				if (GUI.Button (new Rect ((Screen.width / 3) +420, (Screen.height / 3)-20, BotonRegistro.width, BotonRegistro.height), BotonRegistro)) {

						//comprobar los datos de usuario para saber si esta registrado.
						mensaje_errorRegistro=false;
						mensaje_errorSexo = false;
						EnviaDatos ();
						
			
				}
		//boton de ayuda para que el ususario sepa que hacer en todo momento
		GUI.Button (new Rect ((Screen.width/4)-30, (Screen.height/3)+110,BotonAyuda.width,BotonAyuda.height),new GUIContent (BotonAyuda,"Rellene todos los campos para registrarte en la aplicación"));
		GUI.Label(new Rect((Screen.width/4)+10,(Screen.height/3)+115,400,200),GUI.tooltip);

				GUI.Label (new Rect ((Screen.width / 4)-30, (Screen.height / 3)+50, 200, 20), "Sexo");
				//Cambiar la textura al boton para efecto pulsado
		        if (chicoPulsado) {

					GUI.Button (new Rect ((Screen.width / 4)+100, (Screen.height/3)+30, BotonChicoPulsado.width, BotonChicoPulsado.height),BotonChicoPulsado);
				}
				else {
					if(GUI.Button (new Rect ((Screen.width / 4)+100, (Screen.height/3)+30, BotonChico.width, BotonChico.height),BotonChico)){
					chicoPulsado=true;
					chicaPulsado=false;
					}
				}

				//Cambiar la textura al boton para efecto pulsado
				if (chicaPulsado) {
			
					GUI.Button (new Rect ((Screen.width /4)+20, (Screen.height/3)+30, BotonChicaPulsado.width, BotonChicaPulsado.height),BotonChicaPulsado);
				}
				else {
				   if(GUI.Button (new Rect ((Screen.width / 4)+20, (Screen.height/3)+30, BotonChica.width, BotonChica.height),BotonChica)){
						chicoPulsado=false;
						chicaPulsado=true;
					}
				}

		//volver a la pantalla de inicio
		if (GUI.Button (new Rect (100, 100, BotonAtras.width, BotonAtras.height), BotonAtras)) {
	
			Application.LoadLevel("PantallaInicio");
			
		}

		if (mensaje_errorSexo) {
			
			GUI.Label(new Rect((Screen.width/4)+100,(Screen.height/3)+100,250,20),"El sexo Masculino aun no soportado");
		}

		if (mensaje_errorRegistro) {

			GUI.Label(new Rect((Screen.width/4)-40,(Screen.height/3)-20,250,20),"El nombre de usuario ya esta utilizado");
		}
	}



	void EnviaDatos(){
		
		StartCoroutine (consulta ());
		
	}
	
	IEnumerator consulta(){

		if (chicoPulsado) {
						//cargar creacion de usuario avatar chico
			
						mensaje_errorSexo = true;
				}
		else {
			int compara = 1;

			string ConsultaURL = "myfres.com/SmartWardrobe/GuardarRegistro.php?";

			string post_url = ConsultaURL + "Nombre=" + WWW.EscapeURL (stringNombre) + "&Apellido=" + WWW.EscapeURL (stringApellido) + "&Usuario=" + WWW.EscapeURL (stringUsuario) + "&Pass=" + WWW.EscapeURL (stringPass) + "&Email=" + WWW.EscapeURL (stringEmail);
			// Post the URL to the site and create a download object to get the result.
			WWW hs_post = new WWW (post_url);
			yield return hs_post; // Wait until the download is done

			if (hs_post.error != null) {
					print ("Error consulta" + hs_post.error);
			}

			compara = int.Parse (hs_post.text);

			if (compara == 1) {
					mensaje_errorRegistro = false;

					//Cargar el usuario para que empiece en la aplicacion modificacion usuario crear las carpetas del usuario
					if (chicoPulsado) {
							//cargar creacion de usuario avatar chico

							mensaje_errorSexo = true;
					}
					if (chicaPulsado) {
							//obtine el idi usuario
							CompruebaDatos ();
					}

			} else {
					mensaje_errorRegistro = true;
			}
		}
	}

	void CompruebaDatos(){
		
		StartCoroutine (consulta2 ());
		
	}
	
	IEnumerator consulta2(){
		
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
			
			//Creacion de las carpetas necesarias para almacenar de forma local las fotos dependiendo de el tipo de prenda.
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

		//crear un avatar por defecto
		Avatar();
		}


	void Avatar()
	{
		StartCoroutine(AvatarDefecto());
	}
	
	//Comunicarme con el servidor para guardar en la base de datos
	
	IEnumerator AvatarDefecto()
	{
		WWWForm postForm = new WWWForm ();
		
		postForm.AddField ("idUsuario", Variables.idUsuario);

		WWW upload = new WWW("myfres.com/SmartWardrobe/CreaAvatar.php",postForm);
		yield return upload;
		if (upload.error == null)
			Debug.Log("upload done :" + upload.text);
		else
			Debug.Log("Error during upload: " + upload.error);

		//cargar creacion de usuario avatar chica
		Application.LoadLevel("ConfiguracionAvatar");

		
	}
}
		

