using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class HoverColorTMP : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text texto;
    public Color corNormal = Color.white;
    public Color corHover = Color.red;

    void Start()
    {
        if (texto == null)
            texto = GetComponent<TMP_Text>();

        texto.color = corNormal;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        texto.color = corHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        texto.color = corNormal;
    }
}