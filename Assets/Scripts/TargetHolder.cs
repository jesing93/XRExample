using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHolder : MonoBehaviour
{
    //Region dedicated to the different Variables.
    #region Variables
    [SerializeField] List<GameObject> targetPref;
    private GameObject target;
    private float inactiveTime = 100;
    private float activeTime = 0;
    private bool isActive = false;
    private bool isDeactivating = false;
    #endregion

    //Region deidcated to the different Getters/Setters.
    #region Getters/Setters

    public float InactiveTime { get => inactiveTime; }

    #endregion

    //Region dedicated to methods native to Unity.
    #region Unity Functions

    private void FixedUpdate()
    {
        if (!isDeactivating)
        {
            if (isActive)
            {
                activeTime += Time.deltaTime;
                if (activeTime > 5)
                {
                    isDeactivating = true;
                    activeTime = 0;
                    target.GetComponentInChildren<Target>().Deactivate();
                }
            }
            else
            {
                inactiveTime += Time.deltaTime;
            }
        }
    }

    #endregion

    //Region dedicated to Custom methods.
    #region Custom Methods

    public void Activate()
    {
        Debug.Log("Activate holder");
        if (target == null)
        {
            isActive = true;
            target = Instantiate(targetPref[Random.Range(0, targetPref.Count)], transform);
            target.GetComponent<Target>().Activate();
            inactiveTime = 0;
        }
    }

    public void DestroyTarget()
    {
        Debug.Log("Destroy target");
        Destroy(target);
        target = null;
        isActive = false;
        isDeactivating = false;
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
