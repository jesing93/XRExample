using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Target : MonoBehaviour
{
    //Region dedicated to the different Variables.
    #region Variables
    private bool isActive = false;
    public bool isTiff = true;
    #endregion

    //Region dedicated to the different Getters/Setters.
    #region Getters/Setters
    public bool IsActive { get => isActive; }
    #endregion

    //Region dedicated to methods native to Unity.
    #region Unity Functions
    #endregion

    //Region dedicated to Custom methods.
    #region Custom Methods
    public void Hit()
    {
        if(isActive)
        {
            GameManager.instance.TargetHit(isTiff);
            Deactivate();
        }
    }

    public void Activate()
    {
        isActive = true;
        transform.DORotate(new Vector3(-90, transform.rotation.y, transform.rotation.z), 1.0f).SetEase(Ease.InOutQuad);
    }

    public void Deactivate()
    {
        isActive = false;
        transform.DORotate(new Vector3(-180, transform.rotation.y, transform.rotation.z), 1.0f).SetEase(Ease.InOutQuad).OnComplete(AskForDeletion);
    }

    private void AskForDeletion()
    {
        GetComponentInParent<TargetHolder>().DestroyTarget();
    }
    #endregion
}