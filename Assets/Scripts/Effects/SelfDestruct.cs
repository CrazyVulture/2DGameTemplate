using JetBrains.Annotations;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float lifeTime=1.0f;

    public bool hasAnimation=false;

    [CanBeNull]
    public new AnimationClip animation;

    void Start()
    {
        if (hasAnimation)
        {
            lifeTime = animation.length;
        }
            
        Destroy(gameObject, lifeTime);
    } 
}
