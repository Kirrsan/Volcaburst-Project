using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingCubes.Examples;
using Unity.Collections;

public class GameManager : MonoBehaviour
{

    public Data save;
    [SerializeField] private Transform terrain;
    [SerializeField] private SaveDensity densitiesSaved;

    private void Awake()
    {
        Save.Load();
        save = Save.data;
        if (Save.data.terrainHasChanged)
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnApplicationQuit()
    {
        SaveTerrain();
        PrepareSaveAndStore();
    }

    public void PrepareSaveAndStore()
    {
        Save.Store();
    }

    private void DeleteSave()
    {
        Save.Delete();

        Save.Load();
    }

    private void SaveTerrain()
    {
        densitiesSaved.densities.Clear();
        for (int i = 0; i < terrain.childCount; i++)
        {
            HeightmapChunk chunk = terrain.GetChild(i).GetComponent<HeightmapChunk>();
            densitiesSaved.densities.Add(chunk.Densities);

            Save.data.terrainHasChanged = true;
        }
    }
    private void SetTerrain()
    {
        for (int i = 0; i < terrain.childCount; i++)
        {
            HeightmapChunk chunk = terrain.GetChild(i).GetComponent<HeightmapChunk>();
            chunk.Densities = densitiesSaved.densities[i];
        }
    }
}
