using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MazeCellLim : MonoBehaviour
{
    public MazeCell celula, outraCel;

    public DirLab dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(MazeCell celula, MazeCell outraCel, DirLab dir){
        this.celula = celula;
        this.outraCel = outraCel;
        this.dir = dir;
        celula.SetLim(dir, this);
        transform.parent = celula.transform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = dir.Rotacao();
        //transform.localPosition = new Vector3(5, 0, 0);
    }
}
