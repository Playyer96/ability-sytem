# Ability System


This is a basic Ability System, that supports Unity's Input System, passive abilities, active abilities, cooldown, ability cost, player stats.

We show a basic implementation of a PlayerController, that has some stats and basic abilities that interact with the player stats, it has an AbilityController instance and the class generate by InputActionAsset.

It offers an AbilityController class that takes a List of abilities and make the setup for them, based on is an active or passive ability.
Each Ability can implement various interfaces to extend its behavior
