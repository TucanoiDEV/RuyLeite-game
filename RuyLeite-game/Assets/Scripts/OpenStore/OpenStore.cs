using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenStore : MonoBehaviour
{
    public GameObject houseWarning;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, player.transform.position);

        if (dist < 15)
        {
            houseWarning.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("PortuguesScene");
            }
        }
        else
        {
            houseWarning.SetActive(false);
        }
    }
}
