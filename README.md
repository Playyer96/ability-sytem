# Ability System


This is a basic Ability System, that supports Unity's Input System, passive abilities, active abilities, cooldown, ability cost, player stats.

## Player Controller

![image](https://user-images.githubusercontent.com/20919016/224188316-cb30befa-4631-4afd-afa3-3eaeb1973683.png)

We show a basic implementation of a PlayerController, that has some stats and basic abilities that interact with the player stats, it has an AbilityController instance and the class generate by InputActionAsset.

## Ability Controller

![image](https://user-images.githubusercontent.com/20919016/224189042-f0383f06-a613-4bbb-a25d-b718faef2433.png)

The AbilityController class takes a list of abilities and make the setup for them, based on is an active or passive ability.

## Ability

![image](https://user-images.githubusercontent.com/20919016/224189100-c4facf13-0cbe-4e57-b9e3-959888b5ad00.png)

To implement a new Ability is necessary to inherit from AbilityBase class, after that each Ability can implement various interfaces to extend its behavior as IActivable, ICooldownable, ICostable, if the ability is active, you can pick a the desire action in the inspector.

## Input Master Helper

![image](https://user-images.githubusercontent.com/20919016/224189302-3aeb50b2-7811-435f-a4ae-a3d23ff70e0c.png)

The InputMasterHelper is an extention that allows the developer assing an action declared in the InputActionAsset to an Ability trought the inspector.

## Cooldown Manager

A Singleton manager that controls cooldawn for abilities.
