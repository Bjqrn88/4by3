using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gvr;

public class TileController : MonoBehaviour {

	public Text textField;

	public Renderer t0;
	public Renderer t1;
	public Renderer t2;
	public Renderer t3;
	public Renderer t4;
	public Renderer t5;
	public Renderer t6;
	public Renderer t7;
	public Renderer t8;
	public Renderer t9;
	public Renderer t10;
	public Renderer t11;
	public int zoomLvl = 2;
	private bool zIn = false;

	private int count = 0;
	private bool display = false;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		t0.material.mainTexture = Resources.Load("Images/"+zoomLvl+"/zoom0xx0") as Texture2D;
		t1.material.mainTexture = Resources.Load("Images/"+zoomLvl+"/zoom0xx1") as Texture2D;
		t2.material.mainTexture = Resources.Load("Images/"+zoomLvl+"/zoom0xx2") as Texture2D;
		t3.material.mainTexture = Resources.Load("Images/"+zoomLvl+"/zoom0xx3") as Texture2D;
		t4.material.mainTexture = Resources.Load("Images/"+zoomLvl+"/zoom1xx0") as Texture2D;
		t5.material.mainTexture = Resources.Load("Images/"+zoomLvl+"/zoom1xx1") as Texture2D;
		t6.material.mainTexture = Resources.Load("Images/"+zoomLvl+"/zoom1xx2") as Texture2D;
		t7.material.mainTexture = Resources.Load("Images/"+zoomLvl+"/zoom1xx3") as Texture2D;
		t8.material.mainTexture = Resources.Load("Images/"+zoomLvl+"/zoom2xx0") as Texture2D;
		t9.material.mainTexture = Resources.Load("Images/"+zoomLvl+"/zoom2xx1") as Texture2D;
		t10.material.mainTexture = Resources.Load("Images/"+zoomLvl+"/zoom2xx2") as Texture2D;
		t11.material.mainTexture = Resources.Load("Images/"+zoomLvl+"/zoom2xx3") as Texture2D;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (zIn)
		{
			Debug.Log("MIKE SHHHHHH");
			CoZoomIn();
			zIn = false;
		}
		if (display) {
			count += 1;
			textField.text = "blablabla";
		}
		if (count > 100) {
			display = false;
			count = 0;
			textField.text = "";
		}
		
	}

	public void ZoomIn() {
		zIn = true;
	}

	IEnumerator CoZoomIn() {
		display = true;
		yield return null;
	}

}
