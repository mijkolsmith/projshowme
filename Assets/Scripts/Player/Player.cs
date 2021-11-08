using System.Collections;
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

    public PlayerController controller;
    public float horizontalMove = 0f;
    public float runSpeed = 40f;
    public bool jump = false;
    private string horizontalString;
    private string jumpString;
    private string shootString;

    public GameObject bulletGO;
    private bool shooting = false;

    public Image cooldownImage;
    [SerializeField] private float cooldownTime;
    [SerializeField] private bool isCooldown = false;

    private void Start()
    {
        horizontalString = gameObject.name + " Horizontal";
        jumpString = gameObject.name + " Vertical";
        shootString = gameObject.name + " Shoot";
        controller = GetComponent<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw(horizontalString) * runSpeed;
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
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public IEnumerator Shoot()
    {
        shooting = true;
        //GameObject bullet = Instantiate(bulletGO, transform.localPosition, Quaternion.identity, null);
        //bullet.GetComponent<Bullet>().Initialize(Camera.main.ScreenToWorldPoint(Input.mousePosition), bulletSpeed);
        yield return new WaitForSeconds(.2f);
        shooting = false;
    }
}