using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RandomColor : MonoBehaviour
{
    [SerializeField]
    public Color[] ColorBank;
    public bool sprite;
    public bool mesh;

    // Start is called before the first frame update
    void Start()
    {

    int Num = Random.Range(0, ColorBank.Length);

        if(mesh){
            MeshRenderer m = GetComponent<MeshRenderer>();
            m.material.color = ColorBank[Num];
        }
        if(sprite){
            SpriteRenderer s = GetComponent<SpriteRenderer>();
            s.color = ColorBank[Num];
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
