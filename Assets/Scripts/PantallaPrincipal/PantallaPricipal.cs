using UnityEngine;
using System.Collections;

public class PantallaPricipal : MonoBehaviour {

	public Texture2D BotonLibro;
	public Texture2D BotonConsejo;
	public Texture2D BotonArmario;
	public Texture2D BotonCalendario;
	public Texture2D BotonConfiguracion;


	public void OnGUI() {

		if (GUI.Button (new Rect ((Screen.width / 4)-100, (Screen.height / 4)-100, BotonLibro.width, BotonLibro.height), BotonLibro)) {
				Application.LoadLevel("CargaLook");
			}
		GUI.Label (new Rect ((Screen.width / 4)-40, (Screen.height / 4)-120, 50, 50),"Look" );
		if (GUI.Button (new Rect ((Screen.width / 4)+250, (Screen.height / 4)-100, BotonConsejo.width, BotonConsejo.height), BotonConsejo)) {
				Application.LoadLevel("Consejos");
			}
		GUI.Label (new Rect ((Screen.width / 4)+300, (Screen.height / 4)-120, 60, 50),"Consejos");
		if (GUI.Button (new Rect ((Screen.width / 4) + 80, (Screen.height / 3), BotonArmario.width, BotonArmario.height), BotonArmario)) {
				Application.LoadLevel("Habitacion");
			}
		GUI.Label (new Rect((Screen.width / 4)+130,(Screen.height / 3)-20, 60, 50),"Armario" );
		if (GUI.Button (new Rect ((Screen.width / 4)-100, (Screen.height / 2)+40, BotonCalendario.width, BotonCalendario.height), BotonCalendario)) {
			Application.LoadLevel("Calendario");
			}
		GUI.Label (new Rect ((Screen.width / 4)-55, (Screen.height / 2) +20, 70, 50),"Calendario");
		if (GUI.Button (new Rect ((Screen.width / 4)+250, (Screen.height / 2) + 40, BotonConfiguracion.width, BotonConfiguracion.height), BotonConfiguracion)) {
				Application.LoadLevel("configuracion");
			}
		GUI.Label (new Rect ((Screen.width / 4)+290, (Screen.height / 2) +20, 80, 50),"Configuración");
		}
}
