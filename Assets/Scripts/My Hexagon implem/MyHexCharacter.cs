using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHexCharacter : MonoBehaviour {
    [SerializeField]
    public MyHexCell standingOn;

    public Character me;

    private HexCoords tempPos = new HexCoords();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SnapToGrid()
    {

        this.transform.position = MyHexMetric.Hexagonal2Kartesian(standingOn.pos);
    }
    public void SnapToGridWithOffset()
    {

        this.transform.position = MyHexMetric.Hexagonal2Kartesian(standingOn.pos) + Vector3.up;
    }

    public void CheckForValidGround()
    {
        
    }


    private void OnMouseDown()
    {
        Debugger.LogWarning("Pressed on: " + this.gameObject.name );
        if(standingOn)
        {
            Debugger.LogWarning("Standing on: " + standingOn.ToString());
        }
        if (GameManager.Instance.selection)
        {
            if(GameManager.Instance.selection == this)
            {
                GameManager.Instance.selection = null;
                GetComponent<Renderer>().material.SetColor("_Color", Color.red);

            }
            else if (GameManager.Instance.selection.GetType() == typeof(MyHexCell))
            {
                GameManager.Instance.UpdateSelection(this);
                GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            }
            else if (GameManager.Instance.selection.GetType() == typeof(MyHexCharacter))
            {
                Debugger.LogWarning("No Direct Interaction implemented yet!");
            }
        }
        else
        {
            GameManager.Instance.UpdateSelection(this);
            GetComponent<Renderer>().material.SetColor("_Color", Color.green);

        }
    }

}
