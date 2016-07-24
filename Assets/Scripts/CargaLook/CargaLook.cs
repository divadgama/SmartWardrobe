using UnityEngine;
using System.Collections;
using System.IO;

public class CargaLook : MonoBehaviour {

	public Texture2D BotonAtras;

	//objetos para la ropa que corresponde a cada prenda
	public GameObject Camisa;
	public GameObject Camiseta;
	public GameObject Jersey;
	public GameObject Sudadera;
	public GameObject Chaqueta;
	public GameObject Pantalon;
	public GameObject PantalonC;
	public GameObject Vestido;
	public GameObject CamisetaFina;

	public GameObject CamisaJ;
	public GameObject CamisetaJ;
	public GameObject JerseyJ;
	public GameObject SudaderaJ;
	public GameObject ChaquetaJ;
	public GameObject PantalonJ;
	public GameObject PantalonCJ;
	public GameObject VestidoJ;
	public GameObject CamisetaFinaJ;
	
	
	private GameObject Joven;
	private GameObject PelolargoJoven;
	private GameObject bocajoven;
	private GameObject sujetadorjoven;
	private GameObject bragajoven;
	private GameObject ojosjoven;
	private GameObject pestanajoven;
	private GameObject pelojoven;
	private GameObject coleteroDjoven;
	private GameObject coleteroIjoven;
	
	private GameObject Mujer;
	private GameObject PelolargoMujer;
	private GameObject bocamujer;
	private GameObject sujetadormujer;
	private GameObject bragamujer;
	private GameObject ojosmujer;
	private GameObject pestanamujer;
	private GameObject pelomujer;
	private GameObject coleteroDmujer;
	private GameObject coleteroImujer;
	
	public GUIStyle style;

	private string DatosDescarga="";
	private bool ControlDescarga=false;

	//datos parseo
	public Texture2D BtnEliminar;
	private string [] cadenalook;
	private string [] datosLook;


	//Interfaz para le look

	public Texture2D[] texPrenda;
	public Texture2D[] texBoton;
	public bool [] arrayBotones;
	public bool [] arrayBotonesEliminar;
	public string[] nombreFotoP;
	public string[] nombreFotoT;
	public string[] idConjuntos;
	string nombreLookAnterior="";
	int contador=0;
	int numPrendasPorlook=0;
	int contLook=0;

	byte[] imageData;

	//carga del avatar
	
	private string DatosDescargaAvatar="";
	private string [] datosAvatar;
	
	bool ControlDescargaAvatar=false;
	bool precarga=false;

	public void Start()
	{
		Joven = GameObject.FindGameObjectWithTag ("PersonajeNiya");
		PelolargoJoven = GameObject.FindGameObjectWithTag ("PelolargoJoven");
		bocajoven = GameObject.FindGameObjectWithTag ("bocajoven");
		sujetadorjoven = GameObject.FindGameObjectWithTag ("sujetadorjoven");
		bragajoven = GameObject.FindGameObjectWithTag ("bragajoven");
		ojosjoven = GameObject.FindGameObjectWithTag ("ojosjoven");
		pestanajoven = GameObject.FindGameObjectWithTag ("pestanajoven");
		pelojoven = GameObject.FindGameObjectWithTag ("pelojoven");
		coleteroDjoven = GameObject.FindGameObjectWithTag ("coleteroDjoven");
		coleteroIjoven = GameObject.FindGameObjectWithTag ("coleteroIjoven");
	
		Mujer = GameObject.FindGameObjectWithTag ("PersonajeMujer");
		PelolargoMujer = GameObject.FindGameObjectWithTag ("PelolargoMujer");
		bocamujer = GameObject.FindGameObjectWithTag ("bocamujer");
		sujetadormujer = GameObject.FindGameObjectWithTag ("sujetadormujer");
		bragamujer = GameObject.FindGameObjectWithTag ("bragamujer");
		ojosmujer = GameObject.FindGameObjectWithTag ("ojosmujer");
		pestanamujer = GameObject.FindGameObjectWithTag ("pestanamujer");
		pelomujer = GameObject.FindGameObjectWithTag ("pelomujer");
		coleteroDmujer = GameObject.FindGameObjectWithTag ("coleteroDmujer");
		coleteroImujer = GameObject.FindGameObjectWithTag ("coleteroImujer");
		
		
		
		//mostar la ropa en el avatar mujer
		Camisa = GameObject.FindGameObjectWithTag ("Camisa");
		Camiseta = GameObject.FindGameObjectWithTag ("Camiseta");
		Jersey = GameObject.FindGameObjectWithTag ("Jersey");
		Sudadera = GameObject.FindGameObjectWithTag ("Sudadera");
		Chaqueta = GameObject.FindGameObjectWithTag ("Chaqueta");
		Pantalon = GameObject.FindGameObjectWithTag ("Pantalon");
		PantalonC = GameObject.FindGameObjectWithTag ("PantalonC");
		Vestido = GameObject.FindGameObjectWithTag ("Vestido");
		CamisetaFina=GameObject.FindGameObjectWithTag ("CamisetaFina");
		
		//mostar la ropa en el avatar joven
		CamisaJ = GameObject.FindGameObjectWithTag ("CamisaJ");
		CamisetaJ = GameObject.FindGameObjectWithTag ("CamisetaJ");
		JerseyJ = GameObject.FindGameObjectWithTag ("JerseyJ");
		SudaderaJ = GameObject.FindGameObjectWithTag ("SudaderaJ");
		ChaquetaJ = GameObject.FindGameObjectWithTag ("ChaquetaJ");
		PantalonJ = GameObject.FindGameObjectWithTag ("PantalonJ");
		PantalonCJ = GameObject.FindGameObjectWithTag ("PantalonCJ");
		VestidoJ = GameObject.FindGameObjectWithTag ("VestidoJ");
		CamisetaFinaJ=GameObject.FindGameObjectWithTag ("CamisetaFinaJ");
		
	}

	public void OnGUI() {

		if (!ControlDescargaAvatar) {
			CargaAvatar ();
		}
		else {
			
			if (!precarga){//carga del avatar guardado en base de datos
				//hacer consulta a la base de datos para cargar el avatar del usuario
				
				datosAvatar=DatosDescargaAvatar.Split('/');
				print(datosAvatar.Length);
				
				
				if(datosAvatar[0]=="1"){//es hombre aun no soportado
					//contol sexo avatar botones
					
					
				}
				else{
					//contol sexo avatar botones
					
					if(datosAvatar[2]=="1"){//es mujer mayor
						
						
						Joven.renderer.enabled = false;
						PelolargoJoven.renderer.enabled = false;
						bocajoven.renderer.enabled = false;
						sujetadorjoven.renderer.enabled = false;
						bragajoven.renderer.enabled = false;
						ojosjoven.renderer.enabled = false;
						pestanajoven.renderer.enabled = false;
						pelojoven.renderer.enabled = false;
						coleteroDjoven.renderer.enabled = false;
						coleteroIjoven.renderer.enabled = false;
						
						CamisetaJ.renderer.enabled = false;
						PantalonCJ.renderer.enabled = false;
						CamisaJ.renderer.enabled = false;
						JerseyJ.renderer.enabled = false;
						SudaderaJ.renderer.enabled = false;
						ChaquetaJ.renderer.enabled = false;
						PantalonJ.renderer.enabled = false;
						VestidoJ.renderer.enabled = false;
						CamisetaFinaJ.renderer.enabled = false;
						
						Mujer.renderer.enabled = true;
						PelolargoMujer.renderer.enabled = true;
						bocamujer.renderer.enabled = true;
						sujetadormujer.renderer.enabled = true;
						bragamujer.renderer.enabled = true;
						ojosmujer.renderer.enabled = true;
						pestanamujer.renderer.enabled = true;
						pelomujer.renderer.enabled = true;
						coleteroDmujer.renderer.enabled = true;
						coleteroImujer.renderer.enabled = true;
						
						Camiseta.renderer.enabled = true;
						PantalonC.renderer.enabled = true;
						Camisa.renderer.enabled = false;
						Jersey.renderer.enabled = false;
						Sudadera.renderer.enabled = false;
						Chaqueta.renderer.enabled = false;
						Pantalon.renderer.enabled = false;
						Vestido.renderer.enabled = false;
						CamisetaFina.renderer.enabled = false;
						
					}
					else{//es joven
						
						Mujer.renderer.enabled = false;
						PelolargoMujer.renderer.enabled = false;
						bocamujer.renderer.enabled = false;
						sujetadormujer.renderer.enabled = false;
						bragamujer.renderer.enabled = false;
						ojosmujer.renderer.enabled = false;
						pestanamujer.renderer.enabled = false;
						pelomujer.renderer.enabled = false;
						coleteroDmujer.renderer.enabled = false;
						coleteroImujer.renderer.enabled = false;
						
						Camiseta.renderer.enabled = false;
						PantalonC.renderer.enabled = false;
						Camisa.renderer.enabled = false;
						Jersey.renderer.enabled = false;
						Sudadera.renderer.enabled = false;
						Chaqueta.renderer.enabled = false;
						Pantalon.renderer.enabled = false;
						Vestido.renderer.enabled = false;
						CamisetaFina.renderer.enabled = false;
						
						Joven.renderer.enabled = true;
						PelolargoJoven.renderer.enabled = true;
						bocajoven.renderer.enabled = true;
						sujetadorjoven.renderer.enabled = true;
						bragajoven.renderer.enabled = true;
						ojosjoven.renderer.enabled = true;
						pestanajoven.renderer.enabled = true;
						pelojoven.renderer.enabled = true;
						coleteroDjoven.renderer.enabled = true;
						coleteroIjoven.renderer.enabled = true;
						
						CamisetaJ.renderer.enabled = true;
						PantalonCJ.renderer.enabled = true;
						CamisaJ.renderer.enabled = false;
						JerseyJ.renderer.enabled = false;
						SudaderaJ.renderer.enabled = false;
						ChaquetaJ.renderer.enabled = false;
						PantalonJ.renderer.enabled = false;
						VestidoJ.renderer.enabled = false;
						CamisetaFinaJ.renderer.enabled = false;
						
						
					}
					
					if(datosAvatar[3]=="0"){
						Cargar (PelolargoMujer, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Moreno.jpg");
						Cargar (PelolargoJoven, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Moreno.jpg");
					}
					if(datosAvatar[3]=="1"){
						Cargar (PelolargoMujer, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Rubio.jpg");	
						Cargar (PelolargoJoven, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Rubio.jpg");
					}
					if(datosAvatar[3]=="2"){
						Cargar (PelolargoMujer, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Gris.jpg");
						Cargar (PelolargoJoven, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Gris.jpg");
					}
					if(datosAvatar[3]=="3"){
						Cargar (PelolargoMujer, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Castano.jpg");
						Cargar (PelolargoJoven, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Castano.jpg");
					}
					if(datosAvatar[3]=="4"){
						Cargar (PelolargoMujer, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Pelirrojo.jpg");
						Cargar (PelolargoJoven, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Pelirrojo.jpg");
					}	
					
				}
				precarga=true;
				
			}
			else{//si el avatar esta cargado para operar con el

					if (GUI.Button (new Rect (100, 100, BotonAtras.width, BotonAtras.height), BotonAtras)) {
						
						Application.LoadLevel ("PantallaPrincipal");
					}

					if (!ControlDescarga) {
									descargaLook ();
					} 
					else {
						//separo la cadena para conocer los look diferentes
						cadenalook = DatosDescarga.Split ('*');
						arrayBotones = new bool[cadenalook.Length];
						arrayBotonesEliminar = new bool[cadenalook.Length];
						nombreFotoP = new string[cadenalook.Length];
						nombreFotoT = new string[cadenalook.Length];
						texPrenda = new Texture2D[cadenalook.Length];
						idConjuntos = new string[cadenalook.Length];

						contLook=0;
						nombreLookAnterior="";
						for(int i=0;i<(cadenalook.Length)-1;i++){
							//separo la cadena para conocer las partes de cada look
							datosLook=cadenalook[i].Split('/');

							nombreFotoP [i] = "./Assets/RopaArmario/" + Variables.idUsuario + "/" + datosLook[1] + "/Prendas/" + datosLook[2];
							nombreFotoT [i] = "file://" + Application.dataPath + "/RopaArmario/" + Variables.idUsuario + "/" + datosLook[1] + "/Texturas/" + datosLook[2];

							idConjuntos[i]=datosLook[3];
							//Cargar imagen en botones look
							texPrenda [i] = new Texture2D (2, 2, TextureFormat.DXT1, false);
							imageData = File.ReadAllBytes (nombreFotoP [i]);
							texPrenda [i].LoadImage (imageData);
							
							//colocacion de interfaz agrupada por el nombre del look
							if(nombreLookAnterior==datosLook[0]){
								numPrendasPorlook++;
								arrayBotones [i] = GUI.Button (new Rect (850+(numPrendasPorlook*80),((90*contador)+15),70,70), texPrenda [i]);
								contLook--;
								}
							else{
								nombreLookAnterior=datosLook[0];
								numPrendasPorlook=0;
								contador=contLook;
								arrayBotones [i] = GUI.Button (new Rect (850, (90 * contLook) + 15,70,70), texPrenda [i]);
								GUI.Label(new Rect((Screen.width/2)+120,(90*contLook),200,20),datosLook[0],style);
								arrayBotonesEliminar[i]=GUI.Button (new Rect ((Screen.width / 2) + 600, 10+(90*contLook), (BtnEliminar.width)/3, (BtnEliminar.height)/3),BtnEliminar);
							}
							contLook++;

							if (arrayBotones [i]) {
								if (datosLook[1] == "Camisa") {
								if(datosAvatar[2]=="1"){//mayor
										Camiseta.renderer.enabled = false;
										Camisa.renderer.enabled = true;
										Jersey.renderer.enabled = false;
										Sudadera.renderer.enabled = false;
										Chaqueta.renderer.enabled = false;
										Vestido.renderer.enabled = false;
										CamisetaFina.renderer.enabled = false;
									}
									else{//joven
										CamisetaJ.renderer.enabled = false;
										CamisaJ.renderer.enabled = true;
										JerseyJ.renderer.enabled = false;
										SudaderaJ.renderer.enabled = false;
										ChaquetaJ.renderer.enabled = false;
										VestidoJ.renderer.enabled = false;
										CamisetaFinaJ.renderer.enabled = false;
									}
									//para cargra la imagen que se ha fotografiado
									Cargar (Camisa, nombreFotoT [i]);
									Cargar (CamisaJ, nombreFotoT [i]);
								}
								if (datosLook[1] == "Camiseta") {
										if(datosAvatar[2]=="1"){//mayor
											Camiseta.renderer.enabled = true;
											Camisa.renderer.enabled = false;
											Jersey.renderer.enabled = false;
											Sudadera.renderer.enabled = false;
											Chaqueta.renderer.enabled = false;
											Vestido.renderer.enabled = false;
											CamisetaFina.renderer.enabled = false;
										}
										else{//joven
											CamisetaJ.renderer.enabled = true;
											CamisaJ.renderer.enabled = false;
											JerseyJ.renderer.enabled = false;
											SudaderaJ.renderer.enabled = false;
											ChaquetaJ.renderer.enabled = false;
											VestidoJ.renderer.enabled = false;
											CamisetaFinaJ.renderer.enabled = false;
										}
									//para cargra la imagen que se ha fotografiado
									Cargar (Camiseta, nombreFotoT [i]);
									Cargar (CamisetaJ, nombreFotoT [i]);
									}
									if (datosLook[1] == "Jersey") {
										if(datosAvatar[2]=="1"){//mayor
											Camiseta.renderer.enabled = false;
											Camisa.renderer.enabled = false;
											Jersey.renderer.enabled = true;
											Sudadera.renderer.enabled = false;
											Chaqueta.renderer.enabled = false;
											Vestido.renderer.enabled = false;
											CamisetaFina.renderer.enabled = false;
										}
										else{//joven
											CamisetaJ.renderer.enabled = true;
											CamisaJ.renderer.enabled = false;
											JerseyJ.renderer.enabled = false;
											SudaderaJ.renderer.enabled = false;
											ChaquetaJ.renderer.enabled = false;
											VestidoJ.renderer.enabled = false;
											CamisetaFinaJ.renderer.enabled = false;
										}
									//para cargra la imagen que se ha fotografiado
									Cargar (Jersey, nombreFotoT [i]);
									Cargar (JerseyJ, nombreFotoT [i]);
									}
									if (datosLook[1] == "Sudadera") {
										if(datosAvatar[2]=="1"){//mayor
											Camiseta.renderer.enabled = false;
											Camisa.renderer.enabled = false;
											Jersey.renderer.enabled = false;
											Sudadera.renderer.enabled = true;
											Chaqueta.renderer.enabled = false;
											Vestido.renderer.enabled = false;
											CamisetaFina.renderer.enabled = false;
										}
										else{//joven
											CamisetaJ.renderer.enabled = false;
											CamisaJ.renderer.enabled = false;
											JerseyJ.renderer.enabled = false;
											SudaderaJ.renderer.enabled = true;
											ChaquetaJ.renderer.enabled = false;
											VestidoJ.renderer.enabled = false;
											CamisetaFinaJ.renderer.enabled = false;
										}
									//para cargra la imagen que se ha fotografiado
									Cargar (Sudadera, nombreFotoT [i]);
									Cargar (SudaderaJ, nombreFotoT [i]);
									}
									if (datosLook[1] == "Chaqueta") {
										if(datosAvatar[2]=="1"){//mayor
											Camiseta.renderer.enabled = false;
											Camisa.renderer.enabled = false;
											Jersey.renderer.enabled = false;
											Sudadera.renderer.enabled = false;
											Chaqueta.renderer.enabled = true;
											Vestido.renderer.enabled = false;
											CamisetaFina.renderer.enabled = true;
										}
										else{//joven
											CamisetaJ.renderer.enabled = false;
											CamisaJ.renderer.enabled = false;
											JerseyJ.renderer.enabled = false;
											SudaderaJ.renderer.enabled = false;
											ChaquetaJ.renderer.enabled = true;
											VestidoJ.renderer.enabled = false;
											CamisetaFinaJ.renderer.enabled = true;
										}		
									//para cargra la imagen que se ha fotografiado
									Cargar (Chaqueta, nombreFotoT [i]);
									Cargar (ChaquetaJ, nombreFotoT [i]);
									}
									if (datosLook[1] == "Pantalon") {
										if(datosAvatar[2]=="1"){//mayor
											Pantalon.renderer.enabled = true;
											PantalonC.renderer.enabled = false;
											Vestido.renderer.enabled = false;
										}
										else{
											PantalonJ.renderer.enabled = true;
											PantalonCJ.renderer.enabled = false;
											VestidoJ.renderer.enabled = false;
										}
									//para cargra la imagen que se ha fotografiado
									Cargar (Pantalon, nombreFotoT [i]);
									Cargar (PantalonJ, nombreFotoT [i]);
									}
									if (datosLook[1] == "PantalonC") {
										if(datosAvatar[2]=="1"){//mayor
											Pantalon.renderer.enabled = false;
											PantalonC.renderer.enabled = true;
											Vestido.renderer.enabled = false;
										}
										else{
											PantalonJ.renderer.enabled = false;
											PantalonCJ.renderer.enabled = true;
											VestidoJ.renderer.enabled = false;
										}
									//para cargra la imagen que se ha fotografiado
									Cargar (PantalonC, nombreFotoT [i]);
									Cargar (PantalonCJ, nombreFotoT [i]);
									}
								if (datosLook[1] == "Vestido") {
									if(datosAvatar[2]=="1"){//mayor
										Camiseta.renderer.enabled = false;
										Camisa.renderer.enabled = false;
										Jersey.renderer.enabled = false;
										Sudadera.renderer.enabled = false;
										Chaqueta.renderer.enabled = false;
										Pantalon.renderer.enabled = false;
										PantalonC.renderer.enabled = false;
										Vestido.renderer.enabled = true;
										CamisetaFina.renderer.enabled = false;
									}
									else{
										CamisetaJ.renderer.enabled = false;
										CamisaJ.renderer.enabled = false;
										JerseyJ.renderer.enabled = false;
										SudaderaJ.renderer.enabled = false;
										ChaquetaJ.renderer.enabled = false;
										PantalonJ.renderer.enabled = false;
										PantalonCJ.renderer.enabled = false;
										VestidoJ.renderer.enabled = true;
										CamisetaFinaJ.renderer.enabled = false;
									}
									//para cargra la imagen que se ha fotografiado
									Cargar (Vestido, nombreFotoT [i]);
									Cargar (VestidoJ, nombreFotoT [i]);
								}
							}
							//control de botones para eliminar
							if (arrayBotonesEliminar [i]) {		
								eliminaConjunto(idConjuntos[i]);
								ControlDescarga=false;
							}

							
						}//end for
						
					}
			}
		}
	
	}
		


		void CargaAvatar(){
			
			StartCoroutine (loadAvatar(Variables.idUsuario));
			
		}
		
		IEnumerator loadAvatar(int idUsuario){
			
			WWWForm postForm = new WWWForm ();
			postForm.AddField ("idUsuario", Variables.idUsuario);
			
			WWW datos = new WWW("myfres.com/SmartWardrobe/CargaAvatar.php",postForm);
			yield return datos;
			DatosDescargaAvatar = datos.text;
			
			if (datos.isDone) {//control de la descarga	
				ControlDescargaAvatar = true;
			} else {
				ControlDescargaAvatar = false;
			}	
		}

		void descargaLook(){
			
			StartCoroutine (descarga (Variables.idUsuario));
			
		}
		
		IEnumerator descarga (int Usuario){
			
				WWWForm postForm = new WWWForm ();

				postForm.AddField ("idUsuario", Usuario);

				WWW datos = new WWW ("myfres.com/SmartWardrobe/DescargaLook.php", postForm);
				yield return datos;
				DatosDescarga = datos.text;
				if (datos.isDone) {//control de la descarga

						ControlDescarga = true;

				} else {
						ControlDescarga = false;
				}
		}


	void eliminaConjunto (string idConjunto){
		
		StartCoroutine (eliminar (idConjunto));
		
	}
	
	IEnumerator eliminar (string idConjunto){

		WWWForm postForm = new WWWForm ();
		
		postForm.AddField ("idConjunto", idConjunto);
		WWW datos = new WWW ("myfres.com/SmartWardrobe/EliminaLook.php", postForm);
		yield return datos;
		if (datos.error == null)
			Debug.Log("upload done :" + datos.text);
		else
			Debug.Log("Error during upload: " + datos.error);
		
	}
	
	
	
	
	void Cargar(GameObject obj, string url){
			
			StartCoroutine (cargaImagen (obj, url));
		}
		
	IEnumerator cargaImagen(GameObject obj, string url){
			
			WWW imagen = new WWW(url);
			yield return imagen;
			obj.renderer.material.mainTexture = imagen.texture;
		}

}
