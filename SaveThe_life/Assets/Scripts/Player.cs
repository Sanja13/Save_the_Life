using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public CharacterDataBase characterDB;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;
    public float scaleFactor = 0.5f;
    private void Start()
    {
        if (PlayerPrefs.HasKey("selectedOption"))
        {
            Load();
        }
        UpadateCharachter(selectedOption);
        //ScaleSprite();

    }
    private void UpadateCharachter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    //private void ScaleSprite()
    //{
    //    
    //    Transform spriteTransform = artworkSprite.transform;
    //    spriteTransform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
    //}
}
