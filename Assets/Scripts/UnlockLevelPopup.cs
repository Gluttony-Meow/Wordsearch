using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameEvent;

public class UnlockLevelPopup : MonoBehaviour
{
    [System.Serializable]
    public struct CategoryName
    {
        public string name;
        public Sprite sprite;
    };

    public GameData currentGameData;
    public List<CategoryName> categoryNames;
    public GameObject winPopup;
    public Image categoryNameImage;

    void Start()
    {
        winPopup.SetActive(false);

        GameEvent.OnUnlockNextCategory += OnUnlockNextCategory;
    }

    private void OnDisable()
    {
        GameEvent.OnUnlockNextCategory -= OnUnlockNextCategory;
    }
    private void OnUnlockNextCategory()
    {
        bool captureNext = false;

        foreach (var writing in categoryNames)
        {
            if (captureNext)
            {
                categoryNameImage.sprite = writing.sprite;
                captureNext = false;
                break;
            }

            if (writing.name == currentGameData.selectedCategoryName)
            {
                captureNext = true;
            }
        }
        winPopup.SetActive(true);
    }
}
