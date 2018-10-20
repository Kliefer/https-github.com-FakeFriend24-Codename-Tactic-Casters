using UnityEngine;

[System.Serializable]
public struct HexCoordinates
{
    [SerializeField]
    private int a, b, h;

    public int A
    {
        get
        {
            return a;
        }
    }

    public int B
    {
        get
        {
            return b;
        }
    }

    public int H
    {
        get
        {
            return h;
        }
    }

    public HexCoordinates(int x, int z)
    {
        this.a = x;
        this.b = z;
        h = 0;
    }
    public HexCoordinates(int x, int z, int h)
    {
        this.a = x;
        this.b = z;
        this.h = h;
    }

    public static HexCoordinates FromOffsetCoordinates(int x, int z)
    {
        return new HexCoordinates(x - z / 2, z);
    }

    public static HexCoordinates FromOffsetCoordinates(int x, int z, int h)
    {
        return new HexCoordinates(x - z / 2, z, h);
    }

    public int C
    {
        get
        {
            return -A - B;
        }
    }

    public override string ToString()
    {
        return "(" +
            A.ToString() + ", " + C.ToString() + ", " + B.ToString() + ", " + H.ToString() + ")";
    }

    public string ToStringOnSeparateLines()
    {
        return A.ToString() + "\n" + C.ToString() + "\n" + B.ToString() + "\n" + H.ToString();
    }
}