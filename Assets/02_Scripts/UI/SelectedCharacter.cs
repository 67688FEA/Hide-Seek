using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedCharacter : MonoBehaviour
{

    public bool selected;
    public string playerName;
    public string playerDescription;
    public Text description;

    void Update()
    {
        if (selected) {
            HideSeekMainMenu.playerName = playerName;
            description.text = playerDescription;
}
    }

}
