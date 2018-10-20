using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHexMetric {

 

    public const float outerRadius = 1f;

    public const float innerRadius = outerRadius * 0.866025404f;

    public const float heightScaling = 0.2f;

    public static Vector3[] corners = {
        new Vector3(0f, 0f, outerRadius),
        new Vector3(innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(0f, 0f, -outerRadius),
        new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(-innerRadius, 0f, 0.5f * outerRadius)
    };

    public static Vector3[] e = {
        new Vector3(0f, 0f, outerRadius),
        new Vector3(innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(innerRadius, 0f, -0.5f * outerRadius),
    };

    public static HexCoords Kartesian2Hexagonal(Vector3 pos)
    {
        HexCoords index = new HexCoords();

        index.B = Mathf.RoundToInt(pos.z / (1.5f * outerRadius));
        index.A = Mathf.RoundToInt((pos.x - index.B * innerRadius) / (2 * innerRadius));
        index.H = Mathf.RoundToInt(pos.y / heightScaling);
        return index;
    }

    public static HexCoords Kartesian2Hexagonal(Vector3 pos, out float distError)
    {
        HexCoords index = Kartesian2Hexagonal(pos);
        distError = Vector3.Distance(pos, Hexagonal2Kartesian(index));
        return index;
    }


    public static Vector3 Hexagonal2Kartesian(HexCoords kPos)
    {
        return new Vector3(kPos.A * 2 * innerRadius + kPos.B * innerRadius, kPos.H * heightScaling, kPos.B * 1.5f * outerRadius);
    }

}
