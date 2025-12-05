using UnityEngine;

[System.Serializable]
public class Pergunta
{
    public string textoPergunta;
    public string[] alternativas = new string[4];
    public int indiceCorreto; // 0 a 3
}
