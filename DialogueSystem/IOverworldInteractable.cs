using UnityEngine;

public interface IOverworldInteractable
{
    void Interact(Party party = null, GameObject player = null);
    bool ConditionsMet(Party party = null);
}