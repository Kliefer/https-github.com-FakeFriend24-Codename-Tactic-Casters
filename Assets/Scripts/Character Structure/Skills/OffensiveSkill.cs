using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OffensiveSkill : Skill {

    public abstract bool OnSelect(MyHexCharacter me);
    public abstract bool OnActivate(MyHexCharacter me, MyHexCharacter enemy);
}
