using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorHandler : MonoBehaviour
{
    protected Renderer renderer;

    public UnityAction<ValidColor> OnColorChanged;
    [SerializeField] private ValidColor _currentColor = ValidColor.Red;
    public ValidColor CurrentColor
    {
        get { return this._currentColor; }
        set
        {
            this._currentColor = value;

            if (!ReferenceEquals(renderer, null))
                renderer.material.color = GetColor(this._currentColor);

            if (!ReferenceEquals(OnColorChanged, null))
                OnColorChanged.Invoke(value);
        }
    }


    //
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = GetColor(this.CurrentColor);

        OnColorChanged += UpdateColor;
    }

    private void UpdateColor(ValidColor color)
    {
        renderer.material.color = GetColor(this.CurrentColor);
    }

    private Color GetColor(ValidColor color)
    {
        switch (color)
        {
            case ValidColor.Red:
                return Color.red;
            case ValidColor.Green:
                return Color.green;
            case ValidColor.Blue:
                return Color.blue;
            default:
                return Color.yellow;
        }
    }
}
