using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo1 : MonoBehaviour
{


    public TextMeshProUGUI dialogueText;

    public string[] lines;

    public float TextSpeed = 0.1f;

    int index;

    private bool didDialogueStart;


    void Start()
    {
        dialogueText.text = string.Empty; 
        StartDialogue();
        
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if (!didDialogueStart) 
            {
                StartDialogue();
            }
            else if (dialogueText.text == lines[index])
            {
                NextLine();

            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        }
        else if (!didDialogueStart)
        {
            StartDialogue();
        }
        else if (dialogueText.text == lines[index])
        {
            NextLine();

        }

    }

    public void StartDialogue()
    {
        didDialogueStart = true;
        index = 0;
        StartCoroutine(Writeline());

    }

    IEnumerator Writeline()
    {
        dialogueText.text = string.Empty;
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;

            yield return new WaitForSeconds(TextSpeed);
            
        }

    }

    public void NextLine()
    {
        if(index < lines.Length-1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(Writeline());

        }
        else
        {
            didDialogueStart = false;
            gameObject.SetActive(false);

        }
    }

    
}
