Assorted Attractors adds many different magnets that can attract items, mana stars, hearts, or all of them at once. Many different magnets will be available throughout your playthrough.
Range and Speed are configurable via config.
Assorted Attractors integrates with CalamityMod, adding additional higher tier magnets if Calamity is installed.

- "Range" determines how far away an item can be from the player. Items closer than this value will be attracted, items further away will not.
- The "Speed" stat determines the acceleration that an item being grabbed by a magnet experiences and is added to the items velocity every game tick (1 tick = about 1/60th of a second). 
- "Max Speed" is the maximum velocity an item can have when being drawn toward the player. 
   This speed is relative to the player's own speed so moving into a direction will allow the item to move faster to keep up with the player.
- Only one magnet can be active per player at any given time. When activating multiple magnets only the first one will work. 

# Changelog:
## [1.0.1] - 2022-07-21
- Fixed an issue where AssortedAttractors would crash when disabling Calamity
## [1.0.2] - 2022-07-21
- Changed Tidal Force drop-logic to not drop the magnet twice in expert mode
## [1.0.3] - 2022-07-28
- Adjusted for new TModLoader stable version
## [1.0.4] - 2022-08-06
- Range of all magnets has been buffed
- Range is now displayed in tiles instead of pixels as it's far more intuitive
