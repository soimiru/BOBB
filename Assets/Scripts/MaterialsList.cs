using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsList : MonoBehaviour
{

    public List<Material> listMats;
    public Material mat0;
    public Material mat1;
    // Start is called before the first frame update
    void Start()
    {
        listMats = new List<Material>();
        listMats.Add(mat0);
        listMats.Add(mat1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
