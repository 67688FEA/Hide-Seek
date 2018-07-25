using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HideSeekMainMenu : MonoBehaviour {
    
    public GameObject homeMenu;
    
    public GameObject characterSelect;
    public GameObject options;

    public Transform defaultPoint;
    public Transform charactorPoint;
    public GameObject background;
    public GameObject characterTransform;
    public Slider bgMusic;
    public Slider gSound;
    public string currentAnimation="ScrollThirdCharacter";

    private Animation backgroundAnimation;
    private Animation characterAnimation;
    public static string playerName = "Normal Male";
    public static string playerDescription = "Normal Male.";
    AsyncOperation async;
    private SelectedCharacter[] playerList=new SelectedCharacter[5];


    private void Start()
    {
        backgroundAnimation = background.GetComponent<Animation>();
        characterAnimation = characterTransform.GetComponent<Animation>();
    }

    public void OnCharactorChooseClick()
    {
        homeMenu.SetActive(false);
        characterSelect.SetActive(true);
        options.SetActive(false);
        characterTransform.SetActive(true);
        backgroundAnimation.Play("StartMenu");
    }

    public void OnOptionClick()
    {
        homeMenu.SetActive(false);
        options.SetActive(true);
        bgMusic.value = PlayerPrefs.GetFloat("BackgroundMusic");
        gSound.value = PlayerPrefs.GetFloat("GameSound");
        backgroundAnimation.Play("StartMenu");
    }

    public void OnCharacterBackClick()
    {
        homeMenu.SetActive(true);
        characterSelect.SetActive(false);
        options.SetActive(false);
        characterTransform.SetActive(false);
        backgroundAnimation.Play("CharacterMenu");
    }

    public void ConfirmCharacter()
    {
        //GetSelectedCharacter();
        PlayerPrefs.SetString("PlayerName", playerName);
        //SceneManager.LoadScene("LoadingScene");
        StartCoroutine(LoadScene());
    }

    //private void GetSelectedCharacter()
    //{
    //    //playerList = GameObject.FindGameObjectsWithTag("Player");
    //    playerList = GameObject.FindObjectsOfType<SelectedCharacter>();
    //    foreach (SelectedCharacter player in playerList)
    //    {
    //        if (player.selected)
    //        {
    //            playerName = player.playerName;
    //            break;
    //        }
    //    }
    //}

    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync("SpringLevel");
        yield return async;
    }

    public void OnOptionBackClick()
    {
        homeMenu.SetActive(true);
        characterSelect.SetActive(false);
        options.SetActive(false);
        characterTransform.SetActive(false);
        backgroundAnimation.Play("CharacterMenu");
    }

    public void SaveOption()
    {
        PlayerPrefs.SetFloat("BackgroundMusic", bgMusic.value);
        PlayerPrefs.SetFloat("GameSound", gSound.value);
        homeMenu.SetActive(true);
        characterSelect.SetActive(false);
        options.SetActive(false);
        characterTransform.SetActive(false);
        backgroundAnimation.Play("CharacterMenu");
    }

    public void ScrollCharacterRight()
    {
        AnimationState animationState;
        if (currentAnimation=="ScrollThirdCharacter")
        {
            animationState = characterAnimation["ScrollThirdCharacter"];
            characterAnimation.Play("ScrollThirdCharacter");
            animationState.speed = 1;
            animationState.time = 0f;
            currentAnimation = "ScrollFouthCharacter";
        }
        else if (currentAnimation == "ScrollFouthCharacter")
        {
            animationState = characterAnimation["ScrollFouthCharacter"];
            characterAnimation.Play("ScrollFouthCharacter");
            animationState.speed = 1;
            animationState.time = 0f;
            currentAnimation = "ScrollFifthCharacter";
        }
        else if (currentAnimation == "ScrollFifthCharacter")
        {
            animationState = characterAnimation["ScrollFifthCharacter"];
            characterAnimation.Play("ScrollFifthCharacter");
            animationState.speed = 1;
            animationState.time = 0f;
            currentAnimation = "ScrollFirstCharacter";
        }
        else if (currentAnimation == "ScrollFirstCharacter")
        {
            animationState = characterAnimation["ScrollFirstCharacter"];
            characterAnimation.Play("ScrollFirstCharacter");
            animationState.speed = 1;
            animationState.time = 0f;
            currentAnimation = "ScrollSecondCharacter";
        }
        else if (currentAnimation == "ScrollSecondCharacter")
        {
            animationState = characterAnimation["ScrollSecondCharacter"];
            characterAnimation.Play("ScrollSecondCharacter");
            animationState.speed = 1;
            animationState.time = 0f;
            currentAnimation = "ScrollThirdCharacter";
        }
    }

    public void ScrollCharacterLeft()
    {
        AnimationState animationState;
        if (currentAnimation == "ScrollThirdCharacter")
        {
            animationState = characterAnimation["ScrollSecondCharacter"];
            characterAnimation.Play("ScrollSecondCharacter");
            animationState.speed = -1;
            animationState.time = animationState.clip.length;
            currentAnimation = "ScrollSecondCharacter";
        }
        else if (currentAnimation == "ScrollFouthCharacter")
        {
            animationState = characterAnimation["ScrollThirdCharacter"];
            characterAnimation.Play("ScrollThirdCharacter");
            animationState.speed = -1;
            animationState.time = animationState.clip.length;
            currentAnimation = "ScrollThirdCharacter";
        }
        else if (currentAnimation == "ScrollFifthCharacter")
        {
            animationState = characterAnimation["ScrollFouthCharacter"];
            characterAnimation.Play("ScrollFouthCharacter");
            animationState.speed = -1;
            animationState.time = animationState.clip.length;
            currentAnimation = "ScrollFouthCharacter";
        }
        else if (currentAnimation == "ScrollFirstCharacter")
        {
            animationState = characterAnimation["ScrollFifthCharacter"];
            characterAnimation.Play("ScrollFifthCharacter");
            animationState.speed = -1;
            animationState.time = animationState.clip.length;
            currentAnimation = "ScrollFifthCharacter";
        }
        else if (currentAnimation == "ScrollSecondCharacter")
        {
            animationState = characterAnimation["ScrollFirstCharacter"];
            characterAnimation.Play("ScrollFirstCharacter");
            animationState.speed = -1;
            animationState.time = animationState.clip.length;
            currentAnimation = "ScrollFirstCharacter";
        }
    }

}
