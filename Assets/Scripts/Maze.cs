using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    
    public MazeCell cellPrefab;

    private MazeCell[,] celulas;

    public float generationStepDelay;

    public IntVector2 tam;

    public LabPassage passagePrefab;
    public LabWall[] wallPrefabs;

    public LabPorta portaPrefab;

    [Range(0f, 1f)]
    public float doorProb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public MazeCell PegaCell(IntVector2 coords){
        //print(" x " + coords.x + " z " +  coords.z);
        //print("tam x: " + tam.x + "  z" + tam.z);
        return celulas[coords.x, coords.z];
    }

    public IEnumerator Gera(){
        WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
        celulas = new MazeCell[tam.x, tam.z];
        List<MazeCell> ativas = new List<MazeCell>();
        FazPrimGenStep(ativas);
        //IntVector2 coords = RandomCoords;
        while(ativas.Count > 0){
            yield return delay;
            FazProxGenStep(ativas);
        }
    }

    private void FazPrimGenStep(List<MazeCell> ativas){
        ativas.Add(CriaCell(startCoords));
    }

    private void FazProxGenStep(List<MazeCell> ativas){
        //float ind = ativas.Count * 0.75f;
        int index = Random.Range(0, ativas.Count/4);
        MazeCell atualCel = ativas[index];
        if(atualCel.IsInitialized){
            ativas.RemoveAt(index);
            return;
        }
        
        DirLab dir = atualCel.RandomUninitializedDirection;
        IntVector2 coords = atualCel.coords + dir.ParaIntVector2();
        if(ContainsCoords(coords)){
            MazeCell neighbor = PegaCell(coords);
            if(neighbor == null){
                neighbor = CriaCell(coords);
                CriaPassage(atualCel, neighbor, dir);
                ativas.Add(neighbor);
            }
            else{
                CriaWall(atualCel, null, dir);
                //ativas.RemoveAt(index);
            }
            
        }
        else{
            CriaWall(atualCel, null, dir);
            //ativas.RemoveAt(index);
        }
    }

    private MazeCell CriaCell(IntVector2 coords){
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        celulas[coords.x, coords.z] = newCell;
        newCell.coords = coords;
        newCell.name = "Maze Cell " + coords.x + ", " + coords.z;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(coords.x - tam.x * 0.5f + 0.5f, 0f, coords.z - tam.z * 0.5f + 0.5f);
        return newCell;
    }

    private void CriaPassage(MazeCell celula, MazeCell outraCel, DirLab dir){
        LabPassage prefab = Random.value < doorProb ? portaPrefab : passagePrefab;
        LabPassage passagem = Instantiate(prefab) as LabPassage;
        passagem.Initialize(celula, outraCel, dir);
        passagem.transform.localPosition = new Vector3(1, 0.5f, 0);
        passagem = Instantiate(prefab) as LabPassage;
        passagem.Initialize(outraCel, celula, dir.GetOposto());
        passagem.transform.localPosition = new Vector3(0, 0.5f, 0);
    }

    private void CriaWall(MazeCell celula, MazeCell outraCel, DirLab dir){
        LabWall wall = Instantiate(wallPrefabs[Random.Range(0, wallPrefabs.Length)]) as LabWall;
        wall.Initialize(celula, outraCel, dir);
        if(outraCel != null){
            wall = Instantiate(wallPrefabs[Random.Range(0, wallPrefabs.Length)]) as LabWall;
            wall.Initialize(outraCel, celula, dir.GetOposto());
        }
    }

    public IntVector2 startCoords{
        get{
            return new IntVector2(0, 0);
        }
    }

    public IntVector2 RandomCoords{
        get{
            return new IntVector2(Random.Range(0, tam.x), Random.Range(0, tam.z));
        }
    }

    public bool ContainsCoords(IntVector2 coord){
        return coord.x >= 0 && coord.x < tam.x && coord.z >= 0 && coord.z < tam.z;
    }
}
