using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNave3D : MonoBehaviour
{
    public Rigidbody rgb;
    public float moveSpeed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Obt�m a entrada do teclado nos eixos X e Y
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calcula o vetor de movimento com base na entrada do teclado
        Vector3 movement = new Vector3(moveX, moveY, 1f) * moveSpeed;

        // Aplica o movimento apenas nos eixos X e Y (Z � mantido mas caso n�o queira s� dar um frezz)
        rgb.velocity = new Vector3(movement.x, movement.y, movement.z);

        // Obt�m a entrada do mouse para o giro
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Calcula a rota��o do objeto
        float rotationAmount = scrollInput * rotationSpeed * Time.deltaTime;

        // Aplica a rota��o ao objeto em torno do eixo vertical (Y)
        transform.Rotate(0f, 0f, rotationAmount);
    }

}

