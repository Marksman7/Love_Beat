using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Novel_Dio : MonoBehaviour
{
    public string[] characters;
    public string[] dialogue_character;
    public Image Background;
    public Image[] character_art;
    public Sprite[] insert_art_character;
    public Sprite insert_art_background;
    public TextMeshProUGUI dialogue_box;
    public TextMeshProUGUI character_name_box;

    private int character_number = 0;
    private int dialogue_counter = 0;
    
    void Start()
    {
        int im_char = 0;
        foreach(Image im in character_art)
        {
            im.sprite = insert_art_character[im_char];
            im_char = im_char + 1;
        }
        Background.sprite = insert_art_background;

        if(dialogue_box == null)
        {
            Debug.Log("There is no dialogue_box connected");
        }

        Start_dialogue_line();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Next_dialogue_line();
        }
    }

    void Start_dialogue_line()
    {
        if(characters[0] != null)
        {
            Debug.Log("notpe");
        }
        dialogue_box.text = dialogue_character[0];//dialogue_counter
        character_name_box.text = characters[character_number];//character_number

        Next_character_art_image();
    }

    void Next_dialogue_line()
    {
        dialogue_counter = dialogue_counter + 1;

        if (dialogue_counter >= dialogue_character.Length)
        {
            ActivateChoices();
        }
        else
        {
            dialogue_box.text = dialogue_character[dialogue_counter];
            Next_character_line();
        }

    }

    void Next_character_line()
    {

        character_number = character_number + 1;
        if (character_number >= characters.Length)
        {
            character_number = 0;
            character_name_box.text = characters[character_number];
            Next_character_art_image();
        }
        else
        {
            character_name_box.text = characters[character_number];
            Next_character_art_image();
        }
    }

    void Next_character_art_image()
    {
        
        if(character_number == 0)
        {
            character_art[characters.Length - 1].GetComponent<Image>().color = new Color32(255, 255, 225, 75);
        }
        else
        {
            character_art[character_number - 1].GetComponent<Image>().color = new Color32(255, 255, 225, 75);
        }
        character_art[character_number].GetComponent<Image>().color = new Color32(255, 255, 225, 225);

    }

    void ActivateChoices()
    {
        this.transform.GetComponent<Choice>().activated();
    }
}
