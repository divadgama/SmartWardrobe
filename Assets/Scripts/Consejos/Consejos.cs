using UnityEngine;
using System.Collections;
using System.IO;

public class Consejos : MonoBehaviour {

	public Texture2D BotonAtras;
	public Texture2D BotonIdeas;


	//Temporada
	bool verano = false;
	bool invierno = false;
	bool primavera = false;
	bool otonio = false;
	
	//Colores
	bool Negro = false;
	bool Blanco = false;
	bool Gris = false;
	bool VerdeO = false;
	bool VerdeC = false;
	bool AzulO = false;
	bool AzulC = false;
	bool Rojo = false;
	bool Rosa = false;
	bool Morado = false;
	bool Amarillo = false;
	bool Naranja = false;
	
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

	//imagenes de las Prendas
	public Texture2D TCamisa;
	public Texture2D TCamiseta;
	public Texture2D TChaqueta;
	public Texture2D TSudadera;
	public Texture2D TJersey;
	public Texture2D TPantalon;
	public Texture2D TPantalonC;
	public Texture2D TVestido;

	//Prendas Elegidas
	bool camisa = false;
	bool camiseta = false;
	bool chaqueta = false;
	bool sudadera = false;
	bool jersey = false;
	bool pantalon = false;
	bool pantalonC = false;
	bool vestido = false;


	//Look
	bool Diario= false;
	bool Elegante = false;
	bool Deporte = false;
	bool Casual = false;
	bool Formal = false;
	bool Trabajo = false;
	bool Favorita = false;
	bool Club = false;

	//control del servidor
	private string DatosDescarga="";
	private bool ControlDescarga=false;
	bool controlconsulta=false;
	//control de prendas a mostrar
	int numeroPrendas=0;
	private string [] cadenaConsejo;
	private string[] datosConsejo;
	public Texture2D[] texPrenda;
	public string[] nombreFotoP;
	byte[] imageData;

	bool mensaje_errorUsuario=false;
	
	public void OnGUI() {

		if (GUI.Button (new Rect (100, 100, BotonAtras.width, BotonAtras.height), BotonAtras)) {

				Application.LoadLevel ("PantallaPrincipal");
		}
		GUI.Label (new Rect ((Screen.width / 2)-440,50, 200, 20), "Prendas a elegir");

		GUI.enabled = Variables.activocamisa;
		camisa = GUI.Toggle(new Rect((Screen.width / 2)-440, 80, 50, 50), camisa,TCamisa);
		GUI.enabled = Variables.activocamiseta;
		camiseta = GUI.Toggle(new Rect((Screen.width / 2)-380,80, 50, 50), camiseta, TCamiseta);
		GUI.enabled = Variables.activochaqueta;
		chaqueta = GUI.Toggle(new Rect((Screen.width / 2)-320,80, 50, 50), chaqueta, TChaqueta);
		GUI.enabled = Variables.activosudadera;
		sudadera = GUI.Toggle(new Rect((Screen.width / 2)-260,80, 50, 50), sudadera, TSudadera);
		GUI.enabled = Variables.activojersey;
		jersey = GUI.Toggle(new Rect((Screen.width / 2)-440,140, 50, 50), jersey, TJersey);
		GUI.enabled = Variables.activopantalon;
		pantalon = GUI.Toggle(new Rect((Screen.width / 2)-380,140, 50, 50), pantalon, TPantalon);
		GUI.enabled = Variables.activopantalonc;
		pantalonC = GUI.Toggle(new Rect((Screen.width / 2)-320,140, 50, 50), pantalonC, TPantalonC);
		GUI.enabled = Variables.activovestido;
		vestido = GUI.Toggle(new Rect((Screen.width / 2)-260,140, 50, 50), vestido, TVestido);


		//control de la prendas elegidas
		if (camisa || camiseta || chaqueta || sudadera||jersey||pantalon||pantalonC||vestido) {
			if (camisa) {
				Variables.activocamisa=true;
				Variables.activocamiseta=false;
				Variables.activosudadera=false;
				Variables.activovestido=false;
			}
			if (camiseta) {
				Variables.activocamisa=false;
				Variables.activovestido=false;

			}
			if (chaqueta) {
				Variables.activosudadera=false;
				Variables.activovestido=false;

			}
			if (sudadera) {
				Variables.activocamisa=false;
				Variables.activojersey=false;
				Variables.activochaqueta=false;
				Variables.activovestido=false;

			}
			if (jersey) {
				Variables.activosudadera=false;
				Variables.activovestido=false;

			}
			if (pantalon) {
			
				Variables.activopantalonc=false;
				Variables.activovestido=false;

			}
			if (pantalonC) {
				Variables.activopantalon=false;
				Variables.activovestido=false;


			}
			if (vestido) {
				Variables.activocamisa=false;
				Variables.activocamiseta=false;
				Variables.activojersey=false;
				Variables.activosudadera=false;
				Variables.activochaqueta=false;
				Variables.activopantalon=false;
				Variables.activopantalonc=false;


			}
		}
		else {
			Variables.activocamisa=true;
			Variables.activocamiseta=true;
			Variables.activojersey=true;
			Variables.activosudadera=true;
			Variables.activochaqueta=true;
			Variables.activopantalon=true;
			Variables.activopantalonc=true;
			Variables.activovestido=true;
				}

		GUI.enabled =true;
		GUI.Label (new Rect ((Screen.width / 2)-440, 180, 200, 20), "Temporada");
		GUI.Label (new Rect ((Screen.width / 2)-150,50, 200, 20), "Colores Principales");
		GUI.Label (new Rect ((Screen.width / 2)-150,180, 200, 20), "Look");

		
		//Check boton de las temporadas
		GUI.enabled = Variables.activoinvierno;
		invierno = GUI.Toggle(new Rect((Screen.width / 2)-440,200, 70, 20), invierno, " Invierno");
		GUI.enabled = Variables.activoprimavera;
		primavera = GUI.Toggle(new Rect((Screen.width / 2)-300,200, 80, 20), primavera, " Primavera");
		GUI.enabled = Variables.activoverano;
		verano = GUI.Toggle(new Rect((Screen.width / 2)-440,220, 70, 20), verano, " Verano");
		GUI.enabled = Variables.activootonio;
		otonio = GUI.Toggle(new Rect((Screen.width / 2)-300,220, 65, 20), otonio, " Otoño");

		//solo se puede elegir una temporada para las ideas si una actica desactiva las demas
		if (invierno || primavera || verano || otonio) {
			if(invierno)
			{
				Variables.activootonio=false;
				Variables.activoprimavera=false;
				Variables.activoverano=false;
			}
			if(verano)
			{
				Variables.activoinvierno=false;
				Variables.activootonio=false;
				Variables.activoprimavera=false;
			}
			if(otonio)
			{
				Variables.activoinvierno=false;
				Variables.activoprimavera=false;
				Variables.activoverano=false;
			}
			if(primavera)
			{
				Variables.activoinvierno=false;
				Variables.activootonio=false;
				Variables.activoverano=false;
			}
		} 
		else {
			Variables.activoinvierno=true;
			Variables.activootonio=true;
			Variables.activoprimavera=true;
			Variables.activoverano=true;
		}

		
		//Check boton de los colores de la prendas
		GUI.enabled =Variables.activonegro;
		Negro = GUI.Toggle(new Rect((Screen.width / 2)-150, 80, 30, 20), Negro,TNegro);
		GUI.enabled =Variables.activoblanco;
		Blanco = GUI.Toggle(new Rect((Screen.width / 2)-100,80, 30, 20), Blanco, TBlanco);
		GUI.enabled =Variables.activogris;
		Gris = GUI.Toggle(new Rect((Screen.width / 2)-50,80, 30, 20), Gris, TGris);
		GUI.enabled =Variables.activoverdeo;
		VerdeO = GUI.Toggle(new Rect((Screen.width / 2),80, 30, 20), VerdeO, TVerdeO);
		GUI.enabled =Variables.activoverdec;
		VerdeC = GUI.Toggle(new Rect((Screen.width / 2)-150,120, 30, 20), VerdeC, TVerdeC);
		GUI.enabled =Variables.activoazulo;
		AzulO = GUI.Toggle(new Rect((Screen.width / 2)-100,120, 30, 20), AzulO, TAzulO);
		GUI.enabled =Variables.activoazulc;
		AzulC = GUI.Toggle(new Rect((Screen.width / 2)-50,120, 30, 20), AzulC, TAzulC);
		GUI.enabled =Variables.activorojo;
		Rojo = GUI.Toggle(new Rect((Screen.width / 2),120, 30, 20), Rojo, TRojo);
		GUI.enabled =Variables.activorosa;
		Rosa = GUI.Toggle(new Rect((Screen.width / 2)-150,160, 30, 20), Rosa, TRosa);
		GUI.enabled =Variables.activomorado;
		Morado = GUI.Toggle(new Rect((Screen.width / 2)-100,160, 30, 20), Morado, TMorado);
		GUI.enabled =Variables.activoamarillo;
		Amarillo = GUI.Toggle(new Rect((Screen.width / 2)-50,160, 30, 20), Amarillo, TAmarillo);
		GUI.enabled =Variables.activonaranja;
		Naranja = GUI.Toggle(new Rect((Screen.width / 2),160, 30, 20), Naranja, TNaranja);

		if (Negro || Blanco || Gris || VerdeO||VerdeC||AzulO||AzulC||Rojo||Rosa||Morado||Amarillo||Naranja) {
			
			if(Negro)
			{
				Variables.activoazulo=false;
			}
			if(Blanco)
			{
				Variables.activoverdec=false;
				Variables.activonaranja=false;
				Variables.activoamarillo=false;
			}
			if(Gris)
			{
				Variables.activoverdeo=false;
				Variables.activoazulo=false;
			}
			if(VerdeO)
			{
				Variables.activoazulo=false;
				Variables.activoazulc=false;
				Variables.activogris=false;
				Variables.activorojo=false;
			}
			if(VerdeC)
			{
				Variables.activoblanco=false;
				Variables.activoverdeo=false;
				Variables.activorojo=false;
				Variables.activorosa=false;
				Variables.activoazulc=false;
			}
			if(AzulO)
			{
				Variables.activonegro=false;
				Variables.activoverdeo=false;
				Variables.activogris=false;
			}
			if(AzulC)
			{
				Variables.activoverdec=false;
				Variables.activoverdeo=false;
			}
			if(Morado)
			{
				Variables.activorojo=false;
			}
			if(Rojo)
			{
				Variables.activoverdec=false;
				Variables.activomorado=false;
				Variables.activorosa=false;
				Variables.activoamarillo=false;
				Variables.activonaranja=false;
			}
			if(Rosa)
			{
				Variables.activoverdec=false;
				Variables.activorojo=false;
				Variables.activoamarillo=false;
				Variables.activonaranja=false;
			}
			if(Amarillo)
			{
				Variables.activoblanco=false;
				Variables.activorosa=false;
				Variables.activonaranja=false;
			}
			if(Naranja)
			{
				Variables.activorojo=false;
				Variables.activorosa=false;
				Variables.activoamarillo=false;
			}
			
			} 
			else {
				Variables.activonegro=true;
				Variables.activoblanco=true;
				Variables.activogris=true;
				Variables.activoverdeo=true;
				Variables.activoverdec=true;
				Variables.activoazulo=true;
				Variables.activoazulc=true;
				Variables.activorojo=true;
				Variables.activorosa=true;
				Variables.activomorado=true;
				Variables.activoamarillo=true;
				Variables.activonaranja=true;
			}


		//Check boton para el look
		GUI.enabled = Variables.activodiario;
		Diario = GUI.Toggle(new Rect((Screen.width / 2)-150,200, 60, 20), Diario, " Diario");
		GUI.enabled = Variables.activoelegante;
		Elegante = GUI.Toggle(new Rect((Screen.width / 2)-80, 200, 70, 20), Elegante, " Elegante");
		GUI.enabled = Variables.activocasual;
		Casual = GUI.Toggle(new Rect((Screen.width / 2), 200, 60, 20), Casual, " Casual");
		GUI.enabled = Variables.activoclub;
		Club = GUI.Toggle(new Rect((Screen.width / 2)+70, 200, 55, 20), Club, " Club");
		GUI.enabled = Variables.activoformal;
		Formal = GUI.Toggle(new Rect((Screen.width / 2)-150,220, 60, 20), Formal, " Formal");
		GUI.enabled = Variables.activodeporte;
		Deporte = GUI.Toggle(new Rect((Screen.width / 2)-80,220, 70, 20), Deporte, " Deporte");
		GUI.enabled = Variables.activotrabajo;
		Trabajo = GUI.Toggle(new Rect((Screen.width / 2), 220, 70, 20), Trabajo, " Trabajo");
		GUI.enabled = Variables.activofavorita;
		Favorita = GUI.Toggle(new Rect((Screen.width / 2)+70,220, 80, 20), Favorita, " Favorita");

		if (Diario || Elegante || Casual || Club||Formal||Deporte||Trabajo||Favorita) {

			if(Diario)
			{
				Variables.activoelegante=false;
				Variables.activocasual=false;
				Variables.activoclub=false;
				Variables.activoformal=false;
				Variables.activodeporte=false;
				Variables.activotrabajo=false;
				Variables.activofavorita=false;
			}
			if(Elegante)
			{
				Variables.activodiario=false;
				Variables.activocasual=false;
				Variables.activoclub=false;
				Variables.activoformal=false;
				Variables.activodeporte=false;
				Variables.activotrabajo=false;
				Variables.activofavorita=false;
			}
			if(Casual)
			{
				Variables.activoelegante=false;
				Variables.activodiario=false;
				Variables.activoclub=false;
				Variables.activoformal=false;
				Variables.activodeporte=false;
				Variables.activotrabajo=false;
				Variables.activofavorita=false;
			}
			if(Club)
			{
				Variables.activoelegante=false;
				Variables.activocasual=false;
				Variables.activodiario=false;
				Variables.activoformal=false;
				Variables.activodeporte=false;
				Variables.activotrabajo=false;
				Variables.activofavorita=false;
			}
			if(Formal)
			{
				Variables.activoelegante=false;
				Variables.activocasual=false;
				Variables.activoclub=false;
				Variables.activodiario=false;
				Variables.activodeporte=false;
				Variables.activotrabajo=false;
				Variables.activofavorita=false;
			}
			if(Deporte)
			{
				Variables.activoelegante=false;
				Variables.activocasual=false;
				Variables.activoclub=false;
				Variables.activoformal=false;
				Variables.activodiario=false;
				Variables.activotrabajo=false;
				Variables.activofavorita=false;
			}
			if(Trabajo)
			{
				Variables.activoelegante=false;
				Variables.activocasual=false;
				Variables.activoclub=false;
				Variables.activoformal=false;
				Variables.activodeporte=false;
				Variables.activodiario=false;
				Variables.activofavorita=false;
			}
			if(Favorita)
			{
				Variables.activoelegante=false;
				Variables.activocasual=false;
				Variables.activoclub=false;
				Variables.activoformal=false;
				Variables.activodeporte=false;
				Variables.activotrabajo=false;
				Variables.activodiario=false;
			}

		} 
		else {
			Variables.activodiario=true;
			Variables.activoelegante=true;
			Variables.activocasual=true;
			Variables.activoclub=true;
			Variables.activoformal=true;
			Variables.activodeporte=true;
			Variables.activotrabajo=true;
			Variables.activofavorita=true;
		}

		GUI.enabled = true;
		if (GUI.Button (new Rect ((Screen.width / 2)+70, 100, 70, 70), BotonIdeas)) {
			numeroPrendas=0;
			//Numero de prendas que se van a buscar en la base de datos para crear los label necesarios para mostrar las prendas
			if (camisa) {
				numeroPrendas++;
			}
			if (camiseta) {
				numeroPrendas++;	
			}
			if (chaqueta) {
				numeroPrendas++;
			}
			if (sudadera) {
				numeroPrendas++;
			}
			if (jersey) {
				numeroPrendas++;
			}
			if (pantalon) {
				numeroPrendas++;
			}
			if (pantalonC) {
				numeroPrendas++;
			}
			if (vestido) {	
				numeroPrendas++;
			}
			ControlDescarga=false;
			controlconsulta=true;
			//consulta a la base de datos
			descargaConsejo();
		}



		//muestra las prenda que se han seleccionado para el usuario

		if(!ControlDescarga && controlconsulta){
			descargaConsejo();
		}
		else
		{
			if (DatosDescarga=="" && ControlDescarga) {
				GUI.Label(new Rect((Screen.width/4),(Screen.height/3),400,40),"No existe ninguna prenda con la seleccion de parametro, elija unos nuevos parametros");
			}
			controlconsulta=false;
			cadenaConsejo = DatosDescarga.Split ('*');
			nombreFotoP = new string[cadenaConsejo.Length];
			texPrenda = new Texture2D[cadenaConsejo.Length];

			for(int i=0;i<(cadenaConsejo.Length)-1;i++){
				datosConsejo=cadenaConsejo[i].Split('/');
				nombreFotoP [i] = "./Assets/RopaArmario/" + Variables.idUsuario + "/" + datosConsejo[1] + "/Prendas/" + datosConsejo[0];
				texPrenda [i] = new Texture2D (2, 2, TextureFormat.DXT1, false);
				imageData = File.ReadAllBytes (nombreFotoP [i]);
				texPrenda [i].LoadImage (imageData);
				GUI.Label (new Rect (150+(160*i),350, 150, 150), texPrenda [i]);
			}
		}


	}


	void descargaConsejo(){
		
		StartCoroutine (ConsultarBD (Variables.idUsuario));
		
	}
	
	IEnumerator ConsultarBD (int Usuario){
		
		WWWForm postForm = new WWWForm ();
		
		postForm.AddField ("idUsuario", Usuario);

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
		if (camisa) {
			postForm.AddField ("camisa", "1");
		} else {
			postForm.AddField ("camisa", "0");
		}
		if (camiseta) {
			postForm.AddField ("camiseta", "1");
		} else {
			postForm.AddField ("camiseta", "0");
		}
		if (chaqueta) {
			postForm.AddField ("chaqueta", "1");
		} else {
			postForm.AddField ("chaqueta", "0");
		}
		if (jersey) {
			postForm.AddField ("jersey", "1");
		} else {
			postForm.AddField ("jersey", "0");
		}
		if (sudadera) {
			postForm.AddField ("sudadera", "1");
		} else {
			postForm.AddField ("sudadera", "0");
		}
		if (pantalon) {
			postForm.AddField ("pantalon", "1");
		} else {
			postForm.AddField ("pnatalon", "0");
		}
		if (pantalonC) {
			postForm.AddField ("pantalonc", "1");
		} else {
			postForm.AddField ("pantalonc", "0");
		}
		if (vestido) {
			postForm.AddField ("vestido", "1");
		} else {
			postForm.AddField ("vestido", "0");
		}
		
		WWW datos = new WWW("myfres.com/SmartWardrobe/Consejos.php",postForm);
		yield return datos;
		DatosDescarga = datos.text;

		if (datos.isDone) {//control de la descarga	
			ControlDescarga = true;
		} else {
			ControlDescarga = false;
		}
	}
}
