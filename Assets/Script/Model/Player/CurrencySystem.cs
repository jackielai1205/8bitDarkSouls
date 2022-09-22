using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencySystem : MonoBehaviour
{
    public GameObject currencyText;
    public static int currencyCoins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.GetComponent<Text>().text = "Coins: " + currencyCoins;
    }
}
