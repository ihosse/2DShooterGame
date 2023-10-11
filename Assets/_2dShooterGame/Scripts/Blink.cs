using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField]
    private float timeToBlink = 1;

    private void Start()
    {
        StartCoroutine(BlinkObject());
    }

    private IEnumerator BlinkObject() 
    {
        yield return new WaitForSeconds(timeToBlink);
    }
}
