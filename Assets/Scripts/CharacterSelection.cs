using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IBR
{
    /// <summary>
    /// CharacterSelection. Future development will add more characters.
    /// This will be used to store the selection and then use it in GameManager to instantiate in the game.
    /// </summary>
    public class CharacterSelection : MonoBehaviour
    {
        public static CharacterSelection Instance;
        public List<GameObject> Players;
        public int selectedCharacterValue;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        void Start()
        {
            PlayerPrefs.SetInt("selectedCharacter", selectedCharacterValue);
        }

        public void SelectNewCharacter(int characterValue)
        {
            selectedCharacterValue = characterValue;
            PlayerPrefs.SetInt("selectedCharacter", selectedCharacterValue);

            foreach (var player in Players)
            {
                if (player.GetComponent<Player>().characterValue != selectedCharacterValue)
                {
                    player.GetComponent<Player>().selectedCharacter.SetActive(false);
                    player.GetComponent<Player>().characterButton.gameObject.SetActive(true);
                }
            }
        }
    }
}

