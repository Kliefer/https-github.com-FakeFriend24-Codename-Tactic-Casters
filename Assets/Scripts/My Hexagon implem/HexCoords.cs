using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hexagonal Integer Koordinates 
/// </summary>
[System.Serializable]
public struct HexCoords
{
    [SerializeField]
    int a;
    [SerializeField]
    int b;
    [SerializeField]
    int h;

    public static HexCoords[] directions = { HexCoords.DirectionA, HexCoords.DirectionB, -HexCoords.DirectionA + HexCoords.DirectionB, -HexCoords.DirectionA, -HexCoords.DirectionB, HexCoords.DirectionA - HexCoords.DirectionB };


    public int A
    {
        get
        {
            return a;
        }

        set
        {
            a = value;
        }
    }

    public int B
    {
        get
        {
            return b;
        }

        set
        {
            b = value;
        }
    }

    public int C
    {
        get
        {
            return - a - b;
        }
    }

    public int H
    {
        get
        {
            return h;
        }

        set
        {
            h = value;
        }
    }

    /// <summary>
    /// Set coordinates
    /// </summary>
    /// <param name="a">
    /// 1st coordinate (plane)
    /// </param>
    /// <param name="b">
    /// 2nd coordinate (plane)
    /// </param>
    /// <param name="h">
    /// 3rd coordinate (height)
    /// </param>
    public void Set(int a, int b, int h)
    {
        this.a = a;
        this.b = b;
        this.h = h;
    }

    /// <summary>
    /// Set coordinates
    /// </summary>
    /// <param name="v">
    /// Integer vector as hex coords
    /// </param>
    public void Set(Vector3Int v)
    {
        this.a = v.x;
        this.b = v.z;
        this.h = v.y;
    }

    /// <summary>
    /// Checks for equality
    /// </summary>
    /// <param name="obj">
    /// 1st coordinate (plane)
    /// </param>
    /// <returns>
    /// boolean about equality
    /// </returns>
    public override bool Equals(object obj)
    {
        if (!(obj is HexCoords))
        {
            return false;
        }

        var coords = (HexCoords)obj;
        return a == coords.a &&
               b == coords.b &&
               h == coords.h;
    }

    /// <summary>
    /// Get Hashcode 
    /// </summary>
    /// <returns>
    /// returns Hashcode as Integer
    /// </returns>
    public override int GetHashCode()
    {
        var hashCode = 1591471088;
        hashCode = hashCode * -1521134295 + base.GetHashCode();
        hashCode = hashCode * -1521134295 + a.GetHashCode();
        hashCode = hashCode * -1521134295 + b.GetHashCode();
        hashCode = hashCode * -1521134295 + h.GetHashCode();
        return hashCode;
    }

    /// <summary>
    /// Constructor for Coordinates
    /// </summary>
    /// <param name="v">
    /// Integer vector with hexagon coordinates
    /// </param>
    public HexCoords(Vector3Int v)
    {
        this.a = v.x;
        this.b = v.z;
        this.h = v.y;
    }

    /// <summary>
    /// Constructor for Coordinates
    /// </summary>
    /// <param name="a">
    /// 1st coordinate (plane)
    /// </param>
    /// <param name="b">
    /// 2nd coordinate (plane)
    /// </param>
    /// <param name="h">
    /// 3rd coordinate (height)
    /// </param>
    public HexCoords(int a, int b, int h)
    {
        this.a = a;
        this.b = b;
        this.h = h;
    }

    /// <summary>
    /// returns the smallest needed amount of steps
    /// </summary>
    /// <returns>
    /// integer with step size
    /// </returns>
    public int SSteps()
    {
        int t = 0;
        if (a * a < b * b)
        {
            if (a < 0)
                t = -a;
            else
                t = a;

            if (b * b < C * C)
            {
                if (b < 0)
                    t += -b;
                else
                    t += b;
            }
            else
            {
                if (C < 0)
                    t += - C;
                else
                    t += + C;
            }

        }
        else { 
            if (b < 0)
                t =  - b;
            else
                t =  + b;

            if (a * a < C * C)
            {
                if (b < 0)
                    t += -a;
                else
                    t += a;
            }
            else
            {
                if (C < 0)
                    t += -C;
                else
                    t += +C;
            }
        }

        return t;
    }

    // overload operator *
    public static HexCoords operator +(HexCoords a, HexCoords b)
    {
        return new HexCoords(a.a + b.a, a.b + b.b, a.h + b.h);
    }

    public static HexCoords operator -(HexCoords a, HexCoords b)
    {
        return new HexCoords(a.a - b.a, a.b - b.b, a.h - b.h);
    }

    public static HexCoords operator -(HexCoords a)
    {
        return new HexCoords(-a.a, -a.b, -a.h);
    }
    /*
    public static int operator *(HexCoords a, HexCoords b)
    {
        return (a.a * b.a + a.b * b.b + a.h * b.h);
    }
    */
    public static HexCoords operator *(HexCoords a, float b)
    {
        return new HexCoords(Mathf.FloorToInt(a.a * b), Mathf.FloorToInt(a.b * b), Mathf.FloorToInt(a.h * b));
    }

    public static HexCoords operator *(HexCoords a, int b)
    {
        return new HexCoords(a.a * b, a.b * b, a.h * b);
    }

    public static HexCoords operator /(HexCoords a, float b)
    {
        return (a * (1 / b));
    }
    
    public static bool operator >(HexCoords a, HexCoords b)
    {
        return (a.SSteps() > b.SSteps());
    }

    public static bool operator <(HexCoords a, HexCoords b)
    {
        return (b > a);
    }

    public static bool operator >=(HexCoords a, HexCoords b)
    {
        return ( !(a < b) );
    }

    public static bool operator <=(HexCoords a, HexCoords b)
    {
        return ( !(a > b) );
    }

    public static bool operator ==(HexCoords a, HexCoords b)
    {
        return (a.a == b.a && a.b == b.b && a.h == b.h);
    }

    public static bool operator !=(HexCoords a, HexCoords b)
    {
        return !(a == b);
    }

    public static HexCoords DirectionA
    {
        get
        {
            return new HexCoords(1, 0, 0);
        }
    }
    public static HexCoords DirectionB
    {
        get

        {
            return new HexCoords(0, 1, 0);
        }
    }
    public static HexCoords DirectionH
    {
        get

        {
            return new HexCoords(0, 0, 1);
        }
    }
    public static HexCoords Zero
    {
        get

        {
            return new HexCoords(0, 0, 0);
        }
    }

    /// <summary>
    /// inline string output of saved coordinates
    /// </summary>
    /// <returns>
    /// string with coords
    /// </returns>
    public override string ToString()
    {
        return "(" + A.ToString() + ", " + B.ToString() + ", " + C.ToString() + ", " + H.ToString() + ")";
    }

    /// <summary>
    /// multiline string output of saved coordinates
    /// </summary>
    /// <returns>
    /// string with coords
    /// </returns>
    public string ToStringOnSeparateLines()
    {
        return A.ToString() + "\n" + B.ToString() + "\n" + C.ToString() + "\n" + H.ToString();
    }

    public static List<HexCoords> GetAShortestDirectPath(HexCoords a, HexCoords b) {
        List<HexCoords> path = new List<HexCoords>();
        HexCoords direction = (b - a);
        int steps = direction.SSteps();
        
        path.Add(a);
        while(direction.SSteps() > 0)
        {
            if (direction.A > 0 && direction.B < 0)
            {
                direction -= new HexCoords(1, -1, 0);
                path.Add(b - direction);
            }
            else if (direction.A < 0 && direction.B > 0)
            {
                direction -= new HexCoords(-1, 1, 0);
                path.Add(b - direction);
            }
            else if (direction.A > 0)
            {
                direction += HexCoords.DirectionA;
                path.Add(b - direction);
            }
            else if (direction.A < 0)
            {
                direction -= HexCoords.DirectionA;
                path.Add(b - direction);
            }
            else if (direction.B > 0)
            {
                direction += HexCoords.DirectionB;
                path.Add(b - direction);
            }
            else if (direction.B < 0)
            {
                direction -= HexCoords.DirectionB;
                path.Add(b - direction);
            }
        }

        return path;
    } 

    public List<HexCoords> GetPath() {
        return GetAShortestDirectPath(HexCoords.Zero, this);
    }



}
