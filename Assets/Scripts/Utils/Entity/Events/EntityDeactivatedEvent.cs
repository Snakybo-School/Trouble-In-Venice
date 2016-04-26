﻿/// <summary>
/// Send when an entity has been deactivated.
/// </summary>
public class EntityDeactivatedEvent : IEvent
{
	public Entity Entity { private set; get; }

	public EntityDeactivatedEvent(Entity _entity)
	{
		Entity = _entity;
	}
}