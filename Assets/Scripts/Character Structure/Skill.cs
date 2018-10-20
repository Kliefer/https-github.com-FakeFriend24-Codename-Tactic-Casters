using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Skill : ScriptableObject {

    public enum Modifier { defensive, offensive, passive }
    [SerializeField]
    protected string _name;
    [SerializeField]
    protected Modifier modifier;
    

    public new string name
    {
        get
        {
            return _name;
        }
        
    }
    
    
}
