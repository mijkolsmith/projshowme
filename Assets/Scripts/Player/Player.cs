using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private bool invincible = false;
    SpriteRenderer sr;

    private IEnumerator Invincibility()
	{
        invincible = true;
		for (int i = 0; i < 10; i++)
		{
            sr.enabled = false;
            yield return new WaitForSeconds(.1f);
            sr.enabled = true;
        }
        invincible = false;
	}

    private PlayerController controller;
    private float horizontalMove = 0f;
    public float runSpeed = 40f;
    public float speedBoost;
    private bool jump = false;
    private string horizontalString;
    private string jumpString;
    private string shootString;

    public Ability ability;
    public GameObject boxPrefab;
    public Image cooldownImage;
    [SerializeField] private float cooldownTime;
    [SerializeField] private bool isCooldown = false;

    public GameObject bulletGO;
    private bool shooting = false;

    public List<Player> players;

    public GameObject grapplingHook;
    public bool facingRight;

    private void Start()
    {
        horizontalString = gameObject.name + " Horizontal";
        jumpString = gameObject.name + " Vertical";
        shootString = gameObject.name + " Shoot";
        controller = GetComponent<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
        players = transform.parent.GetComponentsInChildren<Player>().ToList();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw(horizontalString) * (runSpeed + speedBoost);
        if (Input.GetButtonDown(jumpString))
        {
            jump = true;
        }
        if (Input.GetButton(shootString) == true && shooting == false)
		{
            StartCoroutine(Shoot());
		}

        if (isCooldown == false)
        {
            // Ability 1 starts
            if (Input.GetButtonDown(shootString))
            {
                UseAbility();
                isCooldown = true;
            }
        }

        if (isCooldown)
		{
            // Cooldown animation & Timer
            cooldownImage.fillAmount += (1 / cooldownTime) * Time.deltaTime;

            if (cooldownImage.fillAmount >= 1)
			{
                cooldownImage.fillAmount = 0;
                isCooldown = false;
			}
		}
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
        facingRight = controller.facingRight;
    }

    public IEnumerator Shoot()
    {
        shooting = true;
        //GameObject bullet = Instantiate(bulletGO, transform.localPosition, Quaternion.identity, null);
        //bullet.GetComponent<Bullet>().Initialize(Camera.main.ScreenToWorldPoint(Input.mousePosition), bulletSpeed);
        yield return new WaitForSeconds(.2f);
        shooting = false;
    }

    void UseAbility()
	{
        if (ability == Ability.GRAPPLE)
		{
            grapplingHook.SetActive(true);
            grapplingHook.GetComponent<GrapplingHook>().player = this;
		}
        if (ability == Ability.BOX)
		{
            Instantiate(boxPrefab, transform.localPosition, Quaternion.identity);
		}
        if (ability == Ability.DASH)
		{
            StartCoroutine(Dash());
		}
	}

    IEnumerator Dash()
	{
        speedBoost += 30;
        yield return new WaitForSeconds(.3f);
        speedBoost -= 30;
	}
}