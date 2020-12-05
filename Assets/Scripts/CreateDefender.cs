using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDefender : MonoBehaviour
{
    Defender defenderPrefab;
    int defenderCreationCosts;
    GameAmbers gameAmbers;
    int totalAmbers;
    Defender newDefender;
    Defender defender;

    BTNCreateDefender btnNewDefender;

    // Start is called before the first frame update
    void Start()
    {
        gameAmbers = FindObjectOfType<GameAmbers>();
        defender = FindObjectOfType<Defender>();
        btnNewDefender = FindObjectOfType<BTNCreateDefender>();
    }


    private void OnMouseDown()
    {
        SpawnDefender(DefenderCoordinate());
    }

    public void SetDefenderPrefab(Defender defenderToSelect, int defenderCosts)
    {
        defenderPrefab = defenderToSelect;
        defenderCreationCosts = defenderCosts;
    }

    private Vector2 DefenderCoordinate()
    {
        Vector2 curPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(curPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        Debug.Log(newX + " ve " + newY);
        //newX = newX + 0.3;
        //newY = newY +3;
        //Debug.Log("Yeni " + newX + " ve " + newY);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 IntWorldPos)
    {
        totalAmbers = gameAmbers.GetTotalAmbers();
        bool isThereAnyDef = Physics2D.OverlapCircle(IntWorldPos, 1);
        Debug.Log("isThereAnyDef " + isThereAnyDef);
        if (defenderCreationCosts <= totalAmbers)
        {
            gameAmbers.SpendingAmbers(defenderCreationCosts);
            newDefender = Instantiate(defenderPrefab, IntWorldPos, Quaternion.identity) as Defender;
        }
    }

}
