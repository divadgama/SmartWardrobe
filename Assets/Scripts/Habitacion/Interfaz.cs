using UnityEngine;
using System.Collections;

public class Interfaz : MonoBehaviour {

	public Texture2D BotonAtras;
	
	public Texture2D BotonVerPulsado;
	public Texture2D BotonVerPulsadoNo;
	public Texture2D MasRopa;


	public void OnGUI() {
		if (GUI.Button (new Rect (100, 100, BotonAtras.width, BotonAtras.height), BotonAtras)) {
			
			Application.LoadLevel ("PantallaPrincipal");
		}
		if (!Variables.VerTodo) {
			if (GUI.Button (new Rect ((Screen.width / 2) - 335, (Screen.height / 2) + 100, MasRopa.width, MasRopa.height), MasRopa)) {
						Application.LoadLevel ("NuevaPrenda");
					}
		}

		//Cambiar la textura al boton para efecto pulsado
		if (Variables.VerTodo) {
			if(GUI.Button (new Rect ((Screen.width /2)-600, (Screen.height/2)+90, BotonVerPulsado.width, BotonVerPulsado.height),BotonVerPulsado)){
				Variables.VerTodo=false;
			}

		}
		else {
			if(GUI.Button (new Rect ((Screen.width / 2)-600, (Screen.height/2)+90, BotonVerPulsadoNo.width, BotonVerPulsadoNo.height),BotonVerPulsadoNo)){
				Variables.VerTodo=true;
			}
		}
	}
}
