using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace IBR
{
    public class Player : MonoBehaviour
    {
        public int characterValue;
        public Button characterButton;
        public GameObject selectedCharacter;


        PlayerSelectedState playerSelection;

        public void Select()
        {
            selectedCharacter.gameObject.SetActive(true);

            CharacterSelection.Instance.SelectNewCharacter(characterValue);
        }
    }

    public enum PlayerSelectedState
    {
        Selected,
        Unselected
    }

}
