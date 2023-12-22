using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuEditor : Editor
{
    [MenuItem("GameObject/Create Board/Create 5x5", false, 10)]
    public static void create5x5(MenuCommand menu)
    {
        Debug.Log(menu.context.name);
        GameObject gameObject = Resources.Load<GameObject>("Prefabs/flag");
        GameObject board = new GameObject("Board");
        board.transform.SetParent((menu.context as GameObject).transform);
        board.layer = 5;
        var rectTrans = board.AddComponent<RectTransform>();
        rectTrans.anchorMin = new Vector2(0, 0);
        rectTrans.anchorMax = new Vector2(0, 1);
        rectTrans.pivot = new Vector2(0, 0);
        rectTrans.sizeDelta = new Vector2(1025, -55);
        
        rectTrans.anchoredPosition = new Vector2(100, 27.5f);
        rectTrans.ForceUpdateRectTransforms();
        var grid = board.AddComponent<GridLayoutGroup>();
        float size = (Mathf.Min(rectTrans.rect.width, rectTrans.rect.height) / 5);

        grid.cellSize = new Vector2(size, size);
        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = 5;

        board.AddComponent<Board>().initBoard(gameObject, board.transform, 5, 5);

        rectTrans.localScale = new Vector3(1, 1, 1);
        
    }

    [MenuItem("GameObject/Create Board/Create 6x6", false, 10)]
    public static void create6x6(MenuCommand menu)
    {
        Debug.Log(menu.context.name);
        GameObject gameObject = Resources.Load<GameObject>("Prefabs/flag");
        GameObject board = new GameObject("Board");
        board.transform.SetParent((menu.context as GameObject).transform);
        board.layer = 5;
        var rectTrans = board.AddComponent<RectTransform>();
        rectTrans.anchorMin = new Vector2(0, 0);
        rectTrans.anchorMax = new Vector2(0, 1);
        rectTrans.pivot = new Vector2(0, 0);
        rectTrans.sizeDelta = new Vector2(1025, -55);

        rectTrans.anchoredPosition = new Vector2(100, 27.5f);
        rectTrans.ForceUpdateRectTransforms();
        var grid = board.AddComponent<GridLayoutGroup>();
        float size = (Mathf.Min(rectTrans.rect.width, rectTrans.rect.height) / 6);

        grid.cellSize = new Vector2(size, size);
        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = 6;

        board.AddComponent<Board>().initBoard(gameObject, board.transform, 6, 6);

        rectTrans.localScale = new Vector3(1, 1, 1);
        
    }

    [MenuItem("GameObject/Create Board/Create 7x7", false, 10)]
    public static void create7x7(MenuCommand menu)
    {
        Debug.Log(menu.context.name);
        GameObject gameObject = Resources.Load<GameObject>("Prefabs/flag");
        GameObject board = new GameObject("Board");
        board.transform.SetParent((menu.context as GameObject).transform);
        board.layer = 5;
        var rectTrans = board.AddComponent<RectTransform>();
        rectTrans.anchorMin = new Vector2(0, 0);
        rectTrans.anchorMax = new Vector2(0, 1);
        rectTrans.pivot = new Vector2(0, 0);
        rectTrans.sizeDelta = new Vector2(1025, -55);

        rectTrans.anchoredPosition = new Vector2(100, 27.5f);
        rectTrans.ForceUpdateRectTransforms();
        var grid = board.AddComponent<GridLayoutGroup>();
        float size = (Mathf.Min(rectTrans.rect.width, rectTrans.rect.height) / 7);

        grid.cellSize = new Vector2(size, size);
        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = 7;

        board.AddComponent<Board>().initBoard(gameObject, board.transform, 7, 7);

        rectTrans.localScale = new Vector3(1, 1, 1);
        
    }

    [MenuItem("GameObject/Create Board/Create 8x8", false, 10)]
    public static void create8x8(MenuCommand menu)
    {
        Debug.Log(menu.context.name);
        GameObject gameObject = Resources.Load<GameObject>("Prefabs/flag");
        GameObject board = new GameObject("Board");
        board.transform.SetParent((menu.context as GameObject).transform);
        board.layer = 5;
        var rectTrans = board.AddComponent<RectTransform>();
        rectTrans.anchorMin = new Vector2(0, 0);
        rectTrans.anchorMax = new Vector2(0, 1);
        rectTrans.pivot = new Vector2(0, 0);
        rectTrans.sizeDelta = new Vector2(1025, -55);

        rectTrans.anchoredPosition = new Vector2(100, 27.5f);
        rectTrans.ForceUpdateRectTransforms();
        var grid = board.AddComponent<GridLayoutGroup>();
        float size = (Mathf.Min(rectTrans.rect.width, rectTrans.rect.height) / 8);

        grid.cellSize = new Vector2(size, size);
        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = 8;

        board.AddComponent<Board>().initBoard(gameObject, board.transform, 8, 8);

        rectTrans.localScale = new Vector3(1, 1, 1);
        
    }

    [MenuItem("GameObject/Create Board/Create 9x9", false, 10)]
    public static void create9x9(MenuCommand menu)
    {
        Debug.Log(menu.context.name);
        GameObject gameObject = Resources.Load<GameObject>("Prefabs/flag");
        GameObject board = new GameObject("Board");
        board.transform.SetParent((menu.context as GameObject).transform);
        board.layer = 5;
        var rectTrans = board.AddComponent<RectTransform>();
        rectTrans.anchorMin = new Vector2(0, 0);
        rectTrans.anchorMax = new Vector2(0, 1);
        rectTrans.pivot = new Vector2(0, 0);
        rectTrans.sizeDelta = new Vector2(1025, -55);

        rectTrans.anchoredPosition = new Vector2(100, 27.5f);
        rectTrans.ForceUpdateRectTransforms();
        var grid = board.AddComponent<GridLayoutGroup>();
        float size = (Mathf.Min(rectTrans.rect.width, rectTrans.rect.height) / 9);

        grid.cellSize = new Vector2(size, size);
        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = 9;

        board.AddComponent<Board>().initBoard(gameObject, board.transform, 9, 9);

        rectTrans.localScale = new Vector3(1, 1, 1);
        
    }
}
