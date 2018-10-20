using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LeveledClass
{
    [SerializeField]
    ClassType _leveledClass;
    [SerializeField]
    int _level;

    public LeveledClass (ClassType lC)
    {
        _leveledClass = lC;
        _level = 1;
    }

    public LeveledClass(ClassType lC, int l)
    {
        _leveledClass = lC;
        _level = l;
    }

    public ClassType leveledClass
    {
        get
        {
            return _leveledClass;
        }

    }

    public int level
    {
        get
        {
            return _level;
        }

    }

    public static LeveledClass operator ++(LeveledClass lC)
    {
        lC._level += 1;
        return lC;
    }

    public static LeveledClass operator --(LeveledClass lC)
    {
        lC._level -= 1;
        return lC;
    }
    public static LeveledClass operator +(LeveledClass lC, int i)
    {
        lC._level += i;
        return lC;
    }

    public static LeveledClass operator -(LeveledClass lC, int i)
    {
        lC._level -= i;
        return lC;
    }


}

[CreateAssetMenu(fileName = "new Character", menuName = "Codename: Tactic Casters/Engine/Front-End/Character")]
public class Character : ScriptableObject {
    public new string name = "new Character";

    public int health = 0;

    public int speed = 0;

    public int movement = 0;

    public LeveledClass mainClass = null;
    public LeveledClass secondaryClass = null;

    public List<LeveledClass> otherLeveledClasses = new List<LeveledClass>();

    public bool ChangeMainClass(string name)
    {
        if (mainClass.leveledClass.name == name)
        {
            return false;
        }
        else if (secondaryClass.leveledClass.name == name)
        {
            LeveledClass t = mainClass;
            mainClass = secondaryClass;
            secondaryClass = t;
            return true;
        }
        else
        {
            for (int i = 0; i < otherLeveledClasses.Count; i++)
            {
                if (otherLeveledClasses[i].leveledClass.name == name)
                {
                    LeveledClass t = mainClass;
                    mainClass = otherLeveledClasses[i];
                    otherLeveledClasses[i] = t;
                    return true;
                }
            }
        }
        return false;
    }

    public bool ChangeSecondaryClass(string name)
    {
        if (secondaryClass.leveledClass.name == name)
        {
            return false;
        }
        else if (mainClass.leveledClass.name == name)
        {
            LeveledClass t = mainClass;
            mainClass = secondaryClass;
            secondaryClass = t;
            return true;
        }
        else
        {
            for (int i = 0; i < otherLeveledClasses.Count; i++)
            {
                if (otherLeveledClasses[i].leveledClass.name == name)
                {
                    LeveledClass t = secondaryClass;
                    secondaryClass = otherLeveledClasses[i];
                    otherLeveledClasses[i] = t;
                    return true;
                }
            }
        }
        return false;
    }

    public int GetJumpingHeight()
    {
        return 1;
    }
}
