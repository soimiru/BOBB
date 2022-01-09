using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CamManager : MonoBehaviour
{
    public string deviceName;
    WebCamTexture wct;
    public Renderer camMaterial;

    // Use this for initialization
    void Start()
    {
        
    }

    // For photo varibles

    public Texture2D heightmap;
    public Vector3 size = new Vector3(100, 10, 100);


    //void OnGUI()
    //{
    //    if (GUI.Button(new Rect(10, 70, 50, 30), "Click"))
    //        TakeSnapshot();
    //
    //}

    // For saving to the _savepath
    private string _SavePath = "C:/Users/Usr/Documents/GitHub/ProyectoPelota/Assets/Materials"; //Change the path here!
    int _CaptureCounter = 0;

    public void OpenCamera() {
        WebCamDevice[] devices = WebCamTexture.devices;
        //for (int i = 0; i < devices.Length; i++)
        //    Debug.Log(devices[i].name);
        deviceName = devices[0].name;
        wct = new WebCamTexture(deviceName, 400, 400, 30);
        GetComponent<Renderer>().material.mainTexture = wct;
        wct.Play();
    }
    
    public void TakeSnapshot()
    {
        Texture2D snap = new Texture2D(wct.width, wct.height);
        snap.SetPixels(wct.GetPixels());
        snap.Apply();

        System.IO.File.WriteAllBytes(_SavePath + "photo" + ".png", snap.EncodeToPNG());
        ++_CaptureCounter;
        camMaterial.material.SetTexture("_snap", snap);
        //EditorUtility.SetDirty(camMaterial);
        //AssetDatabase.SaveAssets();
        //AssetDatabase.Refresh();

    }
}
