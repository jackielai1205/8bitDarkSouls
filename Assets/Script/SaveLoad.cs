using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public Player player;

    void Update() {
        if (PlayerPrefs.GetInt("GameLoaded") == 1){
            PlayerPrefs.SetInt("GameLoaded", 0);
            LoadCharacter();
        }
        // Comment the following to not have saving buttons
        if (Input.GetKeyDown(KeyCode.K)) {
            SaveCharacter();
            
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            LoadCharacter();
        }
        // Essentialy only for debugging reasons, deletes the save
        if (Input.GetKeyDown(KeyCode.J)) {
            PlayerPrefs.DeleteAll();
        }
        
        // Probably something to use with checkpoints
        if (Input.GetKeyDown(KeyCode.H)) {
            StartCoroutine(CharacterRespawn());
        }
        // This if statement checks when player is dead.
        // Launches respawn after 2 seconds.
        if (player.currentHealth <= 0) {
            StartCoroutine(CharacterRespawn());
        }
    }
    /*
    The idea behind using SaveCharacter and load character
    is to be used while moving from one location to another.
    It is a convinient way to remember where character entered
    a location and where he left it.
    */
    public void SaveCharacter() {
        Vector3 playerPos = player.transform.position;

        // Saving a position
        PlayerPrefs.SetFloat("playerPositionX", playerPos.x);
        PlayerPrefs.SetFloat("playerPositionY", playerPos.y);
        // PLayer Stats
        PlayerPrefs.SetInt("playerST", player.stamina);
        PlayerPrefs.SetInt("playerHP", player.health);
        PlayerPrefs.SetInt("playerDMG", player.damage);

        PlayerPrefs.SetInt("playerCurrentST", player.currentStamina);
        PlayerPrefs.SetInt("playerCurrentHP", player.currentHealth);
        // Saving coints
        PlayerPrefs.SetInt("playerCoins", Inventory.currencyCoins);

        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);

        PlayerPrefs.Save();

        /*
        For a more complex way of saving: everything could be
        translated to binary and saved to the custom file
        but I don't feel like it would be necessery for this case.
        */
    }

    public void LoadCharacter() {
        // Loading Player's pos
        float playerPosX = PlayerPrefs.GetFloat("playerPositionX");
        float playerPosY = PlayerPrefs.GetFloat("playerPositionY");
        // Loading stats
        player.stamina = PlayerPrefs.GetInt("playerST");
        player.health = PlayerPrefs.GetInt("playerHP");
        player.damage = PlayerPrefs.GetInt("playerDMG");
        player.currentStamina = PlayerPrefs.GetInt("playerCurrentST");
        player.currentHealth = PlayerPrefs.GetInt("playerCurrentHP");
        Inventory.currencyCoins = PlayerPrefs.GetInt("playerCoins");
        // Triggering UI Rerender
        player.RecoverHealth(0);
        player.UseStamina(0);

        Vector3 playerPos = new Vector3(playerPosX, playerPosY,0);
        player.transform.position = playerPos;
    }

    /*
    The idea behind character reaspawn is that
    it is not going to move character to a particular saved
    position but also restart the scene restoring his hp,
    respawning enemies and basically doing the same stuff as
    respawning in dark souls did. Essentially this function runs after 3 secs
    */
    IEnumerator CharacterRespawn() {
        // Saving a PlayerHasDied state
        PlayerPrefs.SetInt("PlayerHasDied", 1);
        PlayerPrefs.Save();
        // Waiting 3 seconds
        yield return new WaitForSeconds(2);
        // Reloading scene
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));

    }
}
