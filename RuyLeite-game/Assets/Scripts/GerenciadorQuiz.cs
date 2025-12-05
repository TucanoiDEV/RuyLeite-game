using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GerenciadorQuiz : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text textoPergunta;
    public TMP_Text[] textosAlternativas; // arraste os TMP_Text dos botões aqui
    public Button[] botoes;

    [Header("Perguntas")]
    public Pergunta[] perguntas;

    private int indicePerguntaAtual = 0;

    void Start()
    {
        MostrarPergunta();
    }

    void MostrarPergunta()
    {
        Pergunta p = perguntas[indicePerguntaAtual];

        textoPergunta.text = p.textoPergunta;

        for (int i = 0; i < botoes.Length; i++)
        {
            textosAlternativas[i].text = p.alternativas[i];

            int opcao = i;

            botoes[i].onClick.RemoveAllListeners();
            botoes[i].onClick.AddListener(() => SelecionarResposta(opcao));
        }
    }

    void SelecionarResposta(int resposta)
    {
        Pergunta p = perguntas[indicePerguntaAtual];

        if (resposta == p.indiceCorreto)
            Debug.Log("Acertou!");
        else
            Debug.Log("Errou!");

        ProximaPergunta();
    }

    void ProximaPergunta()
    {
        indicePerguntaAtual++;

        if (indicePerguntaAtual < perguntas.Length)
        {
            MostrarPergunta();
        }
        else
        {
            Debug.Log("Acabaram as perguntas!");
        }
    }
}
