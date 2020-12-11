using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class RandomColor : MonoBehaviour
{
    public Color[] ColorBank;
    public bool sprite;
    public bool mesh;
    public string colorString;

    // Start is called before the first frame update
    void Start()
    {

    int Num = Random.Range(0, ColorBank.Length);
            MeshRenderer m = GetComponent<MeshRenderer>();
            m.material.color = ColorBank[Num];
    }
}
