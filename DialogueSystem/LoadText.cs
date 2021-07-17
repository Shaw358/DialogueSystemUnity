using System.Collections;
using TMPro;
using UnityEngine;

public class LoadText : MonoBehaviour
{
    TextInformation textInformation;

    [SerializeField] public TextMeshProUGUI characterName;
    [SerializeField] public TextMeshProUGUI textMesh;
    [SerializeField] public TextMeshProUGUI textShadow;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    public float letterDelay;
    [SerializeField] public bool isActive;

    bool pause;

    private void Awake()
    {
        if(!textMesh)
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }
        if(!audioSource)
        {
            audioSource = GetComponent<AudioSource>(); 
        }
    }

    public void SetMessage(TextInformation newTextInformation)
    {
        textInformation = newTextInformation;
        SetCharacterName();
        StartCoroutine(ShowText());
    }

    private void SetCharacterName()
    {
        characterName.text = textInformation.name;
    }

    private IEnumerator ShowText()
    {
        isActive = true;
        for (int i = 0; i < textInformation.message.Length; i++)
        {
            if(pause)
            {
                audioSource.PlayOneShot(clip);
                pause = false;
            }
            else
            {
                pause = true;
            }
            textShadow.text = string.Concat(textMesh.text, textInformation.message[i]);
            textMesh.text = string.Concat(textMesh.text, textInformation.message[i]);
            yield return new WaitForSeconds(letterDelay);
        }
        isActive = false;
    }

    public void FinishCurrentText()
    {
        if(isActive)
        {
            StopAllCoroutines();
            textShadow.text = textInformation.totalMessage;
            textMesh.text = textInformation.totalMessage;
            isActive = false;
        }
    }

    public void EmptyText()
    {
        textMesh.text = string.Empty;
        textShadow.text = string.Empty;
    }
}