using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControler : MonoBehaviour
{
    //controle de velocidade
    public float speed = 1;


    //configura o total de pontos
    public int total_pontos = 9;

    //setar o texto
    public TextMeshProUGUI pointsText;

  //variável para acessar os movimentos
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    //contagem dos pontos
    private int pontos;

    public GameObject winText;


    //é chamado quando o objeto for criado na cena
    void Start() {
        rb = GetComponent<Rigidbody>();
        pontos = 0;
    }

    //esta relacionado ao sistema de física e é chamado em um intervalo fixo.
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Pickup")){
            pontos++;
            setPointsText();
            other.gameObject.SetActive(false);
            Debug.Log(pontos);
            setPointsText();


        }
    }

    void setPointsText()
    {
        pointsText.text = "Pontos: " + pontos;

        if(pontos >= total_pontos)
        {
            winText.SetActive(true);
        }
    }
}
