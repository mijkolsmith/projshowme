using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool crouch = false;
    private bool canCrouch = false;
    private string horizontalString;
    private string jumpString;
    private string shootString;

    public GameObject bulletGO;
    private float bulletSpeed = 15;
    private bool shooting = false;

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