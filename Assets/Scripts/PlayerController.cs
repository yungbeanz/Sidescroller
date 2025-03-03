using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    private AudioSource audioSrc;

    private float jumpForce = 12f;
    private bool isGrounded = true;
    private bool dead = false;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        dirtParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded&& !dead){
            audioSrc.PlayOneShot(jumpSound);
            dirtParticle.Stop();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            anim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground")){
            dirtParticle.Play();
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Obstacle")){
            audioSrc.PlayOneShot(crashSound);
            dirtParticle.Stop();
            explosionParticle.Play();
            dead = true;
            gameManager.EndGame();
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
        }
    }
    public void Reset(){
        anim.SetBool("Death_b", false);
        dead = false;
        int index = anim.GetLayerIndex("Death");
        anim.Play("Alive", index, 1);
        dirtParticle.Play();
    }
}
