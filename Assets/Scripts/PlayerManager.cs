using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Region dedicated to the different Variables.
    #region Variables
    private List<GameObject> targets;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TargetHolder"))
        {
            targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TargetHolder"))
        {
            targets.Remove(other.gameObject);
        }
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
        return targets[Random.Range(0, targets.Count)].GetComponentInChildren<TargetHolder>();
    }
    #endregion
}