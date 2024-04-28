# CaramellDOOMson Documentation
> Github repository link : <https://github.com/Bhardal/3dEnvironmentsCaramellDOOMson> <br>
> Please refer to the github Readme for the external links and references <br>
> By Rémy Maillard (2400207) and Bastien Roux (2400203) <br>
> Bastien created all the 3d models, Rémy did the rest. <br>

___


## Introduction
### Description

This is a retro-DOOM-like game created using Unity v2022.3.11f1. It is a first person shooter where you can use two differents weapons, a gun and a shotgun. While the gun has infinite magazines, the shotgun has a limited amount of ammunitions, so you'll need to be careful. You'll be facing an army of catgirls, and in the end the scientist that created them. You can pickup health, shield or ammmo on the ground. You'll be required to look for a keycard to access the second and third part of the level. Once you defeat the scientist, the door the freedom opens.

### Story

*You were sent to a lab where a mad scientist was creating what can only be described as an unspeakable horror : **CATGIRLS**. Your goal is to stop him, but you'll have to go through the army he created...*

___


## Environment

The base environment was created using only planes for the floor, walls and ceiling. It was entirely modeled in Unity, but the layout was previously created on the following map :
<br>

![Map Layout](/Screenshots/Map.png "Map Layout")

There is no terrain nor landscape whatsoever. <br>
A basic room look like this :

![Image of a basic room](/Screenshots/BasicRoom.png "Basic Room")

There are spotlights on the ceiling, a directional light on top of the scene used as a "Sun", and a flashlight at the extremity of each gun.

![Example of the use of the flashlight](/Screenshots/FlashlightDemo.png "Example of the flashlight")

All lights in the scene are realtime, to allow for a nicer representation of the shadows.
<br>
You can also find :
- doors :

![Example of a door in the scene](/Screenshots/BlueDoor.png "Example of a door in the scene")

- desks :

![Example of a desk in the scene](/Screenshots/Desk.png "Example of a desk in the scene")

- shelves :

![Example of two shelves in the scene](/Screenshots/Shelves.png "Example of two shelves in the scene")

- drawers :

![Example of a drawer in the scene](/Screenshots/Drawer1.png "Example of a drawer in the scene")
![Another example of a drawer in the scene](/Screenshots/Drawer0.png "Another example of a drawer in the scene")

<br>

As well as some pickable objects on the ground :
- Shield packs refilling your shield bar

![Example of a shield in the scene](/Screenshots/PickableShield.png "Example of a shield in the scene")

- Medkits refilling your health bar

![Example of a medkit in the scene](/Screenshots/PickableHealth.png "Example of a medkit in the scene")

- Shells for the shotgun, and the shotgun

![Example of a shells pickable item, with the pickable shield next to it in the scene](/Screenshots/PickableShotgun&Shells.png "Example of a shells pickable & shotgun pickable in the scene")

___

## Player character

The player characher is a first person capsule with a CharacterController component and a lot a scripts attached. This allows him to move, look around, changing weapons, displaying the current held weapon with ammunitions, picking up the items it walks one, updating the healthbar, ...

It was self modeled (create capsule object in Unity) and doesn't have any animations.

![Image of the deplorable first person characher](/Screenshots/PlayerModel.png "Player model")

___

## Materials / shaders

Most of the textures were created or retouched by Rémy. <br>
None of the materials were imported. <br>
All textures used in materials have a normal map attached, except for the muzzle flash.
All normal maps were created by hand.


<br>

The imported and unchanged texture are the Bullets, Crosshair 001, Crosshar 002, Crosshair 003 and Gun images used in the HUD and the muzzle flash image used for the particles effects when shooting.

![Material for the muzzle flash](/Screenshots/MatMuzlle.png "MuzzleFlash Material")

For the walls, ceiling and floor, multiple base textures found only as well as some created by hand were used, modified, combined, fused and retouched. All of the normal maps were created using the final texture for each (and god it took some time doing the 20 walls, 2 floors and 1 ceiling)

![An example of one of the 20 materials for the walls](/Screenshots/MatWall.png "One of the 20 materials for the walls")


For the doors, an image found online was used as a base texture to create an unpixelised version of it.

![A complete door material](/Screenshots/MatDoor.png "Door Material")

___

## Animations

Five animations were created, but only three were used :
- one for the gun, when shooting or reloading, made in unity, keyframe

![Image of the gun reloading](/Screenshots/GunReload.png "Gun reload")
![Image of the gun reloading when the mag was empty](/Screenshots/GunReloadEmpty.png "Gun reload when mag empty")

- one for the shootgun, in the same conditions, made in unity, keyframe

![Image of the shotgun reloading](/Screenshots/ShotgunReload.png "Shotgun reload")

- one for the doors, made in unity, keyframe

![Image of the door closed](/Screenshots/BlueDoor.png "Door Closed")
![Image of the door opened](/Screenshots/BlueDoorOpen.png "Door Opened")

- one unused for the gun shooting, made in blender, skeletal
- one unused for the shotgun shooting, made in blender, skeletal

___

## Mesh models

The mesh models created by Bastien were :
 - The gun
 - The shotgun
 - The cartridges
 - The desk
 - The drawer
 - The shield pack
 - The Medkit
 - The Lamp
 - The Catgirls

![Image of the first catgirl model](/Screenshots/Catgirl1.png "First catgirl model")
![Image of the second catgirl model](/Screenshots/Catgirl2.png "Second catgirl model")

 - The Scientist

![Image of the scientist model](/Screenshots/ScientistModel.png "Scientist model")

All of the above were created using blender, and the non- pickable scene items have a mesh collision (desk, drawer, shelf)

___

## NPCs

There are two NPCs, both are hostile to the player and will attack on sight. <br>
As said before, NPCs were created using blender.
<br>
<br>

The ennemmies have a cone of sight, and a range of sight. If they detect the player, they will rush towards it and damage it on contact, with a maximum of once every 2.333 seconds per ennemy. Otherwise, they will look left of right for a random amount of time. If they lost sight of the player, they will still move towards it's last detected position.
<br>
When moving towards the player, they will switch their target to a random one in list around the player to prevent them from stacking.
<br>
This was accomplished using `C#` scripts

___

## Interactions

You can interact by pressing the [E] key with the keycards and the doors, or with the pickable items by walking on them.
<br>
Interating with a pickable will hide the item in the hierarchy and execute it's related action (heal for a healthkit)
<br>
Interacting with the keycard will hide the item in the hierarchy and add it to the player's \<inventory>, allowing him to unlock the related door.

![Image of an iteraction with the blue keycard](/Screenshots/BlueKeycard.png "Blue keycard interaction")
![Image of an iteraction with the red keycard](/Screenshots/RedKeycard.png "Red keycard interaction")

Interacting with the doors will play the opening or closing animation.

![Image of an iteraction with the door](/Screenshots/DoorInteraction.png "Door interaction")

The pickup script works with a trigger box collider around the item, and the name of the item.
<br> The interact script works with a long invisible cube acting as a reach tool.

___

## Audio

> For all sound origins, please look at the github repository

### Diegetic & Dynamic sounds
- Shooting or reloading any gun - some are self recorded, some are downloaded and modified
- Taking damage - downloaded
- Low health - downloaded and modified
- Opening a door - downloaded
- Trying to open a closed door - created
- Picking up health, ammunitions, or the shotgun - downloaded
- Picking up shield - downloaded, modified and self created
- Hitting a catgirl or the scientist- downloaded
- killing a catgirl - downloaded
- killing the scientist - recorded and modified

### Non Diegetic & Dynamic
- Win or lose - downloaded

### Non Diegetic & Non Dynamic
- background musics - downloaded

___

## Performance optimization
No terrain outside for the poligon presevation. <br>
Optimized walls for the ennemy detection. <br>
Optimized code for minimum script size. <br>
Optimized ennemy movement for minimal impact.
