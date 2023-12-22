using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
public class FlagBox : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    private static FlagBox pointStart, pointCurrent;

    public const byte LEFT = 0, RIGHT = 1, UP = 2, DOWN = 3;

    public FlagBox[] linkBoxs = new FlagBox[4];

    public GameObject handle;

    public LineRenderer line;
    
    [HideInInspector] public RectTransform rectTransform;

    public FlagType flagType = FlagType.normal;

    private bool _isFinish;

    [SerializeField] private int type = 1;

    private List<FlagBox> paths;

    private Point point;

    private FlagBox start;

    void Awake()
    {
        line.gameObject.SetActive(false);
        rectTransform = this.GetComponent<RectTransform>();
        paths = new List<FlagBox>();
    }

    private void Start()
    {
        //GameObject _center = new GameObject("Center");
        //_center.transform.SetParent(rectTransform);
        //center = _center.AddComponent<RectTransform>();
        //center.anchoredPosition = new Vector2(0, 0);
        //center.ForceUpdateRectTransforms();
    }

    public void updateLine()
    {
        line.positionCount = paths.Count + 1;
        if(paths.Count > 0)
        {
            line.numCapVertices = 90;
            line.numCornerVertices = 90;
        }
        else
        {
            line.numCornerVertices = 90;
            line.numCapVertices = 0;
        }
        line.SetPosition(0, this.GetWorldPoint());
        for (int i = 0; i < paths.Count; i++)
        {
            line.SetPosition(i + 1, paths[i].GetWorldPoint());
        }

    }

    public bool isFinish() => _isFinish;

    public int GetType() => type;

    public Vector3 GetWorldPoint()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(handle.GetComponentInChildren<RectTransform>().position);
        var _pos = Camera.main.WorldToViewportPoint(pos);
        _pos = new Vector3(_pos.x, _pos.y, 0);
        return _pos;
    }

    public void init()
    {
        this.point = Main.main.points[type - 1];
        
        line.SetColors(point.color, point.color);

        //line.gameObject.SetActive(true);
        //Image handleImg = handle.GetComponentInChildren<Image>();
        //var childSize = handleImg.rectTransform.rect.width;
        //Board.lineSize = childSize / this.rectTransform.rect.width;
        line.SetWidth(Board.lineSize, Board.lineSize);
    }

    public int isPointNext(FlagBox flagBox)
    {
        for (int i = 0; i < linkBoxs.Length; i++)
        {
            if (linkBoxs[i] == flagBox)
                return i;
        }
        return -1;
    }

    public void pushLink(FlagBox flagBox, byte dir)
    {
        linkBoxs[dir] = flagBox;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(flagType == FlagType.point)
        {
            Debug.Log("Pointer Down");
            pointStart = this;
            
            pointCurrent = this;

            if (start != null)
            {
                start._isFinish = false;
                start.clearPath();
            }
            start = null;
            this._isFinish = false;
            this.clearPath();

            Board.isDrag = true;
        }
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (eventData.pointerEnter != null && Board.isDrag)
        {
            FlagBox box = eventData.pointerEnter.GetComponent<FlagBox>();

            if (box != null)
            {
                if (pointCurrent != null && pointCurrent != this)
                {
                    if (pointCurrent.isPointNext(box) != -1)
                    {
                        var lastPoint = pointStart.paths.LastOrDefault();
                        if (lastPoint != null && lastPoint != pointStart && lastPoint.type == pointStart.type && lastPoint.flagType == FlagType.point)
                            return;

                        if (box == pointStart)
                        {
                            pointStart.clearPath();
                            return;
                        }    
                        if (box.type != 0 && box.type != pointStart.type)
                        {
                            if (box.flagType == FlagType.point)
                                return;

                            int index = box.start.paths.IndexOf(box);
                            box.start.paths.Skip(index).ToList().ForEach(a => { if (a.flagType != FlagType.point) a.type = 0; });
                            box.start.paths = box.start.paths.Take(index).ToList();
                            box.start.updateLine();

                        }

                        if (pointStart.paths.Contains(box))
                        {
                            int takeCount = pointStart.paths.IndexOf(box);
                            pointStart.paths.Skip(takeCount).ToList().ForEach(a => { if (a.flagType != FlagType.point) a.type = 0; });
                            pointStart.paths = pointStart.paths.Take(takeCount).ToList();
                        }
                        pointStart.paths.Add(box);
                        pointStart.updateLine();
                        box.type = pointStart.type;
                        box.start = pointStart;
                        pointCurrent = box;
                    }
                }
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer Up");
        Board.isDrag = false;
        if (pointStart == null)
            return;
        FlagBox flag = pointStart.paths.LastOrDefault();
        if (flag != null)
        {
            if (flag == pointStart || flag.type != pointStart.type)
            {
                pointStart.clearPath();
            }
            else
            {
                flag.start = pointStart;
                flag._isFinish = true;
                pointStart._isFinish = true;
                Board.board.checkFinish();
            }
        }
        else if(pointStart != null)
        {
            pointStart.clearPath();
        }
        pointStart = null;
        pointCurrent = null;

    }

    public void clearPath()
    {
        this.paths.ForEach(a => { if (a.flagType != FlagType.point) a.type = 0; });
        this.paths.Clear();
        updateLine();
    }

#if UNITY_EDITOR
    private int lastType;
    private void OnValidate()
    {
        if (type <= 0 && flagType == FlagType.point)
            type = 1;
        else if (flagType == FlagType.normal)
            type = 0;
        if(lastType != type)
        {
            Image handleImg = handle.GetComponentInChildren<Image>();

            handleImg.sprite = Resources.Load<Sprite>("marbles/" + type);
            lastType = type;
        }

        if(handle != null)
        {
            if (flagType == FlagType.point)
            {
                handle.GetComponentInChildren<Image>().enabled = true;
            }
            else
            {
                handle.GetComponentInChildren<Image>().enabled = false;
            }
        }
    }
#endif
}
