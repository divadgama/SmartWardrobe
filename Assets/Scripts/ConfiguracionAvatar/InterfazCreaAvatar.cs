using UnityEngine;
using System.Collections;
using System.IO;

public class InterfazCreaAvatar : MonoBehaviour {

	public Texture2D BotonAtras;
	public Texture2D BotonGuarda;

	public Texture2D BotonChico;
	public Texture2D BotonChica;
	public Texture2D BotonChicoPulsado;
	public Texture2D BotonChicaPulsado;
	public Texture2D botonJoven;
	public Texture2D botonJovenpulsado;
	public Texture2D botonMayor;
	public Texture2D botonMayorpulsado;

	public Texture2D botonpeloLargo;
	
	private bool chicoPulsado;
	private bool chicaPulsado;

	private bool jovenPulsado;
	private bool mayorPulsado;


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

	//imagenes de los colores
	public Texture2D TMoreno;
	public Texture2D TRubio;
	public Texture2D TGris;
	public Texture2D TCastano;
	public Texture2D TPelirrojo;

	private bool MostrarColores=false;

	int sexo=2;
	int raza=1;
	int edad=1;
	int pelo=4;


	private string DatosDescarga="";
	private string [] datosAvatar;

	bool ControlDescarga=false;
	bool precarga=false;

	bool ControlGuardado=false;

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
					chicoPulsado=true;
					chicaPulsado=false;
					
					
				}
				else{
					//contol sexo avatar botones
					chicoPulsado=false;
					chicaPulsado=true;
					
					if(datosAvatar[2]=="1"){//es mujer mayor
						print("entro mujer");
						//control de botones de avatar
						jovenPulsado=false;
						mayorPulsado=true;
						
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
						
					}
					else{//es joven
						//control de botones de avatar
						jovenPulsado=true;
						mayorPulsado=false;
						
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
			else{//si el avatar ys se a cargado podemos modificarlo
				if (GUI.Button (new Rect (100, 100, BotonAtras.width, BotonAtras.height), BotonAtras)) {
					
					Application.LoadLevel ("PantallaPrincipal");
				}
				
				if (chicoPulsado) {
					MostrarColores=false;
					GUI.Button (new Rect (100,150, BotonChicoPulsado.width, BotonChicoPulsado.height),BotonChicoPulsado);
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
					
				}
				else {
					if(GUI.Button (new Rect (100,150, BotonChico.width, BotonChico.height),BotonChico)){
						MostrarColores=false;
						chicoPulsado=true;
						chicaPulsado=false;
						
					}
				}
				
				//Cambiar la textura al boton para efecto pulsado
				if (chicaPulsado) {
					sexo=2;
					//boton para pelo
					if(GUI.Button (new Rect (1000, 150, botonpeloLargo.width, botonpeloLargo.height), botonpeloLargo)){
						MostrarColores=true;
					}
					
					//configuracion de los colores pelo
					if(MostrarColores){
						if(GUI.Button (new Rect (1100, 150, TMoreno.width, TMoreno.height), TMoreno)){
							Cargar (PelolargoMujer, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Moreno.jpg");
							Cargar (PelolargoJoven, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Moreno.jpg");
							pelo=0;
						}
						GUI.Label(new Rect (1120, 150, 50,20), "Moreno");
						
						if(GUI.Button (new Rect (1100, 170, TRubio.width, TRubio.height), TRubio)){
							Cargar (PelolargoMujer, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Rubio.jpg");	
							Cargar (PelolargoJoven, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Rubio.jpg");
							pelo=1;
						}
						GUI.Label(new Rect (1120, 170, 50,20), "Rubio");
						
						if(GUI.Button (new Rect (1100, 190, TGris.width, TGris.height), TGris)){
							Cargar (PelolargoMujer, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Gris.jpg");
							Cargar (PelolargoJoven, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Gris.jpg");
							pelo=2;
						}
						GUI.Label(new Rect (1120, 190, 50,20), "Gris");
						
						if(GUI.Button (new Rect (1100, 210, TCastano.width, TCastano.height), TCastano)){
							Cargar (PelolargoMujer, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Castano.jpg");
							Cargar (PelolargoJoven, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Castano.jpg");
							pelo=3;
						}
						GUI.Label(new Rect (1120, 210, 50,20), "Castaño");
						
						if(GUI.Button (new Rect (1100, 230, TPelirrojo.width, TPelirrojo.height), TPelirrojo)){
							Cargar (PelolargoMujer, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Pelirrojo.jpg");
							Cargar (PelolargoJoven, "file://" + Application.dataPath + "/Texture/TexturasAvatar/TexturasPelo/Pelirrojo.jpg");
							pelo=4;
						}
						GUI.Label(new Rect (1120, 230, 50,20), "Pelirojo");
					}
					
					GUI.Button (new Rect (170, 150, BotonChicaPulsado.width, BotonChicaPulsado.height), BotonChicaPulsado);
					
					if (jovenPulsado) {
						edad=2;
						GUI.Button (new Rect (100, 230, botonJovenpulsado.width, botonJovenpulsado.height), botonJovenpulsado);
						
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
					} else {
						if (GUI.Button (new Rect (100, 230, botonJoven.width, botonJoven.height), botonJoven)) {
							jovenPulsado = true;
							mayorPulsado = false;
							//	stringSexo = "1";
						}
					}
					
					if (mayorPulsado) {
						
						edad=1;
						GUI.Button (new Rect (170, 230, botonMayorpulsado.width, botonMayorpulsado.height), botonMayorpulsado);
						
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
						
					} else {
						if (GUI.Button (new Rect (170, 230, botonMayor.width, botonMayor.height), botonMayor)) {
							jovenPulsado = false;
							mayorPulsado = true;
							//stringSexo = "0";
						}
					}
				}
				else {
					if(GUI.Button (new Rect (170,150, BotonChica.width, BotonChica.height),BotonChica)){
						MostrarColores=false;
						chicoPulsado=false;
						chicaPulsado=true;
						//stringSexo = "0";
					}
				}
				if (GUI.Button (new Rect (140, 400, BotonGuarda.width, BotonGuarda.height), BotonGuarda)) {
					
					GuardaAvatar();
					if(ControlGuardado){
						Application.LoadLevel ("PantallaPrincipal");
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
		if (datos.isDone) {//control de la descarga	
			ControlDescarga = true;
		} else {
			ControlDescarga = false;
		}	
	}

	
void GuardaAvatar(){
		
		StartCoroutine (Guardar());
		
	}
	
IEnumerator Guardar(){
		
		WWWForm postForm = new WWWForm ();
		
		postForm.AddField ("idUsuario", Variables.idUsuario);
		postForm.AddField ("sexo", sexo);
		postForm.AddField ("raza", raza);
		postForm.AddField ("edad", edad);
		postForm.AddField ("colorpelo", pelo);


		WWW upload = new WWW("myfres.com/SmartWardrobe/ActualizaAvatar.php",postForm);
		yield return upload;
		if (upload.isDone) {//control de la descarga	
			ControlGuardado = true;
		} else {
			ControlGuardado = false;
		}		
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

