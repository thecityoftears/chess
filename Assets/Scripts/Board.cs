using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject squarePrefab;
    public Square[,] allSquares = new Square[8,8];

    public void Create()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                GameObject newSquare = Instantiate(squarePrefab, this.transform);

                RectTransform rectTransform = newSquare.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(x*100+50, y*100+50);

                allSquares[x, y] = newSquare.GetComponent<Square>();
                allSquares[x, y].Setup(new Vector2Int(x, y), this);
            }
        }

        bool prevBlack = false;
        //set square colour
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (prevBlack)
                {
                    allSquares[x, y].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    prevBlack = false;
                }
                else
                {
                    allSquares[x, y].GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                    prevBlack = true;
                }
            }

            prevBlack = !prevBlack;
        }
    }
}