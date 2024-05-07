using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Button[] _buttonsChoiceLevel;
    private int _levelProgres = 1;

    public void CheckButtonChoiceLevel()
    {
        bool isSaveLevelProgress = PlayerPrefs.HasKey("LevelProgress");
        if (isSaveLevelProgress == true)
        {
            _levelProgres = PlayerPrefs.GetInt("LevelProgress");
        }
        else
        {
            PlayerPrefs.SetInt("LevelProgress", _levelProgres);
        }

        int lengthButtonsChoiceLeve = _buttonsChoiceLevel.Length;

        for(int i = 0; i < lengthButtonsChoiceLeve; i++)
        {
            if (i < _levelProgres)
            {
                _buttonsChoiceLevel[i].interactable = true;
            }
            else
            {
                _buttonsChoiceLevel[i].interactable = false;
            }
        }
    }
}
