using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OverworldNpc : MonoBehaviour, IOverworldInteractable
{
    public new string name;
    public List<TextInformation> textInformation = new List<TextInformation>();
    [SerializeField] TextBox textBox;
    public bool useGenericText = false;

    NPCAnimator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<NPCAnimator>();

        if(textInformation.Count > 0 || useGenericText)
        {
            textBox = GameObject.Find("TextInteraction").GetComponent<TextBox>();
        }
    }

    public void Interact(Party party = null, GameObject player = null)
    {
        animator.LookAt(player.GetComponent<CharacterRaycastOverworld>().lastDirection);
        if (ConditionsMet(party))
        {
            if (textBox.loadText.textMesh.text == string.Empty)
            {
                // Start saying text on first interaction
                textBox.EnableText();
                for (int i = 0; i < GetTextCount(); i++)
                {
                    Debug.Log(textInformation[i].message);
                    textBox.AddText(textInformation[i]);
                }
            }

            if (textBox.loadText.isActive)
            {
                textBox.loadText.FinishCurrentText();
                return;
            }
            else if (ConditionsMet(party))
            {
                // Next text box
                textBox.EnableText();
                textBox.NextText();
            }
        }
    }

    public bool ConditionsMet(Party party = null)
    {
        if (textInformation != null)
        {
            return true;
        }
        return false;
    }

    public int GetTextCount()
    {
        return textInformation.Count;
    }
}