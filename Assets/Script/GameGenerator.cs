using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    public List<GameObject> Valuable = new List<GameObject>();
    public List<GameObject> Rock = new List<GameObject>();

    public float ProbabilityForValuable = 25;
    public float ProbabilityForRock = 55;
    public int CurrentDepthIndex;
    public int CurrentWidthIndex;
    public int MaxDepthIndex = 30;
    public int MaxWidthIndex = 30;
    public int DepthRatio = 1;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGame();
    }

    public void GenerateGame()
    {
        int y = 0;
        int x = 0;
        for (y = 0; y < MaxDepthIndex; y++)
        {
            for (x = 0; x < MaxWidthIndex; x++)
            {
                CreateElement();
                CurrentWidthIndex += 1;
            }
            x = 0;
            CurrentWidthIndex = 0;
            CurrentDepthIndex += 1;
        }
    }

    public void CreateElement()
    {
        float ValuableRand = Random.Range(0, 100 * 1f);
        float RockRand = Random.Range(0, 100 / 1f);
        float PositionVariationX = Random.RandomRange(0.0f, 1.0f);
        float PositionVariationY = Random.RandomRange(0.0f, 1.0f);

        if (ValuableRand <= ProbabilityForValuable)
        {
            Instantiate(Valuable[0],
                        new Vector3(transform.position.x + CurrentWidthIndex + PositionVariationX, transform.position.y - CurrentDepthIndex - PositionVariationY),
                        Quaternion.identity);
        }
        else if (RockRand <= ProbabilityForRock)
        {
            Instantiate(Rock[0],
            new Vector3(transform.position.x + CurrentWidthIndex + PositionVariationX, transform.position.y - CurrentDepthIndex - PositionVariationY),
            Quaternion.identity);
        }
    }
}
