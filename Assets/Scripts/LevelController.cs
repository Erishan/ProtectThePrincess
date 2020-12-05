using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int howManyAttackersAlive;
    [SerializeField] GameObject winningLabel;
    [SerializeField] GameObject lostLabel;
    [SerializeField] float waitingForWinningScreen;
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioClip audioClipLost;
    LevelLoader levelLoader;
    Attacker[] attackers;
    Defender[] defenders;
    GameTimer gameTimer;
    bool doesIt = false;
    bool playerContinues = true;

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        winningLabel.SetActive(false);
        lostLabel.SetActive(false);
    }

    public void AddAttacker()
    {
        howManyAttackersAlive++;
    }

    // Update is called once per frame
    void Update()
    {
        doesIt = gameTimer.GetDoesTimePassed();
        attackers = FindObjectsOfType<Attacker>();
        defenders = FindObjectsOfType<Defender>();
    }

    public void AttackerKilled()
    {
        howManyAttackersAlive--;
        if (howManyAttackersAlive <= 0 && doesIt)
        {
            StartCoroutine(WinningMode());
        }
    }

    IEnumerator WinningMode()
    {
        winningLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(audioClip,transform.position,1f);
        yield return new WaitForSeconds(waitingForWinningScreen);
        GetComponent<LevelLoader>().LevelLoading();
    }

    public void PlayerLost()
    {
        playerContinues = false;
        lostLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(audioClipLost, transform.position, 1f);
        foreach (Attacker attacker in attackers)
        {
            Destroy(attacker.gameObject);
        }
        foreach (Defender defender in defenders)
        {
            Destroy(defender.gameObject);
        }
        FindObjectOfType<AttackerSpawn>().StopSpawning();
    }

    public bool PlayerContinues()
    {
        return playerContinues;
    }

}
