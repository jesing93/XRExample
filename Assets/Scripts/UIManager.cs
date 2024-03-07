using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //Region dedicated to the different Variables.
    #region Variables
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private GameObject menuPanel;
    private bool isMenuOpen = true;
    private float startTime = 0;

    public static UIManager Instance;
    #endregion

    //Region deidcated to the different Getters/Setters.
    #region Getters/Setters

    #endregion

    //Region dedicated to methods native to Unity.
    #region Unity Functions
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            if(isMenuOpen)
            {
                OnCloseMenu();
            }
            else
            {
                OnOpenMenu();
            }
        }
        if (OVRInput.Get(OVRInput.Button.One))
        {
            startTime += Time.deltaTime;
            if(startTime > 1)
            {
                startTime = 0;
                OnRestartGame();
            }
        }
        else
        {
            startTime = 0;
        }
    }
    #endregion

    //Region dedicated to Custom methods.
    #region Custom Methods
    public void UpdatePoints(int points)
    {
        pointsText.text = points.ToString("00000");
    }
    public void UpdateTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void OnStart()
    {
        OnCloseMenu();
        GameManager.instance.StartGame();
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnRestartGame()
    {
        OnCloseMenu();
        GameManager.instance.EndGame();
        GameManager.instance.StartGame();
    }

    private void OnOpenMenu()
    {
        isMenuOpen = true;
        menuPanel.SetActive(true);
    }

    private void OnCloseMenu()
    {
        isMenuOpen = false;
        menuPanel.SetActive(false);
    }
    #endregion
}
