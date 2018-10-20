using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefensiveSkill : Skill {


    public abstract bool OnActivate(MyHexCharacter me, MyHexCharacter attacker);
}
