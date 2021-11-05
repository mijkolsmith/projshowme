using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCooldown : MonoBehaviour
{
    [SerializeField]
    private float seconds;

    [SerializeField]
    private bool coolDownTimer;

    // Start is called before the first frame update
    void Start()
    {
        coolDownTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (coolDownTimer == false)
        //{
        //    // A ability starts
        //    if (Input.GetButtonDown(shootString))
        //    {
        //        coolDownTimer = true;

        //        StartCoroutine(CooldownSeconds());
        //    }
        //}
    }

    private IEnumerator CooldownSeconds()
    {
        // Timer starts - No ability possible
        yield return new WaitForSeconds(seconds);

        // Timer ends - Ability possible
        coolDownTimer = false;
    }
}
