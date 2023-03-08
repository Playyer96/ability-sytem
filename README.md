# Ability System


This is a basic Ability System, that supports Unity's Input System, passive abilities, active abilities, cooldown, ability cost, player stats.

## Player Controller

We show a basic implementation of a PlayerController, that has some stats and basic abilities that interact with the player stats, it has an AbilityController instance and the class generate by InputActionAsset.

## Ability Controller

The AbilityController class takes a list of abilities and make the setup for them, based on is an active or passive ability.

## Ability

To implement a new Ability is necessary to inherit from AbilityBase class, after that each Ability can implement various interfaces to extend its behavior as IActivable, ICooldownable, ICostable, if the ability is active, you can pick a the desire action in the inspector.

## Input Master Helper
The InputMasterHelper is an extention of the InputActionAsset class that allows the developer assing the action trought the inspector
