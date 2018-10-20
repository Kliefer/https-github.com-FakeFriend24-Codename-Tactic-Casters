using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain  {
    public List<TerrainType> types = new List<TerrainType>();
    public Vector3 pos;

    public Terrain(TerrainType[] t, Vector3 p)
    {
        types.AddRange(t);
        pos = p;
    }

    public Terrain(TerrainType t, Vector3 p)
    {
        types.Add(t);
        pos = p;
    }

    public Terrain()
    {
        types = new List<TerrainType>();
        pos = Vector3.zero;
    }

    public int GetMovementCost()
    {
        int costs = -1;
        bool dom = false;
        for (int i = 0; i < types.Count; i++)
        {
            if (types[i].dominantMovementType)
            {
                dom = true;
            }

            if (!dom && costs < types[i].movementCost)
            {
                costs = types[i].movementCost;
            }
            else if (dom && costs > types[i].movementCost)
            {
                costs = types[i].movementCost;
            }
        }

        return costs;
    }

    public float GetMaxRangedCover()
    {
        float cover = 0;

        for (int i = 0; i < types.Count; i++)
        {

            if (cover < types[i].rangedCover)
            {
                cover = types[i].rangedCover;
            }
        }

        return cover;
    }

    public float GetMinRangedCover()
    {
        float cover = 0;

        for (int i = 0; i < types.Count; i++)
        {

            if (cover > types[i].rangedCover)
            {
                cover = types[i].rangedCover;
            }
        }

        return cover;
    }
}
