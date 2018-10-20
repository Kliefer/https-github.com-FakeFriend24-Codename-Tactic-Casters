using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class InterfaceManager : MonoBehaviour {
    public enum InteractionMode
    {
        Move,
        Attack,
        Skill
    }

    InteractionMode activeMode = InteractionMode.Move;

    Skill selectedSkill = null;


    public static void SetInteractionTo(InteractionMode iM)
    {
        if(iM == InteractionMode.Skill)
        {
            Debugger.Log("Skill klicked!");
        }
        GameManager.Instance.interfaceManager.activeMode = iM;
    }

    public static void ResetInteractionMode()
    {
        SetInteractionTo(InteractionMode.Move);
    }
    
}
