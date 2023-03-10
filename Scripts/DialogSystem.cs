using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    
    [SerializeField] Text targetText;
    [SerializeField] Text nameText;
    [SerializeField] Image profilePhoto;

    DialogContainer currentDialog;
    int currentTextLine;
    [Range(0f,1f)]
    [SerializeField] float visibleTextPercent;
    [SerializeField] float timePerLetter = 0.05f;
    float totalTimeToType, currentTime;
    string lineToShow;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PushText();
        }

        TypeOutText();
    }

    private void TypeOutText()
    {
        if (visibleTextPercent >= 1f) return;

        currentTime += Time.deltaTime;
        visibleTextPercent = currentTime / totalTimeToType;
        visibleTextPercent = Mathf.Clamp(visibleTextPercent, 0, 1f);
        UpdateText();
    }

    private void UpdateText()
    {
        int letterCount = (int)(lineToShow.Length * visibleTextPercent);
        targetText.text = lineToShow.Substring(0, letterCount);
    }

    private void PushText()
    {
        if (visibleTextPercent < 1f)
        {
            visibleTextPercent = 1f;
            UpdateText();
            return;
        } 

        if(currentTextLine >= currentDialog.line.Count)
        {
            Conclude();
        }

        else
        {
            CycleLine();
        }
    }

    private void CycleLine()
    {
        lineToShow = currentDialog.line[currentTextLine];
        totalTimeToType = lineToShow.Length * timePerLetter;
        currentTime = 0f;
        visibleTextPercent = 0f;
        targetText.text = "";
        currentTextLine += 1;
    }

    public void InitializeDialog(DialogContainer dialogContainer)
    {
        ShowDialogPanel(true);
        currentDialog = dialogContainer;
        currentTextLine = 0;
        CycleLine();
        UpdateActor();
    }

    private void UpdateActor()
    {
        profilePhoto.sprite = currentDialog.shopKeeper.photo;
        nameText.text = currentDialog.shopKeeper.Name;
    }

    public void ShowDialogPanel(bool v)
    {
        gameObject.SetActive(v);
    }

    private void Conclude()
    {
        Debug.Log("Conversation has ended");
        ShowDialogPanel(false);
    }
}
