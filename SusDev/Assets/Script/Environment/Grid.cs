using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grid
{
    public int _width;
    public int _height;
    public Vector3 _startPos;
    public float _cellSize;
    public int[,] _grid;
    public List<int[]> _vacant;
    public Grid(Vector3 pos, int w, int h, float size)
    {
        _startPos = pos;
        _width = w;
        _height = h;
        _cellSize = size;
        _grid = new int[w, h];
        _vacant = new List<int[]>();

        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for(int j = 0; j < _grid.GetLength(1); j++)
            {
  /*              CreateText(_grid[i, j].ToString(), null, GetWorldPos(i, j));*/
                DrawQuadrant(new Vector3(_startPos.x+ i * size, _startPos.y, _startPos.z + j * size) , size);
                Add2List(i, j);
            }
        }
        ShuffleList();
    }
    public void Add2List(int i, int j)
    {
        _vacant.Add(new int[] { i, j});
    }
    public void RemoveFromList(int i, int j)
    {
        int[] r = new int[] {i, j};
        foreach(var value in _vacant.ToList())
        {
            if(Enumerable.SequenceEqual(value, r))
            {
                _vacant.Remove(value);
            }
        }

    }
    public void ShuffleList()
    {
        for(int i = 0; i < _vacant.Count; i++)
        {
            var temp = _vacant[i];
            int index = Random.Range(i, _vacant.Count);
            _vacant[i] = _vacant[index];
            _vacant[index] = temp;
        }
    }
    private void DrawQuadrant(Vector3 pos, float size)
    {
        //(0,0) to (1,0)
        Debug.DrawLine(pos, pos + new Vector3(size, 0, 0), Color.red, 100f);
        //(1,0) to (1,1)
        Debug.DrawLine(pos + new Vector3(size, 0, 0), pos + new Vector3(size, 0, size), Color.red, 100f);
        //(0,1) to (1,1)
        Debug.DrawLine(pos + new Vector3(0, 0, size), pos + new Vector3(size, 0, size), Color.red, 100f);
        //(0,0) to (0,1)
        Debug.DrawLine(pos, pos + new Vector3(0, 0, size), Color.red, 100f);
    }
    public Vector3 GetWorldPos(int x, int z)
    {
        return new Vector3(_startPos.x + x * _cellSize, _startPos.y, _startPos.z + z * _cellSize);
    }
    private Vector2Int GetCordinate(Vector3 worldPos)
    {
        Vector2Int vector = new Vector2Int(Mathf.FloorToInt(worldPos.x / _cellSize), Mathf.FloorToInt(worldPos.z / _cellSize));
        return vector;
    }
    public void SetValue(Vector3 worldPos, int value)
    {
        int x = GetCordinate(worldPos).x;
        int z = GetCordinate(worldPos).y;
        if(x >= 0 && z >= 0 && x <_width && z < _height)
        {
            _grid[x,z] = value;
            RemoveFromList(x, z);
           // Debug.Log(_vacant.Count);
          //  Debug.Log(x + " " + z + " value is " + _grid[x, z]);
        }
    }
    public static TextMesh CreateText(string text, Transform parent = null, Vector3 localPos = default(Vector3), int fontSize = 10, Color color = default(Color))
    {
        if (color == null) color = Color.white;
        return CreateText(parent, text, localPos, fontSize, color);
    }
    public static TextMesh CreateText(Transform parent, string text, Vector3 localPos, int fontSize, Color color)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPos;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        return textMesh;
    }
}
