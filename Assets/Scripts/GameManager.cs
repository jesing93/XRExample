using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Region dedicated to the different Variables.
    #region Variables
    private float lastActive;
    private bool searchingTarget = true;
    #endregion

    //Region deidcated to the different Getters/Setters.
    #region Getters/Setters

    #endregion

    //Region dedicated to methods native to Unity.
    #region Unity Functions
    private void Update()
    {
        if (!searchingTarget)
        {
            lastActive += Time.deltaTime;
            if (lastActive > 5)
            {
                StartCoroutine(SearchTarget());
            }
        }
    }
    #endregion

    //Region dedicated to Custom methods.
    #region Custom Methods
    public void StartGame()
    {
        Time.timeScale = 1.0f;
        searchingTarget = false;
    }

    private IEnumerator SearchTarget()
    {
        searchingTarget = true;
        lastActive = 0;
        GameObject target = null;
        while (target == null)
        {
            yield return new WaitForSeconds(1);
            target = PlayerManager.instance.GetRandomTargetInArea();
            if(target != null)
            {
                if (target.GetComponent<Target>().IsValid())
                {
                    target.GetComponent<Target>().Activate();
                }
                else
                {
                    target = null;
                }
            }
        }
        searchingTarget = false;
    }

    #endregion
}