using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirLab{
    Norte, Leste, Sul, Oeste
}

public static class DirLabs{
    public const int Count = 4;

    public static DirLab RV{
        get{
            return (DirLab)Random.Range(0, Count);
        }
    }

    private static IntVector2[] vecs = {
        new IntVector2(0, 1),
        new IntVector2(1, 0),
        new IntVector2(0, -1),
        new IntVector2(-1, 0)
    };

    public static IntVector2 ParaIntVector2(this DirLab dir){
        return vecs[(int)dir];
    }

    private static DirLab[] opostos = {
        DirLab.Sul, DirLab.Oeste, DirLab.Norte, DirLab.Leste
    };

    public static DirLab GetOposto(this DirLab dir){
        return opostos[(int) dir];
    }

    public static Quaternion[] rotacoes = {
        Quaternion.identity,
        Quaternion.Euler(0f, 90f, 0f),
        Quaternion.Euler(0f, 180f, 0f),
        Quaternion.Euler(0f, 270f, 0f)
    };

    public static Quaternion Rotacao(this DirLab dir){
        return rotacoes[(int) dir];
    }
}