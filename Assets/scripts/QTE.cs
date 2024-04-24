using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour
{
    private bool canPress;
    public int TempsApparition = 5;
    public int TempsActivation = 2;
    public int TempsPresence = 3;
    public GameObject barre1;
    public GameObject barre2;

    void Start()
    {
        canPress = false;
        barre1.SetActive(false);
        barre2.SetActive(false);
        StartCoroutine("beforeActiv");
    }
    void Update()
    {
        if (canPress && Input.GetButtonDown("Fire1"))
        {
            print("done");
            close();
        }else if(!canPress && Input.GetButtonDown("Fire1"))
        {
            print("trop tot");
        }
    }
    IEnumerator beforeActiv()
    {
        yield return new WaitForSeconds(TempsApparition);
        barre1.SetActive(true);
        StartCoroutine("openQTE");
    }

    IEnumerator openQTE()
    {
        yield return new WaitForSeconds(TempsActivation);
        print("test");
        canPress = true;
        barre1.SetActive(false);
        barre2.SetActive(true);
        StartCoroutine("closeQTE");
    }
    IEnumerator closeQTE()
    {
        yield return new WaitForSeconds(TempsPresence);
        close();
    }
    void close()
    {
        print("closed");
        canPress = false;
        barre2.SetActive(false);
    }
}
