using UnityEngine;

[System.Serializable]
public class TextInformation
{
    public string name;
    public Sprite characterPicture;
    public string message;

    public string totalMessage;

    public TextInformation(string newName, string newMessage, Sprite newCharacterPicture = null)
    {
        characterPicture = newCharacterPicture;
        name = newName;
        message = newMessage;

        BuildTotalMessage();
    }

    private void BuildTotalMessage()
    {
        totalMessage = name + "\n\n" + message;
    }
}