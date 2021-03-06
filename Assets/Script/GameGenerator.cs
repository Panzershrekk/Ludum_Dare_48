using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    public List<Element> Valuable = new List<Element>();
    public List<float> ValuableProbability = new List<float>();
    public List<Element> Rock = new List<Element>();

    [Range(0.0f, 100.0f)]
    public float RatioPower;
    public float ProbabilityForValuable = 25;
    public float ProbabilityForRock = 55;
    private float _currentDepthIndex;
    private float _currentWidthIndex;
    public float MaxDepthIndex = 30;
    public int MaxWidthIndex = 30;
    private float _depthRatio = 1;
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
            _depthRatio = (_currentDepthIndex / MaxDepthIndex);
            for (x = 0; x < MaxWidthIndex; x++)
            {
                CreateElement();
                _currentWidthIndex += 1;
            }
            x = 0;
            _currentWidthIndex = 0;
            _currentDepthIndex += 1;
        }
    }

    public void CreateElement()
    {
        float ValuableRand = Random.Range(0f, 100f - (RatioPower * _depthRatio));
        float RockRand = Random.Range(0f, 100f + (RatioPower * _depthRatio));
        float PositionVariationX = Random.Range(0.0f, 1.0f);
        float PositionVariationY = Random.Range(0.0f, 1.0f);
        if (ValuableRand <= ProbabilityForValuable)
        {
            Element ele = Instantiate(ValuableWithProbability(),
                        new Vector3(transform.position.x + _currentWidthIndex + PositionVariationX, transform.position.y - _currentDepthIndex - PositionVariationY, 1),
                        Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
        }
        else if (RockRand <= ProbabilityForRock)
        {
            Element ele = Instantiate(Rock[Random.Range(0, Rock.Count)],
                        new Vector3(transform.position.x + _currentWidthIndex + PositionVariationX, transform.position.y - _currentDepthIndex - PositionVariationY, 1),
                        Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
        }
    }

    public Element ValuableWithProbability()
    {
        int index = 0;
        float Rand = Random.Range(0f, 100f);
        Element element = null;
        foreach (float prob in ValuableProbability)
        {
            if (Rand > prob)
            {
                element = Valuable[index];
                break;
            }
            else
            {
                index++;
            }
        }
        //element = Valuable[Random.Range(0, Valuable.Count)];
        return element;
    }
}
