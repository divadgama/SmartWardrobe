using UnityEngine;
using System.Collections;
using System.IO;

public class NuevaPrenda : MonoBehaviour {

	public Texture2D BotonAtras;
	public Texture2D BotonCamaraT;//camara para la textura
	public Texture2D BotonCamaraP;//camara para la prenda
	public Texture2D BotonGuarda;

	public Texture2D imagenes;

	public GameObject Textura;
	public GameObject Prenda;
	private string StringFotoTextura;
	private string StringFotoPrenda;
	
	//Flaga para esperar a que se suban las fotos
	private int FlagSuvirFotos=0;

	//Temporada
	public bool verano = false;
	public bool invierno = false;
	public bool primavera = false;
	public bool otonio = false;

	//Colores
	public bool Negro = false;
	public bool Blanco = false;
	public bool Gris = false;
	public bool VerdeO = false;
	public bool VerdeC = false;
	public bool AzulO = false;
	public bool AzulC = false;
	public bool Rojo = false;
	public bool Rosa = false;
	public bool Morado = false;
	public bool Amarillo = false;
	public bool Naranja = false;

	//imagenes de los colores
	public Texture2D TNegro;
	public Texture2D TBlanco;
	public Texture2D TGris;
	public Texture2D TVerdeO;
	public Texture2D TVerdeC;
	public Texture2D TAzulO;
	public Texture2D TAzulC;
	public Texture2D TRojo;
	public Texture2D TRosa;
	public Texture2D TMorado;
	public Texture2D TAmarillo;
	public Texture2D TNaranja;

	//Look
	public bool Diario= false;
	public bool Elegante = false;
	public bool Deporte = false;
	public bool Casual = false;
	public bool Formal = false;
	public bool Trabajo = false;
	public bool Favorita = false;
	public bool Club = false;

	//Tipo prenda

	GUIContent[] comboBoxList;
	private ComboBox comboBoxControl;
	private GUIStyle listStyle = new GUIStyle();
	int selectedItemIndex=0;

	//varialble de usuario
	int idUsuario=0;
	

	void Start() {
		idUsuario = Variables.idUsuario;
		StringFotoTextura = "file://"+ Application.dataPath+"/Fotos/fotoT.JPG";
		StringFotoPrenda = "file://"+ Application.dataPath +"/Fotos/fotoP.JPG";

		Textura = GameObject.FindGameObjectWithTag ("Textura");
		//para cargra la imagen que se ha fotografiado
		Cargar (Textura, StringFotoTextura);

		Prenda = GameObject.FindGameObjectWithTag ("Prenda");
		//para cargra la imagen que se ha fotografiado
		Cargar (Prenda, StringFotoPrenda);


	comboBoxList = new GUIContent[8];
	comboBoxList[0] = new GUIContent("Pantalon");
	comboBoxList[1] = new GUIContent("Camiseta");
	comboBoxList[2] = new GUIContent("Sudadera");
	comboBoxList[3] = new GUIContent("Camisa");
	comboBoxList[4] = new GUIContent("Vestido");
	comboBoxList[5] = new GUIContent("Jersey");
	comboBoxList[6] = new GUIContent("Pantalon Corto");
	comboBoxList[7] = new GUIContent("Chaqueta");


	listStyle.normal.textColor = Color.white; 
	listStyle.onHover.background =
	listStyle.hover.background = new Texture2D(2, 2);
	listStyle.padding.left =
	listStyle.padding.right =
    listStyle.padding.top =
	listStyle.padding.bottom = 4;

	comboBoxControl = new ComboBox(new Rect((Screen.width / 2), (Screen.height / 2)+80,130,20), comboBoxList[0], comboBoxList, "button", "box", listStyle);


	}

	void Cargar(GameObject obj, string url){
		
		StartCoroutine (cargaImagen (obj, url));
		
	}

	IEnumerator cargaImagen(GameObject obj, string url){

		WWW imagen = new WWW(url);
		yield return imagen;
		obj.renderer.material.mainTexture = imagen.texture;
	}

	public void OnGUI() {

		GUI.Label (new Rect ((Screen.width / 4)-30, (Screen.height / 3)-150, 200, 20), "Textura");
		GUI.Label (new Rect ((Screen.width / 3) + 260, (Screen.height / 3)-150, 200, 20), "Prenda Completa");

		GUI.enabled = Variables.activoGuardar;
		if (GUI.Button (new Rect (550, 250, BotonGuarda.width, BotonGuarda.height), BotonGuarda)) {

			string nombreFoto;

			nombreFoto=System.DateTime.Now.Year.ToString()+System.DateTime.Now.Month.ToString()+System.DateTime.Now.Day.ToString()+System.DateTime.Now.Hour.ToString()+System.DateTime.Now.Minute.ToString()+System.DateTime.Now.Second.ToString();
			//Guardar Imagenes en carpeta armario del usuario correspondiente

			byte[] bytesT;
			byte[] bytesP;
			bytesT = File.ReadAllBytes("./assets/Fotos/fotoT.JPG");
			bytesP = File.ReadAllBytes("./assets/Fotos/fotoP.JPG");

			//es un pantalon
			if(selectedItemIndex==0){

				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+"/Pantalon/Texturas/"+nombreFoto+".JPG",bytesT);
				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+ "/Pantalon/Prendas/"+nombreFoto+".JPG",bytesP);
				//Guarda la informacion de la prenda en la base de datos
				GuardaBD(idUsuario+ "/Pantalon/",nombreFoto+".JPG");
				//guarda las imagenes en el servidor
				GuardaImagenSrv(idUsuario+ "/Pantalon/Prendas/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/Pantalon/Prendas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");
				GuardaImagenSrv(idUsuario+ "/Pantalon/Texturas/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/Pantalon/Texturas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");


			}

			//es una Camiseta
			if(selectedItemIndex==1){
				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+"/Camiseta/Texturas/"+nombreFoto+".JPG",bytesT);
				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+ "/Camiseta/Prendas/"+nombreFoto+".JPG",bytesP);
				//Guarda la informacion de la prenda en la base de datos
				GuardaBD(idUsuario+ "/Camiseta/",nombreFoto+".JPG");
				//guarda las imagenes en el servidor
				GuardaImagenSrv(idUsuario+ "/Camiseta/Prendas/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/Camiseta/Prendas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");
				GuardaImagenSrv(idUsuario+ "/Camiseta/Texturas/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/Camiseta/Texturas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");
			}

			//es un Sudadera
			if(selectedItemIndex==2){
				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+"/Sudadera/Texturas/"+nombreFoto+".JPG",bytesT);
				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+ "/Sudadera/Prendas/"+nombreFoto+".JPG",bytesP);
				//Guarda la informacion de la prenda en la base de datos
				GuardaBD(idUsuario+ "/Sudadera/",nombreFoto+".JPG");
				//guarda las imagenes en el servidor
				GuardaImagenSrv(idUsuario+ "/Sudadera/Prendas/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/Sudadera/Prendas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");
				GuardaImagenSrv(idUsuario+ "/Sudadera/Texturas/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/Sudadera/Texturas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");


			}

			//Es una camisa
			if(selectedItemIndex==3){
				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+"/Camisa/Texturas/"+nombreFoto+".JPG",bytesT);
				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+ "/Camisa/Prendas/"+nombreFoto+".JPG",bytesP);
				//Guarda la informacion de la prenda en la base de datos
				GuardaBD(idUsuario+ "/Camisa/",nombreFoto+".JPG");
				//guarda las imagenes en el servidor
				GuardaImagenSrv(idUsuario+ "/Camisa/Prendas/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/Camisa/Prendas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");
				GuardaImagenSrv(idUsuario+ "/Camisa/Texturas/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/Camisa/Texturas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");

			}

			//Es un vestido
			if(selectedItemIndex==4){
				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+"/Vestido/Texturas/"+nombreFoto+".JPG",bytesT);
				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+ "/Vestido/Prendas/"+nombreFoto+".JPG",bytesP);
				//Guarda la informacion de la prenda en la base de datos
				GuardaBD(idUsuario+ "/Vestido/",nombreFoto+".JPG");
				//guarda las imagenes en el servidor
				GuardaImagenSrv(idUsuario+ "/Vestido/Prendas/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/Vestido/Prendas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");
				GuardaImagenSrv(idUsuario+ "/Vestido/Texturas/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/Vestido/Texturas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");

			}

			//Es un jersey
			if(selectedItemIndex==5){
				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+"/Jersey/Texturas/"+nombreFoto+".JPG",bytesT);
				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+ "/Jersey/Prendas/"+nombreFoto+".JPG",bytesP);
				//Guarda la informacion de la prenda en la base de datos
				GuardaBD(idUsuario+ "/Jersey/",nombreFoto+".JPG");
				//guarda las imagenes en el servidor
				GuardaImagenSrv(idUsuario+ "/Jersey/Prendas/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/Jersey/Prendas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");
				GuardaImagenSrv(idUsuario+ "/Jersey/Texturas/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/Jersey/Texturas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");

			}

			//Es un pantalon corto
			if(selectedItemIndex==6){
				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+"/PantalonCorto/Texturas/"+nombreFoto+".JPG",bytesT);
				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+ "/PantalonCorto/Prendas/"+nombreFoto+".JPG",bytesP);
				//Guarda la informacion de la prenda en la base de datos
				GuardaBD(idUsuario+ "/PantalonCorto/",nombreFoto+".JPG");
				//guarda las imagenes en el servidor
				GuardaImagenSrv(idUsuario+ "/PantalonCorto/Prendas/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/PantalonCorto/Prendas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");
				GuardaImagenSrv(idUsuario+ "/PantalonCorto/Textura/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/PantalonCorto/Texturas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");

			}

			//Es una Chaqueta
			if(selectedItemIndex==7){
				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+"/Chaqueta/Texturas/"+nombreFoto+".JPG",bytesT);
				File.WriteAllBytes("./assets/RopaArmario/" +idUsuario+ "/Chaqueta/Prendas/"+nombreFoto+".JPG",bytesP);
				//Guarda la informacion de la prenda en la base de datos
				GuardaBD(idUsuario+ "/Chaqueta/",nombreFoto+".JPG");
				//guarda las imagenes en el servidor
				GuardaImagenSrv(idUsuario+ "/Chaqueta/Prendas/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/Chaqueta/Prendas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");
				GuardaImagenSrv(idUsuario+ "/Chaqueta/Texturas/","file://"+ Application.dataPath+"/RopaArmario/" +idUsuario+ "/Chaqueta/Texturas/"+nombreFoto+".JPG","myfres.com/SmartWardrobe/CargaImagen.php");
			}

		

			//poner las variables para el control de interfaz a false
			Variables.activoGuardar=false;
			Variables.activoClasificacion=false;
			Variables.Colores=false;
			Variables.Temporada=false;
			Variables.Look=false;
			Variables.FotoPrenda=false;
			Variables.FotoTextura=false;
		}

		//Una vez guardada la prenda vuelve a la pantalla de la habitación
		if (FlagSuvirFotos==2){
			//reemplazo de las fotos por las fotos por defecto
			File.Delete(Application.dataPath+"/Fotos/fotoT.JPG");
			File.Delete(Application.dataPath+"/Fotos/fotoP.JPG");
			File.Copy(Application.dataPath+"/Fotos/Defecto/fotoT.JPG",Application.dataPath+"/Fotos/fotoT.JPG");
			File.Copy(Application.dataPath+"/Fotos/Defecto/fotoP.JPG",Application.dataPath+"/Fotos/fotoP.JPG");

			Application.LoadLevel ("Habitacion");
		}

		GUI.enabled = true;
		if (GUI.Button (new Rect (100, 100, BotonAtras.width, BotonAtras.height), BotonAtras)) {

			Application.LoadLevel ("Habitacion");
		}

		if (GUI.Button (new Rect (330, 370, BotonCamaraT.width, BotonCamaraT.height), BotonCamaraT)) {

			Variables.TipoDefoto=1;
			Variables.FotoTextura=true;
			Application.LoadLevel ("Camara");
			
		}
		if (GUI.Button (new Rect (755, 370, BotonCamaraP.width, BotonCamaraP.height), BotonCamaraP)) {

			Variables.TipoDefoto=2;
			Variables.FotoPrenda=true;
			
			Application.LoadLevel ("Camara");

		}
		if (Variables.FotoTextura && Variables.FotoPrenda) {
		 	Variables.activoClasificacion=true;
		}

		GUI.enabled = Variables.activoClasificacion;
		//creación de las opciones para clasificacion de las prendas

		GUI.Label (new Rect ((Screen.width / 2)-600, (Screen.height / 2)+50, 200, 20), "Temporada");
		GUI.Label (new Rect ((Screen.width / 2)-400, (Screen.height / 2)+50, 200, 20), "Colores Principales");
		GUI.Label (new Rect ((Screen.width / 2)-150, (Screen.height / 2)+50, 200, 20), "Look");
		GUI.Label (new Rect ((Screen.width / 2)+50, (Screen.height / 2)+50, 200, 20), "Prenda");


		invierno = GUI.Toggle(new Rect((Screen.width / 2)-600, (Screen.height / 2)+80, 80, 20), invierno, " Invierno");
		primavera = GUI.Toggle(new Rect((Screen.width / 2)-600, (Screen.height / 2)+100, 80, 20), primavera, " Primavera");
		verano = GUI.Toggle(new Rect((Screen.width / 2)-600, (Screen.height / 2)+120, 80, 20), verano, " Verano");
		otonio = GUI.Toggle(new Rect((Screen.width / 2)-600, (Screen.height / 2)+140, 80, 20), otonio, " Otoño");

		if (invierno || primavera || verano || otonio) {
			Variables.Temporada=true;	
				}
		else {
			Variables.Temporada=false;
				}

		//Check boton de los colores de la prendas

		Negro = GUI.Toggle(new Rect((Screen.width / 2)-410, (Screen.height / 2)+80, 30, 20), Negro,TNegro);
		Blanco = GUI.Toggle(new Rect((Screen.width / 2)-370, (Screen.height / 2)+80, 30, 20), Blanco, TBlanco);
		Gris = GUI.Toggle(new Rect((Screen.width / 2)-330, (Screen.height / 2)+80, 30, 20), Gris, TGris);
		VerdeO = GUI.Toggle(new Rect((Screen.width / 2)-290, (Screen.height / 2)+80, 30, 20), VerdeO, TVerdeO);
		VerdeC = GUI.Toggle(new Rect((Screen.width / 2)-410, (Screen.height / 2)+120, 30, 20), VerdeC, TVerdeC);
		AzulO = GUI.Toggle(new Rect((Screen.width / 2)-370, (Screen.height / 2)+120, 30, 20), AzulO, TAzulO);
		AzulC = GUI.Toggle(new Rect((Screen.width / 2)-330, (Screen.height / 2)+120, 30, 20), AzulC, TAzulC);
		Rojo = GUI.Toggle(new Rect((Screen.width / 2)-290, (Screen.height / 2)+120, 30, 20), Rojo, TRojo);
		Rosa = GUI.Toggle(new Rect((Screen.width / 2)-410, (Screen.height / 2)+160, 30, 20), Rosa, TRosa);
		Morado = GUI.Toggle(new Rect((Screen.width / 2)-370, (Screen.height / 2)+160, 30, 20), Morado, TMorado);
		Amarillo = GUI.Toggle(new Rect((Screen.width / 2)-330, (Screen.height / 2)+160, 30, 20), Amarillo, TAmarillo);
		Naranja = GUI.Toggle(new Rect((Screen.width / 2)-290, (Screen.height / 2)+160, 30, 20), Naranja, TNaranja);

		if (Negro || Blanco || Gris || VerdeC||VerdeO||AzulC||AzulO||Rojo||Rosa||Morado||Amarillo||Naranja) {
			Variables.Colores=true;	
		}
		else {
			Variables.Colores=false;
		}

		//Check boton para el look

		Diario = GUI.Toggle(new Rect((Screen.width / 2)-200, (Screen.height / 2)+80, 60, 20), Diario, " Diario");
		Elegante = GUI.Toggle(new Rect((Screen.width / 2)-200, (Screen.height / 2)+100, 70, 20), Elegante, " Elegante");
		Casual = GUI.Toggle(new Rect((Screen.width / 2)-200, (Screen.height / 2)+120, 60, 20), Casual, " Casual");
		Club = GUI.Toggle(new Rect((Screen.width / 2)-200, (Screen.height / 2)+140, 55, 20), Club, " Club");
		Formal = GUI.Toggle(new Rect((Screen.width / 2)-100, (Screen.height / 2)+80, 60, 20), Formal, " Formal");
		Deporte = GUI.Toggle(new Rect((Screen.width / 2)-100, (Screen.height / 2)+100, 70, 20), Deporte, " Deporte");
		Trabajo = GUI.Toggle(new Rect((Screen.width / 2)-100, (Screen.height / 2)+120, 70, 20), Trabajo, " Trabajo");
		Favorita = GUI.Toggle(new Rect((Screen.width / 2)-100, (Screen.height / 2)+140, 80, 20), Favorita, " Favorita");

		if (Diario || Elegante || Casual || Club||Formal||Deporte||Trabajo||Favorita) {
			Variables.Look=true;	
		}
		else {
			Variables.Look=false;
		}

		//Combobox prendas en la base de datos hacer consulta a la base de datos con tipos de prendas
	   selectedItemIndex = comboBoxControl.Show();	 
		if (Variables.Look && Variables.Colores && Variables.Temporada) {
				Variables.activoGuardar = true;
				} 
		else {
			Variables.activoGuardar = false;
				}
	}


	void GuardaBD(string ruta,string nombreFoto)
	{
		StartCoroutine(GuardaBDInfo(ruta,nombreFoto));
	}
	
	//Comunicarme con el servidor para guardar en la base de datos
	
	IEnumerator GuardaBDInfo(string ruta, string nombreFoto)
	{
		
				WWWForm postForm = new WWWForm ();
				
				postForm.AddField ("ruta", ruta);
				postForm.AddField ("nombreFoto", nombreFoto);
				postForm.AddField ("idUsuario", idUsuario.ToString());

				//para saber la estacion seleccionada
				if (verano) {
						postForm.AddField ("verano", "1");
				} else {
						postForm.AddField ("verano", "0");
				}
				if (invierno) {
						postForm.AddField ("invierno", "1");
				} else {
						postForm.AddField ("invierno", "0");
				}
				if (primavera) {
						postForm.AddField ("primavera", "1");
				} else {
						postForm.AddField ("primavera", "0");
				}
				if (otonio) {
						postForm.AddField ("otonio", "1");
				} else {
						postForm.AddField ("otonio", "0");
				}

				//para saber los Colores Pincipales
				if (Negro) {
						postForm.AddField ("Negro", "1");
				} else {
						postForm.AddField ("Negro", "0");
				}
				if (Blanco) {
						postForm.AddField ("Blanco", "1");
				} else {
						postForm.AddField ("Blanco", "0");
				}
				if (Gris) {
						postForm.AddField ("Gris", "1");
				} else {
						postForm.AddField ("Gris", "0");
				}
				if (VerdeO) {
						postForm.AddField ("VerdeO", "1");
				} else {
						postForm.AddField ("VerdeO", "0");
				}
				if (VerdeC) {
						postForm.AddField ("VerdeC", "1");
				} else {
						postForm.AddField ("VerdeC", "0");
				}
				if (AzulO) {
						postForm.AddField ("AzulO", "1");
				} else {
						postForm.AddField ("AzulO", "0");
				}
				if (AzulC) {
						postForm.AddField ("AzulC", "1");
				} else {
						postForm.AddField ("AzulC", "0");
				}
				if (Rojo) {
						postForm.AddField ("Rojo", "1");
				} else {
						postForm.AddField ("Rojo", "0");
				}
				if (Rosa) {
						postForm.AddField ("Rosa", "1");
				} else {
						postForm.AddField ("Rosa", "0");
				}
				if (Morado) {
						postForm.AddField ("Morado", "1");
				} else {
						postForm.AddField ("Morado", "0");
				}
				if (Amarillo) {
						postForm.AddField ("Amarillo", "1");
				} else {
						postForm.AddField ("Amarillo", "0");
				}
				if (Naranja) {
						postForm.AddField ("Naranja", "1");
				} else {
						postForm.AddField ("Naranja", "0");
				}

				// para saber el look
				if (Diario) {
						postForm.AddField ("Diario", "1");
				} else {
						postForm.AddField ("Diario", "0");
				}
				if (Elegante) {
						postForm.AddField ("Elegante", "1");
				} else {
						postForm.AddField ("Elegante", "0");
				}
				if (Deporte) {
						postForm.AddField ("Deporte", "1");
				} else {
						postForm.AddField ("Deporte", "0");
				}
				if (Casual) {
						postForm.AddField ("Casual", "1");
				} else {
						postForm.AddField ("Casual", "0");
				}
				if (Formal) {
						postForm.AddField ("Formal", "1");
				} else {
						postForm.AddField ("Formal", "0");
				}
				if (Trabajo) {
						postForm.AddField ("Trabajo", "1");
				} else {
						postForm.AddField ("Trabajo", "0");
				}
				if (Favorita) {
						postForm.AddField ("Favorita", "1");
				} else {
						postForm.AddField ("Favorita", "0");
				}
				if (Club) {
						postForm.AddField ("Club", "1");
				} else {
						postForm.AddField ("Club", "0");
				}
				//Saber el tipo de prenda
				if (selectedItemIndex == 0) {
					postForm.AddField ("Prenda","Pantalon");
				}
				if (selectedItemIndex == 1) {
					postForm.AddField ("Prenda","Camiseta");
				}
				if (selectedItemIndex == 2) {
					postForm.AddField ("Prenda","Sudadera");
				}
				if (selectedItemIndex == 3) {
					postForm.AddField ("Prenda","Camisa");
				}
				if (selectedItemIndex == 4) {
					postForm.AddField ("Prenda","Vestido");
				}
				if (selectedItemIndex == 5) {
					postForm.AddField ("Prenda","Jersey");
				}
				if (selectedItemIndex == 6) {
					postForm.AddField ("Prenda","Pantalon_Corto");
				}
				if (selectedItemIndex == 7) {
					postForm.AddField ("Prenda","Chaqueta");
				}
		
		WWW upload = new WWW("myfres.com/SmartWardrobe/GuardaRopaBD.php",postForm);
		yield return upload;
		if (upload.error == null)
			Debug.Log("upload done :" + upload.text);
		else
			Debug.Log("Error during upload: " + upload.error);

	}

	
	//lamada a la carga del archivo para subir al servidor
	
	void GuardaImagenSrv(string ruta,string localFileName, string uploadURL)
	{
		StartCoroutine(GuardaImagenCo(ruta,localFileName, uploadURL));
	}
	
	//Comunicarme con el servidor para subir las fotos

	IEnumerator GuardaImagenCo(string ruta,string localFileName, string uploadURL)
	{
		WWW localFile = new WWW(localFileName);
		print (localFile);
		yield return localFile;
		if (localFile.error == null)
			Debug.Log("Loaded file successfully");
		else
		{
			Debug.Log("Open file error: "+localFile.error);
			yield break; // stop the coroutine here
		}

		WWWForm postForm = new WWWForm ();

		postForm.AddField ("ruta",ruta);
		postForm.AddBinaryData("uploadedfile",localFile.bytes,localFileName,"text/plain");

		WWW upload = new WWW(uploadURL,postForm);
		yield return upload;
		if (upload.error == null) {
			Debug.Log ("upload done :" + upload.text);
			FlagSuvirFotos++;

				}
		else
			Debug.Log("Error during upload: " + upload.error);
	}
}