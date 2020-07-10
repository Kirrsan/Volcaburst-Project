using UnityEngine;
using System.Collections.Generic;
using Unity.Collections;

[System.Serializable]
public class Data
{
    public int level = 0;
    public float time = 0;
    public float numberOfVictories = 0;
    public float numberOfLosses = 0;
    //public List<ListOfList> densities = new List<ListOfList>();
    public bool terrainHasChanged = false;
}

//[System.Serializable]
//public class ListOfList
//{
//    public NativeArray<float> firstListWithDensities = new NativeArray<float>();

//    public void Add(System.Object marabou) { }
//}

public static class Save
{
    public static Data data;
    public static event System.Action onLoaded;
    static string keyName = "save";

    public static void Store()
    {
        PlayerPrefs.SetString(keyName, Serializer.Serialize<Data>(data));
    }

    public static void Load(System.Action whenLoad = null)
    {
        if(PlayerPrefs.HasKey(keyName))
        {
            data = Serializer.Deserialize<Data>(PlayerPrefs.GetString(keyName));
        }
        else
        {
            data = new Data();
            Store();
        }
        
        if(whenLoad != null) whenLoad.Invoke();
        if(onLoaded != null) onLoaded.Invoke();

    }


    public static void Delete()
    {
        DeleteKey(keyName);
    }

    public static void DeleteKey(string key)
    {
        if(PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.DeleteKey(key);
        }
    }
}