using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerLayer;

    public string nameActor;

    bool isPlayerOnRangeToInteract;

    public DialogueSettings dialogue;

    //talvez colocar isso tudo junto em um só array, em uma só lista, pode ocupar menos espaçõ na memoria
    private List<string> sentences = new List<string>();
    private List<string> sayerName = new List<string>();
    private List<Sprite> sayerSprites = new List<Sprite>();

    void Start()
    {
        GetNPCInfo();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerOnRangeToInteract)
        {
            DialogController.instance.Speech(sentences.ToArray(), sayerName.ToArray(), sayerSprites.ToArray());
        }
    }

    private void FixedUpdate()
    {
        ShowDialogue();
    }

    void GetNPCInfo() 
    {

        for (int i = 0; i < dialogue.dialogues.Count; i++)
        { 
            sayerName.Add(dialogue.dialogues[i].actorName);
            sayerSprites.Add(dialogue.dialogues[i].profile);

            switch (DialogController.instance.language)
            {
                case DialogController.idiom.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;
                case DialogController.idiom.eng:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;
                case DialogController.idiom.spa:
                    sentences.Add(dialogue.dialogues[i].sentence.spanish);
                    break;

            }
        }
    }
    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null) 
        {
            isPlayerOnRangeToInteract = true;
        }
        else
        {
            isPlayerOnRangeToInteract = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }


}
