using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{
    EntityStats hp;
    public Slider life;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHP();
    }

    void PlayerHP()
    {
        life.maxValue = hp.maxHp;
        life.value = hp.hp;
    }
}
