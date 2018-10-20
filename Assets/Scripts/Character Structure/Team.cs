using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team {
    List<MyHexCharacter> teammates = new List<MyHexCharacter>();


    /// <summary>
    /// Adds Character to Team
    /// </summary>
    /// <param name="p">
    /// Character to Add
    /// </param>
    /// <returns>
    /// returns true if character was added, false if character is already in it
    /// </returns>
    public bool AddMate(MyHexCharacter p)
    {
        for (int i = teammates.Count -1; i >= 0 ; i--)
        {
            if (teammates[i] == p)
            {
                return false;
            }
        }
        teammates.Add(p);
        return true;
    }

    /// <summary>
    /// Get Character by name
    /// </summary>
    /// <param name="name">
    /// name of the character to search
    /// </param>
    /// <returns>
    /// returns searched character, null if not part of the Team
    /// </returns>
    public MyHexCharacter GetMate(string name)
    {
        for(int i = 0; i < teammates.Count; i++)
        {
            if(teammates[i].name == name)
            {
                return teammates[i];
            }
        }
        return null;
    }

    /// <summary>
    /// Get all Team Characters
    /// </summary>
    /// <returns>
    /// returns all Teammates
    /// </returns>
    public List<MyHexCharacter> GetMates()
    {
        return teammates;
    }
}
