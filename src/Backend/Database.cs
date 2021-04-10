using System;
using System.Collections.Generic;
using System.Linq;
using DynamicData;
using H3VRModInstaller.Frontend;
using H3VRModInstaller.JSON;
using H3VRModInstaller.Models;

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
        
        /*
        public IEnumerable<ModItem> GetItems() => new[]
        {
            new ModItem { Name = "KewlMod",       Description = test, Version = Version.Parse("0.0.1"), Authors = Actions.AuthorArrayToString(authorTest)},
            new ModItem { Name = "JigglePhysics", Description = test, Version = Version.Parse("0.0.2"), Authors = Actions.AuthorArrayToString(authorTest)},
            new ModItem { Name = "BestHands Mod", Description = test, Version = Version.Parse("0.0.3"), Authors = Actions.AuthorArrayToString(authorTest)},
            new ModItem { Name = "KewlMod",       Description = test, Version = Version.Parse("0.0.1"), Authors = Actions.AuthorArrayToString(authorTest)},
            new ModItem { Name = "JigglePhysics", Description = test, Version = Version.Parse("0.0.2"), Authors = Actions.AuthorArrayToString(authorTest)},
            new ModItem { Name = "BestHands Mod", Description = test, Version = Version.Parse("0.0.3"), Authors = Actions.AuthorArrayToString(authorTest)},
            new ModItem { Name = "KewlMod",       Description = test, Version = Version.Parse("0.0.1"), Authors = Actions.AuthorArrayToString(authorTest)},
            new ModItem { Name = "JigglePhysics", Description = test, Version = Version.Parse("0.0.2"), Authors = Actions.AuthorArrayToString(authorTest)},
            new ModItem { Name = "BestHands Mod", Description = test, Version = Version.Parse("0.0.3"), Authors = Actions.AuthorArrayToString(authorTest)},
            new ModItem { Name = "KewlMod",       Description = test, Version = Version.Parse("0.0.1"), Authors = Actions.AuthorArrayToString(authorTest)},
            new ModItem { Name = "JigglePhysics", Description = test, Version = Version.Parse("0.0.2"), Authors = Actions.AuthorArrayToString(authorTest)},
            new ModItem { Name = "BestHands Mod", Description = test, Version = Version.Parse("0.0.3"), Authors = Actions.AuthorArrayToString(authorTest)},
            
        };
        */
    }
}