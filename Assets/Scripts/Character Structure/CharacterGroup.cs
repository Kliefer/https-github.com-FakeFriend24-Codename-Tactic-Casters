using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Character Group", menuName = "Codename: Tactic Casters/Engine/Front-End/Character Group")]
public class CharacterGroup : ScriptableObject {
    [SerializeField]
    List<Character> _chars = new List<Character>();

    public List<Character> chars
    {
        get
        {
            return _chars;
        }

        set
        {
            _chars = value;
        }
    }
}
