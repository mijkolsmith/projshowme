using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCooldown : MonoBehaviour
{
    [SerializeField]
    private float seconds;

    private bool coolDownTimer;

    // Start is called before the first frame update
    void Start()
    {
        coolDownTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (coolDownTimer == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                coolDownTimer = true;

                StartCoroutine(CooldownSeconds());
            }
        }
    }

    private IEnumerator CooldownSeconds()
    {
        yield return new WaitForSeconds(seconds);

        coolDownTimer = false;
    }
}
