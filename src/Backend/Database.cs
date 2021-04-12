using System;
using System.Collections.Generic;
using System.Linq;
using DynamicData;
using H3VRModInstaller.Frontend;
using H3VRModInstaller.JSON;
using H3VRModInstaller.Models;
using JetBrains.Annotations;

namespace H3VRModInstaller.Services
{
    public class Database
    {

        public IEnumerable<ModItem> GetDownloadableItems()
        {
            var modList = JsonModList.GetModLists();

            var listItems =
            (
                from modlistarr in modList
                from modfile in modlistarr.Modlist
                select new ModItem
                {
                    Name = modfile.Name,
                    Authors = Actions.ArrayToString(modfile.Author),
                    Description = modfile.Description
                }
            ).ToList();
            
            return listItems;
        }
        
        public IEnumerable<ModItem> GetInstalledMods() => 
        InstalledMods.GetInstalledMods().Select
        (
            mod => new ModItem
            {
                Name = mod.Name,
                Description = mod.Description,
                Authors = Actions.ArrayToString(mod.Author)
            }
        ).ToList();
    }
}