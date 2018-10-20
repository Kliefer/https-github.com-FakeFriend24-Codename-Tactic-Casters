using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHexGrid : MonoBehaviour
{
    private static MyHexGrid _instance;

    private List<List<MyHexCell>>[] coords = new List<List<MyHexCell>>[4];


    public static MyHexGrid Instance {
        get
        {


            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MyHexGrid>();
                if (_instance == null)
                {
                   
                    _instance = new GameObject("My HexGrid").AddComponent<MyHexGrid>();
                    _instance.transform.position = Vector3.zero;
                   

                }
            }

            return _instance;
        }
    }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        InitiateGrid();
        
        if(Debugger.IsInEditorPlayMode() && Debugger.debug)
        {
            MyHexCell go;
            for(int i = -6; i <= 6; i++)
            {
                for(int j = -6; j <= 6; j++)
                {
                    if( (-i-j)*(-i-j) <= 6*6)
                    {
                        go = new GameObject("Debug: " + i + " | " + j).AddComponent<MyHexCell>();
                    
                        SetElementAt(go, i, j, Mathf.RoundToInt(Random.Range(-3,3)));

                    }
                    
                }
            }
        }
        
    }

    /// <summary>
    /// Initiates Grid
    /// </summary>
    void InitiateGrid()
    {
        for(int i= 0; i < coords.Length; i++ )
        {
            coords[i] = new List<List<MyHexCell>>();
        }
    }
    
    /// <summary>
    /// Get cell at hexagon coordinates 
    /// </summary>
    /// <param name="a">
    /// 1st coordinate (plane)
    /// </param>
    /// <param name="b">
    /// 2nd coordinate (plane)
    /// </param>
    /// <returns>
    /// cell at coordinates
    /// </returns>
    public MyHexCell GetElementAt(int a, int b)
    {
        MyHexCell t = null;
        if( a >= 0 && b >= 0 )
        {
            t = GetElementAtQuarter(a, b, 0);
        }
        else if( a < 0 && b >= 0 )
        {
            t = GetElementAtQuarter(a*(-1) -1, b, 1);

        }
        else if( a >= 0 && b < 0 )
        {
            t = GetElementAtQuarter(a, b * (-1) - 1, 2);

        }
        else
        {
            t = GetElementAtQuarter(a * (-1) - 1, b * (-1) - 1, 3);

        }


        return t;
    }

    /// <summary>
    /// Get cell at hexagon coordinates 
    /// </summary>
    /// <param name="hC">
    /// Hexagon Coordinates (only plane relevant)
    /// </param>
    /// <returns>
    /// cell at coordinates
    /// </returns>
    public MyHexCell GetElementAt(HexCoords hC)
    {
        return GetElementAt(hC.A, hC.B);
    }


    /// <summary>
    /// Set cell at hexagon coordinates on height
    /// </summary>
    /// <param name="t">
    /// cell to set
    /// </param>
    /// <param name="a">
    /// 1st coordinate (plane)
    /// </param>
    /// <param name="b">
    /// 2nd coordinate (plane)
    /// </param>
    /// <param name="h">
    /// 3rd coordinate (height)
    /// </param>
    /// <returns>
    /// returns if cell got saved
    /// </returns>
    public bool SetElementAt(MyHexCell t, int a, int b, int h)
    {
        bool r = false;
        if( a >= 0 && b >= 0)
        {
            r = SetElementAtQuarter(t, a, b, 0);
        }
        else if( a < 0 && b >= 0)
        {
            r = SetElementAtQuarter(t, -a -1, b, 1);

        }
        else if(a >= 0 && b < 0)
        {
            r = SetElementAtQuarter(t, a, -b - 1, 2);

        }
        else
        {
            r = SetElementAtQuarter(t, -a - 1, -b - 1, 3);

        }

        t.pos.A = a;
        t.pos.B = b;
        t.pos.H = h;
        t.SnapToGridWithOffset();

        return r;
    }

    /// <summary>
    /// Set cell at hexagon coordinates on height
    /// </summary>
    /// <param name="t">
    /// cell to set
    /// </param>
    /// <param name="hC">
    /// Hexagon Coordinates the Tile has to be set to
    /// </param>
    /// <returns>
    /// returns if cell got saved
    /// </returns>
    public bool SetElementAt(MyHexCell t, HexCoords hC)
    {
        return SetElementAt(t, hC.A, hC.B, hC.H);
    }

    /// <summary>
    /// Set cell at hexagon coordinates 
    /// </summary>
    /// <param name="t">
    /// cell to set
    /// </param>
    /// <param name="a">
    /// 1st coordinate (plane)
    /// </param>
    /// <param name="b">
    /// 2nd coordinate (plane)
    /// </param>
    /// <returns>
    /// returns if cell got saved
    /// </returns>
    public bool SetElementAt(MyHexCell t, int a, int b)
    {
        return SetElementAt(t, a, b, 0);
    }

    /// <summary>
    /// Get cell at hexagon coordinates in system quarter
    /// </summary>
    /// <param name="a">
    /// 1st coordinate (plane)
    /// </param>
    /// <param name="b">
    /// 2nd coordinate (plane)
    /// </param>
    /// <returns>
    /// returns cell at coordinates
    /// </returns>
    private MyHexCell GetElementAtQuarter(int a, int b, int quarter)
    {
        MyHexCell t = null;
        if (coords[quarter].Count > a)
        {
            if (coords[quarter][a].Count > b)
            {
                t = coords[quarter][a][b];
            }
        }
        return t;
    }


    /// <summary>
    /// Set cell at hexagon coordinates in system quarter
    /// </summary>
    /// <param name="t">
    /// cell to set
    /// </param>
    /// <param name="a">
    /// 1st coordinate (plane)
    /// </param>
    /// <param name="b">
    /// 2nd coordinate (plane)
    /// </param>
    /// <param name="quarter">
    /// index of the system quarter
    /// </param>
    /// <returns>
    /// returns if cell got saved
    /// </returns>
    private bool SetElementAtQuarter(MyHexCell t, int a, int b, int quarter)
    {
        if (coords[quarter].Count <= a)
        {
            for(int i = coords[quarter].Count; i <= a; i++ )
            {
                coords[quarter].Add(new List<MyHexCell>());
            }
        }
        if (coords[quarter][a].Count <= b)
        {
            for (int i = coords[quarter][a].Count; i <= b; i++)
            {
                coords[quarter][a].Add(null);
            }
        }
        if(coords[quarter][a][b] != null)
        {
            Debugger.LogWarning("HexCell is already Set!");
            if(Debugger.IsInEditorMode() && !Debugger.IsInEditorPlayMode())
            {
                
            }
            return false;
        }
        else
        {
            coords[quarter][a][b] = t;
            return true;
        }
    }

    /// <summary>
    /// Get cell at hexagon coordinates
    /// </summary>
    /// <param name="hCoords">
    /// hexagon coordinate vector
    /// </param>
    /// <returns>
    /// Cell at hexagon coordinates
    /// </returns>
    public MyHexCell GetElementAt(Vector3Int hCoords)
    {
        return GetElementAt(hCoords.x, hCoords.z);
    }
    
}
