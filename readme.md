# A **better** SOE Template™ #

The default template for server object extensions from esri is _pretty_ bad. I wasn't very happy with it so I modified it. 

1. Automatic endpoint discovery
2. Comments and method documentation!
3. Separated the logic into multiple classes 
 - I really don't like single class applications. This isn't VBA right?
4. Command Pattern Implementation

## Fork and abuse! ##

##To Install##

<span class="mega-icon mega-icon-clone">Clone</span> the repository or <span class="mega-icon mega-icon-download">download<span> the zip and 

1. **Login** to arcgis server manager.
2. **Click** on `Site` then the `Extensions` tab.
3. **Click** `Add Extension` and upload the .soe file in the `install` folder.
4. **Edit** the map service hosting the solar analysis points.
5. **Click** on `Capabilities` tab and **check** `Solar Potential`.
6. **Configure** the service by **filling** out all the properties below. 
7. **Click** `Save and Restart`.
8. **Use** the `REST Url` to access the service.