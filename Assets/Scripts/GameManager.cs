using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Region dedicated to the different Variables.
    #region Variables
    private float lastActive;
    private bool searchingTarget = true;
    private float maxTime = 180;
    private float seconds;
    private int points = 0;
    private bool isGameStarted = false;

    public static GameManager instance;
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
    private void Update()
    {
        if (isGameStarted)
        {
            seconds = Mathf.Max(0, seconds - Time.deltaTime);
            UIManager.Instance.UpdateTime(seconds);
            if (seconds == 0) {
                EndGame();
            }
        }
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
        seconds = maxTime;
        points = 0;
        isGameStarted = true;
        searchingTarget = false;
    }

    public void EndGame()
    {
        isGameStarted = false;
    }

    public void TargetHit(bool isTiff = false)
    {
        if (isTiff)
        {
            points += 10;
        }
        else
        {
            points -= 20;
        }
        UIManager.Instance.UpdatePoints(points);
    }

    private IEnumerator SearchTarget()
    {
        searchingTarget = true;
        lastActive = 0;
        TargetHolder target = null;
        while (target == null)
        {
            yield return new WaitForSeconds(1);
            target = PlayerManager.instance.GetRandomTargetInArea();
            if(target != null)
            {
                if (target.IsValid())
                {
                    target.Activate();
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