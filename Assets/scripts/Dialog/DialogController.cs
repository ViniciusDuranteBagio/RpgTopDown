using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{

    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj;
    public Image profileSprite;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;

    //variaveis de controle
    private bool isShowing;
    private int index;
    private string[] sentences;
    private string[] sayerName;
    private Sprite[] sayerSprite;


    public static DialogController instance;

    public bool IsShowing { get => isShowing; set => isShowing = value; }

    // adicionar o nome do npc que esta falando para aparecer na ui 
    // adicionar a imagem do npc que esta falando para mudar na ui
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    //printando lettra por letra da frase a ser falada pelo npn
    IEnumerator TypeSentence() 
    {
        foreach(char letter in sentences[index].ToCharArray())
        {  
            speechText.text += letter;
            actorNameText.text = sayerName[index];
            profileSprite.sprite = sayerSprite[index];
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentecene() 
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                actorNameText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                actorNameText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    public void Speech(string[] txt, string[] actorName, Sprite[] actorSprite)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            sayerName = actorName;
            sayerSprite = actorSprite;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }

}
