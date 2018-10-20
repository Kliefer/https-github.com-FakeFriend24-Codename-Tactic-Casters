using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCreator : MonoBehaviour {
    [SerializeField]
    int sizeX = 6;
    [SerializeField]
    int sizeY = 6;

    [SerializeField]
    bool debug = true;

    [SerializeField]
    Terrain[,] map;

	// Use this for initialization
	void Start() {
        map = new Terrain[sizeX,sizeY];

        InitiateMap( TypeDictionary.Instance.GetTerrainType("Stone_Floor") );
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitiateMap(TerrainType tT)
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                map[i, j] = new Terrain(tT, new Vector3(i - (sizeX) / 2 + 0.5f, 0, j - (sizeY) / 2 + 0.5f));

            }

        }

        DebugCubes();
    }

    void DebugCubes()
    {
        if(debug)
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    GameObject cube =  GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.localScale -= Vector3.up * 0.8f;
                    cube.transform.position = map[i, j].pos - Vector3.up * 0.1f ;


                }


            }

        }
    }
}
