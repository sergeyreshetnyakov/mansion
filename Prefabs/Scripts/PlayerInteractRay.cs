using Godot;

public partial class PlayerInteractRay : InteractRay
{
	[Signal]
	public delegate void LabelEventHandler(string text);
	[Signal]
	public delegate void MessageEventHandler(string text);
	
    public override void OnInteractableObject(InteractableObject collider)
    {
		EmitSignal(SignalName.Label, collider.Label);
		if (Input.IsActionJustPressed("Interact"))
		{
		string InteractMessage = collider.Interact();
		EmitSignal(SignalName.Message, InteractMessage);
		}
    }

    public override void OnUninteractableObject()
    {
        EmitSignal(SignalName.Label, " ");
    }
}
