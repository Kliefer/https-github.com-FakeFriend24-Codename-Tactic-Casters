using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class MyHexCell : MonoBehaviour {

    enum HexDirection {
        East,
        NorthEast,
        NorthWest,
        West,
        SouthWest,
        SouthEast
    }

    public int costs {
        get {
            return 5;
        }
    }
    
    public HexCoords pos = new HexCoords( );

    private HexCell[] adjacent = new HexCell[6];

    public GameObject debugMesh; 

    private void Awake()
    {
        this.gameObject.AddComponent<Rigidbody>().isKinematic = true;
        if (Debugger.IsInEditorMode())
        {

        }
        else
        {
            SnapToGridWithOffset();
        }
    }

    private void Start()
    {
        if (Debugger.IsInEditorPlayMode())
        {
            CreateDebugMesh();
        }
        else
        {

        }
    }

    private void Update()
    {
        if (Debugger.IsInEditorMode())
        {
            pos = MyHexMetric.Kartesian2Hexagonal(transform.position);
            // Debugger.Log(MyHexMetric.Kartesian2Hexagonal(transform.position).ToString());
        }
        else if(Debugger.IsInEditorPlayMode())
        {
            // Debugger.Log(MyHexMetric.Kartesian2Hexagonal(transform.position).ToString());
        }
    }

    public void SnapToGrid()
    {
        
        this.transform.position = MyHexMetric.Hexagonal2Kartesian(pos);
    }
    public void SnapToGridWithOffset()
    {

        this.transform.position = MyHexMetric.Hexagonal2Kartesian(pos) - Vector3.up*MyHexMetric.heightScaling;
    }

    public void CreateDebugMesh()
    {
        if(Debugger.debug)
        {
            GameObject wrapper = new GameObject("Box Wrapper");
            GameObject t;
            for (int i = 0; i < 3; i++)
            {
                t = GameObject.CreatePrimitive(PrimitiveType.Cube);
                t.transform.parent = wrapper.transform;
                t.name = "Cube " + (i+1);
                t.transform.localPosition = Vector3.zero;
                t.transform.localRotation = Quaternion.Euler(0,  i * 60, 0);
                t.transform.localScale = new Vector3(2*Mathf.Cos(Mathf.Deg2Rad * 30) * MyHexMetric.outerRadius, MyHexMetric.heightScaling, 2*Mathf.Sin(Mathf.Deg2Rad * 30) * MyHexMetric.outerRadius);


            }
            wrapper.transform.parent = this.transform;
            wrapper.transform.localPosition = Vector3.zero;

            HexCollider hC = this.gameObject.AddComponent<HexCollider>();
            hC.enabled = false;
            hC.height = 0.2f;
            hC.edgeRadius = MyHexMetric.outerRadius;
            hC.enabled = true;
        }
    }
    
    private void OnMouseDown()
    {
        Debugger.LogWarning("Pressed on: " + pos.ToString());
        if (GameManager.Instance.selection)
        {
            if(GameManager.Instance.selection == this)
            {
                GameManager.Instance.selection = null;
            }
            else if (GameManager.Instance.selection.GetType() == typeof(MyHexCell))
            {
                GameManager.Instance.UpdateSelection(this);
            }
            else if (GameManager.Instance.selection.GetType() == typeof(MyHexCharacter))
            {
                if((GameManager.Instance.selection as MyHexCharacter).standingOn) { 
                    try
                    {
                        HexGridPathfinding pathTo = new HexGridPathfinding( (GameManager.Instance.selection as MyHexCharacter).standingOn, this, (GameManager.Instance.selection as MyHexCharacter).me.GetJumpingHeight());
                        if(pathTo.pathExists)
                        {
                            (GameManager.Instance.selection as MyHexCharacter).standingOn = this;
                            (GameManager.Instance.selection as MyHexCharacter).SnapToGridWithOffset();

                        }
                        else
                        {
                            Debugger.LogWarning("No Path Accessable");
                        }
                    }
                    catch
                    {
                        Debug.LogError("You made some weird Shit!");
                    }
                
                }
                else
                {
                    (GameManager.Instance.selection as MyHexCharacter).standingOn = this;
                    (GameManager.Instance.selection as MyHexCharacter).SnapToGridWithOffset();


                }

            }
        }
        else
        {
            GameManager.Instance.UpdateSelection(this);
        }
    }

}
