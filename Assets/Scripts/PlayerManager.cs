using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Region dedicated to the different Variables.
    #region Variables
    private List<TargetHolder> targets = new();
    public static PlayerManager instance;
    #endregion

    //Region deidcated to the different Getters/Setters.
    #region Getters/Setters

    #endregion

    //Region dedicated to methods native to Unity.
    #region Unity Functions
    private void Awake()
    {
        instance = this;
    }
    #endregion

    //Region dedicated to Custom methods.
    #region Custom Methods
    public TargetHolder GetRandomTargetInArea()
    {
        if (targets.Count == 0)
        {
            return null;
        }
        return targets[Random.Range(0, targets.Count)];
    }

    public void AllowTarget(TargetHolder newTarget)
    {
        targets.Add(newTarget);
    }

    public void RemoveTarget(TargetHolder oldTarget)
    {
        targets.Remove(oldTarget);
    }
    #endregion
}