using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public GameObject[] Cameras;
    public Camera CurrentCamera;
    public int CameraInitIndex = 1;
    //public Text buttontext;
    //public GameObject FireButton;

    private int Index;     // camera now



    // Use this for initialization
    void Start ()
    {
        Index = CameraInitIndex;
        CurrentCamera = Cameras[Index].GetComponent<Camera>();
        if (CheckCameras()) 
        {
            Debug.LogError("Camera cannot be null, check GameController again."); 
        }
        //FireButton.GetComponent();
        //Debug.Log(buttontext.text);
        //buttontext

	}
	
	// Update is called once per frame
	void Update ()
    {
        //当点击esc后
        if (Input.GetKeyDown("z"))
        {
            SwitchCamera();
        }
	}

    /*************************** Camera(GameObject) **************************/

    bool CheckCameras()
    {
        for (int i = 0; i < Cameras.Length; i++) 
        { 
            if (Cameras[i] == null) return true;

            // init gb
            SetCamera(i, false);
        }
        SetCamera(CameraInitIndex, true);
        return false;
    }

    void SwitchCamera()
    {
        SetCamera(Index, false);
        Index = Index == Cameras.Length - 1 ? 0 : Index + 1;
        SetCamera(Index, true);
    }

    void SetCamera(int i, bool b)
    {
        Cameras[i].GetComponent<Camera>().enabled = b;
        Cameras[i].GetComponent<AudioListener>().enabled = b;
        SetScript(i , b);
        if (b) { CurrentCamera = Cameras[i].GetComponent<Camera>(); }
    }

    /******************************** Scripts ********************************/

    public GameObject Player;

    void SetScript(int i, bool b)
    {
        if(i == 0)
        {
            //Cameras[0].GetComponent<FirstViewScript>().enabled = b;
            //Player.GetComponent<FreeMover>().enabled = b;
            Cameras[0].GetComponent<FreeView>().enabled = b;
        }
        else
        {
            Cameras[i].GetComponent<RectView>().enabled = b;
        }
    }




}
