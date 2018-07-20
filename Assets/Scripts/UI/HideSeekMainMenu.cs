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
    public GameObject characterTransform;
    public string currentAnimation="ScrollThirdCharacter";

    private Animation backgroundAnimation;
    private Animation characterAnimation;


    private void Start()
    {
        backgroundAnimation = background.GetComponent<Animation>();
        characterAnimation = characterTransform.GetComponent<Animation>();
    }

    public void OnCharactorChooseClick()
    {
        title.SetActive(false);
        Main.SetActive(false);
        charactorChoose.SetActive(true);
        charactorDescription.SetActive(true);
        charactorChooseButton.SetActive(true);
        characterTransform.SetActive(true);
        backgroundAnimation.Play("StartMenu");

    }
    public void OnBackClick()
    {
        title.SetActive(true);
        Main.SetActive(true);
        charactorChoose.SetActive(false);
        charactorDescription.SetActive(false);
        charactorChooseButton.SetActive(false);
        characterTransform.SetActive(false);
        backgroundAnimation.Play("CharacterMenu");
    }

    public void ScrollCharacterLeft()
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

    public void ScrollCharacterRight()
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
