using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkInteract : Interactable
{
    [SerializeField] DialogContainer dialog;

    public override void Interact(Character character)
    {
        GameManager.instance.dialogSystem.InitializeDialog(dialog);
    }

    public override void Hide(Character character)
    {
        GameManager.instance.dialogSystem.ShowDialogPanel(false);
    }
}
