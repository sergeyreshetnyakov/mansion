using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Door : InteractableObject
{
	[Export]
	public bool IsOpened {get; set;} = false;
	[Export]
	public bool IsLocked { get; set; } = true;
	[Export]
	public string Key { get; set; }
	[Export]
	public string LockedMessage { get; set; } = "The door is jammed";
	[Export]
	public string UnlockedMessage { get; set; } = "Unlocked";
	[Export]
	public AnimationPlayer AnimationPlayer {get; set;}

    public override string Interact()
	{
		if (IsLocked)
		{
			return LockedMessage;
		}
		else
		{
			if (IsOpened) AnimationPlayer.PlayBackwards();
			else AnimationPlayer.Play("open");

			IsOpened = !IsOpened;

			return Message;
		}
	}

	public string Unlock()
	{
		IsLocked = false;
		
		return UnlockedMessage;
	}
}
