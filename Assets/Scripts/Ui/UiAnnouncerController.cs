using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnnouncerController : MonoBehaviour
{
    [SerializeField]
    private GameObject sunsetMsg;
    [SerializeField]
    private GameObject sunriseMsg;
    void Start()
    {
        GameManager.Instance.dayCycle.startNight += SunriseTextCoroutine;
        GameManager.Instance.dayCycle.endNight += SunsetTextCoroutine;
    }


    private void SunsetTextCoroutine()
    {

        StartCoroutine(SunsetText());
    }

    IEnumerator SunsetText()
    {
        Debug.Log("SunsetText »£√‚");
        sunsetMsg.SetActive(true);

        yield return new WaitForSeconds(3f);

        sunsetMsg.SetActive(false);
    }

    private void SunriseTextCoroutine()
    {
        StartCoroutine(SunRiseText());
    }

    IEnumerator SunRiseText()
    {

        sunriseMsg.SetActive(true); 

        yield return new WaitForSeconds(3f);

        sunriseMsg.SetActive(false);
    }
}
