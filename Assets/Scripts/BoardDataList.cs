using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "board Data List", menuName = "Board/new Board data list")]
public class BoardDataList : ScriptableObject
{
    [Header("5x5")]
    public List<GameObject> data5x5;

    [Header("6x6")]
    public List<GameObject> data6x6;

    [Header("7x7")]
    public List<GameObject> data7x7;

    [Header("8x8")]
    public List<GameObject> data8x8;

    [Header("9x9")]
    public List<GameObject> data9x9;

    public GameObject GetBoardData(BoardType type, int level)
    {
        switch (type)
        {
            case BoardType.x5:
                return data5x5[level - 1];
            case BoardType.x6:
                return data6x6[level - 1];
            case BoardType.x7:
                return data7x7[level - 1];
            case BoardType.x8:
                return data8x8[level - 1];
            case BoardType.x9:
                return data9x9[level - 1];
            default:
                throw new System.Exception("Not found board");
                break;
        }
    }

    public List<GameObject> GetBoardDatas(BoardType type)
    {
        switch (type)
        {
            case BoardType.x5:
                return data5x5;
            case BoardType.x6:
                return data6x6;
            case BoardType.x7:
                return data7x7;
            case BoardType.x8:
                return data8x8;
            case BoardType.x9:
                return data9x9;
            default:
                return null;
        }
    }
}
