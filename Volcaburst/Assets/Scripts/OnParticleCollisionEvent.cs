using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnParticleCollisionEvent : MonoBehaviour
{

    public UnityEvent onParticleCollisionEvents;

    private void OnParticleCollision(GameObject other)
    {
        onParticleCollisionEvents.Invoke();
    }
}
