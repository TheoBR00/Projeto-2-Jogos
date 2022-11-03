using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public struct IntVector2
{
    public int x;
    public int z;

    public IntVector2(int x, int z){
        this.x = x;
        this.z = z;
    }

    public static IntVector2 operator + (IntVector2 p1, IntVector2 p2){
        p1.x += p2.x;
        p1.z += p2.z;
        return p1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
