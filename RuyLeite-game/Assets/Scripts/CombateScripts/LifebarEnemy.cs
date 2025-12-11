using UnityEngine;
using UnityEngine.UI;

public class LifebarEnemy : MonoBehaviour
{
    EntityStats hp;
    public Slider life;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EntityStats>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyHP();
    }

    void EnemyHP()
    {
        life.maxValue = hp.maxHp;
        life.value = hp.hp;
    }
}
