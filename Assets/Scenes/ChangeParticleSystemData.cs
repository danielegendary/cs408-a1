using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeParticleSystemData : MonoBehaviour
{
    public ParticleSystem particleSys;
    ParticleSystem.EmissionModule parEmission;
    ParticleSystem.ShapeModule parShape;
    ParticleSystem.MinMaxCurve parMinMaxCurve;
    public float alpha = 1.00f;
    public float Red = 0.25f;
    public float Green = 0.25f;
    public float blue = 0.25f;
    public float size=0.5F;
    void Start()
    {   
        particleSys = GetComponent<ParticleSystem>();
        parEmission = particleSys.emission;
        parShape = particleSys.shape;
        parMinMaxCurve = new ParticleSystem.MinMaxCurve(20);
        parEmission.rateOverTime = parMinMaxCurve;
    }
    void Update()
    {   
        ParticleSystem.MainModule main = particleSys.main;
        main.startColor = new Color (Red,Green,blue,alpha);
        main.startSize =size;
        if (Input.GetKeyDown(KeyCode.P))//play the particle
        {
            particleSys.Play();
        }
        if (Input.GetKeyDown(KeyCode.O))//pasue
        {
            particleSys.Stop();
        }
        if (Input.GetKeyDown(KeyCode.E))//set emission over distance
        {
            SetParEmission(1, 50);
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))// increase emission rate
        {
            increaseParEmission(10);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))// decrease emission rate
        {
            decreaseParEmission(10);
        }
        if (Input.GetKeyDown(KeyCode.H))// change shape
        {
            SetParShape();
        }
        if (Input.GetKeyDown(KeyCode.R)) //change color to red
        {
            Red += .05f;
        }
        if (Input.GetKeyDown(KeyCode.G))//change color to green
        {
            Green += .05f;
        }
        if (Input.GetKeyDown(KeyCode.B))//change color to blue
        {
            blue += .05f;
        }
        if (Input.GetKeyDown(KeyCode.K))//increase size
        {
            size+=0.5F;
        }
        if (Input.GetKeyDown(KeyCode.L))//decrease size
        {
            size-=0.5F;
        }
    }
    /// <summary>
    /// set emission
    /// </summary>
    private void SetParEmission(float min, float max)
    {
        parEmission.rateOverDistance = new ParticleSystem.MinMaxCurve(min, max);
    }
    private void increaseParEmission(float addRate)
    {
        parMinMaxCurve.constant += 2;
        parEmission.rateOverTime = parMinMaxCurve; 
    }
    private void decreaseParEmission(float addRate)
    {
        parMinMaxCurve.constant -= 2;
        parEmission.rateOverTime = parMinMaxCurve; 
    }
    private void SetParShape()
    {
        parShape.shapeType = ParticleSystemShapeType.Box;//set shape
        parShape.scale = new Vector3(1, 1, 1); //set scale
    }
}

 


