using UnityEngine;
using UnityEngine.UI;

namespace IBR
{
    /// <summary>
    /// Contains several UI elements and logic for selecting/deselecting.
    /// </summary>
    public class CharacterSelect : MonoBehaviour
    {
        public string id;

        public int value;

        public GameObject select;

        public GameObject selected;


        //sets the initial purchase/selection state
        void Awake()
        {
            //the product has not been bought yet, but it is not marked as buyable
            //on the App Store either. Meaning we hide the buy button and show the
            //select button for it directly instead.

            select.SetActive(true);

        }

        //validates the value saved on the device against the value of this product: if they match,
        //this means that we previously selected this product and reinitialize it as selected again
        void Start()
        {
            if (PlayerPrefs.GetString(PlayerPrefKeys.activeCharacter) == value.ToString())
                IsSelected(true);
        }

        /// <summary>
        /// For already bought products: sets this product UI state to 'selected' and saves the
        /// current selection value on the device. If a product gets selected, this method is
        /// called for all other products in the same group too, with the boolean being false.
        /// Thus both the logic for selection and deselection is handled within this method.
        /// Invoked by the onValueChanged event on the select button inspector.
        /// </summary>
        public void IsSelected(bool thisSelect)
        {

            //if this object has been selected
            if (thisSelect)
            {
                //get a reference to the Toggle component on the select button
                Toggle toggle = select.GetComponent<Toggle>();

                //in case this product is part of a group of items
                if (toggle.group)
                {
                    //because Toggle components on deactivated gameobjects do not receive onValueChanged events,
                    //here we implement a hacky way to deselect all other Toggles, even deactivated ones
                    CharacterSelect[] others = toggle.group.GetComponentsInChildren<CharacterSelect>(true);
                    for (int i = 0; i < others.Length; i++)
                    {
                        //unselect the character if it is not the selected character.
                        if (others[i].select != null && others[i] != this)
                        {
                            others[i].IsSelected(false);
                        }
                    }
                }

                //display that this character is selected
                toggle.isOn = true;
                select.SetActive(false);
                if (selected) selected.SetActive(true);

                //save the selection value to the device
                PlayerPrefs.SetString(PlayerPrefKeys.activeCharacter, value.ToString());
            }
            else
            {
                //if another object has been selected, show the select button
                //for this product and unset the 'selected' state
                if (select) select.SetActive(true);
                if (selected) selected.SetActive(false);
            }
        }
    }
}
