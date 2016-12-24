using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Camera))]
public class Underwater : MonoBehaviour {

	//This script enables underwater effects. Attach to main camera.

	//Define variable
	public int underwaterLevel = 7;
	public Color backgroundColor = new Color(0, 0.4f, 0.7f, 1);
	public Color underwaterFogColor = new Color(0, 0.4f, 0.7f, 0.6f);
	public float underwaterFogDensity = 0.04f;
	public Material underwaterSkyBox;

	//The scene's default fog settings
	private bool defaultFog;
	private Color defaultFogColor;
	private float defaultFogDensity;
	private Material defaultSkybox;


	void Start () {
		//Set the background color
		GetComponent<Camera>().backgroundColor = backgroundColor;

		defaultFog = RenderSettings.fog;
		defaultFogColor = RenderSettings.fogColor;
		defaultFogDensity = RenderSettings.fogDensity;
		defaultSkybox = RenderSettings.skybox;
	}

	void Update () {
		if (transform.position.y < underwaterLevel)
		{
			RenderSettings.fog = true;
			RenderSettings.fogColor = underwaterFogColor;
			RenderSettings.fogDensity = underwaterFogDensity;
			RenderSettings.skybox = underwaterSkyBox;
		}
		else
		{
			RenderSettings.fog = defaultFog;
			RenderSettings.fogColor = defaultFogColor;
			RenderSettings.fogDensity = defaultFogDensity;
			RenderSettings.skybox = defaultSkybox;
		}
	}
}