using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IBR
{
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
        // Start is called before the first frame update
        void Start()
        {
            PlayerPrefs.SetInt("selectedCharacter", selectedCharacterValue);
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(PlayerPrefs.GetInt("selectedCharacter"));
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

