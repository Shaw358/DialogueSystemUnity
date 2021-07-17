using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OverworldNpc))]
public class CharacterTextContainer : MonoBehaviour
{
    public List<string> texts = new List<string>();
    public List<Sprite> faces = new List<Sprite>();
    public List<string> names = new List<string>();

}
