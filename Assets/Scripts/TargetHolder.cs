using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHolder : MonoBehaviour
{
    //Region dedicated to the different Variables.
    #region Variables
    [SerializeField] GameObject targetPref;
    private GameObject target;
    private float inactiveTime = 100;
    private bool isActive = false;
    #endregion

    //Region deidcated to the different Getters/Setters.
    #region Getters/Setters

    public float InactiveTime { get => inactiveTime; }

    #endregion

    //Region dedicated to methods native to Unity.
    #region Unity Functions

    private void Update()
    {
        if (!isActive)
        {
            inactiveTime += Time.deltaTime;
        }
    }

    #endregion

    //Region dedicated to Custom methods.
    #region Custom Methods

    public void Activate()
    {
        if (target == null)
        {
            isActive = true;
            target = Instantiate(gameObject, transform);
            target.GetComponent<Target>().Activate();
            inactiveTime = 0;
        }
    }

    public void DestroyTarget()
    {
        Destroy(target);
        target = null;
        isActive = false;
    }

    public bool IsValid()
    {
        if(!isActive && inactiveTime > 10)
        {
            return true;
        }
        return false;
    }

    #endregion
}
