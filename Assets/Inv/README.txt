When editing the inventory, make sure to edit prefabs rather than scene objects

Editables are marked with _ prefix
Needed items are marked with * prefix

Editables:
    PREFABS:
        You can add further cosmetics in the created empties (make sure to put them as children of these, otherwise it will cause issues)
        Also ensure to untick 'Raycast Target' on any added cosmetics
        You can also change details such as fonts and sizing on text/images marked with *

        SlotPrefab:
            _SlotBack (background image)
            
        InvPrefab:
            _InvBackground (background image)

    DATA:
        RMB (project view) -> Create -> Data -> ItemData




TODO:
    External Counter of each item
    Resort function (collects & groups types of data together)