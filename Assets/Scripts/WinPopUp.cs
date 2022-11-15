using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPopUp : MonoBehaviour
{
    public GameObject winPopUp;
    void Start()
    {
        winPopUp.SetActive(false);
    }

    private void OnDisable()
    {
        GameEvent.OnBoardCompleted -= ShowWinPopUp;
    }

    private void OnEnable()
    {
        GameEvent.OnBoardCompleted += ShowWinPopUp;
    }

    private void ShowWinPopUp()
    {
        winPopUp.SetActive(true);
    }
    public void LoadNextLevel()
    {
        GameEvent.LoadNextLevelMethod();
    }
}
