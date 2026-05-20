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
    public GameObject createThis;
    public float waitTime = 1f;
    public float comebackTime = 10f;
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
    public void WaterPlant()
    {
        StartCoroutine("Water");
    }
    public void RemovePlant()
    {
        StartCoroutine("Weeding");
    }
    public void GrowPlant()
    {
        StartCoroutine("Planting");
    }
    public void RemoveTrash()
    {
        StartCoroutine("Littering");
    }
    IEnumerator ChopTree()
    {
        MultiplayerManager.instance.playerControllers[1].animator.SetBool("saw", true);
        MultiplayerManager.instance.playerControllers[1].freeze = true;
        yield return new WaitForSeconds(waitTime);
        MultiplayerManager.instance.playerControllers[1].animator.SetBool("saw", false);
        MultiplayerManager.instance.playerControllers[1].freeze = false;
        ZoneManager.TaskCompleted(zone);
        EnableThis(createThis);
        DisableThis(trigger);
        DisableThis(taskCollider);
    }
    IEnumerator Water()
    {
        MultiplayerManager.instance.playerControllers[0].animator.SetBool("water", true);
        MultiplayerManager.instance.playerControllers[0].freeze = true;
        yield return new WaitForSeconds(waitTime);
        MultiplayerManager.instance.playerControllers[0].animator.SetBool("water", false);
        MultiplayerManager.instance.playerControllers[0].freeze = false;
        ZoneManager.TaskCompleted(zone);
        EnableThis(createThis);
        DisableThis(trigger);
        DisableThis(taskCollider);
        
    }
    IEnumerator Weeding()
    {
        MultiplayerManager.instance.playerControllers[1].animator.SetBool("interact", true);
        MultiplayerManager.instance.playerControllers[1].freeze = true;
        yield return new WaitForSeconds(waitTime);
        MultiplayerManager.instance.playerControllers[1].animator.SetBool("interact", false);
        MultiplayerManager.instance.playerControllers[1].freeze = false;
        EnableThis(createThis);
        DisableThis(trigger);
        DisableThis(taskCollider);
    }
    IEnumerator Planting()
    {
        MultiplayerManager.instance.playerControllers[0].animator.SetBool("interact", true);
        MultiplayerManager.instance.playerControllers[0].freeze = true;
        yield return new WaitForSeconds(waitTime);
        MultiplayerManager.instance.playerControllers[0].animator.SetBool("interact", false);
        MultiplayerManager.instance.playerControllers[0].freeze = false;
        ZoneManager.TaskCompleted(zone);
        EnableThis(createThis);
        DisableThis(trigger);
        DisableThis(taskCollider);
    }
    IEnumerator Littering()
    {
        MultiplayerManager.instance.playerControllers[1].animator.SetBool("interact", true);
        MultiplayerManager.instance.playerControllers[1].freeze = true;
        yield return new WaitForSeconds(waitTime);
        MultiplayerManager.instance.playerControllers[1].animator.SetBool("interact", false);
        MultiplayerManager.instance.playerControllers[1].freeze = false;
        ZoneManager.TaskCompleted(zone);
        EnableThis(createThis);
        DisableThis(trigger);
        DisableThis(taskCollider);
    }
    public void CanComeBack(GameObject thebacker)
    {
        StartCoroutine("Comeback", thebacker);
    }
    public void PreventComeBack()
    {
        //StopCoroutine(Comeback(gameObject));
        if(doing)
        {
            doing = false;
            ZoneManager.TaskCompleted(zone);
            Debug.Log("yay");
        }
    }
    IEnumerator Comeback(GameObject thebacker)
    {
        doing = true;
        yield return new WaitForSeconds(comebackTime);
        if(doing)
        {
            thebacker.SetActive(true);
            DisableThis(createThis);
        }
        doing = false;
        
        
    }
}
