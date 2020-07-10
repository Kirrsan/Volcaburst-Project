using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

[CreateAssetMenu(fileName = "Save", menuName = "Save/DensitySave", order = 1)]
[System.Serializable]
public class SaveDensity : ScriptableObject
{
    public List<NativeArray<float>> densities = new List<NativeArray<float>>();
}
