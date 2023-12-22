using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
public class Main : MonoBehaviour
{
    
    public static Main main;

    public Point[] points;

    public int Score;

    public BoardType boardType = BoardType.x5;

    public int level;

    [SerializeField] Transform BoardContent;

    [SerializeField] BoardDataList boardDataList;

    [SerializeField] GameObject gameSuccess;

    [SerializeField] Sprite s_mute;

    [SerializeField] Sprite s_unMute;

    [SerializeField] TMP_Text t_level;

    [SerializeField] TMP_Text t_score;

    private bool isMute;

    void Awake()
    {
        main = this;
        Score = PlayerPrefs.GetInt("Score", 0);
        t_score.text = "Score:\t\t" + Score;
        if (PlayerPrefs.HasKey("type"))
        {
            boardType = (BoardType)PlayerPrefs.GetInt("type", (int)BoardType.x5);
            level = PlayerPrefs.GetInt("level", 1);
            PlayerPrefs.DeleteKey("type");
            PlayerPrefs.DeleteKey("level");
        }

        if(points == null || points.Length == 0)
        {
            points = Resources.LoadAll<Point>("marbles").OrderBy(a => int.Parse(a.name)).ToArray();
        }

        GameObject.Find("mute").GetComponent<Image>().sprite = isMute ? s_mute : s_unMute;


        GameObject board = boardDataList.GetBoardData(boardType, level);

        Instantiate(board, BoardContent);
    }

    void Update()
    {
        
    }

    internal void GameSuccess() => gameSuccess.SetActive(true);

    public void home() => SceneManager.LoadScene(0);

    public void Retry()
    {
        PlayerPrefs.SetInt("type", (int)boardType);
        PlayerPrefs.SetInt("level", level);
        SceneManager.LoadScene(1);
    }

    public void next()
    {

    }

    public void mute()
    {
        isMute = !isMute;
        GameObject.Find("mute").GetComponent<Image>().sprite = isMute ? s_mute : s_unMute;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.Save();
    }

    
}
