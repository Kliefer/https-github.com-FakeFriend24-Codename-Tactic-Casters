using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new TerrainType", menuName = "Codename: Tactic Casters/TerrainTypes")]
public class TerrainType : ScriptableObject {

    public new string name;

    public int movementCost = 1;
    [Range(0, 1)]
    public float rangedCover = 0;

    public bool dominantMovementType = false;
}
