using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNCreateDefender : MonoBehaviour
{

    [SerializeField] Defender defenderPrefab;
    [SerializeField] int defenderCreationCosts;

    GameAmbers gameAmbers;
    CreateDefender createDefender;
    Defender defender;

    // Start is called before the first frame update
    void Start()
    {
        gameAmbers = FindObjectOfType<GameAmbers>();
        createDefender = FindObjectOfType<CreateDefender>();
        defender = FindObjectOfType<Defender>();
    }

    private void OnMouseDown()
    {
        //Debug.Log("OBJE ADI ONMOUSEDOWN" + gameObject.name);
        var buttons = FindObjectsOfType<BTNCreateDefender>();
        foreach (BTNCreateDefender button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(82, 82, 82, 255);
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        //defenderPrefab = defender.GetDefenderPrefab();
        createDefender.SetDefenderPrefab(defenderPrefab, defenderCreationCosts);
        //defender.CallTheDefender();
    }

    public int GetDefenderCosts()
    {
        //Debug.Log("OBJE ADI COSTS" + gameObject.name);

        return defenderCreationCosts;
    }
}
