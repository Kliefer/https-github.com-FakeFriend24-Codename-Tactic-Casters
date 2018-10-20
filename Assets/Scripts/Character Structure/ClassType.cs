using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Class", menuName = "Codename: Tactic Casters/Engine/Front-End/Character Class")]
public class ClassType : ScriptableObject {
    [SerializeField]
    public new string name = "new Class";
    [SerializeField]
    public List<OffensiveSkill> oSkills = new List<OffensiveSkill>();

    [SerializeField]
    public List<DefensiveSkill> dSkills = new List<DefensiveSkill>();

    [SerializeField]
    public List<PassiveSkill> pSkills = new List<PassiveSkill>();
}
