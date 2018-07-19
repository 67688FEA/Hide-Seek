using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSeekMainMenu : MonoBehaviour {

    public GameObject title;
    public GameObject Main;

    public GameObject charactorChoose;
    public GameObject charactorDescription;
    public GameObject charactorChooseButton;

    public Transform defaultPoint;
    public Transform charactorPoint;
    public GameObject background;

    public void OnCharactorChooseClick()
    {
        title.SetActive(false);
        Main.SetActive(false);
        charactorChoose.SetActive(true);
        charactorDescription.SetActive(true);
        charactorChooseButton.SetActive(true);
        background.transform.position = Vector3.Lerp(background.transform.position, charactorPoint.position, 2f);
        background.transform.rotation = charactorPoint.rotation;

    }
    public void OnBackClick()
    {
        title.SetActive(true);
        Main.SetActive(true);
        charactorChoose.SetActive(false);
        charactorDescription.SetActive(false);
        charactorChooseButton.SetActive(false);
        background.transform.position = Vector3.Lerp(background.transform.position, defaultPoint.position, 2f);
        background.transform.rotation = defaultPoint.rotation;
    }

}
