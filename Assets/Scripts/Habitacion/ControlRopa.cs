using UnityEngine;
using System.Collections;
using System.IO;

public class ControlRopa : MonoBehaviour {
	
	//prendas en el gameobject
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


	public Texture2D[] texPrenda;
	public Texture2D BtnEliminar;



	public Texture2D[] texBoton;
	public bool [] arrayBotones;
	public bool [] arrayBotonesEliminar;
	public string[] nombreFotoP;
	public string[] nombreFotoT;
	private string rutaprenda;

	public int toolbarInt = 0;
	byte[] imageData;

	//guardar los nombres de las fotos que el usuario lleva encima
	private string[] arrayRopaPuesta= new string[]{"","","","","","","",""};
	private bool PulsadoGuardar=false;
	private string stringDia="";
	private string stringMes="";
	private string stringAnyo="";
	public GUIStyle style;
	public Texture2D BotonGuarda;
	private string CadenaRopaPuesta="";

	private bool Pulsadolook=false;
	private string stringNombreLook="";


	//carga del avatar

	private string DatosDescarga="";
	private string [] datosAvatar;
	
	bool ControlDescarga=false;
	bool precarga=false;

	public void Start()
	{
		//eleccion avatar

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

		if (!ControlDescarga) {
			CargaAvatar ();
		}
		else {
			
			if (!precarga){//carga del avatar guardado en base de datos
				//hacer consulta a la base de datos para cargar el avatar del usuario
				
				datosAvatar=DatosDescarga.Split('/');
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
			
				if (!Variables.VerTodo) {
								//barra de menu donde se encuentran los elementos de ropa
								//Colocacion de botones para la ropa
								toolbarInt = GUI.SelectionGrid (new Rect (1100, 10, 70, 700), toolbarInt, texBoton, 1);

								//Ocultar el objeto para cambios de vestuario.
								//Camiseta.renderer.enabled = false;

								if (toolbarInt == 0) {
										rutaprenda = "Camisa";
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
										}
										if (toolbarInt == 1) {
										rutaprenda = "Camiseta";
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
									}
									if (toolbarInt == 2) {
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
										CamisetaJ.renderer.enabled = false;
										CamisaJ.renderer.enabled = false;
										JerseyJ.renderer.enabled = true;
										SudaderaJ.renderer.enabled = false;
										ChaquetaJ.renderer.enabled = false;
										VestidoJ.renderer.enabled = false;
										CamisetaFinaJ.renderer.enabled = false;
										}
										rutaprenda = "Jersey";
									}
									if (toolbarInt == 3) {

										rutaprenda = "Sudadera";
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
									}
									if (toolbarInt == 4) {
										
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
										rutaprenda = "Chaqueta";
								}
								if (toolbarInt == 5) {
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
										rutaprenda = "Pantalon";
								}
								if (toolbarInt == 6) {
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
										rutaprenda = "PantalonCorto";
								}
								if (toolbarInt == 7) {
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
										rutaprenda = "Vestido";
								}
								int i = 0;
								//crear un array de botones con las fotos de las prendas guardadas en la carpeta 
								//Contar el numero de archivos que hay en la carpeta
								DirectoryInfo dir = new DirectoryInfo (Application.dataPath + "/RopaArmario/" + Variables.idUsuario + "/" + rutaprenda + "/Prendas/");
								FileInfo[] info = dir.GetFiles ("*.JPG");
						
								foreach (FileInfo f in info) {
										i++;
								}
								//creación de array dinamicos
								texPrenda = new Texture2D[i];
								arrayBotones = new bool[i];
								arrayBotonesEliminar = new bool[i];
								nombreFotoP = new string[i];
								nombreFotoT = new string[i];
								i = 0;
								foreach (FileInfo f in info) {


										nombreFotoP [i] = "./Assets/RopaArmario/" + Variables.idUsuario + "/" + rutaprenda + "/Prendas/" + info [i].Name;
							
										texPrenda [i] = new Texture2D (2, 2, TextureFormat.DXT1, false);

							
										imageData = File.ReadAllBytes (nombreFotoP [i]);
										texPrenda [i].LoadImage (imageData);

										arrayBotones [i] = GUI.Button (new Rect (1200, (120 * i) + 10, 100, 100), texPrenda [i]);
										arrayBotonesEliminar [i] = GUI.Button (new Rect (1320, (120 * i) + 10, BtnEliminar.width, BtnEliminar.height), BtnEliminar);
						
										//array con nombre de las texturas
										nombreFotoT [i] = "file://" + Application.dataPath + "/RopaArmario/" + Variables.idUsuario + "/" + rutaprenda + "/Texturas/" + info [i].Name;
										//funcionalidad de cada boton del array
										if (arrayBotones [i]) {
													PulsadoGuardar = false;
													Pulsadolook=false;
													if (toolbarInt == 0) {
														arrayRopaPuesta [toolbarInt] = info [i].Name;
														arrayRopaPuesta [1] = "";
														arrayRopaPuesta [2] = "";
														arrayRopaPuesta [3] = "";
														arrayRopaPuesta [4] = "";
														arrayRopaPuesta [7] = "";
														//para cargra la imagen que se ha fotografiado
														Cargar (Camisa, nombreFotoT [i]);
														Cargar (CamisaJ, nombreFotoT [i]);
												}
												if (toolbarInt == 1) {		
														arrayRopaPuesta [toolbarInt] = info [i].Name;
														arrayRopaPuesta [0] = "";
														arrayRopaPuesta [2] = "";
														arrayRopaPuesta [3] = "";
														arrayRopaPuesta [4] = "";
														arrayRopaPuesta [7] = "";
														//para cargra la imagen que se ha fotografiado
														Cargar (Camiseta, nombreFotoT [i]);
														Cargar (CamisetaJ, nombreFotoT [i]);
												}
												if (toolbarInt == 2) {
														arrayRopaPuesta [toolbarInt] = info [i].Name;
														arrayRopaPuesta [0] = "";
														arrayRopaPuesta [1] = "";
														arrayRopaPuesta [3] = "";
														arrayRopaPuesta [4] = "";
														arrayRopaPuesta [7] = "";
														//para cargra la imagen que se ha fotografiado
														Cargar (Jersey, nombreFotoT [i]);
														Cargar (JerseyJ, nombreFotoT [i]);
												}
												if (toolbarInt == 3) {
														arrayRopaPuesta [toolbarInt] = info [i].Name;
														arrayRopaPuesta [0] = "";
														arrayRopaPuesta [1] = "";
														arrayRopaPuesta [2] = "";
														arrayRopaPuesta [4] = "";
														arrayRopaPuesta [7] = "";
														//para cargra la imagen que se ha fotografiado
														Cargar (Sudadera, nombreFotoT [i]);
														Cargar (SudaderaJ, nombreFotoT [i]);
												}
												if (toolbarInt == 4) {
														
														arrayRopaPuesta [toolbarInt] = info [i].Name;
														arrayRopaPuesta [0] = "";
														arrayRopaPuesta [1] = "";
														arrayRopaPuesta [2] = "";
														arrayRopaPuesta [3] = "";
														arrayRopaPuesta [7] = "";
														//para cargra la imagen que se ha fotografiado
														Cargar (Chaqueta, nombreFotoT [i]);
														Cargar (ChaquetaJ, nombreFotoT [i]);
												}
												if (toolbarInt == 5) {
														
														arrayRopaPuesta [toolbarInt] = info [i].Name;
														arrayRopaPuesta [6] = "";
														arrayRopaPuesta [7] = "";
														//para cargra la imagen que se ha fotografiado
														Cargar (Pantalon, nombreFotoT [i]);
														Cargar (PantalonJ, nombreFotoT [i]);
												}
												if (toolbarInt == 6) {
														
														arrayRopaPuesta [toolbarInt] = info [i].Name;
														arrayRopaPuesta [5] = "";
														arrayRopaPuesta [7] = "";
														//para cargra la imagen que se ha fotografiado
														Cargar (PantalonC, nombreFotoT [i]);
														Cargar (PantalonCJ, nombreFotoT [i]);
												}
												if (toolbarInt == 7) {
														
														arrayRopaPuesta [toolbarInt] = info [i].Name;
														arrayRopaPuesta [0] = "";
														arrayRopaPuesta [1] = "";
														arrayRopaPuesta [2] = "";
														arrayRopaPuesta [3] = "";
														arrayRopaPuesta [4] = "";
														arrayRopaPuesta [5] = "";
														arrayRopaPuesta [6] = "";
														//para cargra la imagen que se ha fotografiado
														Cargar (Vestido, nombreFotoT [i]);
														Cargar (VestidoJ, nombreFotoT [i]);
												}
									
										
										}
										if (arrayBotonesEliminar [i]) {

												//borrar la ropa tanto de la aplicacaión como del servidor

												BorrarRopaSrv ("armariosUsuarios/" + Variables.idUsuario + "/" + rutaprenda + "/Texturas/" + info [i].Name, "armariosUsuarios/" + Variables.idUsuario + "/" + rutaprenda + "/Prendas/" + info [i].Name);

												print ("borrar del server fotos y base datos " + info [i].Name);

												File.Delete (Application.dataPath + "/RopaArmario/" + Variables.idUsuario + "/" + rutaprenda + "/Texturas/" + info [i].Name);
												File.Delete (Application.dataPath + "/RopaArmario/" + Variables.idUsuario + "/" + rutaprenda + "/Prendas/" + info [i].Name);


										}
										i++;		
								}
								if (GUI.Button (new Rect ((Screen.width / 2) - 600, (Screen.height / 2) + 150, 155, 50), "Guardar en Calendario")) {
										PulsadoGuardar = true;
										Pulsadolook=false;


								}

								//guarda por fecha en el calendario 
								if (PulsadoGuardar) {
										
										GUI.Label (new Rect ((Screen.width / 2) - 600, (Screen.height / 3) + 350, 40, 20), "Dia",style);
										GUI.Label (new Rect ((Screen.width / 2) - 600, (Screen.height / 3) + 370, 40, 20), "Mes",style);
										GUI.Label (new Rect ((Screen.width / 2) - 600, (Screen.height / 3) + 390, 40, 20), "Año",style);
										stringDia = GUI.TextField (new Rect ((Screen.width / 2) - 540, (Screen.height / 3) + 350, 50, 20), stringDia, 2);
										stringMes = GUI.TextField (new Rect ((Screen.width / 2) - 540, (Screen.height / 3) + 370, 50, 20), stringMes, 2);
										stringAnyo = GUI.TextField (new Rect ((Screen.width / 2) - 540, (Screen.height / 3) + 390, 50, 20), stringAnyo, 4);
										string fecha;
										fecha = stringAnyo + "-" + stringMes + "-" + stringDia;
										if (GUI.Button (new Rect ((Screen.width / 2) - 470, (Screen.height / 3) + 355, BotonGuarda.width, BotonGuarda.height), BotonGuarda)) {
												int j;
												for (j=0; j<8; j++) {
														if (arrayRopaPuesta [j] != "") {
																CadenaRopaPuesta = CadenaRopaPuesta + arrayRopaPuesta [j] + "," + j + "/";
														}
												}
												GuardaCalendario (fecha, CadenaRopaPuesta);
												CadenaRopaPuesta = "";
												stringDia = "";
												stringMes = "";
												stringAnyo = "";
												fecha = "";
												stringNombreLook = "";
												PulsadoGuardar = false;
							
										}


								}
								if (GUI.Button (new Rect ((Screen.width / 2) - 430, (Screen.height / 2) + 150, 155, 50), "Guardar Conjunto")) {
									Pulsadolook=true;
									PulsadoGuardar=false;
								}
								//guarda los look en la base de datos
								if (Pulsadolook) {
										
										GUI.Label (new Rect ((Screen.width / 2) - 600, (Screen.height / 3) + 340, 40, 20), "Nombre Conjunto",style);
										stringNombreLook = GUI.TextField (new Rect ((Screen.width / 2) - 600, (Screen.height / 3) + 365, 200, 20), stringNombreLook, 30);
										if (GUI.Button (new Rect ((Screen.width / 2) - 390, (Screen.height / 3) + 355, BotonGuarda.width, BotonGuarda.height), BotonGuarda)) {
												int j;
												for (j=0; j<8; j++) {
														if (arrayRopaPuesta [j] != "") {
																CadenaRopaPuesta = CadenaRopaPuesta + arrayRopaPuesta [j] + "," + j + "/";
														}
												}
												GuardaLook (stringNombreLook, CadenaRopaPuesta);
												CadenaRopaPuesta = "";
												stringNombreLook = "";
												stringDia = "";
												stringMes = "";
												stringAnyo = "";
												Pulsadolook = false;
										}
								}
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
			DatosDescarga = datos.text;
			print (DatosDescarga);
			if (datos.isDone) {//control de la descarga	
				ControlDescarga = true;
			} else {
				ControlDescarga = false;
			}	
		}

	void GuardaLook(string nombre,string ropa){
		
		StartCoroutine (look (nombre, ropa,Variables.idUsuario));
		
	}
	
	IEnumerator look(string nombre,string ropa,int Usuario){
		
		WWWForm postForm = new WWWForm ();
		
		postForm.AddField ("nombre", nombre);
		postForm.AddField ("ropa", ropa);
		postForm.AddField ("idUsuario", Usuario);
		WWW upload = new WWW("myfres.com/SmartWardrobe/Guardalook.php",postForm);
		yield return upload;
		if (upload.error == null)
			Debug.Log("upload done :" + upload.text);
		else
			Debug.Log("Error during upload: " + upload.error);
		
	}


	void GuardaCalendario(string fecha,string ropa){
		
		StartCoroutine (Calendario (fecha, ropa,Variables.idUsuario));
		
	}
	
	IEnumerator Calendario(string fecha,string ropa,int Usuario){
		
		WWWForm postForm = new WWWForm ();
		
		postForm.AddField ("fecha", fecha);
		postForm.AddField ("ropa", ropa);
		postForm.AddField ("idUsuario", Usuario);
		WWW upload = new WWW("myfres.com/SmartWardrobe/GuardaCalendario.php",postForm);
		yield return upload;
		if (upload.error == null)
			Debug.Log("upload done :" + upload.text);
		else
			Debug.Log("Error during upload: " + upload.error);
		
	}

	void BorrarRopaSrv(string rutaT,string rutaP){
		
		StartCoroutine (Borrar (rutaT, rutaP));
		
	}
	
	IEnumerator Borrar(string rutaT,string rutaP){
		
		WWWForm postForm = new WWWForm ();
		
		postForm.AddField ("rutaT", rutaT);
		postForm.AddField ("rutaP", rutaP);
		WWW upload = new WWW("myfres.com/SmartWardrobe/EliminarRopa.php",postForm);
		yield return upload;
		if (upload.error == null)
			Debug.Log("upload done :" + upload.text);
		else
			Debug.Log("Error during upload: " + upload.error);
	
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
