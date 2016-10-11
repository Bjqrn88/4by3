﻿using System.Collections;
using UnityEngine;

public class TileController : MonoBehaviour {

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
    public int maxZoomLvl = 1;
    public int row = 0;
    public int column = 0;
    public GameObject Tiles;
    public GameObject Controller;
    public Light LightSource;

    private Texture2D t0Tex;
    private Texture2D t1Tex;
    private Texture2D t2Tex;
    private Texture2D t3Tex;
    private Texture2D t4Tex;
    private Texture2D t5Tex;
    private Texture2D t6Tex;
    private Texture2D t7Tex;
    private Texture2D t8Tex;
    private Texture2D t9Tex;
    private Texture2D t10Tex;
    private Texture2D t11Tex;
    private bool zIn = false;
	private int count = 0;
	private bool display = false;
    private bool maxZoomLvlReached = false;
    private float angle = 0;
    private float rotateAngle = 0;
    private bool scroll = false;
    private bool left = false;
    private bool moved = true;
    private bool up = false;
    private bool getTiles = false;

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
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

		if (zIn)
		{
            Debug.Log("Run in update");
            StartCoroutine(CoGetTiles());
            StartCoroutine(CoCheckBounds());
            StartCoroutine(CoSetTiles());
			zIn = false;
		}

		if (scroll)
        {
            StartCoroutine(CoGetTiles());
            StartCoroutine(CoCheckBounds());
            StartCoroutine(CoSetTiles());
            scroll = false;
            moved = true;
        }
	}

	public void ZoomIn()
    {
        zoomLvl -= 1;
        if (zoomLvl < maxZoomLvl)
        {
            maxZoomLvlReached = true;
            Debug.Log("Max ZoomLvl");
            zoomLvl = maxZoomLvl;
        }
        else
        {
            Debug.Log("zIn = true");
            zIn = true;
        }
	}

    // Loads the tiles from the Resources folder
    IEnumerator CoGetTiles()
    {
        Debug.Log("CoGetTiles()");
        t0Tex = Resources.Load("Images/"+zoomLvl + "/zoom" + (row - 1) + "xx" + (column - 1)) as Texture2D;
        t1Tex = Resources.Load("Images/" + zoomLvl + "/zoom" + (row - 1) + "xx" + column) as Texture2D;
        t2Tex = Resources.Load("Images/" + zoomLvl + "/zoom" + (row - 1) + "xx" + (column + 1)) as Texture2D;
        t3Tex = Resources.Load("Images/" + zoomLvl + "/zoom" + (row - 1) + "xx" + (column + 2)) as Texture2D;

        t4Tex = Resources.Load("Images/" + zoomLvl + "/zoom" + row + "xx" + (column - 1)) as Texture2D;
        t5Tex = Resources.Load("Images/" + zoomLvl + "/zoom" + row + "xx" + column) as Texture2D;
        t6Tex = Resources.Load("Images/" + zoomLvl + "/zoom" + row + "xx" + (column + 1)) as Texture2D;
        t7Tex = Resources.Load("Images/" + zoomLvl + "/zoom" + row + "xx" + (column + 2)) as Texture2D;

        t8Tex = Resources.Load("Images/" + zoomLvl + "/zoom" + (row + 1) + "xx" + (column - 1)) as Texture2D;
        t9Tex = Resources.Load("Images/" + zoomLvl + "/zoom" + (row + 1) + "xx" + column) as Texture2D;
        t10Tex = Resources.Load("Images/" + zoomLvl + "/zoom" + (row + 1) + "xx" + (column + 1)) as Texture2D;
        t11Tex = Resources.Load("Images/" + zoomLvl + "/zoom" + (row + 1) + "xx" + (column + 2)) as Texture2D;
        yield return null;
    }

    IEnumerator CoSetTiles()
    {
        Debug.Log("CoSetTiles()");
        t0.material.mainTexture = t0Tex;
        t1.material.mainTexture = t1Tex;
        t2.material.mainTexture = t2Tex;
        t3.material.mainTexture = t3Tex;

        t4.material.mainTexture = t4Tex;
        t5.material.mainTexture = t5Tex;
        t6.material.mainTexture = t6Tex;
        t7.material.mainTexture = t7Tex;

        t8.material.mainTexture = t8Tex;
        t9.material.mainTexture = t9Tex;
        t10.material.mainTexture = t10Tex;
        t11.material.mainTexture = t11Tex;
        yield return null;
    }

    // Sets the row
    public void SetRow(int rowNum)
    {
        if (!maxZoomLvlReached)
        {
            row = row + (rowNum * 2);
        }
    }

    // Set the column
    public void SetColumn(int colNum)
    {
        if (!maxZoomLvlReached)
        {
            column = column + (colNum * 2);
        }
    }

    IEnumerator CoTurn()
    {
        angle = Camera.main.transform.eulerAngles.y;
        var rads = angle * ((Mathf.PI * 2) / 360);

        Tiles.transform.position = new Vector3(((Mathf.Sin(rads) * 10)), 0, (Mathf.Cos(rads) * 10));
        yield return null;
        Tiles.transform.eulerAngles = new Vector3(0, angle, 0);
        yield return null;

        Controller.transform.position = new Vector3(((Mathf.Sin(rads) * 10)), 0, (Mathf.Cos(rads) * 10));
        yield return null;
        Controller.transform.eulerAngles = new Vector3(0, angle, 0);
        yield return null;

        LightSource.transform.eulerAngles = new Vector3(0, angle, 0);
    }

    public void ScrollLeft()
    {
        left = true;
        column -= 1;
        scroll = true;
    }

    public void ScrollRight()
    {
        ++column;
        scroll = true;
    }

    public void ScrollUp()
    {
        if (moved)
        {
            moved = false;
            up = true;
            --row;
            scroll = true;
            
        }
    }

    public void ScrollDown()
    {
        if (moved)
        {
            moved = false;
            ++row;
            scroll = true;
        }
    }

    IEnumerator CoCheckBounds()
    {
        if (t0Tex == null && left)
        {
            column += 1;
            left = false;
            getTiles = true;
        }
        else if (t0Tex == null && up)
        {
            row += 1;
            up = false;
            getTiles = true;
        }
        else if (t3Tex == null)
        {
            column -= 1;
            getTiles = true;
        }
        else if (t8Tex == null)
        {
            row -= 1;
            getTiles = true;
        }
        yield return null;
    }
}
