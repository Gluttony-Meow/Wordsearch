using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPopup : MonoBehaviour
{
    public GameObject gameOverPopup;
    public GameObject continueGameAfterAdsButton;
    
    void Start()
    {
        continueGameAfterAdsButton.GetComponent<Button>().interactable = false;
        gameOverPopup.SetActive(false);

        GameEvent.OnGameOver += ShowGameOverPopup;
    }
    private void OnDisable()
    {
        GameEvent.OnGameOver -= ShowGameOverPopup;
    }
    private void ShowGameOverPopup()
    {
        gameOverPopup.SetActive(true);
        continueGameAfterAdsButton.GetComponent<Button>().interactable = false;
    }
}
