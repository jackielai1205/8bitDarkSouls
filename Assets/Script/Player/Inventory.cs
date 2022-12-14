using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] items;
    public GameObject currencyText;
    public static int currencyCoins;

    // Start is called before the first frame update
    void Start()
    {
        currencyCoins = PlayerPrefs.GetInt("currency");
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.GetComponent<Text>().text = "Coins: " + currencyCoins;
        PlayerPrefs.SetInt("currency", currencyCoins);
    }
}
