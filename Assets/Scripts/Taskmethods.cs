using System;
using System.Collections;
using UnityEngine;

public class Taskmethods : MonoBehaviour
{
    [SerializeField, Range(0, 2)] int zone;
    public GameObject disableThis;
    public GameObject enableThis;
    public float waitTime = 1f;
    bool doing;
    public static event Action<bool> OnCarry;
    public void DisableThis()
    {
        if(disableThis != null)
        {
            disableThis.SetActive(false);
        }
    }
    public void EnableThis()
    {
        if (enableThis != null)
        {
            enableThis.SetActive(true);
        }
    }
    public void CanComeBack()
    {
        StartCoroutine("Comeback");
    }
    public void PreventComeBack()
    {
        StopAllCoroutines();
        if(doing)
        {
            Debug.Log("yay");
        }
    }
    IEnumerator Comeback()
    {
        doing = true;
        yield return new WaitForSeconds(waitTime);
        doing = false;
    }
}
