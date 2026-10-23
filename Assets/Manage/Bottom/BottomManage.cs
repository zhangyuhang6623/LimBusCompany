using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomManage : MonoBehaviour
{
    public CharacterSelectEventSo characterSelect;
    public Button button;
    private void Awake()
    {
        button=GetComponent<Button>();
    }
    private void Update()
    {
        if (characterSelect.player1 != null)
        {
            button.interactable = true;
        }
        else {
            button.interactable = false;
        }
    }
}
