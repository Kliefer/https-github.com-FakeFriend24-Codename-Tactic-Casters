using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeDictionary : MonoBehaviour {
    private static TypeDictionary _instance;

    [SerializeField]
    List<TerrainType> terrainTypes;

    public static TypeDictionary Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public TerrainType GetTerrainType(string name)
    {
        TerrainType t = null;
        for(int i = 0; i < terrainTypes.Count; i++)
        { 
            if( terrainTypes[i].name == name )
            {
                t = terrainTypes[i];
            }
        }
        return t;
    }
}
