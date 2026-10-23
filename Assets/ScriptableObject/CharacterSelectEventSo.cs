using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Event/CharacterSelect")]
public class CharacterSelectEventSo : ScriptableObject
{
    public GameObject player1;
    //public GameObject player2;
    public void SelectCharacter (GameObject character)
    {
        player1 = character;
    }
}
