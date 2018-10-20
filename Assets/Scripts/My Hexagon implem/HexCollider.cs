using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HexCollider : MonoBehaviour {

    private BoxCollider[] hexCollider = new BoxCollider[3];
    private GameObject wrapper;

    [SerializeField]
    public float edgeRadius = 1;

    [SerializeField]
    public float height = 1;

    [SerializeField]
    [Range(0, 60)]
    public float rotOffset = 0;
    
    private void OnEnable()
    {
        OnDisable();

        if (height > 0 && edgeRadius > 0)
        {
            wrapper = new GameObject("Collider Wrapper");
            for (int i = 0; i < hexCollider.Length; i++)
            {
                hexCollider[i] = new GameObject("Box Collider " + (i + 1)).AddComponent<BoxCollider>();
                hexCollider[i].transform.parent = wrapper.transform;
                hexCollider[i].transform.localPosition = Vector3.zero;
                hexCollider[i].transform.localRotation = Quaternion.Euler(0, rotOffset + i * 60, 0);
                hexCollider[i].size = new Vector3(2*Mathf.Cos(Mathf.Deg2Rad * 30) * edgeRadius, height , 2*Mathf.Sin(Mathf.Deg2Rad * 30) * edgeRadius);


            }
            wrapper.transform.parent = this.transform;
            wrapper.transform.localPosition = Vector3.zero;
        }
    }

    private void OnDisable()
    {
        if(!Application.isEditor)
        {
            Destroy(wrapper);
        }
        else
        {
            DestroyImmediate(wrapper);
        }
    }
}
