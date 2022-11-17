using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEvent;

public class GridSquare : MonoBehaviour
{
    public int SquareIndex { get; set; }
    private AlphabetData.LetterData _normaLetterData;
    private AlphabetData.LetterData _selectedLetterData;
    private AlphabetData.LetterData _correctLetterData;

    private SpriteRenderer displayedImage;
    private bool _selected;
    private bool _clicked;
    private int _index = -1;
    private bool _correct;

    private AudioSource _source;
    public void SetIndex(int Index)
    {
        _index = Index;
    }

    public int GetIndex()
    {
        return _index;
    }
    private void Start()
    {
        _selected = false;
        _clicked = false;
        _correct = false;
        displayedImage = GetComponent<SpriteRenderer>();
        _source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GameEvent.OnEnableSquareSelection += OnEnableSquareSelection;
        GameEvent.OnDisableSquareSelection += OnDisableSquareSelection;
        GameEvent.OnSelectSquare += SelectSquare;
        GameEvent.OnCorrectWord += CorrectWord;
    }

    private void OnDisable()
    {
        GameEvent.OnEnableSquareSelection -= OnEnableSquareSelection;
        GameEvent.OnDisableSquareSelection -= OnDisableSquareSelection;
        GameEvent.OnSelectSquare -= SelectSquare;
        GameEvent.OnCorrectWord -= CorrectWord;
    }

    private void CorrectWord(string word, List<int> squareIndexes)
    {
        if (_selected && squareIndexes.Contains(_index))
        {
            _correct = true;
            displayedImage.sprite = _correctLetterData.image;
        }

        _selected = false;
        _clicked = false;
    }

    public void OnEnableSquareSelection()
    {
        _clicked = true;
        _selected = false;
    }

    public void OnDisableSquareSelection()
    {
        _selected = false;
        _clicked = false;

        if (_correct == true)
            displayedImage.sprite = _correctLetterData.image;
        else
            displayedImage.sprite = _normaLetterData.image;
    }

    private void SelectSquare(Vector3 position)
    {
        if (this.gameObject.transform.position == position)
            displayedImage.sprite = _selectedLetterData.image;
    }
    public void SetSprite(AlphabetData.LetterData normaLetterData, AlphabetData.LetterData selectedLetterData,
        AlphabetData.LetterData correctLetterData)
    {
        _normaLetterData = normaLetterData;
        _selectedLetterData = selectedLetterData;
        _correctLetterData = correctLetterData;

        GetComponent<SpriteRenderer>().sprite = _normaLetterData.image;
    }
    private void OnMouseDown()
    {
        OnEnableSquareSelection();
        GameEvent.EnableSquareSelectionMethod();
        CheckSquare();
        displayedImage.sprite = _selectedLetterData.image;
    }

    private void OnMouseEnter()
    {
        CheckSquare();
    }
    private void OnMouseUp()
    {
        GameEvent.ClearSelectionMethod();
        GameEvent.DisableSquareSelectionMethod();
    }

    public void CheckSquare()
    {
        if (_selected == false && _clicked == true)
        {
            if (SoundManager.instance.IsSoundFXMuted() == false)
                _source.Play();

            _selected = true;
            GameEvent.CheckSquareMethod(_normaLetterData.letter, gameObject.transform.position, _index);
        }
    }

}
