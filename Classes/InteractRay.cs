using Godot;

[GlobalClass]
public partial class InteractRay : RayCast3D
{
	public override void _PhysicsProcess(double delta)
	{
		if (IsColliding() && GetCollider() is InteractableObject collider) OnInteractableObject(collider);
		else OnUninteractableObject();
	}

	public virtual void OnInteractableObject(InteractableObject collider)
	{
		return;
	}

	public virtual void OnUninteractableObject()
	{
		return;
	}
}
