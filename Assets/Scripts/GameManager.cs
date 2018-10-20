using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private static MyHexGrid grid;

    private List<Team> teams = new List<Team>();

    public MonoBehaviour selection = null;

    public InterfaceManager interfaceManager;
    
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                if (_instance == null)
                {

                    _instance = new GameObject("My HexGrid").AddComponent<GameManager>();
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

        grid = MyHexGrid.Instance;
        interfaceManager = GetComponent<InterfaceManager>() ?? gameObject.AddComponent<InterfaceManager>();
        
    }

    public void UpdateSelection(MonoBehaviour mb)
    {
        selection = mb;
        Debugger.LogWarning("Selection Changed!");
    }
    
    public void InitiateTeamlist(CharacterGroup cG, HexCoords hC) 
    {

    }
}
