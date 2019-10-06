using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Component
{
    public abstract void Operation();
}

class ConcreteComponent : Component
{
    public override void Operation()
    {
        Console.WriteLine("ConcreteComponent.Operation()");
    }
}

abstract class Decorator : Component
{
    protected Component component;

    public void SetComponent(Component component)
    {
        this.component = component;
    }

    public override void Operation()
    {
        if(component != null)
        {
            component.Operation();
        }
    }
}

class ConcreteComponentA : Decorator
{
    public override void Operation()
    {
        base.Operation();
        AddedBehaviour();
        Console.WriteLine("ConcreteDecoratorB.AddedBehaviour()");
    }

    void AddedBehaviour()
    {
        Console.WriteLine("ConcreteDecoratorB.AddedBehaviour()");
    }
}
