using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // public Item[] items;
    public GameObject currencyText;
    public GameObject healthQuantityText;
    public GameObject staminaQuantityText;
    public GameObject rejuvenationQuantityText;
    public GameObject powerQuantityText;

    public static int currencyCoins;
    public static int healthPotions;
    public static int staminaPotions;
    public static int rejuvenationPotions;
    public static int powerPotions;

    // Start is called before the first frame update
    void Start()
    {
        currencyCoins = PlayerPrefs.GetInt("currency");
        healthPotions = PlayerPrefs.GetInt("healthPotion");
        staminaPotions = PlayerPrefs.GetInt("staminaPotion");
        rejuvenationPotions = PlayerPrefs.GetInt("rejuvenationPotion");
        powerPotions = PlayerPrefs.GetInt("powerPotion");
    }

    // Update is called once per frame
    void Update()
    {
        //update coins quantity UI canvas
        currencyText.GetComponent<Text>().text = "Coins: " + currencyCoins;
        PlayerPrefs.SetInt("currency", currencyCoins);

        //update potions quantity UI canvas
        healthQuantityText.GetComponent<Text>().text = healthPotions.ToString();
        PlayerPrefs.SetInt("healthPotion", healthPotions);

        staminaQuantityText.GetComponent<Text>().text = staminaPotions.ToString();
        PlayerPrefs.SetInt("staminaPotion", staminaPotions);

        rejuvenationQuantityText.GetComponent<Text>().text = rejuvenationPotions.ToString();
        PlayerPrefs.SetInt("rejuvenationPotion", rejuvenationPotions);

        powerQuantityText.GetComponent<Text>().text = powerPotions.ToString();
        PlayerPrefs.SetInt("powerPotion", powerPotions);
    }
}
