using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionarPlataformaCircle : MonoBehaviour
{
    public float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotacionar o objeto em torno do eixo Z com a velocidade definida
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
