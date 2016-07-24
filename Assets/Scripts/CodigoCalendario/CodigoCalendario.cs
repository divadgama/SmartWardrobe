using UnityEngine;
using System;
using System.Collections;
using System.Globalization;
using System.IO;



public class CodigoCalendario : MonoBehaviour {

	private string[] Months;
	private DateTime iMonth;
	private DateTime curDisplay;
	private string[] Days;
	private string[] DiasSemana={"Lunes","Martes","Miercoles","Jueves","Viernes","Sabado","Domingo"};
	public GUIStyle EstiloLabel;

	int numMes=0;
	int numAnyo=0;

	public Texture2D BotonAdelante;
	public Texture2D BotonAtras;
	public Texture2D BotonAtrasMes;

	//datos para la descaga del calendario
	private string DatosDescarga="";
	private bool ControlDescarga=false;

	private string [] cadenaCalendario;
	private string [] datosCalendario;
	private string [] cadenafecha;


	public Texture2D[] texPrenda;
	public string[] nombreFotoP;
	byte[] imageData;

		void Start()
		{
		  numMes = System.DateTime.Now.Month - 1;
		  numAnyo = System.DateTime.Now.Year;
		  CreateCalendar();
		}


	void CreateCalendar()
		
	{
		Months = new string[12];


		System.DateTime iMonth = new System.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day);


		for (int i = 0; i < 12; ++i) 
		{

		switch (i)
			{
			case 0:
				Months[i] ="Enero";
				break;
			case 1:
				Months[i] ="Febrero";
				break;
			case 2:
				Months[i] ="Marzo";
				break;
			case 3:
				Months[i] ="Abril";
				break;
			case 4:
				Months[i] ="Mayo";
				break;
			case 5:
				Months[i] ="Junio";
				break;
			case 6:
				Months[i] ="Julio";
				break;
			case 7:
				Months[i] ="Agosto";
				break;
			case 8:
				Months[i] ="Septiembre";
				break;
			case 9:
				Months[i] ="Octubre";
				break;
			case 10:
				Months[i] ="Noviembre";
				break;
			case 11:
				Months[i] ="Diciembre";
				break;
			default:
				print ("Mes Erroneo");
				break;
			}
		}

		Days = new string[37];
		int index=0;
		
		clearArray ();
		
		curDisplay= new System.DateTime(numAnyo, iMonth.Month,1);
		int curDays = GetDays(curDisplay.DayOfWeek);//que dia de la semana empieza el mes
		//para saber donde tiene que comenzar el mes en que posición del array
		if(curDays > 0)
			index = (curDays - 1);
		else
			index = curDays;
		
		while(curDisplay.Month == iMonth.Month)
		{
			
			Days[index]=curDisplay.Day.ToString();
			curDisplay = curDisplay.AddDays(1);
			index++;
		}
		
	}
	

	void CrearCalendario()
	{
		Days = new string[37];
		int index=0;
		
		clearArray ();
		
		curDisplay= new System.DateTime(numAnyo, iMonth.Month,1);
		int curDays = GetDays(curDisplay.DayOfWeek);//que dia de la semana empieza el mes
		//para saber donde tiene que comenzar el mes en que posición del array
		if(curDays > 0)
			index = (curDays - 1);
		else
			index = curDays;
		
		while(curDisplay.Month == iMonth.Month)
		{

			Days[index]=curDisplay.Day.ToString();
			curDisplay = curDisplay.AddDays(1);
			index++;
		}
	}


	private int GetDays(DayOfWeek day)
	{
		switch(day)
		{
		case DayOfWeek.Monday:      return 1;
		case DayOfWeek.Tuesday:     return 2;
		case DayOfWeek.Wednesday:   return 3;
		case DayOfWeek.Thursday:    return 4;
		case DayOfWeek.Friday:      return 5;
		case DayOfWeek.Saturday:    return 6;
		case DayOfWeek.Sunday:      return 7;
		default:                    throw new Exception("Unexpected DayOfWeek: " + day);
		}
	}

	void clearArray()
	{
		for(int x = 0; x <Days.Length; x++)
		{
			Days[x] = null;
		}
	}
		

	void OnGUI () 

		{

		if (GUI.Button (new Rect (50, 50, BotonAtras.width, BotonAtras.height), BotonAtras)) {
			
			Application.LoadLevel ("PantallaPrincipal");
		}

		if (!ControlDescarga) {
			descargaCalendario ();
		}
		else {
			cadenaCalendario = DatosDescarga.Split ('*');
			
			nombreFotoP = new string[cadenaCalendario.Length];
			texPrenda = new Texture2D[cadenaCalendario.Length];
		}


		if (GUI.Button (new Rect ((Screen.width/4)+330, (Screen.height/4)-70, BotonAdelante.width, BotonAdelante.height),BotonAdelante)) {
		

			numMes++;
			if(numMes==12){
				numMes=0;
				numAnyo++;
			}
			iMonth=new System.DateTime(numAnyo,numMes+1,System.DateTime.Now.Day);
			CrearCalendario();
		}
		if (GUI.Button (new Rect ((Screen.width/4)+30, (Screen.height/4)-70, BotonAtrasMes.width, BotonAtrasMes.height),BotonAtrasMes)) {
			numMes--;
			if(numMes==-1){
				numMes=11;
				numAnyo--;
			}
			iMonth=new System.DateTime(numAnyo,numMes+1,System.DateTime.Now.Day);
			CrearCalendario();
			
		}
			GUI.Label(new Rect((Screen.width/4)+180,(Screen.height/4)-60,200,20),Months[numMes]);

		//para los dias de la semana
		for(int i=0;i<7;i++){

			float ancho=(Screen.width/6)-100+(i*150);
			float alto= (Screen.height/4);

			if(GetDays(System.DateTime.Now.DayOfWeek)-1==i)
				{
				GUI.Label(new Rect(ancho,alto,200,20),DiasSemana[i],EstiloLabel);
				}

			else{
				GUI.Label(new Rect(ancho,alto,200,20),DiasSemana[i]);
			}

		}
		//colocacion de los dias del mes en el calendario.
		int semanas = 0;
		int dias = 0;
		int contador = 0;
		for (int i=0; i<Days.Length; i++) {
						if (i % 7 == 0) {
								if (i != 0) {
										semanas += 100;
										contador = 0;
										dias = 155 * contador;
								}
						} else {
								contador++;
								dias = 155 * contador;
						}
						float ancho = (Screen.width / 6) - 100 + dias;
						float alto = (Screen.height / 4) + 30 + semanas;
						string idconjunto="";
						if (System.DateTime.Now.Day.ToString () == Days [i]) {
								GUI.Label (new Rect (ancho, alto, 200, 20), Days [i], EstiloLabel);
								int contadorPrendas=0;
								for(int j=0;j<(cadenaCalendario.Length)-1;j++){
									datosCalendario=cadenaCalendario[j].Split('/');
									nombreFotoP [j] = "./Assets/RopaArmario/" + Variables.idUsuario + "/" + datosCalendario[1] + "/Prendas/" + datosCalendario[0];
									cadenafecha=datosCalendario[2].Split('-');
									int Mes = int.Parse (cadenafecha [1]);
									int anyo = int.Parse (cadenafecha [0]);
									if(cadenafecha [2]==Days[i] && Mes==numMes+1 && anyo==numAnyo){
										texPrenda [j] = new Texture2D (2, 2, TextureFormat.DXT1, false);
										imageData = File.ReadAllBytes (nombreFotoP [j]);
										texPrenda [j].LoadImage (imageData);
										if(datosCalendario[3]==idconjunto){
											contadorPrendas++;
											switch (contadorPrendas)
											{
												case 1:
												GUI.Label (new Rect (ancho+5, alto+15, 50, 50), texPrenda [j]);
												break;
												case 2:
												GUI.Label (new Rect (ancho-50, alto+55, 50, 50), texPrenda [j]);
												break;
												case 3:
												GUI.Label (new Rect (ancho+5, alto+55, 50, 50), texPrenda [j]);
												break;
											}
										}
										else{
											contadorPrendas=0;
											idconjunto=datosCalendario[3];
											GUI.Label (new Rect (ancho-(30*contadorPrendas), alto+15, 50, 50), texPrenda [j]);
										}
									}
								}
						} else {
								GUI.Label (new Rect (ancho, alto, 200, 20), Days [i]);
								int contadorPrendas=0;
								for(int j=0;j<(cadenaCalendario.Length)-1;j++){
									datosCalendario=cadenaCalendario[j].Split('/');
									nombreFotoP [j] = "./Assets/RopaArmario/" + Variables.idUsuario + "/" + datosCalendario[1] + "/Prendas/" + datosCalendario[0];
									cadenafecha=datosCalendario[2].Split('-');
									int Mes = int.Parse (cadenafecha [1]);
									int anyo = int.Parse (cadenafecha [0]);
									if(cadenafecha [2]==Days[i] && Mes==numMes+1 && anyo==numAnyo){
										texPrenda [j] = new Texture2D (2, 2, TextureFormat.DXT1, false);
										imageData = File.ReadAllBytes (nombreFotoP [j]);
										texPrenda [j].LoadImage (imageData);
										if(datosCalendario[3]==idconjunto){
											contadorPrendas++;
											switch (contadorPrendas)
											{
											case 1:
												GUI.Label (new Rect (ancho+5, alto+15, 50, 50), texPrenda [j]);
												break;
											case 2:
												GUI.Label (new Rect (ancho-50, alto+55, 50, 50), texPrenda [j]);
												break;
											case 3:
												GUI.Label (new Rect (ancho+5, alto+55, 50, 50), texPrenda [j]);
												break;
											}
										}
										else{
											contadorPrendas=0;
											idconjunto=datosCalendario[3];
											GUI.Label (new Rect (ancho-50+(55*contadorPrendas), alto+15, 50, 50), texPrenda [j]);
										}
									}
							}
					}
		
		}
	}

	void descargaCalendario(){
		
		StartCoroutine (descarga (Variables.idUsuario));
		
	}
	
	IEnumerator descarga (int Usuario){
		
		WWWForm postForm = new WWWForm ();
		
		postForm.AddField ("idUsuario", Usuario);
		
		WWW datos = new WWW ("myfres.com/SmartWardrobe/DescargaCalendario.php", postForm);
		yield return datos;
		DatosDescarga = datos.text;
		if (datos.isDone) {//control de la descarga	
			ControlDescarga = true;
		} else {
			ControlDescarga = false;
		}
	}
}
