using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialog")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialog")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Lenguages sentence;
}

[System.Serializable]
public class Lenguages
{
    public string portuguese;
    public string english;
    public string spanish;
}

 //no curso ele ensina a fazer esse if  porem ele não precisa ser feito
 //pois na versão atual do editor da Unity
 //existe um botão para adicionar um item em um list
   /**
    * #if UNITY_EDITOR
    [CustomEditor(typeof(DialogueSettings))]
    public class BuilderEditor : Editor 
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            DialogueSettings ds = (DialogueSettings)target;

            Lenguages l = new Lenguages();
            l.portuguese = ds.sentence;

            Sentences s = new Sentences();
            s.profile = ds.speakerSprite;
            s.sentence = l;

            if (GUILayout.Button("Create Dialogue"))
            {
                if(ds.sentence != "")
                {
                    ds.dialogs.Add(s);
                    ds.speakerSprite = null;
                    ds.sentence = "";
                }
            }
        }
    }
    #endif
   */
   