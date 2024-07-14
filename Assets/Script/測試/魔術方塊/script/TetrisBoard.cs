using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TetrisBoard : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPrefab;
    [SerializeField]
    private Sprite[] blockSprite;
    private struct Block
    {
        public int x;
        public int y;
        public GameObject ob;

        public Block (int x, int y,GameObject ob) 
        {
           this.x = x;
            this.y = y;
            this.ob = ob;
        
        }
    }
    private Block[] piece = new Block[4]
    {
        new Block(),
        new Block(),
        new Block(),
        new Block()
    };
    private int W = 10;
    private int H = 20;
    private Block[,] block;
    private int[,] shapes = new int[,]
    {
         {1,3,5,7}, //l
         {2,4,5,7}, //Z
         {3,4,5,6}, //S
         {3,4,5,7}, //T
         {2,3,5,7}, //L
         {3,5,6,7}, //J
    };

 //   private float moveTime = 0;
  //  private float moveSpeed = 0.06f;


    void Start()
    {
        block = new Block[W, H];
        Grenerate();
    }


   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            HoldAndMove(-1, 0);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            HoldAndMove(1, 0);
        if (Input.GetKeyDown(KeyCode.UpArrow))
            HoldAndMove(0, 1);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            HoldAndMove(0, -1);
        if (Input.GetKeyDown(KeyCode.Space))
            Rotate();


    }

    private void Grenerate() 
    {
        int n = 5;
        for(int i = 0; i<4;i++)
        {
            piece[i].x = shapes[n, i] %2;
            piece[i].y = -shapes[n, i] / 2;

        }
        Sprite sprite = blockSprite[0];
        for(int i = 0; i < 4; i++) 
        {
            piece[i].ob = Instantiate(blockPrefab , new Vector2(piece[i].x, piece[i].y),Quaternion.identity);
            SpriteRenderer sr = piece[i].ob.GetComponent<SpriteRenderer>();
            sr.sprite = sprite;
        }
    }

    private void HoldAndMove(int dx,int dy) 
    {

             Move(dx,dy);

        
        
    }
    private void Move(int dx, int dy)
    {
        for(int i = 0;i<4;i++)
        {
            piece[i].x += dx;
            piece[i].y += dy;
            piece[i].ob.transform.position = new Vector2(piece[i].x, piece[i].y);
        }
    }
    private void Rotate() 
    {

            Block p = piece[1];
            for (int i = 0; i < 4; i++)
            {
                int x = piece[i].y - p.y;
                int y = piece[i].x - p.x;
                piece[i].x = p.x - x;
                piece[i].y = p.y + y;
                piece[i].ob.transform.position = new Vector2(piece[i].x, piece[i].y);
               
            }
        
    }


}
