using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public CharacterDataBase characterDB;

    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        Debug.Log("Character Database Length: " + characterDB.CharachterCounter);
        if (PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpadateCharachter(selectedOption);
    }
    public void NextOption()
    {
        selectedOption++;
        if(selectedOption>= characterDB.CharachterCounter)
        {
            selectedOption = 0;
        }
        UpadateCharachter(selectedOption);
        Save();
    }
    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption=characterDB.CharachterCounter - 1;
        }
        UpadateCharachter(selectedOption);
        Save();
    }

    private void UpadateCharachter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    
}
