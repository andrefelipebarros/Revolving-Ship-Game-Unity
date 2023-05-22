using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveNave3D : MonoBehaviour
{
    public Rigidbody rgb;
    public float moveSpeed;
    public float rotationSpeed;

    public float boostMultiplier;
    public float boostDuration;
    public float boostCooldown;

    [SerializeField]private bool isBoosting;
    private float boostTimer;
    private float boostCooldownTimer;
    public GameObject Boost;

    ////

    [SerializeField] private GameObject painelMenu;
    public bool painelMenuBool;
    private bool isPaused = false;
    [SerializeField]private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        MenuBool();

        // Obtém a entrada do teclado nos eixos X e Y
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calcula o vetor de movimento com base na entrada do teclado
        Vector3 movement = new Vector3(moveX, moveY, 1f) * moveSpeed;

        ////

        // Verifica se a tecla de espaço está pressionada e se o boost não está em cooldown
        if (Input.GetKey(KeyCode.Space) && boostCooldownTimer <= 0)
        {
            // Inicia o boost
            if (!isBoosting)
            {
                isBoosting = true;
                boostTimer = boostDuration;
                boostCooldownTimer = boostCooldown;

                // Reproduz o efeito sonoro
                //
            }

            // Aplica o multiplicador de boost ao vetor de movimento
            movement *= boostMultiplier;

            // Reduz o tempo restante do boost
            boostTimer -= Time.deltaTime;

            // Verifica se o boost terminou
            if (boostTimer <= 0)
            {
                isBoosting = false;
                Boost.SetActive(false);

                // Para o efeito sonoro
                //
            }
            else
            {
                Boost.SetActive(true); // Ativa o GameObject do boost
            }
        }
        else
        {
            // Reduz o cooldown do boost
            boostCooldownTimer -= Time.deltaTime;

            Boost.SetActive(false); // Desativa o GameObject do boost
        }

        ////

        // Aplica o movimento apenas nos eixos X e Y (Z é mantido mas caso não queira só dar um frezz)
        rgb.velocity = new Vector3(movement.x, movement.y, movement.z);

        // Obtém a entrada do mouse para o giro
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Calcula a rotação do objeto
        float rotationAmount = scrollInput * rotationSpeed * Time.deltaTime;

        // Aplica a rotação ao objeto em torno do eixo vertical (Y)
        transform.Rotate(0f, 0f, rotationAmount);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("plataforma"))
        {
            // Destruir a plataforma
            Destroy(other.gameObject);

            // Reiniciar o jogo
            ReiniciarJogo();
        }
    }

    private void ReiniciarJogo()
    {
        // Aqui você pode adicionar a lógica para reiniciar o jogo
        // Por exemplo, recarregar a cena atual

        // Reiniciar o jogo carregando a cena "SampleScene"
        Application.LoadLevel("SampleScene");
    }

    private void MenuBool()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Função responsável pela booleana
            if (isPaused)
            {
                ResumeMenu();
            }
            else
            {
                PauseMenu();
            }
        }
    }

    private void PauseMenu()
    {
        Time.timeScale = 0f;
        painelMenu.SetActive(true);
        isPaused = true;
    }

    public void ResumeMenu()
    {
        Time.timeScale = 1f;
        painelMenu.SetActive(false);
        isPaused = false;
    }

    public void SairMenu()
    {
        Application.LoadLevel("Menu");
        Time.timeScale = 0f;
    }
}

