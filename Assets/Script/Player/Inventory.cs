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
    private Text _currencyText;
    private Text _healthText;
    private Text _staminaText;
    private Text _rejuvenationText;
    private Text _powerText;

    // Start is called before the first frame update
    void Start()
    {
        _currencyText = currencyText.GetComponent<Text>();
        _healthText = healthQuantityText.GetComponent<Text>();
        _staminaText = staminaQuantityText.GetComponent<Text>();
        _rejuvenationText = rejuvenationQuantityText.GetComponent<Text>();
        _powerText = powerQuantityText.GetComponent<Text>();
        
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
        _currencyText.text = "Coins: " + currencyCoins;
        PlayerPrefs.SetInt("currency", currencyCoins);

        //update potions quantity UI canvas
        _healthText.text = healthPotions.ToString();
        PlayerPrefs.SetInt("healthPotion", healthPotions);

        _staminaText.text = staminaPotions.ToString();
        PlayerPrefs.SetInt("staminaPotion", staminaPotions);

        _rejuvenationText.text = rejuvenationPotions.ToString();
        PlayerPrefs.SetInt("rejuvenationPotion", rejuvenationPotions);

        _powerText.text = powerPotions.ToString();
        PlayerPrefs.SetInt("powerPotion", powerPotions);
    }
}
