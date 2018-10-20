using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new EnhancementSkill", menuName = "Codename: Tactic Casters/Engine/Front-End/Skills/Passives/Enhancement Skill")]
public class EnhancementPassiveSkill : PassiveSkill {
    public enum EnhanceableValue
    {
        Movement,
        Speed

    }

    public enum EnhancementType
    {
        Percentage,
        Additive

    }
    
    public EnhanceableValue valueName;
    public EnhancementType type;

    public float value;
    
    /*
    // Use this for initialization
    public virtual bool OnActivation(MyHexCharacter me)
    {
        Debugger.Log("Skill " + name + " activated!");
        return true;
    }
    public virtual bool OnDeactivation(MyHexCharacter me)
    {
        Debugger.Log("Skill " + name + " deactivated!");
        return false;
    }
    */
}
