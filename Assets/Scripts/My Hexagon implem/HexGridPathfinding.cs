using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGridPathfinding  {

    class HexCoordsPathNode
    {
        public MyHexCell coords;
        public HexCoordsPathNode anchor;
        public int fCost;
        public int gCost;

        public HexCoordsPathNode(MyHexCell coords, HexCoordsPathNode anchor, int fCost, int gCost)
        {
            this.coords = coords;
            this.anchor = anchor;
            this.fCost = fCost;
            this.gCost = gCost;
            
        }

        public int cost
        {
            get
            {
                return fCost + gCost;
            }
        }

    }

    public MyHexCell start;
    public MyHexCell end;

    public int allowedHeightDist;

    public bool pathExists;

    List<HexCoords>  aStarPath = new List<HexCoords>();
    List<HexCoordsPathNode> open = new List<HexCoordsPathNode>();
    List<HexCoordsPathNode> closed = new List<HexCoordsPathNode>();


    public HexGridPathfinding(MyHexCell start, MyHexCell end, int allowedHeightDist)
    {
        this.start = start;
        this.end = end;
        this.allowedHeightDist = allowedHeightDist;
        pathExists = GetShortestAStarPathFor(start, end);
    }

    bool AddToOrUpdateOpen(HexCoordsPathNode hCPN)
    {
        for (int i = 0; i < open.Count; i++)
        {
            if (hCPN.coords == open[i].coords)
            {
                if (hCPN.gCost < open[i].gCost)
                {
                    open[i] = hCPN;
                    return true;
                }
                else
                {
                    return false;
                }
            }



        }
        open.Add(hCPN);
        return true;
    }

    bool AddToOrUpdateOpen(MyHexCell coords, HexCoordsPathNode anchor, int fCost, int gCost)
    {
        for (int i = 0; i < open.Count; i++)
        {
            if (coords == open[i].coords)
            {
                if (fCost < open[i].fCost)
                {
                    open[i] = new HexCoordsPathNode(coords, anchor, fCost, gCost);
                    return true;
                }
                else
                {
                    return false;
                }
            }



        }
        open.Add(new HexCoordsPathNode(coords, anchor, fCost, gCost));
        return true;
    }

    bool InClosedList(MyHexCell t)
    {
        for(int i = 0; i < closed.Count; i++)
        {
            if (t == closed[i].coords)
            {
                return true;
            }
        }
        return false;
    }

    int LowestScoreInOpen()
    {

        int index = open.Count > 0 ? 0 : -1;
        for (int i = 1; i < open.Count; i++ )
        {
            if(open[i].cost < open[index].cost)
            {
               
                index = i;
            } else if(open[i].cost == open[index].cost && open[i].gCost < open[index].gCost)
            {
                index = i;

            }
        }
        return index;
    }

    public bool GetShortestAStarPathFor(MyHexCell start, MyHexCell dest)
    {
        MyHexCell tempRef = null; 
        tempRef = start;

        
        HexCoordsPathNode temp = new HexCoordsPathNode(tempRef, null, 0, tempRef.pos.SSteps());
        AddToOrUpdateOpen(temp);
        while (temp.coords != dest)
        {
            int lScore = LowestScoreInOpen();
            if (lScore == -1)
                return false;
            temp = open[lScore];
            open.RemoveAt(lScore);
            closed.Add(temp);

            for (int i = 0; i < HexCoords.directions.Length; i++)
            {
                MyHexCell t = MyHexGrid.Instance.GetElementAt(temp.coords.pos + HexCoords.directions[i]);
                if (t && !InClosedList(t) && (t.pos.H - temp.coords.pos.H) <= allowedHeightDist)
                    AddToOrUpdateOpen(t, temp, temp.cost +  t.costs , tempRef.pos.SSteps());
                
            }
        }
        

        
        while( temp.coords != start)
        {
            aStarPath.Add(temp.coords.pos);
            temp = temp.anchor;
        }

        aStarPath.Reverse();

        return true;
    }
}
