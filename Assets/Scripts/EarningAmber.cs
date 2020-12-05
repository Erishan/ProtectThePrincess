using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarningAmber : MonoBehaviour
{
    [SerializeField] int earningPerSecond = 1;
    // [SerializeField] int addToAmbers = 0;
    // GameAmbers gameAmbers;

    // Start is called before the first frame update
    // IEnumerator Start()
    // {
    //     gameAmbers = FindObjectOfType<GameAmbers>();
    //     while (true)
    //     {
    //         yield return new WaitForSeconds(2f);
    //         GetAddingAmbers();
    //     }
    // }

    public void GetAddingAmbers()
    {
        // gameAmbers.AddingAmbers(earningPerSecond);
        FindObjectOfType<GameAmbers>().AddingAmbers(earningPerSecond);
    }
}
