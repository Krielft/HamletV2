using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject dialogueSpawn;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject dialogueContent;

    private WritingEffect writingEffect;


    public void StartDialogue() // Setup Dialogue Box 
    {
        dialogueBox.SetActive(true);
        dialogueSpawn.SetActive(false);
        writingEffect = GetComponent<WritingEffect>();
        CloseDialogueBox();
        ShowDialogue(dialogueContent);
    }

    public void ShowDialogue(DialogueObject dialogueObject) // Dialogue Box Begin
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject) // Letters Detector
    {
        for(int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];

            yield return RunTypingEffect(dialogue);                  // Writing Effect

            textLabel.text = dialogue;

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        CloseDialogueBox();
    }

    private IEnumerator RunTypingEffect(string dialogue) // Writing Effect Activator
    {
        writingEffect.Run(dialogue, textLabel);

        while (writingEffect.IsRunning) // Writing Effect Detector
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Space)) // Writing Effect Skip
            {
                Debug.Log("Skip");
                writingEffect.Stop();
            }
        }
    }

    private void CloseDialogueBox() 
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
