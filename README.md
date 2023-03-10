# Ability System


This is a basic Ability System, that supports Unity's Input System, passive abilities, active abilities, cooldown, ability cost, player stats.

## Player Controller

![image](https://user-images.githubusercontent.com/20919016/224188316-cb30befa-4631-4afd-afa3-3eaeb1973683.png)

We show a basic implementation of a PlayerController, that has some stats and basic abilities that interact with the player stats, it has an AbilityController instance and the class generate by InputActionAsset.

## Ability Controller

![image](https://user-images.githubusercontent.com/20919016/224189042-f0383f06-a613-4bbb-a25d-b718faef2433.png)

The AbilityController class takes a list of abilities and make the setup for them, based on is an active or passive ability.

## Ability

![image](https://user-images.githubusercontent.com/20919016/224190130-ea4b6359-a88d-4dab-b60a-6f54d245065d.png)

To implement a new Ability is necessary to inherit from AbilityBase class, after that each Ability can implement various interfaces to extend its behavior as IActivable, ICooldownable, ICostable, if the ability is active, you can pick a the desire action in the inspector.

## Input Master Helper

![image](https://user-images.githubusercontent.com/20919016/224190160-7ae75d3e-be89-48a6-98e3-7530b81d1df2.png)

The InputMasterHelper is an extention that allows the developer assing an action declared in the InputActionAsset to an Ability trought the inspector.

## Cooldown Manager

A Singleton manager that controls cooldawn for abilities.
