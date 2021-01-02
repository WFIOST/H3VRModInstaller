# H3VRModInstaller

This is a program which installs mods for H3VR for you.

## Installation

If using the standalone, extract the zip into the folder where h3vr.exe is located.

If using the net5.0 version, simply drag-drop it into the folder.

## Usage instructions

Instructions are shown upon launching the executable. Type in `help` for more info.

- `wipe` wipes `installedmods.json` which contains information about what mods have been downloaded, stopping H3VRMI from reinstalling already downloaded mods.
- `dl [modname]` downloads the mod from the modid typed.
- `check [modname]` opens up the mod page in your browser.
- `modlists` lists all modlists, which are a list of multiple mods.
- `list [modlist]` lists all modids contained in a modlist.
- `list installedmods` lists all installed mods H3VRMI knows about.
- `exit` Closes H3VRMI.

## Example Of Installing A Mod

1. Type `modlists`, which will return something similar to:

`charactermods`

`codemods`

`customitems`

`dependencies`

`mapmods`

2. Type `list mapmods`, which will return:

`shootyhouse`

`promeatheus`

`wurstwar`

3. Then, you can type in `dl shootyhouse`, or if you want more info on it, `check shootyhouse`. H3VRMI will take the reins from here, and download all the dependencies and install them for you.



