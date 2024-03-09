using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Region dedicated to the different Variables.
    #region Variables
    private float lastActive;
    private bool searchingTarget = false;
    private float maxTime = 60;
    private float seconds;
    private int points = 0;
    private bool isGameStarted = false;
    private bool isEndSoundStarted = false;
    public AudioClip startClip;
    public AudioClip endClip;
    private AudioSource audioSource;
    public AudioSource musicSource;

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
        audioSource = GetComponent<AudioSource>();
        //musicSource = GetComponentInChildren<AudioSource>();
    }
    private void FixedUpdate()
    {
        if (isGameStarted)
        {
            seconds = Mathf.Max(0, seconds - Time.deltaTime);
            if(seconds < 10 && !isEndSoundStarted)
            {
                isEndSoundStarted = true;
                audioSource.clip = endClip;
                audioSource.Play();
            }
            UIManager.Instance.UpdateTime(seconds);
            if (seconds == 0) {
                EndGame();
            }
            if (!searchingTarget)
            {
                lastActive += Time.deltaTime;
                if (lastActive > .5)
                {
                    StartCoroutine(SearchTarget());
                }
            }
        }
    }
    #endregion

    //Region dedicated to Custom methods.
    #region Custom Methods
    public void StartGame()
    {
        audioSource.Stop();
        audioSource.clip = startClip;
        audioSource.Play();
        if (!musicSource.isPlaying)
        {
            musicSource.DOKill();
            musicSource.volume = 0;
            musicSource.Play();
            musicSource.DOFade(.5f, 1);
        }
        seconds = maxTime;
        points = 0;
        isGameStarted = true;
        isEndSoundStarted = false;
        searchingTarget = false;
    }

    public void EndGame(bool isRestart = false)
    {
        isGameStarted = false;
        if(!isRestart)
            musicSource.DOFade(0, 1).OnComplete(StopMusic);
    }

    private void StopMusic()
    {
        musicSource.Stop();
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
        Debug.Log("Start searching");
        searchingTarget = true;
        lastActive = 0;
        TargetHolder target = null;
        while (target == null)
        {
            yield return new WaitForEndOfFrame();
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