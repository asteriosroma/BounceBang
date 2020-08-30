using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public GameObject left_enemy_block;
    public GameObject right_enemy_block;
    public GameObject center_enemy_block;
    public EnemyController ec;
    public TextMesh lvl_title;
    public Text pause_btn_label;
    int level_counter;
    bool is_pause;
    void Start()
    {
        level_counter = 1;
        lvl_title.text = "Level " + level_counter;
        is_pause = false;
    }
    void Update()
    {
        CheckLvlComplete();
    }

    void CheckLvlComplete()
    {
        if(!left_enemy_block.activeInHierarchy && !right_enemy_block.activeInHierarchy && !center_enemy_block.activeInHierarchy)
        {
            print("Level " + level_counter + " is complete");
            level_counter++;
            lvl_title.text = "Level " + level_counter;
            ec.enemy_speed += 1;
            left_enemy_block.SetActive(true);
            right_enemy_block.SetActive(true);
            center_enemy_block.SetActive(true);
        }
    }

    public void Pause()
    {
        if (!is_pause)
        {
            Time.timeScale = 0;
            pause_btn_label.text = "Continue";
            print("pause");
        }
        if (is_pause)
        {
            Time.timeScale = 1;
            pause_btn_label.text = "Pause";
            print("continue");
        }
        is_pause = !is_pause;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
