If you use a sprite sheet and you need parameters for slice character animations, they description placed in separate text files in the directory of appropriately character's animations.



Preparation of test scene_______________________________________________

if the objects are displayed in the test scene incorrectly probably not created the appropriate Sorting Layers.
Then for the properly work of test scene create Sorting Layers appropriately named groups of objects ("Tiles", "Decals", "Objects") in the inspector.
Select all objects in the group (faster by clicking first object and while holding Shift key, clicking on last object), and select to them appropriate created sorting layer in inspector. 
Do it with each group, and then everything will be ready.

It will take a couple of minutes, and I hope not to deliver strong discomfort.

P.S. if you need prefabs, then they too will have to adjust Sorting Layers. Used prefabs are located in the folder "Prefabs".




Description of Scripts__________________________________________________

"CameraController" executes a simple movement to the object. The object is assigned in Inspector.

"OrderinLayerSpriteSorting" sorts the objects on Sorting Layer depending on their position on the Y axis. Multiplier determines how accurately will Order in Layer.

"PlayerController" controlling the player movement and animations.

"BigObjectTransparent" It makes objects translucent If you enter into their trigger.



________________________________________________________________________
Thanks for buying and I hope you will enjoy this.
