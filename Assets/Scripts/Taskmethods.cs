using System;
using System.Collections;
using UnityEngine;

public class Taskmethods : MonoBehaviour
{
    [SerializeField, Range(0, 2)] int zone;
    //public GameObject disableThis;
    //public GameObject enableThis;
    public GameObject trigger;
    public GameObject taskCollider;
    public float waitTime = 1f;
    public float comebackTime = 5f;
    bool doing;
    public static event Action<bool> OnCarry;
    public void DisableThis(GameObject disableThis)
    {
        if(disableThis != null)
        {
            disableThis.SetActive(false);
        }
    }
    public void EnableThis(GameObject enableThis)
    {
        if (enableThis != null)
        {
            enableThis.SetActive(true);
        }
    }
    public void SawTree()
    {
        StartCoroutine("ChopTree");
    }
    IEnumerator ChopTree()
    {
        MultiplayerManager.instance.playerControllers[1].animator.SetBool("saw", true);
        yield return new WaitForSeconds(waitTime);
        MultiplayerManager.instance.playerControllers[1].animator.SetBool("saw", false);
        ZoneManager.TaskCompleted(zone);
        DisableThis(trigger);
        DisableThis(taskCollider);
    }
    public void CanComeBack()
    {
        StartCoroutine("Comeback");
    }
    public void PreventComeBack()
    {
        StopCoroutine(Comeback());
        if(doing)
        {
            Debug.Log("yay");
        }
    }
    IEnumerator Comeback()
    {
        doing = true;
        yield return new WaitForSeconds(comebackTime);
        doing = false;
    }
}
