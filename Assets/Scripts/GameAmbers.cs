using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameAmbers : MonoBehaviour
{
    [SerializeField] GameObject amberPrefab;
    [SerializeField] int totalAmbers;
    CreateDefender createDefender;
    [SerializeField] TextMeshProUGUI ambersCount;
    EarningAmber earningAmbers;
    int ambersEarnings;

    private void Start()
    {
        createDefender = FindObjectOfType<CreateDefender>();
        ambersCount.text = totalAmbers.ToString();
        earningAmbers = FindObjectOfType<EarningAmber>();
    }

    public void AddingAmbers(int addToAmbers)
    {
        //Debug.Log("Add to ambers'e girdik ");
        //Debug.Log("Addto ambers after delta time is " + addToAmbers);
        totalAmbers += addToAmbers;
        //Debug.Log("Addto ambers after toplamak withatotal ambers " + addToAmbers);
        ambersCount.text = totalAmbers.ToString();
    }

    public void SpendingAmbers(int defenderCosts)
    {
        //Debug.Log("Spendin Ambers'e Girdik");
        //defenderCosts = defender.GetDefenderCosts();
        //Debug.Log("Defender Cost is " + defenderCosts);
        //Debug.Log("total amber is " + totalAmbers);
        totalAmbers -= defenderCosts;
        //Debug.Log("New total amebr is" + totalAmbers);
        ambersCount.text = totalAmbers.ToString();
    }

    public int GetTotalAmbers()
    {
        return totalAmbers;
    }
}
