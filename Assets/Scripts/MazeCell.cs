using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    public IntVector2 coords;

    private int initializedLimCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private MazeCellLim[] lims = new MazeCellLim[DirLabs.Count];

    public MazeCellLim PegaEdge(DirLab dir){
        return lims[(int)dir];
    }

    public bool IsInitialized{
        get{
            return initializedLimCount == DirLabs.Count;
        }
    }

    public void SetLim(DirLab dir, MazeCellLim lim){
        lims[(int) dir] = lim;
        initializedLimCount += 1;
    }

    public DirLab RandomUninitializedDirection {
		get {
			int pulos = Random.Range(0, DirLabs.Count - initializedLimCount);
			for (int i = 0; i < DirLabs.Count; i++) {
				if (lims[i] == null) {
					if (pulos == 0) {
						return (DirLab)i;
					}
				    pulos -= 1;
				}
			}
            throw new System.InvalidOperationException("MazeCell uninitialized dirs left");
		}
	}

}
