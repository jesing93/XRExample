using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Target : MonoBehaviour
{
    //Region dedicated to the different Variables.
    #region Variables
    private bool isActive = false;
    private float inactiveTime = 100;
    #endregion

    //Region dedicated to the different Getters/Setters.
    #region Getters/Setters
    public bool IsActive { get => isActive; }
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
    public void Hit()
    {
        if(isActive)
        {
            Debug.Log("Points!");
            Deactivate();
        }
    }

    public void Activate()
    {
        isActive = true;
        inactiveTime = 0;
        transform.DORotate(new Vector3(-90, transform.rotation.y, transform.rotation.z), 1.0f).SetEase(Ease.InOutQuad);
    }

    private void Deactivate()
    {
        isActive = false;
        transform.DORotate(new Vector3(-180, transform.rotation.y, transform.rotation.z), 1.0f).SetEase(Ease.InOutQuad);
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