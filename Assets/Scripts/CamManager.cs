using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CamManager : MonoBehaviour
{
    public string deviceName;
    WebCamTexture wct;
    public Renderer camMaterial;
    public Material playerCamMat;

    public Texture2D heightmap;
    public Vector3 size;

    private string _SavePath; //Change the path here!

    // Use this for initialization
    void Start()
    {
        size = new Vector3(100, 10, 100);
        _SavePath = Application.dataPath + "/Materials/"; //Change the path here!
    }


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

        //System.IO.File.WriteAllBytes(_SavePath + "photo" + ".png", snap.EncodeToPNG());
        //snap.LoadImage(System.IO.File.ReadAllBytes(_SavePath + "photo" + ".png"));
        //camMaterial.material.SetTexture("_snap", snap);
        camMaterial.material.mainTexture = snap;
        

        playerCamMat.CopyPropertiesFromMaterial(camMaterial.material);
        snap.Apply();
        //EditorUtility.SetDirty(camMaterial);
        //AssetDatabase.SaveAssets();
        //AssetDatabase.Refresh();

    }
}
