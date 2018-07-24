using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExitButton : Button {

    public override void OnPointerClick(PointerEventData eventData)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		    Application.Quit();
#endif
    }

    protected override void Awake()
    {
        base.Awake();
    }

}
