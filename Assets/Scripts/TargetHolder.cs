using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHolder : MonoBehaviour
{
    //Region dedicated to the different Variables.
    #region Variables
    [SerializeField] List<GameObject> targetPref;
    private GameObject target;
    private AudioSource clickSound;
    private float inactiveTime = 100;
    private float activeTime = 0;
    private bool isActive = false;
    private bool isDeactivating = false;
    private bool isWaitingActivation = false;
    #endregion

    //Region deidcated to the different Getters/Setters.
    #region Getters/Setters

    public float InactiveTime { get => inactiveTime; }

    #endregion

    //Region dedicated to methods native to Unity.
    #region Unity Functions

    private void Awake()
    {
        clickSound = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (!isDeactivating)
        {
            if (isActive)
            {
                activeTime += Time.deltaTime;
                if (activeTime > 7.5f)
                {
                    isDeactivating = true;
                    activeTime = 0;
                    target.GetComponentInChildren<Target>().Deactivate();
                }
            }
            else
            {
                if(inactiveTime > 5)
                {
                    float playerDistance = Vector3.Distance(transform.position, PlayerManager.instance.transform.position);
                    if (playerDistance <= 10 && !isWaitingActivation)
                    {
                        isWaitingActivation = true;
                        PlayerManager.instance.AllowTarget(this);
                    }
                    else if(playerDistance > 10 && isWaitingActivation)
                    {
                        isWaitingActivation = false;
                        PlayerManager.instance.RemoveTarget(this);
                    }
                }
                else
                {
                    inactiveTime += Time.deltaTime;
                }
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
            PlayerManager.instance.RemoveTarget(this);
            target = Instantiate(targetPref[Random.Range(0, targetPref.Count)], transform);
            target.GetComponentInChildren<Target>().Activate();
            inactiveTime = 0;
            isWaitingActivation = false;
            clickSound.Play();
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
        if(!isActive && inactiveTime > 5)
        {
            return true;
        }
        return false;
    }

    #endregion
}
