using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Board : MonoBehaviour
{
    public static Board board;
    public static bool isDrag;

    public static float lineSize;

    [SerializeField] LineRenderer linePrefab;

    [HideInInspector] public FlagBox[] flagBoxs;

    [HideInInspector] private FlagBox[][] flagPoint;
    
    void Start()
    {
        board = this;
        var grid = GetComponent<GridLayoutGroup>();
        lineSize = grid.cellSize.x / 205f * 0.8f;

        var _listPoints = flagBoxs.Where(a => a.flagType == FlagType.point).OrderBy(a => a.GetType()).ToList();

        flagPoint = new FlagBox[_listPoints.Count / 2][];

        for (int i = 0; i < flagPoint.Length; i++)
        {
            flagPoint[i] = new FlagBox[2];
            flagPoint[i][0] = _listPoints[i * 2];
            flagPoint[i][1] = _listPoints[i * 2 + 1];
            
            var line = Instantiate(linePrefab);
            line.name = "Line " + i;
            flagPoint[i][0].line = line;
            flagPoint[i][1].line = line;

            flagPoint[i][0].init();
            flagPoint[i][1].init();
        }

        //int numCol = (int)Main.main.boardType;
        //int numRow = (int)Main.main.boardType;
        //flagBoxs = new FlagBox[numCol * numRow];
        //var rect = GetComponent<RectTransform>();
        

        //float size = (Mathf.Min(rect.rect.width, rect.rect.height) / numCol);

        //Grid.cellSize = new Vector2(size, size);

        //Grid.constraintCount = numCol;

        //for (int y = 0; y < numRow; y++)
        //{
        //    for (int x = 0; x < numCol; x++)
        //    {
        //        var flagBoxO = Instantiate(flagPrefab, this.transform);
        //        flagBoxO.name = "flag " + (y * numCol + x);
        //        var flagBox = flagBoxO.GetComponent<FlagBox>();

        //        if (x != 0)
        //        {
        //            flagBox.pushLink(flagBoxs[y * numCol + x - 1], FlagBox.LEFT);

        //            flagBoxs[y * numCol + x - 1].pushLink(flagBox, FlagBox.RIGHT);
        //        }
        //        if(y != 0)
        //        {
        //            flagBox.pushLink(flagBoxs[(y - 1) * numCol + x], FlagBox.UP);

        //            flagBoxs[(y - 1) * numCol + x].pushLink(flagBox, FlagBox.DOWN);

        //        }
        //        flagBoxs[y * numCol + x] = flagBox;
        //    }
        //}

        //List<int> types = new List<int>();

        //flagPoint = new FlagBox[numCol - 1][];

        //for (int i = 0; i < numCol - 1;)
        //{
        //    int type = Random.Range(1, 11);
        //    if (!types.Contains(type))
        //    {
        //        types.Add(type);
        //        flagPoint[i] = new FlagBox[2];
        //        while (true)
        //        {
        //            int pos1 = Random.Range(0, numCol * numRow);
        //            int pos2 = Random.Range(0, numCol * numRow);
        //            if (flagBoxs[pos1].GetType() != 0 || flagBoxs[pos2].GetType() != 0 || pos1 == pos2)
        //                continue;
        //            flagBoxs[pos1].setTypeColor(type);
        //            flagBoxs[pos2].setTypeColor(type);
        //            flagPoint[i][0] = flagBoxs[pos1];
        //            flagPoint[i][1] = flagBoxs[pos2];
        //            var line = Instantiate(linePrefab);
        //            flagBoxs[pos1].line = line;
        //            flagBoxs[pos2].line = line;
        //            break;
        //        }
        //        i++;
        //    }
        //}

    }

    public void initBoard(GameObject flagPrefabs, Transform parent, int numRow, int numCol)
    {
        flagBoxs = new FlagBox[numCol * numRow];
        for (int y = 0; y < numRow; y++)
        {
            for (int x = 0; x < numCol; x++)
            {
                var flagBoxO = Instantiate(flagPrefabs, parent);
                flagBoxO.name = "flag " + (y * numCol + x);
                var flagBox = flagBoxO.GetComponent<FlagBox>();

                if (x != 0)
                {
                    flagBox.pushLink(flagBoxs[y * numCol + x - 1], FlagBox.LEFT);

                    flagBoxs[y * numCol + x - 1].pushLink(flagBox, FlagBox.RIGHT);
                }
                if (y != 0)
                {
                    flagBox.pushLink(flagBoxs[(y - 1) * numCol + x], FlagBox.UP);

                    flagBoxs[(y - 1) * numCol + x].pushLink(flagBox, FlagBox.DOWN);

                }
                flagBoxs[y * numCol + x] = flagBox;
            }
        }
    }

    public void checkFinish()
    {
        foreach (var points in flagPoint)
        {
            if(!points[0].isFinish() || !points[1].isFinish())
            {
                return;
            }
        }

        foreach (var flag in flagBoxs)
        {
            if(flag.GetType() == 0)
            {

                return;
            }
        }


        Main.main.GameSuccess();

    }
}
