using UnityEngine;

public class HexCell : MonoBehaviour
{
    public HexCoordinates coordinates;


    public HexGrid hG; 

    private HexCollider hC;

    private void Awake()
    {
        hC = this.gameObject.AddComponent<HexCollider>();
    }
    /*
    private HexCell[] GetAdjacentCells() {
        return hG.GetAdjacentCells(this);
    }
    */
}