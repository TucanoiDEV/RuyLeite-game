using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityStats : MonoBehaviour
{
    public int maxHp = 4;
    public int hp;
    public int attack = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Death()
    {
        if(gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene("GameplayScene");
        }
    }

}
