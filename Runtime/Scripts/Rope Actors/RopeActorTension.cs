using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeActorTension : RopeActorBase
{
    private RopeSimulatorTension ropeSimulatorTension;
    public RopeSimulatorTension RopeSimulatorTension { get { return ropeSimulatorTension; } }

    private RopeActorRigidbody ropeActorRigidbody;
    public RopeActorRigidbody RopeActorRigidbody { get { return ropeActorRigidbody; } }

    public RopeActorTension(
        Rope rope,
        RopeActorRigidbody ropeActorRigidbody,
        bool tensionEnabled,
        float thresholdTendsion,
        float springStrength,
        float dampingStrength
        ) : base(rope)
    {
        this.ropeActorRigidbody = ropeActorRigidbody;
        this.ropeSimulatorTension = new RopeSimulatorTension(
            this.ropeActorRigidbody.RopeSimulatorRigidbody,
            tensionEnabled,
            thresholdTendsion,
            springStrength,
            dampingStrength
            );

        actionExecutions.Add((ExecutionOrder, ExertForce));
    }

    public override int ExecutionOrder { get { return ropeActorRigidbody.ExecutionOrder - 2; } }

    public bool TensionEnabled { set => ropeSimulatorTension.TensionEnabled = value; }
    public float ThresholdTension { get => ropeSimulatorTension.ThresholdTension; set => ropeSimulatorTension.ThresholdTension = value; }
    public float SpringStrength { get => ropeSimulatorTension.SpringStrength; set => ropeSimulatorTension.SpringStrength = value; }
    public float DampingStrength { get => ropeSimulatorTension.DampingStrength; set => ropeSimulatorTension.DampingStrength = value; }


    private void ExertForce()
    {
        ropeSimulatorTension.ExertForces(Rope.Sticks, Rope.CurrentTimeStep);
    }
}
