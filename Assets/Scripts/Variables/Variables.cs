
using UnityEngine;
using System.Collections;


public class Variables {

	public static int idUsuario;

	public static int TipoDefoto=1;//tipo1 es la textura, tipo 2 es la prenda.

	//Contol de interfaz de nuevas prendas
	public static bool activoClasificacion=false;
	public static bool activoGuardar=false;
	public static bool FotoTextura=false;
	public static bool FotoPrenda=false;
	public static bool Temporada=false;
	public static bool Colores=false;
	public static bool Look=false;


	//Contol de interfaz de consejos
	//temporada
	public static bool activoinvierno=true;
	public static bool activoverano=true;
	public static bool activoprimavera=true;
	public static bool activootonio=true;
	//look
	public static bool activodiario=true;
	public static bool activoelegante=true;
	public static bool activoclub=true;
	public static bool activodeporte=true;
	public static bool activocasual=true;
	public static bool activoformal=true;
	public static bool activotrabajo=true;
	public static bool activofavorita=true;

	//colores

	public static bool activonegro=true;
	public static bool activoblanco=true;
	public static bool activogris=true;
	public static bool activoverdeo=true;
	public static bool activoverdec=true;
	public static bool activoazulo=true;
	public static bool activoazulc=true;
	public static bool activorojo=true;
	public static bool activorosa=true;
	public static bool activomorado=true;
	public static bool activoamarillo=true;
	public static bool activonaranja=true;

	//ropa
	public static bool activocamisa=true;
	public static bool activocamiseta=true;
	public static bool activochaqueta=true;
	public static bool activosudadera=true;
	public static bool activojersey=true;
	public static bool activopantalon=true;
	public static bool activopantalonc=true;
	public static bool activovestido=true;


	//control interfaz Habitacion

	public static bool VerTodo=false;

	public Variables()
	{}

}