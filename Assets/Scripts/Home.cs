using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    [SerializeField] BoardDataList dataList;
    [SerializeField] GameObject contents;
    [SerializeField] TMP_Text m_textLevel;
    [SerializeField] GameObject listLevelView;
    [SerializeField] GameObject btnLevelPrefab;

    public void TypeSelect(int boardType)
    {
        BoardType type = (BoardType)boardType;
        switch (type)
        {
            case BoardType.x5:
                m_textLevel.text = "5x5";
                break;
            case BoardType.x6:
                m_textLevel.text = "6x6";
                break;
            case BoardType.x7:
                m_textLevel.text = "7x7";
                break;
            case BoardType.x8:
                m_textLevel.text = "8x8";
                break;
            case BoardType.x9:
                m_textLevel.text = "9x9";
                break;
            default:
                break;
        }

        listLevelView.SetActive(true);

        for (int i = 0; i < contents.transform.childCount; i++)
        {
            Destroy(contents.transform.GetChild(i).gameObject);
        }

        int countLevel = dataList.GetBoardDatas(type).Count;
        for (int i = 0; i < countLevel; i++)
        {
            var g = Instantiate(btnLevelPrefab, contents.transform);
            g.GetComponentInChildren<TMP_Text>().text = (i + 1).ToString();
            int level = i + 1;
            g.GetComponent<Button>().onClick.AddListener(() => { Player(type, level);  });
        }
    }

    public void Player(BoardType type, int level)
    {
        PlayerPrefs.SetInt("type", (int)type);
        PlayerPrefs.SetInt("level", level);
        SceneManager.LoadScene(1);
    }
}
