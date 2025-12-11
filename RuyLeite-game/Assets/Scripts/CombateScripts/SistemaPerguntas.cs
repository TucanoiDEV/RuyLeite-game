using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Pergunta
{
    public string textoPergunta;
    public string[] respostas;  // Todas as respostas
    public int indiceCorreta;   // Índice da correta dentro de "respostas"
}

public class SistemaPerguntas : MonoBehaviour
{
    public TextMeshProUGUI textoPerguntaUI;
    public Button[] botoesUI;

    public List<Pergunta> perguntas;

    private Pergunta perguntaAtual;
    private int indiceCorretaEmbaralhada;

    public EntityStats hp;
    public EntityStats hpEnemy;

    void Start()
    {
        NovaPergunta();
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
        hpEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EntityStats>();
    }

    public void NovaPergunta()
    {
        // Seleciona uma pergunta aleatória
        perguntaAtual = perguntas[Random.Range(0, perguntas.Count)];

        // Atualiza texto da pergunta
        textoPerguntaUI.text = perguntaAtual.textoPergunta;

        // Copia as respostas
        List<string> respostasEmbaralhadas = new List<string>(perguntaAtual.respostas);

        // Embaralha
        for (int i = 0; i < respostasEmbaralhadas.Count; i++)
        {
            string temp = respostasEmbaralhadas[i];
            int randomIndex = Random.Range(0, respostasEmbaralhadas.Count);
            respostasEmbaralhadas[i] = respostasEmbaralhadas[randomIndex];
            respostasEmbaralhadas[randomIndex] = temp;
        }

        // Descobre onde a resposta correta ficou após embaralhar
        indiceCorretaEmbaralhada = respostasEmbaralhadas.IndexOf(
            perguntaAtual.respostas[perguntaAtual.indiceCorreta]
        );

        // Coloca respostas nos botões
        for (int i = 0; i < botoesUI.Length; i++)
        {
            if (i < respostasEmbaralhadas.Count)
            {
                botoesUI[i].gameObject.SetActive(true);

                // Texto do botão
                botoesUI[i].GetComponentInChildren<TextMeshProUGUI>().text =
                    respostasEmbaralhadas[i];

                int index = i;

                // Limpa listeners antigos
                botoesUI[i].onClick.RemoveAllListeners();

                // Adiciona função ao ser clicado
                botoesUI[i].onClick.AddListener(() => Responder(index));
            }
            else
            {
                botoesUI[i].gameObject.SetActive(false);
            }
        }
    }

    void Responder(int indice)
    {
        if (indice == indiceCorretaEmbaralhada)
        {
            Debug.Log("✔ Resposta correta!");
            hpEnemy.hp -= 1;

            if(hpEnemy.hp <= 0)
            {
                SceneManager.LoadScene("GameplayScene");
            }
        }
        else
        {
            Debug.Log("✖ Resposta errada!");
            hp.hp -= 1;
            
            if(hp.hp <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        // Chama outra pergunta aleatória
        NovaPergunta();
    }
}
