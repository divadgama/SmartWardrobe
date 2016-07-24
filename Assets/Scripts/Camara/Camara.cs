using UnityEngine;
using System.Collections;
using System.IO;

public class Camara : MonoBehaviour {

		public Texture2D BotonAtras;
		public Texture2D TipoCamara;
		public Texture2D BtnFoto;

		public WebCamTexture mCamara = null;
		public GameObject plane;
	    public string NombreDispositivo ;
		public WebCamDevice [] dispositivos;
		
		public Texture2D Photo;
		
		private bool DelanteraOTrasera=false;
		
		// Use this for initialization
		void Start ()
		{


		    dispositivos   = new WebCamDevice[5];
			mCamara = new WebCamTexture ();

			//Debug.Log ("Script has been started");
			plane = GameObject.FindWithTag ("Player");
			
			mCamara = new WebCamTexture ();
			plane.renderer.material.mainTexture = mCamara;
			mCamara.Play ();
			
		}
		
	void OnGUI(){

		if (GUI.Button (new Rect (Screen.width / 2 -350,20 ,BotonAtras.width, BotonAtras.height), BotonAtras)) {
			
			Application.LoadLevel ("NuevaPrenda");
		}

		if (GUI.Button (new Rect (Screen.width / 2 +270,20 ,TipoCamara.width, TipoCamara.height), TipoCamara)) {
			if(DelanteraOTrasera){

				mCamara.Stop();
				mCamara.deviceName = dispositivos[1].name;
				NombreDispositivo      = dispositivos[1].name;
				
				mCamara = new WebCamTexture(NombreDispositivo, Screen.width, Screen.height, 30);
				
				mCamara.Play();			
				renderer.material.mainTexture = mCamara;

				DelanteraOTrasera=false;
			}
			else{
	
				mCamara.Stop();
				
				mCamara.deviceName = dispositivos[0].name;
				NombreDispositivo      = dispositivos[0].name;
				
				mCamara = new WebCamTexture(NombreDispositivo, Screen.width, Screen.height, 30);
				
				mCamara.Play();
				renderer.material.mainTexture = mCamara;

				DelanteraOTrasera=true;
			}
		}

		// Guarda la textura de la camara i la pone en el objeto
		if (GUI.Button (new Rect (Screen.width / 2-20, Screen.height / 2+350, BtnFoto.width, BtnFoto.height), BtnFoto)) {
			
						Photo = new Texture2D (mCamara.width, mCamara.height);
						Photo.SetPixels (mCamara.GetPixels ());
						Photo.Apply ();
						byte[] bytes = Photo.EncodeToJPG ();
			
						if (Variables.TipoDefoto == 1) {
								// Escribir el PNG. Por supuesto que tiene que sustituir your_path algo sensato 
								File.WriteAllBytes ("./assets/Fotos/" + "fotoT.JPG", bytes);
				
						}
						if (Variables.TipoDefoto == 2) {
								File.WriteAllBytes ("./assets/Fotos/" + "fotoP.JPG", bytes);
						}
				
						Application.LoadLevel ("NuevaPrenda");
					}
			
			/*
				Guardar Cuando se utiliza Dispositivos moviles por si no funciona
				Application.CaptureScreenshot("/foto.png");
 
				Para recuperar la captura.
 
				var screenShootText = new WWW("file://"+ Application. persistentDataPath + "/foto.png");
				yield screenShootText;
				renderer.material.mainTexture = screenShootText.texture;


Application.CaptureScreenshot("assets/StreamingAssets/foto.png");
 
y cambiar algo de tu codigo
//var screenShootText = new WWW("file://"+ Application.dataPath + "/foto.png");   // esto
var screenShootText = new WWW("file://"+ Application.streamingAssetsPath + "/foto.png");  // por esto
 
yield screenShootText;
//screenShootText.LoadImageIntoTexture(gameObject.renderer.material.mainTexture);
renderer.material.mainTexture = screenShootText.texture;
 
Gracias por todo
Ahora voy  a ver si consigo guardar la imagen con la cámara y si no puedo , con este código conseguire lo que quiero hacer.
 
Como podría guardar una imagen que tengo guardada en un variable texture.?
 
var textura          : Texture;
en la ruta que utiliza 
Application.CaptureScreenshot("assets/StreamingAssets/foto.png");



			 */

	}
}