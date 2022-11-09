using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchingWord : MonoBehaviour
{
    public Text displayedText;
    public Image crossLine;

    private string _word;

    void Start()
    {

    }

    private void OnEnable()
    {
        GameEvent.OnCorrectWord += CorrectWord;
    }

    private void OnDisable()
    {
        GameEvent.OnCorrectWord -= CorrectWord;
    }

    public void SetWord(string word)
    {
        _word = word;
        displayedText.text = word;
    }

    private void CorrectWord(string word, List<int> squareIndexas)
    {
        if (word == _word)
        {
            crossLine.gameObject.SetActive(true);
        }
    }
}
