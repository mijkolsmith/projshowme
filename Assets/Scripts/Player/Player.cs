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
    private string crouchString;

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

    public DisablePlatform disablePlatform;

    private void Start()
    {
        horizontalString = gameObject.name + " Horizontal";
        jumpString = gameObject.name + " Vertical";
        shootString = gameObject.name + " Shoot";
        crouchString = gameObject.name + " Crouch";
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

        if (Input.GetButton(crouchString))
		{
            if (disablePlatform != null)
            {
                StartCoroutine(disablePlatform.Disable());
            }
		}

        if (isCooldown == false)
        {
            // Ability 1 starts
            if (Input.GetButtonDown(shootString))
            {
                UseAbility();
                isCooldown = true;
                cooldownImage.fillAmount = 0;
            }
        }

        if (isCooldown)
        {
            // Cooldown animation & Timer
            cooldownImage.fillAmount += (1 / cooldownTime) * Time.deltaTime;

            if (cooldownImage.fillAmount >= 1)
            {
                cooldownImage.fillAmount = 1;
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
			grapplingHook.GetComponentInChildren<GrapplingHook>().ExecuteCoroutine(this, grapplingHook.transform);
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
        controller.rigidbody2D.gravityScale -= 1;
        yield return new WaitForSeconds(.3f);
        controller.rigidbody2D.gravityScale += 1;
        speedBoost -= 30;
    }

    private void OnCollisionEnter2D(Collision2D collision)
	{
        // Crouch
        if (collision.gameObject.layer == 3) // 3 for ground
        {
            if (disablePlatform == null)
            {
                disablePlatform = collision.gameObject.GetComponent<DisablePlatform>();
            }
        }
    }

	private void OnCollisionExit2D(Collision2D collision)
	{
        // Crouch
        if (collision.gameObject.layer == 3) // 3 for ground
        {
            if (disablePlatform != null)
            {
                disablePlatform = null;
            }
        }
    }
}